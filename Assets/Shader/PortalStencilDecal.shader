Shader "Custom/Stencil Decal"
{
    Properties
    {
		_Intensity("Intensity", Range(0,10)) = 5.0
	
		[Header(Movement)]
		_SpeedX("Speed X", Range(-5,5)) = 1.0
		_SpeedY("Speed Y", Range(-5,5)) = 1.0
		_RadialScale("Radial Scale", Range(0,10)) = 1.0
		_LengthScale("Length Scale", Range(0,10)) = 1.0
		_MovingTex ("MovingTex", 2D) = "white" {}
		_Multiply("Multiply Moving", Range(0,10)) = 1.0
		
		[Header(Shape)]
		_ShapeTex("Shape Texture", 2D) = "white" {}
		_ShapeTexIntensity("Shape tex intensity", Range(0,6)) = 0.5
		
		[Header(Gradient Coloring)]
		_Gradient("Gradient Texture", 2D) = "white" {}
		_Stretch("Gradient Stretch", Range(-2,10)) = 1.0
		_Offset("Gradient Offset", Range(-2,10)) = 1.0

		[Header(Cutoff)]	
		_Cutoff("Outside Cutoff", Range(0,1)) = 1.0
		_Smoothness("Outside Smoothness", Range(0,1)) = 1.0

    }   
    SubShader
    {         
		Tags
        {
            "Queue" = "Geometry+1"           
        }
        CGINCLUDE
		#include "UnityCG.cginc"
		#include "AutoLight.cginc"
		#include "Lighting.cginc"

		float _Cutoff, _Smoothness;
		sampler2D _MovingTex;
		float _SpeedX, _SpeedY;
		sampler2D _ShapeTex;
		float _ShapeTexIntensity;
		sampler2D _Gradient;
		float _Stretch,_Multiply;
		float _Intensity,_Offset;
		float _RadialScale, _LengthScale;

		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_DEFINE_INSTANCED_PROP(float4, _Tint)
		UNITY_INSTANCING_BUFFER_END(Props)

		sampler2D _CameraDepthTexture;

		// helper functions
		float2 Unity_PolarCoordinates(float2 UV, float2 Center, float RadialScale, float LengthScale)
		{
			float2 delta = UV - Center;
			float radius = length(delta) * 2.0 * RadialScale;
			float angle = atan2(delta.y, delta.x) * 1.0/6.28318 * LengthScale;
			return float2(radius, angle);
		}

		float3 ReconstructObjectPosition(float3 viewPos, float4 screenUV)
		{
		
 			viewPos = viewPos * (_ProjectionParams.z / viewPos.z) ;

			//Screenspace UV
			float2 uv = screenUV.xy / screenUV.w ;
				
			// read depth
			float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, uv);	
			float depthLinear = Linear01Depth(depth);

			// reconstruct world space
			float4 vpos = float4(viewPos * depthLinear, 1);
			float4 wpos = mul(unity_CameraToWorld, vpos);
			// back to object space
			float3 opos = mul(unity_WorldToObject, float4(wpos)).xyz;
			return opos;
		}

		float GetFinalDistortion(float2 uvProj, float shapeTex)
		{
			fixed2 polarUV = Unity_PolarCoordinates(uvProj, float2(0.5, 0.5), _RadialScale, _LengthScale);
				
			// move UV
			float2 movingUV = float2(polarUV.x + (_Time.x * _SpeedX), polarUV.y +(_Time.x * _SpeedY));


			// final moving texture with the distortion
			fixed4 final =  tex2D(_MovingTex, movingUV).r;

			shapeTex *= _ShapeTexIntensity;
			final *= shapeTex;
			return final;
		}
        
        struct v2f
        {
            float4 pos : SV_POSITION;
			half3 uv : TEXCOORD0;
			float4 screenUV : TEXCOORD1;
			float3 viewPos : TEXCOORD2;
        };

        v2f vert(appdata_full v)
        {
           	v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;
			float2 uv = v.texcoord.xy;
			o.screenUV = ComputeScreenPos(o.pos);	
			o.viewPos = UnityObjectToViewPos(float4(v.vertex.xyz,0)).xyz * float3(-1,-1,1);	
			TRANSFER_VERTEX_TO_FRAGMENT(o);
			return o;
        }
 
        fixed4 fragStencilMask(v2f i) : SV_Target
        {
			float3 opos = ReconstructObjectPosition(i.viewPos, i.screenUV);
				
			// clip outside of the decal cube
			clip(float3(0.5,0.5,0.5)- abs(opos.xyz));

			// offset uvs
			float2 uvProj = opos.xz + 0.5;	
			// get the main shape texture for the alpha
			fixed shapeTex = tex2D(_ShapeTex, uvProj).r;	

			float vortexEffect = GetFinalDistortion(uvProj, shapeTex);				
					
			// discard outside of texture alpha
			clip(vortexEffect- 0.1);
			return float4(1,1,1,1);
        }

		 fixed4 frag(v2f i) : SV_Target
        {
			// get the world position from depth
           	float3 opos = ReconstructObjectPosition(i.viewPos, i.screenUV);

			clip(float3(0.5,0.5,0.5)- abs(opos.xyz));

			// offset uvs
			float2 uvProj = opos.xz + 0.5;
			// get the main shape texture for the alpha
			fixed shapeTex = tex2D(_ShapeTex, uvProj).r;
				
			fixed vortexEffect =  GetFinalDistortion(uvProj, shapeTex);
			
			// add the coloring from the gradient map
			float4 gradientmap = tex2D(_Gradient, (vortexEffect * _Stretch) + _Offset) * _Intensity ;
			gradientmap *= vortexEffect;
			gradientmap *= _Tint;	
				
			// add tinting and transparency
			gradientmap.rgb *= _Tint.rgb;
			gradientmap *= _Tint.a;
			gradientmap *= shapeTex;

			// create a cutoff point for the outside of the portal effect
			gradientmap *= smoothstep(_Cutoff-_Smoothness,_Cutoff, vortexEffect * _Multiply);
			// increase intensity
			gradientmap = saturate(gradientmap * 10) * _Intensity;
			return gradientmap;
        }

        ENDCG   
 
		Pass
        {
            Name "Decal Mask"
            Ztest Greater
            Zwrite off
            Cull Off
            Colormask 0
            Lighting Off

			Tags
            {
                "RenderType" = "Transparent"             
                "RenderPipeline" = "UniversalPipeline"
            }
            
            Stencil
            {
                comp Always
                ref 1
                pass replace
            }

			CGPROGRAM
            #pragma vertex vert
            #pragma fragment fragStencilMask
            
        ENDCG
        }
  
		
		Pass
        {
            Name "Decal Effect"
            Zwrite off
            Ztest Off
            Cull Front
            Lighting Off
          	Blend OneMinusDstColor One

			Tags
            {
                "RenderType" = "Transparent"
                "Queue" = "Transparent"
                "RenderPipeline" = "UniversalPipeline"
                "LightMode" = "UniversalForward"
            }
           
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag  
            ENDCG
        }       
    }
}
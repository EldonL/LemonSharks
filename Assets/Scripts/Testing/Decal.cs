using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Decal : MonoBehaviour
{
    public Material m_Material;

    [Header("PropertyBlock Settings")]
    public Texture2D texture;
    public string textureName = "_MainTex";


    [ColorUsage(true, true)]
    public Color color = Color.white;
    public string colorName = "_Tint";

    // mesh to draw with
    Mesh m_CubeMesh;
    // extra settings
    MaterialPropertyBlock props;
    // render settings
    RenderParams m_renderParams;

    void SetPropertyBlockSettings()
    {
        if (props == null)
        {
            props = new MaterialPropertyBlock();
        }
        if (texture)
        {
            props.SetTexture(textureName, texture);
        }
        props.SetColor(colorName, color);

    }

    private void OnValidate()
    {
        SetPropertyBlockSettings();
    }
    public void OnEnable()
    {
        SetPropertyBlockSettings();
        m_CubeMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
        m_renderParams = new(m_Material) { matProps = props, receiveShadows = false };
    }

#if UNITY_EDITOR
    private void DrawGizmo(bool selected)
    {
        // draw a cube dizmo and a line in the direction of the decal
        var col = new Color(0.0f, 0.7f, 1f, 1.0f);
        col.a = selected ? 0.3f : 0.1f;
        Gizmos.color = col;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
        col.a = selected ? 0.5f : 0.05f;
        Gizmos.color = col;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        Handles.matrix = transform.localToWorldMatrix;
        Handles.DrawBezier(Vector3.zero, Vector3.down, Vector3.zero, Vector3.down, Color.red, null, selected ? 4f : 2f);
    }
#endif


#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        DrawGizmo(false);
    }
    public void OnDrawGizmosSelected()
    {
        DrawGizmo(true);
    }
#endif

    void Update()
    {
        // draw the cube using the render parameters
        Graphics.RenderMesh(m_renderParams, m_CubeMesh, 0, transform.localToWorldMatrix);
    }
}

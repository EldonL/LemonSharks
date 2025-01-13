using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
public class ScalingDisc : MonoBehaviour
{
    // public Transform center; // The center point
    public float maxScale = 1f; // Maximum scale at the center
    public float minScale = 0.0f; // Minimum scale far from the center
    public Transform topEdge;
    public Transform bottomEdge; // Bottom edge of the page
    public float fullSizeZone = 0.35f; // Distance from the center where the object stays full size
    private float scaleThreshold = 0.35f; // Distance near the edges where scaling begins
    
    public SkinnedMeshRenderer skinnedMeshRendererButton;
    private JourneyTable journeyTable; 

    public delegate void DiscPressed();
    public static event DiscPressed onDiscPressed;
    void Start()
    {
        journeyTable = FindObjectOfType<JourneyTable>();
    }

    void OnDestroy()
    {
        onDiscPressed = null;
    }
    void Update()
    {
                // Use local positions relative to the shared parent
        Vector3 localDiscPosition = journeyTable.gameObject.transform.InverseTransformPoint(transform.position);
        Vector3 localTopEdgePosition = journeyTable.gameObject.transform.InverseTransformPoint(topEdge.position);
        Vector3 localBottomEdgePosition = journeyTable.gameObject.transform.InverseTransformPoint(bottomEdge.position);
        // Work with the z-axis in local space
        float discLocation = localDiscPosition.y;
        float topLocation = localTopEdgePosition.y;
        float bottomLocation = localBottomEdgePosition.y;

        if(discLocation < bottomLocation)
        {
             transform.localScale = Vector3.zero;
             return;
        }

        if(discLocation > topLocation)
        {
             transform.localScale = Vector3.zero;
             return;
        }

        float distanceToTop = Mathf.Abs(discLocation  - topLocation);
        float distanceToBottom = Mathf.Abs(discLocation  - bottomLocation);

        // Find the distance to the nearest edge
        float distanceToNearestEdge = Mathf.Min(distanceToTop, distanceToBottom);

        // If inside the full-size zone, keep full scale
        if (distanceToNearestEdge > scaleThreshold)
        {
            transform.localScale = Vector3.one * maxScale;
            return;
        }

        // Otherwise, scale down smoothly near the edges
        float normalizedDistance = Mathf.Clamp01(distanceToNearestEdge / scaleThreshold);
        float scale = Mathf.Lerp(minScale, maxScale, normalizedDistance);

        // Apply the scale
        transform.localScale = Vector3.one * scale;
    }

    public void ButtonSelected()
    {
        skinnedMeshRendererButton.SetBlendShapeWeight(1,25.0f);
        onDiscPressed?.Invoke();
    }
        public void ButtonUnSelected()
    {
        skinnedMeshRendererButton.SetBlendShapeWeight(1,0.0f);
    }
}

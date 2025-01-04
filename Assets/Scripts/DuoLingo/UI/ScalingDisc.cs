using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScalingDisc : MonoBehaviour
{
    // public Transform center; // The center point
    public float maxScale = 1f; // Maximum scale at the center
    public float minScale = 0.0f; // Minimum scale far from the center
    public Transform topEdge;
    public Transform bottomEdge; // Bottom edge of the page
    public float fullSizeZone = 0.5f; // Distance from the center where the object stays full size
    public float scaleThreshold = 0.1f; // Distance near the edges where scaling begins
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {

        if(transform.position.z > bottomEdge.position.z)
        {
             transform.localScale = Vector3.zero;
             return;
        }

        if(transform.position.z < topEdge.position.z)
        {
             transform.localScale = Vector3.zero;
             return;
        }

        float distanceToTop = Mathf.Abs(transform.position.z - topEdge.position.z);
        float distanceToBottom = Mathf.Abs(transform.position.z - bottomEdge.position.z);

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
}

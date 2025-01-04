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
    public float fullSizeZone = 0.7f; // Distance from the center where the object stays full size
    public float scaleThreshold = 0.1f; // Distance near the edges where scaling begins
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //     // if (Input.GetKeyDown(KeyCode.S))
        //     // {
        //     //     transform.DOScaleX(2f, 1f).SetEase(Ease.InQuad);
        //     //     //transform.DOScaleY(2f, 2f).SetEase(Ease.OutElastic);
        //     //     transform.DOScaleZ(2f, 1f).SetEase(Ease.InQuad);
        //     // }
        //     // if (Input.GetKeyDown(KeyCode.A))
        //     // {
        //     //     transform.DOScaleX(1f, 1f).SetEase(Ease.InQuad);
        //     //     //transform.DOScaleY(2f, 2f).SetEase(Ease.OutElastic);
        //     //     transform.DOScaleZ(1f, 1f).SetEase(Ease.InQuad);
        //     // }
        //     // Calculate the distance to the center
        //     float distance = Mathf.Abs(transform.position.z - center.position.z);//Vector3.Distance(transform.position, center.position);

        //     // Normalize the distance (0 at the center, 1 at the edge of scaleDistance)
        //     float normalizedDistance = Mathf.Clamp01(distance / scaleDistance);
        //     float curveScale = 1f - Mathf.SmoothStep(0f, 1f, normalizedDistance);
        //     // Calculate the target scale based on distance
        //    float targetScale = Mathf.Lerp(minScale, maxScale, curveScale);

        //     // Use DOTween to smoothly scale the object
        //     // transform.DOScaleX(targetScale, 0.0f);//.SetEase(Ease.InQuad);
        //     // transform.DOScaleY(targetScale, 0.0f);//.SetEase(Ease.InQuad);
        //     // transform.DOScaleZ(targetScale, 0.0f);//.SetEase(Ease.InQuad);
        //     transform.DOScale(targetScale,0.0f);
        // Calculate distance to the top and bottom edges
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageBall : MonoBehaviour
{
    public Material outlineMaterial;
    public Material regualrMaterial;

    public MeshRenderer meshRenderer;

    public Transform startTransform;
    public Transform endTransform;

    public bool isBallTriggerEnter = false;

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _lineRendererStartTransform;
    [SerializeField] private Transform _lineRendererEndTransform;
    
    private void Start()
    {
        _lineRenderer.positionCount = 2;

    }


    public void DisplayOutLineMaterial()
    {
        meshRenderer.material = outlineMaterial;
    }

    public void DisplayRegularMaterial()
    {
        meshRenderer.material = regualrMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Beak")
        {
            isBallTriggerEnter = true;
            DisplayOutLineMaterial();
            SetLineTransform();
            EnableLineTransform();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Beak")
        {
            isBallTriggerEnter = false;
            DisplayRegularMaterial();
            DisableLineTransform();
        }
    }

    private void SetLineTransform()
    {
        _lineRenderer.SetPosition(0, _lineRendererStartTransform.position);
        _lineRenderer.SetPosition(1, _lineRendererEndTransform.position);
    }

    public void EnableLineTransform()
    {
        _lineRenderer.gameObject.SetActive(true);
    }

    public void DisableLineTransform()
    {
        _lineRenderer.gameObject.SetActive(false);
    }

}

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
        Debug.Log("collision entered ");
        if (other.gameObject.tag == "Beak")
        {
            isBallTriggerEnter = true;
            Debug.Log($"collision entered languageball {other.gameObject.name}");
            DisplayOutLineMaterial();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Beak")
        {
            isBallTriggerEnter = false;
            DisplayRegularMaterial();
        }
    }

}

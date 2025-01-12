using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabbablePart : MonoBehaviour
{
    [SerializeField] private Material selected; 
    [SerializeField] private Material unselected;
    
    [SerializeField] private MeshRenderer meshRenderer; 

    public void OnSelected()
    {
        meshRenderer.material = selected;
    }

    public void OnUnSelected()
    {
        meshRenderer.material = unselected;
    }
}

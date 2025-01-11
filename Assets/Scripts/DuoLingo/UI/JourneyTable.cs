using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyTable : MonoBehaviour
{
    public JourneyTableFrame journeyTableFrame; // Reference to the Model
    public JourneyDisc journeyDisc; // Reference to the View

    public LineRenderer journeyTableLineRenderer;


    void Awake()
    {
        journeyTableFrame.OnRotationChanged += HandleRotationChanged;
        journeyTableLineRenderer.positionCount = 2;
    }

    void Start()
    {
        journeyTableLineRenderer.gameObject.SetActive(false);
        DuoDiscController.onDiscSelected+=DiscSelected;
    }

    private void OnDestroy()
    {
        DuoDiscController.onDiscSelected -= DiscSelected;
        journeyTableFrame.OnRotationChanged -= HandleRotationChanged;
    }

    private void HandleRotationChanged(Vector3 rotation)
    {
        // Logic to determine movement based on rotation
        // Vector3 movement = new Vector3(0, 0,rotation.z); // Example mapping
        journeyDisc.UpdatePosition(rotation);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "disc")
        {
            journeyTableLineRenderer.gameObject.SetActive(true);
            other.gameObject.GetComponent<DuoDiscs>().isTouchingJourneyDisc = true;
        }

    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "disc")
        {
            ObjectHover(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "disc")
        {
            journeyTableLineRenderer.gameObject.SetActive(false);
            other.gameObject.GetComponent<DuoDiscs>().isTouchingJourneyDisc = false;
        }
    }
    public void ObjectHover(Collider other)
    {
        journeyTableLineRenderer.SetPosition(0, transform.position);
        journeyTableLineRenderer.SetPosition(1, other.gameObject.transform.position);
    }

    public void DiscSelected()
    {
        journeyTableLineRenderer.gameObject.SetActive(false);
    }

}

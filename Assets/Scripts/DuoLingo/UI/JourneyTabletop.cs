using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyTabletop : MonoBehaviour
{
    public LineRenderer journeyTableLineRenderer;
    public GameObject portal;
    void Awake()
    {

        journeyTableLineRenderer.positionCount = 2;
    }

    void Start()
    {
        journeyTableLineRenderer.gameObject.SetActive(false);
        portal.SetActive(false);
        DuoDiscController.onDiscSelected += DiscSelected;
    }

    private void OnDestroy()
    {
        DuoDiscController.onDiscSelected -= DiscSelected;

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
        portal.SetActive(true);
    }
}

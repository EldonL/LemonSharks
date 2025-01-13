using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LevelChangeSceneController : MonoBehaviour
{
    public GameObject owl;
    public GameObject owlDestionation;

    public Animator owlAnimator;
    // Start is called before the first frame update
    void Start()
    {
        ScalingDisc.onDiscPressed+=OwlFinalDestination;
    }

    void Destroy()
    {
        ScalingDisc.onDiscPressed-=OwlFinalDestination;
    }

    public void OwlFinalDestination()
    {   
        owlAnimator.Play("Takeoff2");
        owl.transform.DOScale(0.0f,2.0f);
        owl.transform.DOMove(owlDestionation.transform.position,2.0f);
    }
}

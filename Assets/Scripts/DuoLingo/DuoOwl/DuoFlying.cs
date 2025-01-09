using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DuoFlying : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject leftHand;
    public GameObject rightHand;

    [SerializeField] private Animator DuoAnimator;
    public void FlyTowardsLeftHand()
    {
        objectToMove.transform.DOMove(leftHand.transform.position,1).OnComplete(()=>{
           // objectToMove.transform.SetParent(leftHand.transform);
        });
    }

    public void FlyTowardsRightHand()
    {
        objectToMove.transform.DOMove(rightHand.transform.position,1).OnComplete(()=>{
            //objectToMove.transform.SetParent(rightHand.transform);
        });
    }

    public void UnSelectedHand()
    {
        // objectToMove.transform.SetParent(null);
            DuoAnimator.Play("Takeoff");
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DuoFlying : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject leftHand;
    public GameObject rightHand;
    public void FlyTowardsLeftHand()
    {
        objectToMove.transform.DOMove(leftHand.transform.position,1);
    }

    public void FlyTowardsRightHand()
    {
        objectToMove.transform.DOMove(rightHand.transform.position,1);
    }
}

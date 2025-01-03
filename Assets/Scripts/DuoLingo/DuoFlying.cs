using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DuoFlying : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject leftHand;
    public void FlyTowardsHand()
    {
        objectToMove.transform.DOMove(leftHand.transform.position,1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peach : MonoBehaviour
{
    public Animator peach;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="knife")
        {
            peach.SetBool("isCut",true);
        }

    }
}

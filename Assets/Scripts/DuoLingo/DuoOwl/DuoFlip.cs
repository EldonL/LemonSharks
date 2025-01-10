using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuoFlip : MonoBehaviour
{
    
    [SerializeField] private Animator DuoAnimator;

    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.A))
        // {
        //     Grabbed();
        // }
    }
    public void Grabbed()
    {            
        Debug.Log($"<color=yellow>gar bunkle</color>");
        // objectToMove.transform.SetParent(null);
            DuoAnimator.Play("FlyIdle1");

    }
}

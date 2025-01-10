using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyInPortal : MonoBehaviour
{
    public Animator portal;
    public Animator person; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            portal.Play("PORTALOPEN");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            person.Play("Idle");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            person.Play("TalkLoop");
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            person.Play("Think");
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            person.Play("Bow");
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            person.Play("Disapprove");
        }
    }
}

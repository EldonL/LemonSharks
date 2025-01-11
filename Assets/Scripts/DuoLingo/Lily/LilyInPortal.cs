using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyInPortal : MonoBehaviour
{
    public Animator portal;
    public Animator person;
    public GameObject root; 
    // Start is called before the first frame update
    void Start()
    {
        root.SetActive(false);
        StartCoroutine(PlayLilyPortalRoutine());
    }

    public IEnumerator PlayLilyPortalRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        root.SetActive(true);
        PortalOpen();
        portal.SetBool("playPortal", true);
        person.SetBool("StartTalk", true);
        yield return new WaitForSeconds(4.0f);
        person.SetBool("StartThink", true); 

    }

    public void PortalOpen()
    {
        portal.Play("PORTALOPEN");        
    }

    public void Idle()
    {
        person.Play("Idle"); 
    }

    public void TalkLoop()
    {
        person.Play("TalkLoop");        
    }

    public void Think()
    {
        person.Play("Think");
    }

    public void Bow()
    {
        person.Play("Bow");        
    }

    public void Disapprove()
    {
        person.Play("Disapprove");       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
             PortalOpen();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Idle();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            TalkLoop();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            Think();
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            Bow();
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
           Disapprove();
        }
    }
}

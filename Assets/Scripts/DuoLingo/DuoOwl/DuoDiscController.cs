using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DuoDiscController : MonoBehaviour
{
    public List<DuoDiscs> duoDiscs = new();
    // Start is called before the first frame update
    void Start()
    {
        foreach(var duoDisc in duoDiscs)
        {
            duoDisc.gameObject.SetActive(false);
        }      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            DisplayDisc();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            HideDisc();
        }
    }

    public void DisplayDisc()
    {
        foreach(var duoDisc in duoDiscs)
        {
            duoDisc.gameObject.SetActive(true);
            duoDisc.transform.DOMove(duoDisc.discEndTransform.position,1.0f);
        }
    }

    public void HideDisc()
    {
        foreach(var duoDisc in duoDiscs)
        {
            duoDisc.transform.DOMove(duoDisc.discStartTransform.position,1.0f);
        }
    }
}

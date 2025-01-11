using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DuoDiscController : MonoBehaviour
{
    public List<DuoDiscs> duoDiscs = new();
    bool isDisplayDisc = false;
    
    public delegate void DiscSelectedHandler();
    public static event DiscSelectedHandler onDiscSelected;

    void Start()
    {
        foreach(var duoDisc in duoDiscs)
        {
            duoDisc.gameObject.SetActive(false);
        }      
    }

    
    public void ObjectHover()
    {
        HideDisc();       
    }
    public void DisplayDisc()
    {
        if(isDisplayDisc)
        {
            HideDisc();
            isDisplayDisc = false;
            return;
        }
        isDisplayDisc = true;
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
            if(duoDisc.isTouchingJourneyDisc)
            {
               // duoDisc.transform.DOScale(0.05f,1.0f).OnComplete(()=>{
                    duoDisc.gameObject.SetActive(false);
                    onDiscSelected?.Invoke();
               // });
                
                continue;
            }
            duoDisc.transform.DOMove(duoDisc.discStartTransform.position, 1.0f).OnComplete(() =>
             {
                 duoDisc.gameObject.SetActive(false);
             });
        }
    }
}

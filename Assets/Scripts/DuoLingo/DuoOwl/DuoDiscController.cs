using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DuoDiscController : MonoBehaviour
{
    public List<DuoDiscs> duoDiscs = new();
    bool isDisplayDisc = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var duoDisc in duoDiscs)
        {
            duoDisc.gameObject.SetActive(false);
        }      
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
            duoDisc.transform.DOMove(duoDisc.discStartTransform.position, 1.0f).OnComplete(() =>
             {
                 duoDisc.gameObject.SetActive(false);
             });
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LanguageBallController : MonoBehaviour
{
    public List<LanguageBall> languageBalls = new();
    // Start is called before the first frame update
    void Start()
    {
        foreach(var languageBall in languageBalls)
        {
            languageBall.gameObject.SetActive(false);
        }      
    }

    public void DisplayBall()
    {

        foreach(var languageball in languageBalls)
        {
            languageball.gameObject.SetActive(true);
            languageball.transform.DOMove(languageball.endTransform.position,1.0f);
        }
    }

    public void HideBall()
    {       

        foreach(var languageball in languageBalls)
        {
            languageball.transform.DOMove(languageball.startTransform.position, 1.0f).OnComplete(() =>
            {
                languageball.gameObject.SetActive(false);
            });

        }
    }


}

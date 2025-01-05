using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuoPetting : MonoBehaviour
{
    public List<GameObject> Duo = new(); 
    private int duoCount = 0;
    [SerializeField] private Animator DuoAnimator;
    public void Petting()
    {
        DuoAnimator.Play("FlySparkle");
        // Duo[duoCount].SetActive(false);
        // duoCount++;
        // if(duoCount>=Duo.Count)
        // {
        //     duoCount=0;
        // }
        // Duo[duoCount].SetActive(true);
    }
}

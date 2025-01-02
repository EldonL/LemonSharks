using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuoPetting : MonoBehaviour
{
    public List<GameObject> Duo = new(); 
    private int duoCount = 0;
    public void Petting()
    {
        Duo[duoCount].SetActive(false);
        duoCount++;
        if(duoCount>=Duo.Count)
        {
            duoCount=0;
        }
        Duo[duoCount].SetActive(true);
    }
}

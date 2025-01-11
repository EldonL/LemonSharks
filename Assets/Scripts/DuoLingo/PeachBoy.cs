using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PeachBoy : MonoBehaviour
{
    public GameObject babyDuo;
    public Transform babyDuoEndTransform;

    public void Start()
    {
        babyDuo.SetActive(false);
    }
    public void BabyDuoFlies()
    {
        StartCoroutine(BabyDuoFliesRoutine());
    }

    private IEnumerator BabyDuoFliesRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        babyDuo.SetActive(true);
        babyDuo.transform.DOMove(babyDuoEndTransform.position,2.0f);
    }
}

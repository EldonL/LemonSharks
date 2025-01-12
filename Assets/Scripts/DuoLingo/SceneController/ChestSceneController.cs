using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ChestSceneController : MonoBehaviour
{
    public Animator chestAnimator;

    public GameObject chest;

    public GameObject duoGlasses;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Update()
    {
         if (Input.GetKey(KeyCode.D) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
         {
            StartCoroutine(ChestRoutine());
            chest.transform.localScale = new Vector3(0.0f,0.0f,0.0f);
         }
    }

    private IEnumerator ChestRoutine()
    {
        yield return new WaitForSeconds(7.0f);
        duoGlasses.SetActive(true);
        chest.transform.DOScale(1,1.5f).OnComplete(()=>{
            chestAnimator.SetBool("openChest", true);
        });

    }
}

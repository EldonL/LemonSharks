using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuoBeak : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)

    {
        Debug.Log("collision entered ");
        if (other.gameObject.tag == "LanguageBall")
        {
            Debug.Log("collision entered languageball");
            var languageBall = other.gameObject.GetComponent<LanguageBall>();
            languageBall.DisplayOutLineMaterial();
            other.gameObject.transform.parent = this.gameObject.transform;
            other.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}

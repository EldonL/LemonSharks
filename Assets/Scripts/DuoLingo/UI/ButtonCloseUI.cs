using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseUI : MonoBehaviour
{
    public GameObject gameObjectToOpenClose;

    public void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            OpenClose();
        }

    }
    public void OpenClose()
    {
        gameObjectToOpenClose.SetActive(!gameObjectToOpenClose.activeInHierarchy);
    }
}

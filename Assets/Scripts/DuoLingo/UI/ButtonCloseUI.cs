using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonCloseUI : MonoBehaviour
{
    public GameObject gameObjectToOpenClose;

    public void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            OpenClose();
        }
        if(OVRInput.GetDown(OVRInput.Button.Two))
        {
            RestartScene();
        }

    }
    public void OpenClose()
    {
        gameObjectToOpenClose.SetActive(!gameObjectToOpenClose.activeInHierarchy);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

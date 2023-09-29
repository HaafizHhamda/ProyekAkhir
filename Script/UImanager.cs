using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public AudioSource Sfx;
    public bool ison = true;


    //private float timeElapsed;
    //private float delayBeforeLoading = 1f;
    //public Rect button;

    public void loadScene(string nameScene)
    {
        Sfx.Play();
        SceneManager.LoadScene(nameScene);
    }

        //public void loadSceneState(string nameScene)
        //{
        //    Sfx.Play();
        //    SceneManager.LoadScene(nameScene);
        
        //}
    public void appexit()
    {
        Application.Quit();
        Debug.Log("exit apps");
    }

    
}

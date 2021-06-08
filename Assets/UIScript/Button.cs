using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject FadePlane;

    void Start()
    {
        FadePlane = GameObject.Find("FadeIn");
    }

    public void OnStart()
    {
        FadePlane.SetActive(true);
        FadeIn.Step = 2;
    }

    public void OnExit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour
{
    // Start is called before the first frame update
    

    public void OnStart()
    {
        GameManager.instance.ChangeScene("Stage1_1");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}

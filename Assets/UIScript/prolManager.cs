using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class prolManager : MonoBehaviour
{
    
    public GameObject[] Images;

    public static int Show;
    // Start is called before the first frame update
    void Start()
    {   
        Show = 1;
        prolFade.TimeCheck = 7;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) GameManager.instance.ChangeScene("Stage1_1");

        switch(Show)
        {
            case 1:
                Images[0].SetActive(true);
                break;
            case 2:
                Images[0].SetActive(false);
                Images[1].SetActive(true);
                break;
            case 3:
                Images[1].SetActive(false);
                Images[2].SetActive(true);
                break;
            case 4:
                Images[2].SetActive(false);
                Images[3].SetActive(true);
                break;
            case 5:
                GameManager.instance.ChangeScene("Stage1_1");
                break;
        }
    }
}

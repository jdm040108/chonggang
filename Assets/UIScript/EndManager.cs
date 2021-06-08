using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Images;

    public static int EndShow;
    // Start is called before the first frame update
    void Start()
    {   
        EndShow = 1;
        prolFade.TimeCheck = 5;
    }

    // Update is called once per frame
    void Update()
    {
        switch(EndShow)
        {
            case 1:
                Images[0].SetActive(true);
                prolFade.TimeCheck = 2.5f;
                break;
            case 2:
                Images[0].SetActive(false);
                Images[1].SetActive(true);
                prolFade.TimeCheck = 5;
                break;
            case 3:
                Images[1].SetActive(false);
                Images[2].SetActive(true);
                break;
            case 4:
                Images[2].SetActive(false);
                Images[3].SetActive(true);
                prolFade.TimeCheck = 2.5f;
                break;
            case 5:
                Images[3].SetActive(false);
                Images[4].SetActive(true);
                break;
            case 6:
                Images[4].SetActive(false);
                Images[5].SetActive(true);
                prolFade.TimeCheck = 5;
                break;
            case 7:
                Images[5].SetActive(false);
                Images[6].SetActive(true);
                break;
            case 8:
                Images[6].SetActive(false);
                Images[7].SetActive(true);
                break;
        }
    }
}

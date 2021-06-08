using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightImage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Image;
    void Start()
    {
        Image[0].SetActive(false);
        Image[1].SetActive(false);
    }

    void Update()
    {
        if(ButtonOn.LightCheck)
        {
            Image[0].SetActive(true);
            //Image[1].SetActive(true);
        }
        else
        {
            Image[0].SetActive(false);
            //Image[1].SetActive(false);
        }

        if(Button2.LightCheck2)
        {
            Image[1].SetActive(true);
            //Image[1].SetActive(true);
        }
        else
        {
            Image[1].SetActive(false);
            //Image[1].SetActive(false);
        }

        
    }
    // Update is called once per frame
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject Gemture;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(gameObject.tag == "MonGem")
            {
                StageClear.Stage = 1;
                Gemture.SetActive(true);
                Destroy(gameObject);
            }
            else if(gameObject.tag == "TueGem")
            {
                StageClear.Stage = 2;
                Gemture.SetActive(true);
                Destroy(gameObject);
            }
            else if(gameObject.tag == "WedGem")
            {
                StageClear.Stage = 3;
                Gemture.SetActive(true);
                Destroy(gameObject);
            }
            else if(gameObject.tag == "ThuGem")
            {
                StageClear.Stage = 4;
                Gemture.SetActive(true);
                Destroy(gameObject);
            }
            else if(gameObject.tag == "FriGem")
            {
                StageClear.Stage = 5;
                Gemture.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}

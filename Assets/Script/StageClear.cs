using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Stage = 1;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            /*if(Stage == 1)
            {
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("2Stage");
                Stage = 2;
            }*/
            //12 = 1-2   13 = 1-3 이런식으로 스테이지 표시했음 
            if (Stage == 1)
            {
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("Stage1_2");
                Stage = 12;
            }
            else if (Stage == 12)
            {
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("Stage1_3");
                Stage = 13;
            }
            else if (Stage == 13)
            {
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("2Stage");
                Stage = 2;
            }
            else if(Stage == 2)
            {
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("3Stage");
                Stage = 3;
            }
            else if(Stage == 3)
            {
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("4Stage");
                Stage = 4;
            }
            else if(Stage == 4)
            {
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("5Stage");
                Stage = 5;
            }
            else if(Stage == 5)
            {
                GameManager.instance.ChangeScene("EndingScene");
            }
        }

    }
}

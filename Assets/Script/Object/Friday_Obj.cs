using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friday_Obj : MonoBehaviour
{
    P_Charactor p_Charactor;

    SpriteRenderer sr;

    private GameObject X_Img;
    // Start is called before the first frame update
    void Start()
    {
        X_Img = GameObject.Find("Skill_False");
        X_Img.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            p_Charactor = collision.gameObject.GetComponent<P_Charactor>();
            sr = collision.gameObject.GetComponent<SpriteRenderer>();
            p_Charactor.Is_Skill_On = false;
            sr.material.color = new Color(0.3f, 0.3f, 0.3f);
            X_Img.SetActive(true);
            GameManager.IsAttack_Return = true;
            //Invoke("Skill_False_After", 3f); //스킬 false 후
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        p_Charactor.Is_Skill_On = true;
        sr.material.color = new Color(1f, 1f, 1f);
        X_Img.SetActive(false);
        GameManager.IsAttack_Return = false;
    }

    void Skill_False_After() 
    {
        p_Charactor.Is_Skill_On = true;
        sr.material.color = new Color(1f, 1f, 1f);
        X_Img.SetActive(false);
        GameManager.IsAttack_Return = false;
    }
}

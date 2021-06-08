using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skill_Cool : MonoBehaviour
{
    // Start is called before the first frame update
    P_Charactor p_Charactor;

    public Image img_Skill; 

    public static bool Is_Skill_Cool_On = false;
    void Start()
    {
        //img_Skill = gameObject.GetComponent<Image>();
        Debug.Log(img_Skill);
    }

    // Update is called once per frame
    void Update()
    {
        if(!p_Charactor)
        p_Charactor =  GameObject.FindWithTag("Player").GetComponent<P_Charactor>();

        if(Is_Skill_Cool_On)
        {
            Is_Skill_Cool_On = false;
            Debug.Log("Is_Skill_Cool_false" + Is_Skill_Cool_On);
            StartCoroutine(CoolTime(p_Charactor.info.skills[0].delay.cool + 1));
        }
    }

    IEnumerator CoolTime(float cool)
    {
    //    print("쿨타임 코루틴 실행");
        
   //     Debug.Log("Cool" + cool);
        
        while (cool > 1.0f)
        {
//            Debug.Log("Cool" + cool);
            cool -= Time.deltaTime;
            img_Skill.fillAmount = (1.0f/cool);
            //img_Skill.gameObject.SetActive(true);
            yield return new WaitForFixedUpdate();
        }
        
        //img_Skill.gameObject.SetActive(false);
    //    print("쿨타임 코루틴 완료");
    }
}

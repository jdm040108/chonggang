using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_OBS : MonoBehaviour
{
    [Header("[ 이 캐릭터가 시전하는 스킬에 장애물이 사라짐 ]")]
    public P_Charactor.Type type;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        P_Skill skill = collision.gameObject.GetComponent<P_Skill>();
        if (skill)
            if (skill.type == type)
                Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(type == P_Charactor.Type.ALL) Destroy(gameObject);
        P_Skill skill = collision.gameObject.GetComponent<P_Skill>();
        if (skill)
            if (skill.type == type || type == P_Charactor.Type.ALL) Destroy(gameObject);
    }
}

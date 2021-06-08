using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class P_Skill : MonoBehaviour
{
    [Header("[ 스킬을 시전하는 캐릭터 ]")]
    public P_Charactor.Type type;
    [Header("[ 스킬을 시전할때 사용하는 키 ]")]
    [Space(20)]
    public P_Charactor.Key key;
    [Header("[ 스킬의 데미지 ]")]
    [Space(20)]
    [Range(0, 9999)]
    public int damage;
    [Header("[ 스킬을 시전할때 스킬 위치 보정 벡터 ]")]
    [Space(20)]
    public Vector2 add_pos;
    [Header("[ 체크시 스킬이 적과 충돌 후 삭제 ]")]
    [Space(20)]
    public bool isCollisionDestroy = false;
    [Header("[ 다음 콤보 스킬 ]")]
    [Space(20)]
    public NextSkill next_skill;

    [Serializable]
    public class NextSkill
    {
        [Header("[ 스킬 객체 ]")]
        public P_Skill skill_obj;
        [Header("[ 다시 눌러야 하는 시간 ]")]
        [Range(0, 100)]
        public float during;
    }

    float now;
    bool isKeyDown;

    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb2D;

    P_Enemy target { get; set; }

    bool isCollision = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        now = Time.time;
        isKeyDown = false;

        if (GameObject.FindWithTag("Player").GetComponent<P_Charactor>().IsGrab)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void CastNextSkill()
    {
        if (isKeyDown)
        {
            isKeyDown = false;
            GameObject player = GameObject.FindWithTag("Player");
            P_Skill skill = Instantiate(next_skill.skill_obj, player.transform.position + new Vector3((player.GetComponent<P_Charactor>().info.move.IsRight ? 1 : -1) * next_skill.skill_obj.add_pos.x, next_skill.skill_obj.add_pos.y, 0), Quaternion.identity);
            skill.GetComponent<SpriteRenderer>().flipX = sr.flipX;
        }
    }

    private void Update()
    {
        if (now + next_skill.during >= Time.time)
            if (Input.GetKeyDown(P_Charactor.GetKeyCode(key)))
                isKeyDown = true;
        switch (type)
        {
            case P_Charactor.Type.COUNTER:
                if (key == P_Charactor.Key.Z)
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Counter_Attack_Motionanim") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                    {
                        CastNextSkill();
                        Destroy(gameObject);
                    }
                break;
            case P_Charactor.Type.JUPITER:
                if (key == P_Charactor.Key.Z)
                {
                    Grab();
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("JupiterAttack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                    {
                        CastNextSkill();
                        Destroy(gameObject);
                    }
                }
                break;
            case P_Charactor.Type.REAPER:
                if (key == P_Charactor.Key.Z)
                {

                }
                break;
            case P_Charactor.Type.STRIKER:
                if (key == P_Charactor.Key.Z)
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("StrikerAttackMotion") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.01)
                    {
                        GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("Attack2");
                    }
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("StrikerAttackMotion") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
                    {
                        CastNextSkill();
                        Destroy(gameObject);
                    }
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("StrikerAttack1") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
                    {
                        CastNextSkill();
                        Destroy(gameObject);
                    }
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameObject.FindWithTag("Player").GetComponent<P_Charactor>().IsGrab && !target)
        {
            if (collision.gameObject.GetComponent<P_Enemy>())
                target = collision.gameObject.GetComponent<P_Enemy>();
        }
        if (target)
        {
            if (target.tag == "unfriendly")
                isCollision = true;
            if (isCollisionDestroy)
                Destroy(gameObject);
        }
    }

    void Grab()
    {
        P_Charactor player = GameObject.FindWithTag("Player").GetComponent<P_Charactor>();

        if (isCollision)
        {
            if (!player.IsGrab)
            {
                if (target && !target.IsThrowing)
                {
                    player.IsGrab = true;
                    target.GetComponent<BoxCollider2D>().enabled = false;
                    target.gameObject.tag = "Ground";
                    target.gameObject.layer = 8;
                    target.GetComponent<SpriteRenderer>().material.color = new Color(0.3f, 0.3f, 0.3f);
                    player.Target = target;
                    target = null;
                }
            }
        }
        else
        {
            if (player.IsGrab)
            {
                player.IsGrab = false;
                player.enemy_throw = true;
            }
        }
    }
}

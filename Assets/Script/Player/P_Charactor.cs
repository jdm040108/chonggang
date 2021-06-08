using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class P_Charactor : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb2D;
    public AudioClip AttackSound;
    public bool IsGrab { get; set; } = false;
    public bool enemy_throw { get; set; } = false;
    public P_Enemy Target { get; set; }

    [Serializable]
    public class HpInfo
    {
        public int Hp { get { return GameManager.hp; } set { GameManager.hp = value; } }
        public int Max_hp { get { return GameManager.maxHp; } set { GameManager.maxHp = value; } }
        public bool isDie;
    }

    [Serializable]
    public class Move
    {
        [Header("[ 이동 속도 ]")]
        [Range(0, 100)]
        public float speed;
        [Header("[ 이동 방향 ]")]
        public float x_axis;
        public bool IsLeft { get { return x_axis < 0; } }
        public bool IsRight { get { return x_axis >= 0; } }
        [Header("[ 점프 크기 ]")]
        [Range(0, 100)]
        public float jump_scale;
        [Header("[ 점프 중인가? ]")]
        public bool isJump;
    }

    public enum Type { COUNTER, JUPITER, REAPER, STRIKER, ALL }
    public enum Key { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z }

    [Serializable]
    public class Delay
    {
        [Header("[ 지연 시간 ]")]
        [Range(0, 600)]
        public float delay;
        [Header("[ 흐른 시간 ]")]
        public float cool;
        [Header("[ 지연 중인가? ]")]
        public bool isDelay;
    }

    private float BackUpSpeed = 0;

    public GameObject Dust_Eff;
    public static KeyCode GetKeyCode(Key key)
    {
        switch (key)
        {
            case Key.A:
                return KeyCode.A;
            case Key.B:
                return KeyCode.B;
            case Key.C:
                return KeyCode.C;
            case Key.D:
                return KeyCode.D;
            case Key.E:
                return KeyCode.E;
            case Key.F:
                return KeyCode.F;
            case Key.G:
                return KeyCode.G;
            case Key.H:
                return KeyCode.H;
            case Key.I:
                return KeyCode.I;
            case Key.J:
                return KeyCode.J;
            case Key.K:
                return KeyCode.K;
            case Key.L:
                return KeyCode.L;
            case Key.M:
                return KeyCode.M;
            case Key.N:
                return KeyCode.N;
            case Key.O:
                return KeyCode.O;
            case Key.P:
                return KeyCode.P;
            case Key.Q:
                return KeyCode.Q;
            case Key.R:
                return KeyCode.R;
            case Key.S:
                return KeyCode.S;
            case Key.T:
                return KeyCode.T;
            case Key.U:
                return KeyCode.U;
            case Key.V:
                return KeyCode.V;
            case Key.W:
                return KeyCode.W;
            case Key.X:
                return KeyCode.X;
            case Key.Y:
                return KeyCode.Y;
            case Key.Z:
                return KeyCode.Z;
            default:
                Debug.LogError("Key값 리턴 실패!");
                return KeyCode.None;
        }
    }

    [Serializable]
    public class Fx
    {
        [Header("Fx 객체")]
        public GameObject fx;
        [Header("Fx 객체의 위치 보정 벡터")]
        public Vector2 add_pos;
    }

    [Serializable]
    public class Skill
    {
        [Header("[ 스킬 사용할 키 ]")]
        public Key key;
        [Header("[ 지연 관련 설정 ]")]
        public Delay delay;
        [Header("[ 스킬 객체 ]")]
        public P_Skill obj;
        [Header("[ Fx 관련 설정 ]")]
        public Fx fx;
    }

    [Serializable]
    public class Info
    {
        [Header("[ 캐릭터 타입 ]")]
        public Type type;
        [Header("[ 체력 관련 설정 ]")]
        [Space(20)]
        public HpInfo hp;
        [Header("[ 이동 관련 설정 ]")]
        [Space(20)]
        public Move move;
        [Header("[ 스킬 관련 설정 ]")]
        [Space(20)]
        public List<Skill> skills;
    }

    public Info info = new Info();

    public bool Is_Skill_On = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        BackUpSpeed = info.move.speed;
        //img_Skill.gameObject.SetActive(false);
        AudioSet();
    }

    private void AudioSet()
    {
        // audioSource.mute = false;
        // audioSource.loop = false;
        // audioSource.playOnAwake = false;
        // Debug.Log("세팅");
    }
    public void HpCheck()
    {
        if (info.hp.Hp > info.hp.Max_hp)
            info.hp.Hp = info.hp.Max_hp;
        if (info.hp.Hp <= 0)
        {
            info.hp.isDie = true;
            anim.SetTrigger("isDead");
            Invoke("AfterDead", 1.0f);
        }
        else
            info.hp.isDie = false;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !info.move.isJump)
        {
            rb2D.AddForce(Vector2.up * info.move.jump_scale, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            info.move.isJump = true;
        }
    }

    void AfterDead()
    {
        GameManager.instance.ChangeScene("Title2");
        info.hp.Hp = info.hp.Max_hp;
        StageClear.Stage = 1;
    }

    void Grab()
    {
        if (IsGrab)
        {
            if (Target)
            {
                enemy_throw = true;
                Target.transform.position = transform.position + new Vector3(0, 7, 0);
            }
        }
        else
        {
            if (Target)
            {
                Target.Freeze_all = true;
                Rigidbody2D target_rb2D = Target.GetComponent<Rigidbody2D>();
                target_rb2D.constraints = RigidbodyConstraints2D.None;
                target_rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                if (enemy_throw)
                {
                    enemy_throw = false;
                    Target.MonsterIdle();
                    Target.GetComponent<Enemy_Move>().enabled = false;
                    target_rb2D.velocity = Vector2.zero;
                    Target.IsThrowing = true;
                    target_rb2D.AddForce((info.move.IsRight ? Vector2.right : Vector2.left) * 500);
                }
                Target.GetComponent<BoxCollider2D>().enabled = true;
                Target = null;
            }
        }
    }

    public void Update()
    {
        HpCheck();
        SkillCast();
        Jump();
        Grab();

        if (Input.GetButton("Horizontal"))
        {
            info.move.x_axis = Input.GetAxisRaw("Horizontal");
            //transform.Translate(info.move.x_axis, 0, 0);
            sr.flipX = info.move.IsLeft;
        }

        if (Input.GetButtonUp("Horizontal"))
            rb2D.velocity = new Vector2(rb2D.velocity.normalized.x * 0.5f, rb2D.velocity.y);

        if (Mathf.Abs(rb2D.velocity.x) < 0.4)
            anim.SetBool("Walking", false);
        else
        {
            if (anim.GetBool("isJumping"))
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("Walking", false);
            }
            else
            {
                if(GameObject.Find("Dust_effect(Clone)")) return;
                
                Instantiate(Dust_Eff, transform.position, Quaternion.identity);
                anim.SetBool("Walking", true);        
            }
        }

        ObjectManager.PlayerPos = transform.position;
    }

    public void LateUpdate()
    {
        rb2D.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal"), ForceMode2D.Impulse);

        if (rb2D.velocity.x > info.move.speed)
            rb2D.velocity = new Vector2(info.move.speed, rb2D.velocity.y);
        else if (rb2D.velocity.x < info.move.speed * (-1))
            rb2D.velocity = new Vector2(info.move.speed * (-1), rb2D.velocity.y);

        if (rb2D.velocity.y < 0)
        {
            Debug.DrawRay(rb2D.position, Vector3.down * 4, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rb2D.position, Vector3.down * 4, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
                if (rayHit.distance < 1f)
                    info.move.isJump = false;
        }
    }

    public void KnockBack(Vector3 target)
    {
        rb2D.AddForce(new Vector2(transform.position.x - target.x > 0 ? 1 : -1, 1) * 14, ForceMode2D.Impulse);
    }

    public void Hit()
    {
        gameObject.layer = 11;

        sr.color = new Color(1, 1, 1, 0.4f);

        Invoke("EndHit", 3);

        if (!info.hp.isDie)
            anim.SetTrigger("Hit");
    }

    void EndHit()
    {
        gameObject.layer = 10;
        sr.color = new Color(1, 1, 1, 1);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "unfriendly")
        {

            if (gameObject.layer == 10)
            {
                info.hp.Hp -= collision.gameObject.GetComponent<P_Enemy>().damage;
                //KnockBack(collision.transform.position);
                Hit();
                Earthquake.instance.Earthquake_On = true;
            }

        }
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("isJumping", false);
            info.move.isJump = false;
            //info.move.speed = BackUpSpeed;
        }
        //if(collision.gameObject.tag == "Object") 
        //{
        //    anim.SetBool("isJumping", false);
        //    info.move.isJump = false;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "unfriendly")
        {
            info.hp.Hp -= collision.gameObject.GetComponent<P_Enemy>().damage;
            //KnockBack(collision.transform.position);
            Hit();
            if (collision.gameObject.layer == 18)
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("isJumping", false);
            info.move.isJump = false;
        }
    }

    IEnumerator EDelay(Skill skill)
    {
        skill.delay.cool = skill.delay.delay;

        while (skill.delay.cool > 0)
        {
            skill.delay.cool -= Time.deltaTime;
            yield return null;
        }

        Debug.Log($"Delay({skill.delay.delay} sec) End!");
        skill.delay.isDelay = false;
        yield return null;
    }

    void SkillCast()
    {


        for (int i = 0; i < info.skills.Count; i++)
        {
            Skill skill = info.skills[i];

            if (skill.delay.isDelay)
                continue;

            if (Input.GetKeyDown(GetKeyCode(skill.key)))
            {
                if (!Is_Skill_On)
                {
                    Earthquake.instance.Earthquake_On = true;
                    return;
                }

                switch (info.type)
                {
                    case Type.COUNTER:
                        if (skill.key == Key.Z)
                        {
                            anim.SetTrigger("Attack");
                            return;
                        }
                        break;
                    case Type.JUPITER:
                        if (skill.key == Key.Z)
                        {
                            anim.SetTrigger("Attack");
                        }
                        break;
                    case Type.REAPER:
                        if (skill.key == Key.Z)
                        {
                            //audioSource.Play();
                            Sound_Manager.instance.SFXPlay("Reaper_Z", AttackSound);
                            anim.SetTrigger("Attack");
                            if (skill.fx.fx)
                            {
                                GameObject temp = Instantiate(skill.fx.fx, new Vector2(transform.position.x + (info.move.IsRight ? 1 : -1) * skill.fx.add_pos.x, transform.position.y + skill.fx.add_pos.y), Quaternion.identity);
                                temp.GetComponent<SpriteRenderer>().flipX = sr.flipX;
                            }
                        }
                        break;
                    case Type.STRIKER:
                        if (skill.key == Key.Z)
                        {
                            anim.SetTrigger("Attack1");
                        }
                        break;
                }

                P_Skill skill_obj = Instantiate(skill.obj, transform.position + new Vector3((info.move.IsRight ? 1 : -1) * skill.obj.add_pos.x, skill.obj.add_pos.y), Quaternion.identity);
                skill_obj.GetComponent<SpriteRenderer>().flipX = info.move.IsLeft;

                GameObject reaper_clone = GameObject.Find("Reaper(Clone)");
                GameObject reaper = GameObject.Find("Reaper");

                if (reaper_clone || reaper)
                    skill_obj.GetComponent<BulletMove>().Dir = new Vector2(info.move.IsRight ? 1 : -1, 0);

                Debug.Log($"[ Skill Cast OK ] Delay({skill.delay.delay} sec) Start!");
                skill.delay.isDelay = true;

                StartCoroutine(EDelay(skill));

                Skill_Cool.Is_Skill_Cool_On = true;
                Debug.Log("Is_Skill_Cool_On" + Skill_Cool.Is_Skill_Cool_On);
            }
        }
    }

    void Counter_Skill_Instan()
    {
        for (int i = 0; i < info.skills.Count; i++)
        {
            Skill skill = info.skills[i];

        P_Skill skill_obj = Instantiate(skill.obj, transform.position + new Vector3((info.move.IsRight ? 1 : -1) * skill.obj.add_pos.x, skill.obj.add_pos.y), Quaternion.identity);
            skill_obj.GetComponent<SpriteRenderer>().flipX = info.move.IsLeft;

        skill.delay.isDelay = true;

        StartCoroutine(EDelay(skill));

        Skill_Cool.Is_Skill_Cool_On = true;
        Debug.Log("Is_Skill_Cool_On" + Skill_Cool.Is_Skill_Cool_On);
        }
    }
}



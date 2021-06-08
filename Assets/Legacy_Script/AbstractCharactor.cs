using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class AbstractCharactor : MonoBehaviour
{

    Rigidbody2D rigid;  //Rigidbody2D -������ rigid ���� 
    SpriteRenderer spriteRenderer;
    Animator anim;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //rigid ���� �ʱ�ȭ
        //maxSpeed = 5f;              //�ִ�ӵ�
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coroutine_delay = 5;
    }

    protected virtual void OnEnable()
    {
        //coroutine_delay = 5;
    }

    protected float speed;
    protected float jumpScale;

    protected float damage;

    protected float NowTime;
    public bool isJump;

    bool DeadOn = false;

    public static bool SkillDrc;

    float coroutine_delay;
    
    protected virtual void Update()
    {
        if (!DeadOn)
        {
            Z();
            X();

            Move();
            LateMove();
        }
        if (GameManager.hp <= 0)
        {
            StartCoroutine(jangdongmin(coroutine_delay));
            DeadOn = true;
        }
        if (GameManager.hp > GameManager.maxHp)
        {
            GameManager.hp = GameManager.maxHp;
        }
    }
    protected virtual void BeforeDelay()
    {
        Dead();
    }
    protected virtual void AfterDelay()
    {
        GameManager.instance.ChangeScene("Title2");
        GameManager.hp = GameManager.maxHp;
    }
    IEnumerator jangdongmin(float delayTime)
    {
        Debug.Log("딜레이 전");
        BeforeDelay();
        yield return new WaitForSeconds(delayTime);
        Debug.Log("딜레이 후");
        AfterDelay();
        yield return null;
    }
    protected abstract void Z();
    protected abstract void X();

    protected virtual void LateMove()
    {
        float h = Input.GetAxisRaw("Horizontal");       //h�� Ű�� ������ �Է� ������=1,����=-1
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); //h * �����ʰ��ؼ� ���� ��

        if (rigid.velocity.x > speed)         //x�ӵ��� maxSpeed ���� ũ��, �ӵ� maxSpeed�� ����
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
        else if (rigid.velocity.x < speed * (-1))       //x�ӵ��� -maxSpeed ���� ������(�������� ����) �ӵ��� -maxSpeed�� ����
            rigid.velocity = new Vector2(speed * (-1), rigid.velocity.y);

        //Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down * 4, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down * 4, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1f)
                {
                    isJump = false;
                    Debug.Log(isJump);
                }
            }
        }
    }
    protected virtual void Move()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJump)
        {
            rigid.AddForce(Vector2.up * jumpScale, ForceMode2D.Impulse);
            Jump();
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            //Ű�� ����,x�� �ӵ� �⺻ 0.5��, y�� �ӵ��� �״��
        }

        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            if (spriteRenderer.flipX)
                SkillDrc = true;
            else
                SkillDrc = false;
            //Ű�� ������ ������, ���ʴ����� -1�Ǽ� �¿�ٲٱ�
        }
        //animation
        if (Mathf.Abs(rigid.velocity.x) < 0.4)
        {
            anim.SetBool("Walking", false);
        }
        else
        {
            if (anim.GetBool("isJumping") == true)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("Walking", false);
                return;
            }
            anim.SetBool("Walking", true);
        }


        ObjectManager.PlayerPos = transform.position;
    }
    public void Hit()
    {
        anim.SetTrigger("Hit");
    }
    public void Jump()
    {
        anim.SetBool("isJumping", true);
        isJump = true;
        Debug.Log(isJump);
    }

    public void Dead()
    {
        anim.SetTrigger("isDead");
    }
    protected void Counter_Z_Attack()
    {
        anim.SetTrigger("Attack");
    }
    protected void Striker_Z_Attack()
    {
        anim.SetTrigger("Attack1");
    }
    protected void Reaper_Z_Attack()
    {
        anim.SetTrigger("Attack");
    }
    protected void Jupiter_Z_Attack()
    {
        anim.SetTrigger("Attack");
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "unfriendly")
        {
            if(this.gameObject.layer==10) 
            {
                OnDamaged(collision.transform.position);
                //MinusHp(collision.gameObject.GetComponent<Enemy>().Damage);
                if (GameManager.hp > 0)
                    anim.SetTrigger("Hit");
            }
            
        }

        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("isJumping", false);
            isJump = false;
        }

        if (collision.gameObject.name == "Deathline" || collision.gameObject.name == "Deathline 1")
        {
            coroutine_delay = 1.25f;
        }

    
    }

    void MinusHp(int damage)
    {
        GameManager.hp -= damage;

    }
    protected void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 11;

        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        rigid.AddForce(new Vector2(transform.position.x - targetPos.x > 0 ? 1 : -1, 1) * 14, ForceMode2D.Impulse);

        Invoke("OffDamaged", 3);
    }

    protected void OffDamaged()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}

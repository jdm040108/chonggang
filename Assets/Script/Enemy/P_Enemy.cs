using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class P_Enemy : MonoBehaviour
{
    [Header("[ 적의 체력 ]")]
    [Range(0, 9999)]
    public int hp;
    [Header("[ 적의 최대 체력 ]")]
    [Space(20)]
    [Range(0, 9999)]
    public int max_hp;
    [Header("[ 적의 공격력 ]")]
    [Space(20)]
    [Range(0, 9999)]
    public int damage;

    SpriteRenderer sr;
    Rigidbody2D rb2D;

    AudioSource audioSource;
    public bool IsThrowing { get; set; } = false;

    private GameObject target;
    public bool Freeze_all { get; set; } = false;

    public bool hasHpbar = false;

    public delegate void VoidCallBack();
    public event VoidCallBack take_damage;

    private void Start()
    {
        take_damage += () => { };

        sr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        AudioSet();

        if (hasHpbar)
        {
            Hpbar hp = Instantiate(Resources.Load<Hpbar>("HpEffect"), transform.position + new Vector3(0, 1), Quaternion.identity);
            hp.transform.position = new Vector3(hp.transform.position.x, hp.transform.position.y);
            hp.Owner = this;
            hp.name = name + " hpbar";
            hp.transform.SetParent(GameObject.Find("Canvas").transform);
            hp.transform.localScale = Vector3.one;
        }
    }

    private void AudioSet()
    {
        if (audioSource)
        {
            audioSource.mute = false;
            audioSource.loop = false;
            audioSource.playOnAwake = false;
            audioSource.volume = 0.5f;
        }
        //Debug.Log("세팅");
    }

    public void Update()
    {
        if (hp > max_hp)
            hp = max_hp;
    }
    public void LateUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down * 2, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.down, 2, LayerMask.GetMask("Platform")/*, LayerMask.GetMask("TileMap")*/);

        if (rayHit.collider != null)
        {
            if (Freeze_all)
            {
                Freeze_all = false;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                GetComponent<Enemy_Move>().enabled = true;
                IsThrowing = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.gameObject.GetComponent<P_Skill>())
        {
            take_damage();
            hp -= col.gameObject.GetComponent<P_Skill>().damage;
        }

        if (col.gameObject.tag == "Attack")
        {
            audioSource.Play();
            gameObject.tag = "Ground";
            gameObject.layer = 8;
            sr.material.color = new Color(0.3f, 0.3f, 0.3f);
            Invoke("MonsterIdle", 4f);
        }

        if (col.gameObject.tag == "Attack2" || col.gameObject.tag == "Attack3")
        {
            Debug.Log("기모티콘");

            if (col.gameObject.GetComponent<SpriteRenderer>().flipX == true)
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 15f);
            if (col.gameObject.GetComponent<SpriteRenderer>().flipX == false)
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -15f);

            sr.material.color = new Color(1f, 0f, 0f);
            Invoke("Rotate_Change_After", 0.2f);
            audioSource.Play();
        }
    }

    public void Rotate_Change_After()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        sr.material.color = new Color(1f, 1f, 1f);
        if (hp <= 0)
        {
            Debug.Log(hp);
            Destroy(gameObject);
        }
    }
    public void MonsterIdle()
    {
        gameObject.tag = "unfriendly";
        gameObject.layer = 9;
        sr.material.color = new Color(1f, 1f, 1f);
        if (hp <= 0)
        {
            Debug.Log(hp);
            Destroy(gameObject);
        }
    }
}

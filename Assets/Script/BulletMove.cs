using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [Header("총알의 속도")]
    public float BulletSpeed;
    public Vector2 Dir { get; set; }
    [Header("총알 발사후 중력의 영향을 받기 시작하는 시간")]
    [Space(20)]
    [Range(0, 10)]
    public int fall_time;

    [Header("친화적인가?")]
    [Space(20)]
    public bool isFriend = true;

    float NowTime;

    Rigidbody2D rb2D;

    void Start()
    {
        NowTime = Time.time;
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (NowTime + fall_time <= Time.time)
            rb2D.gravityScale += 0.1f;

        transform.Translate(Dir * BulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFriend)
        {
            if (collision.gameObject.tag == "unfriendly" || collision.gameObject.tag == "Ground")
                Destroy(gameObject);
        }
        else
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
                Destroy(gameObject);
        }
    }
}

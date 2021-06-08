using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    enum BossState {START, IDLE, WAIT, WALK, ATTACK, HIT, DEAD}; 

    public float Boss_Speed;

    public bool isUFO = false;

    private BossState bossState = BossState.IDLE;

    private float WaitTime;

    private float Cur_WaitTime;
    
    private Vector3 TargetPos;
    private int xForce;

    // Start is called before the first frame update
    void Start()
    {
        Cur_WaitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Cur_WaitTime += Time.deltaTime;
        switch(bossState)
        {
            case BossState.START:
                break;
            case BossState.IDLE:
                int r = Random.Range(0, 2);

                switch(r)
                {
                    case 0: //보스 생각
                        Cur_WaitTime = 0;
                        WaitTime = Random.Range(1, 2);
                        bossState = BossState.WAIT;
                        break;
                    case 1: //보스 이동
                    int Dir = Random.Range(0, 2);
                    float Distance = Random.Range(100, 200) * 0.01f;
                    if(Dir == 0) //오른쪽
                    {
                        xForce = 1;
                    }
                    else if(Dir == 1) //왼쪽
                    {
                        xForce = -1;
                    }

                    TargetPos = gameObject.transform.position;
                    TargetPos.x += (Distance * xForce);

                    bossState = BossState.WALK;
                    break;
                }
                break;
            case BossState.WAIT:
               if(WaitTime <= Cur_WaitTime)
                {
                    bossState = BossState.IDLE;
                }
                break;
            case BossState.WALK:
                TargetPos.y = gameObject.transform.position.y;
                TargetPos.z = gameObject.transform.position.z;

                float ds = Boss_Speed * Time.deltaTime;
                Vector3 cha = (TargetPos - gameObject.transform.position);
                float lenth =  Vector3.Distance(TargetPos, gameObject.transform.position);
                // Mathf.Abs(TargetPos.x - gameObject.transform.position.x);
                // 

                // Debug.Log("cha x " + cha.x + "cha y" + cha.y + "cha z" + cha.z + "lenth" + lenth);

                if(lenth < ds)
                {
                    gameObject.transform.position = TargetPos;
                    bossState = BossState.IDLE;
                }
                else
                {
                    //animator.SetBool("IsWalk", true);
                   // Debug.Log(lenth);
                    float per = ds / lenth;
                    Vector3 np = cha * per;
                   // np.y = np.z = 0;

                   // Debug.Log("np :" + np.x + "lenth :" + lenth +"per :" +  per);
                    
                    gameObject.transform.position += np;

                }
                break;
            case BossState.ATTACK:
                break;
            case BossState.HIT:
                break;
            case BossState.DEAD:
                break;
        }
    }

    // public void OnCollisionStay2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Ground")
    //     {
    //         Debug.Log("충돌!");
    //         bossState = BossState.IDLE;
    //     }
    // }
}

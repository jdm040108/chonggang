using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuesday_Obj : MonoBehaviour
{
    // Start is called before the first frame update
    P_Charactor p_Charactor;

    [Header("[ 감소 스피드 ]")]
    [Range(0, 20)]
    public float Sub_Speed;

    private float Backup_Speed = 0;

    private bool Is_Sub = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Is_Sub)
            {
                Debug.Log("엔초는 짱이야");
                return;
            }

            p_Charactor = collision.gameObject.GetComponent<P_Charactor>();
            Backup_Speed = p_Charactor.info.move.speed;
            p_Charactor.info.move.speed -= Sub_Speed;
            Debug.Log(p_Charactor.info.move.speed);
            Is_Sub = true;
            Invoke("Return_Speed", 3f);
        }
    }

    void Return_Speed() 
    {
        p_Charactor.info.move.speed = Backup_Speed;
        Is_Sub = false;
        Debug.Log(p_Charactor.info.move.speed);
    }
}

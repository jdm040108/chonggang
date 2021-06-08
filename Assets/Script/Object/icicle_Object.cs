using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icicle_Object : MonoBehaviour
{
    enum Icicle_Object_State {START, IDLE, WAIT, WALK, ATTACK, HIT, DEAD}; 

    private Icicle_Object_State icicle_Object_State = Icicle_Object_State.IDLE;
    private float CurTime = 0;
 
    public float MaxTime;
    
    public GameObject Ice_Fall_Object;

    private GameObject target;

    private int ice_Move_On = 0;

    private float Icicle_vibration_cycle;
    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CurTime += Time.deltaTime;
        
        target = GameObject.FindWithTag("Player");

        switch(icicle_Object_State)
        {
            case Icicle_Object_State.START:
                CurTime = 0;
                Icicle_vibration_cycle = Random.Range(5f, 10f);
               // Debug.Log("스타트!");
                icicle_Object_State = Icicle_Object_State.IDLE;
                break;
            case Icicle_Object_State.IDLE:
                if(CurTime < Icicle_vibration_cycle) return;

                CurTime = 0;
                //Debug.Log("아이들");
                icicle_Object_State = Icicle_Object_State.WALK;
                break;
            case Icicle_Object_State.WALK:
                Ice_fall();
                //Debug.Log("움직여!");
                
                break;
        }

        //Debug.Log("고드름 X값: " + (transform.position.x - boxCollider2D.size.x));
    }

    void Ice_fall() 
    {
        if (ice_Move_On == 0)
        {
            transform.position += new Vector3(2.5f, 0, 0) * Time.deltaTime;
            //Debug.Log("+5");
            ice_Move_On = 1;
        }
        else if (ice_Move_On == 1)
        {
            transform.position -= new Vector3(2.5f, 0, 0) * Time.deltaTime;
            //Debug.Log("-5");
            ice_Move_On = 0;
        }

        // if (target.transform.position.x > transform.position.x - boxCollider2D.size.x && target.transform.position.x < transform.position.x) //장애물 범위 안
        // {
            if (CurTime < MaxTime) return;

            Instantiate(Ice_Fall_Object, transform.position, Quaternion.identity);
            
            icicle_Object_State = Icicle_Object_State.START;
            Debug.Log("떨어짐");
        //}
    }

  
}

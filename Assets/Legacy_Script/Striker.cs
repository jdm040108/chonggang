using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : AbstractCharactor
{
    private void Start()
    {
        jumpScale = 15f;
        speed = 7;
      
        NowTime = Time.time;
    }

    protected override void X()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Striker - X");
        }
    }

    protected override void Z()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(NowTime + 0.8f < Time.time)
            {
                Striker_Z_Attack();
                Debug.Log("Striker - Z");
                GetComponent<StrikerZ>().UseSkill();
                NowTime = Time.time;
            }
            else
            {
                
            }
        }
    }
    protected override void Update()
    {
        base.Update();
    }
}

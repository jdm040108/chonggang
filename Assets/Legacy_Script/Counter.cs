using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : AbstractCharactor
{
    public GameObject skillZ;

    
    private void Start()
    {
        jumpScale = 15f;
        speed = 5;
        NowTime = Time.time;
    }

    

    protected override void X()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Counter - X");
        }
    }

    protected override void Z()
    {
        if(Input.GetKeyDown(KeyCode.Z) && NowTime + 1.5f < Time.time)
        {
            Debug.Log("Counter - Z");
            Counter_Z_Attack();
            GetComponent<CounterZ>().UseSkill();
            NowTime = Time.time;
        }
    }
    protected override void Update()
    {
        base.Update();
    }
}

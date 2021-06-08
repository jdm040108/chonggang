using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jupiter : AbstractCharactor
{
    private void Start()
    {
        jumpScale = 15f;
        speed = 5;
        NowTime = Time.time;
    }


    protected override void X()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Jupiter - X");
        }
    }

    protected override void Z()
    {
        if (Input.GetKeyDown(KeyCode.Z) && NowTime + 1.5f < Time.time)
        {
            Debug.Log("Jupiter - Z");
            GetComponent<JupiterZ>().UseSkill();
            Jupiter_Z_Attack();
            NowTime = Time.time;
        }
    }
    protected override void Update()
    {
        base.Update();
    }
}

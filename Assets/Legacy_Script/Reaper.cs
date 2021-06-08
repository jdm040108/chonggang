using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : AbstractCharactor
{
    public GameObject EffObj;
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
            Debug.Log("Reaper - X");
        }
    }

    protected override void Z()
    {
        if (Input.GetKeyDown(KeyCode.Z) && NowTime + 1.5f < Time.time)
        {
            Debug.Log("Reaper - Z");
            Reaper_Z_Attack();
            GetComponent<ReaperZ>().UseSkill();
            MakeEff();
            NowTime = Time.time;
        }
    }
    
    protected override void Update()
    {
        base.Update();
    }

    public void MakeEff()
    {
        Instantiate(EffObj, new Vector2(transform.position.x + 1.8f, transform.position.y + 1.9f), Quaternion.identity);
    }
}

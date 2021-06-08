using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperZ : AbstractSkill
{
    // Start is called before the first frame update
    //Animator animator;
    // Start is called before the first frame update

    public GameObject obj;

    

    Animator animator;
    protected override void Start()
    {
        base.Start();
        targetTime = 3;
        damage = 1;
        delayTime = 5;
        skillObj = obj;
        spriteRenderer = skillObj.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void UseSkill()
    {
        StartCoroutine(jangdongmin(0.5f));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
    }

    protected override void AfterDelay()
    {
        
        SetSkillPos(new Vector2(1.8f, 1.9f));
        CastSkill();
    }
}

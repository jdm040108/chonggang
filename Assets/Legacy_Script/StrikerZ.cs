using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerZ : AbstractSkill
{

    Animator animator;

    // Start is called before the first frame update

    public GameObject obj;
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

    public void UseSkill()
    {
        SetSkillPos(new Vector2(0, 3));
        CastSkill();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("StrikerAttackMotion") &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.85f)
            Destroy(gameObject);
    }

    protected override void AfterDelay()
    {
        
    }
}

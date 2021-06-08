using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterZ : AbstractSkill
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
        Invoke("CounterSkillDelay", 0.7f);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Counter_Attack_Motionanim") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            Destroy(gameObject);
    }

    protected override void AfterDelay()
    {
        throw new System.NotImplementedException();
    }

    void CounterSkillDelay()
    {
        SetSkillPos(new Vector2(5, 3.8f));
        CastSkill();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JupiterZ : AbstractSkill
{
    Animator animator;

    public GameObject obj;
    // Start is called before the first frame update
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
        SetSkillPos(new Vector2(4, 2));
        CastSkill();
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("JupiterAttack") &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            Destroy(gameObject);
    }

    protected override void AfterDelay()
    {

    }
}

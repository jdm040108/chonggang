using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSkill : MonoBehaviour
{
    protected int damage;
    public int Damage => damage;
    protected float delayTime;
    protected float targetTime;
    protected GameObject skillObj;
    public float posX;
    bool isCast;

    protected Vector3 SkillPos = Vector3.zero;


    protected SpriteRenderer spriteRenderer;
    //protected Transform skillPos;
    public IEnumerator jangdongmin(float delayTime)
    {
        Debug.Log("딜레이 전");
        yield return new WaitForSeconds(delayTime);
        Debug.Log("딜레이 후");
        AfterDelay();
        yield return null;
    }
    protected abstract void AfterDelay();

    protected virtual void Start()
    {
        delayTime = 0;
        targetTime = 0;
        isCast = false;
        damage = 1;
    }
    protected virtual void SetSkillPos(Vector2 _pos)
    {
        posX = _pos.x;
        SkillPos = new Vector3(gameObject.transform.position.x + _pos.x, gameObject.transform.position.y + _pos.y, 5);
        //        Debug.Log(SkillPos);
    }
    protected virtual void CastSkill()
    {
        if (AbstractCharactor.SkillDrc)
        {
            spriteRenderer.flipX = true;
            SkillPos.x = posX * -2 + SkillPos.x;
        }
        else
            spriteRenderer.flipX = false;
        Instantiate(skillObj, SkillPos, Quaternion.identity);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<P_Enemy>() != null)
        {
            P_Enemy enemy = collision.gameObject.GetComponent<P_Enemy>();
            //enemy.DamageEnemy(damage);
        }
    }


    protected virtual void Update()
    {
        /*
        if (isCast)
        {
            delayTime += Time.deltaTime;
            if (delayTime >= targetTime)
            {
                delayTime = 0;
                isCast = false;

            }
        }
        */
    }

}

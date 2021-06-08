using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter_ZDst : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Counter_Attack_Motionanim") &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust_Eff : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    SpriteRenderer spriteRenderer;

    P_Charactor p_Charactor;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.color = new Color(255, 255, 255, 125); 
    }

    // Update is called once per frame
    void Update()
    {
        if(!p_Charactor)
        p_Charactor =  GameObject.FindWithTag("Player").GetComponent<P_Charactor>();

        if(p_Charactor.info.move.IsLeft)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }

    void Destroy_Eff()
    {
        Destroy(gameObject);
    }
}

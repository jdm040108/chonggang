using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Obj : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;

    P_Charactor p_Charactor;
    private float BackUp_Speed = 0;
    private float BackUp_JumpScale = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = sprites[1];
            p_Charactor = collision.gameObject.GetComponent<P_Charactor>();
            BackUp_Speed = p_Charactor.info.move.speed;
            BackUp_JumpScale = p_Charactor.info.move.jump_scale;
            p_Charactor.info.move.speed = 0;
            p_Charactor.info.move.jump_scale = 1.0f;
            Debug.Log("물림");
            Invoke("Trap_After", 2f);
        }
    }

    private void Trap_After()
    {
        spriteRenderer.sprite = sprites[0];
        p_Charactor.info.move.speed = BackUp_Speed;
        p_Charactor.info.move.jump_scale = BackUp_JumpScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Object : MonoBehaviour
{
    float Speed = 0;
    float OldPlayerSpeed = 0;
    float OldEnemySpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.gameObject.tag == "unfriendly")
        {
            //Debug.Log("HI");
            Speed = 25;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
            Debug.Log(Speed);
        }
        if (collision.gameObject.tag == "Player") 
        {
            Speed = 100;
            //Debug.Log("HI");
            if(collision.gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 150);
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 150);
            }
            Debug.Log(Speed);
        }
      
    }
}

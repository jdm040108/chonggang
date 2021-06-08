using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfrom : MonoBehaviour
{
    public Vector2 dir;
    P_Charactor player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<P_Charactor>();
    }

    void Update()
    {
        if (!player)
            player = GameObject.FindWithTag("Player").GetComponent<P_Charactor>();

        transform.Translate(dir * 10 * Time.deltaTime);

        if (transform.position.y > player.transform.position.y)
            GetComponent<BoxCollider2D>().isTrigger = true;
        else
            GetComponent<BoxCollider2D>().isTrigger = false;
    }
}

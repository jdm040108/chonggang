using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icicle_Fall_Object : MonoBehaviour
{
    public float Fall_Speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Fall_Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground") 
        {
            Destroy(gameObject);
        }
    }
}

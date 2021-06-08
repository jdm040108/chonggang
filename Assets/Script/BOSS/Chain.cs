using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (transform.localScale.x < 10)
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(10, 2, 1), Time.deltaTime * 3);
        if (transform.localScale.x >= 9)
            Destroy(gameObject);
    }
}

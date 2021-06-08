using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Fx : MonoBehaviour
{
    [Header("몇초뒤에 사라지는가")]
    [Range(0, 100)]
    public float during_time;
    float start_time;

    void Start()
    {
        start_time = Time.time;
    }

    void Update()
    {
        if (start_time + during_time <= Time.time)
            Destroy(gameObject);
    }
}

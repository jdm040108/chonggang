using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [Header("회전속도 조절")]
    [SerializeField] [Range(1, 500)] int rotatedSpeed = 50;
    [Header("회전 방향 조절")]
    [SerializeField] [Range(-1, 1)] int direction = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotatedSpeed*direction, Space.Self);
    }
}

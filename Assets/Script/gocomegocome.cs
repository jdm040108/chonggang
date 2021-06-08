using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gocomegocome : MonoBehaviour
{
    int a = 1;
    int b = 1;
    [Header("0으로 만들면 그 축은 변함 X")]
    [SerializeField] [Range(0, 1)] public int x = 1;
    [SerializeField] [Range(0, 1)] public int y = 1;
    float startPSX;
    float startPSY;
    public int speed = 5;
    public float leftDistance = 5;
    public float rightDistance = 5;
    public float upDistance = 0;
    public float downDistance = 0;
    void Start()
    {
        startPSX = transform.position.x;
        startPSY = transform.position.y;
    }
    void Update()
    {
        if (transform.position.x < startPSX - leftDistance)
        {
            a = 1;
        }
        else if (transform.position.x > startPSX+ rightDistance)
        {
            a = -1;
        }
        if (transform.position.y < startPSY - upDistance)
        {
            b = 1;
        }
        else if (transform.position.y > startPSY + downDistance)
        {
            b = -1;
        }
        transform.Translate(Time.deltaTime * a*speed*x, Time.deltaTime * b * speed*y, 0);
    }
}

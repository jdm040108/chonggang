using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject Target { get; set; }
    public float Angle { get; set; }

    private void Update()
    {
        if (Target)
        {
            Vector3 dir;
            dir = Target.transform.position;
            dir -= transform.position;
            Angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        }
    }
}

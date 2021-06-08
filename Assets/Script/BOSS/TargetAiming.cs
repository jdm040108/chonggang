using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAiming : MonoBehaviour
{
    public delegate void CALLBACK();
    public event CALLBACK Aiming_End;
    public GameObject Target { get; set; } = null;

    private void Start()
    {
        StartCoroutine(EAiming(5));
    }

    IEnumerator EAiming(int delay)
    {
        // 타겟팅 시작
        // 원래는 Aiming GameObject를 생성해야함 테스트 용
        yield return new WaitForSeconds(delay);
        Target = null;
        GameObject.Find("LazerStart").GetComponent<LookAt>().Target = Target;
        Aiming_End();
        yield return null;
        // 타겟팅 종료
    }
    void Update()
    {
        if (Target)
            transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y + 3, Target.transform.position.z);
        else
        {
            Target = GameObject.FindWithTag("Player");
            LookAt look = GameObject.Find("LazerStart").GetComponent<LookAt>();
            if (look)
                look.Target = Target;
        }
    }
}

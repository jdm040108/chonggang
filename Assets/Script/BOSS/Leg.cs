using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    bool first = true;
    void Start()
    {
        StartCoroutine(EStart());
    }

    IEnumerator EStart()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.5f); // 여기서 공격 예고
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1); // 여기서 실제 공격
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(1); // 여기서 객체 삭제
        Destroy(gameObject);
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float time;

    void Start()
    {
        StartCoroutine(EDestroy());
    }

    IEnumerator EDestroy()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        yield return null;
    }
}

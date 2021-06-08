using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public GameObject target;
    public float delay;

    Vector3 dir, prev_pos;
    float angle;
    //bool isTracking = true;


    private void Start()
    {
        if (!target)
            target = GameObject.FindWithTag("Player");
        StartCoroutine(ETracking());
    }

    private void Update()
    {
        //if (isTracking)
        //{
        if (!target)
            target = GameObject.FindWithTag("Player");
        else
        {
            prev_pos = Vector3.Lerp(prev_pos, target.transform.position, 1.5f * Time.deltaTime);
            dir = prev_pos - transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), 50 * Time.deltaTime);
            transform.Translate(Vector3.up * 15 * Time.deltaTime);
        }

        //float dis = transform.position.x - target.transform.position.x;

        //if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        //{
        //    if (dis > 0 && dir.x > 0)
        //        isTracking = false;
        //    else if (dis < 0 && dir.x < 0)
        //        isTracking = false;
        //}
        //}
        //else
        //    transform.Translate(Vector3.up * 15 * Time.deltaTime);
    }

    IEnumerator ETracking()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            if (target)
                prev_pos = Vector3.Lerp(prev_pos, target.transform.position, 1.5f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
            Destroy(gameObject);
    }

}



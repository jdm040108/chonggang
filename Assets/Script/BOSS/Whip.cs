using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Whip : MonoBehaviour
{
    public List<GameObject> whip_child = new List<GameObject>();
    public Vector2 MousePos { get; set; }

    private void Start()
    {
        StartCoroutine(EAttackMouse());
    }

    private void Update()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    IEnumerator EAttackMouse()
    {
        Vector3 dir;
        float angle;

        while (true)
        {
            foreach (var whip in whip_child)
            {
                dir = MousePos;
                dir -= whip.transform.position;
                angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;
                whip.transform.rotation = Quaternion.Lerp(whip.transform.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), Time.deltaTime * 75);
                yield return new WaitForSeconds(0.1f);
            }
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool isUp = true;

    Vector3 pos;

    private void Start()
    {
        pos = Camera.main.transform.position + new Vector3(0, 0, 90);
        StartCoroutine(EWarning());
    }

    IEnumerator EWarning()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Resources.Load<GameObject>("WARNING"), pos, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
        if (isUp)
            Instantiate(Resources.Load<GameObject>("HANDUP"), pos, Quaternion.identity);
        else
            Instantiate(Resources.Load<GameObject>("HANDDOWN"), pos, Quaternion.identity);

        yield return null;
    }
}

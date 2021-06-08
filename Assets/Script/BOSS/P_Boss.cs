using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class P_Boss : MonoBehaviour
{
    public enum Day
    {
        MONDAY,
        TUESDAY,
        WEDNESDAY,
        THURSDAY,
        FRIDAY,
    }

    public Day day;

    bool isLockon = false;

    Vector2 dir;

    GameObject child;
    IEnumerator EDestroy(float time, GameObject obj)
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);
        yield return null;
    }

    IEnumerator ESwitch()
    {
        while (day == Day.MONDAY)
        {
            yield return new WaitForSeconds(10);
            isLockon = !isLockon;

            if (isLockon)
            {
                child.transform.localScale = Vector3.one;
                child.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("LOCKON");
                child.transform.rotation = Quaternion.identity;
                dir = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
                dir = dir.normalized;
                child.transform.localPosition = Vector3.zero;
                transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 11.327663f, 90);
            }
            else
            {
                child.transform.localScale = Vector3.one * 0.7f;
                child.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("LOCKOFF");
            }
        }
        yield return null;
    }

    private void Start()
    {
        switch (day)
        {
            case Day.MONDAY:
                child = GetComponentInChildren<SpriteRenderer>().gameObject;
                dir = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
                dir = dir.normalized;
                StartCoroutine(ESwitch());
                break;
            case Day.TUESDAY:
                break;
            case Day.WEDNESDAY:
                break;
            case Day.THURSDAY:
                break;
            case Day.FRIDAY:
                break;
        }

        StartCoroutine(CUpdate());
    }

    IEnumerator CUpdate()
    {
        while (true)
        {
            int pattern_case = Random.Range(0, 3);

            yield return new WaitForSeconds(5);

            switch (day)
            {
                case Day.MONDAY:
                    if (isLockon)
                    {
                        transform.position = Vector3.Lerp(transform.position, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 11.327663f, 0), Time.deltaTime * 0.1f);
                        switch (pattern_case)
                        {
                            case 0:
                                ChainSpear(10, 2);
                                break;
                            case 1:
                                Aim_And_Shoot();
                                break;
                            case 2:
                                StartCoroutine(EFalling());
                                break;
                        }
                    }
                    break;
                case Day.TUESDAY:
                    switch (pattern_case)
                    {
                        case 0:
                            LegAttack(6);
                            break;
                        case 1:
                            RotatingSushi();
                            break;
                        case 2:
                            break;
                    }
                    break;
                case Day.WEDNESDAY:
                    switch (pattern_case)
                    {
                        case 0:
                            HandUp();
                            break;
                        case 1:
                            StartCoroutine(EFalling(false));
                            break;
                        case 2:
                            break;
                    }
                    break;
                case Day.THURSDAY:
                    switch (pattern_case)
                    {
                        case 0:
                            HandDown();
                            break;
                        case 1:
                            StartCoroutine(ERocketPunch());
                            break;
                        case 2:
                            break;
                    }
                    if (!isLockon)
                        transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(0.90f, 0)).x, GameObject.FindWithTag("Player").transform.position.y + 5);
                    break;
                case Day.FRIDAY:
                    switch (pattern_case)
                    {
                        case 0:
                            StartCoroutine(EShootPattern(Random.Range(1, 5)));
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                    break;
            }

            yield return null;
        }
    }

    private void Update()
    {
        if (!isLockon)
        {
            Destroy(GameObject.Find("Lazer"));
            Destroy(GameObject.Find("Aiming"));
            child.transform.Rotate(new Vector3(0, 0, 5));
            transform.Translate(dir * 20 * Time.deltaTime);
            Vector2 v2 = Camera.main.WorldToViewportPoint(child.transform.position);
            if (v2.x > 1)
                dir = Vector3.left;
            else if (v2.x > 0.9f)
            {
                transform.Translate(Vector3.left * 0.3f);
                dir = Vector3.Reflect(dir, Vector3.right);
            }

            if (v2.y > 1)
                dir = Vector3.down;
            else if (v2.y > 0.9f)
            {
                transform.Translate(Vector3.down * 0.3f);
                dir = Vector3.Reflect(dir, Vector3.up);
            }

            if (v2.x < 0)
                dir = Vector3.right;
            else if (v2.x < 0.1f)
            {
                transform.Translate(Vector3.right * 0.3f);
                dir = Vector3.Reflect(dir, Vector3.left);
            }

            if (v2.y < 0)
                dir = Vector3.up;
            else if (v2.y < 0.1f)
            {
                transform.Translate(Vector3.up * 0.3f);
                dir = Vector3.Reflect(dir, Vector3.down);
            }
        }
    }

    #region MONDAY_BOSS_CODE

    public void Aim_And_Shoot()
    {
        GameObject aiming = Instantiate(Resources.Load<GameObject>("Aiming"));
        aiming.name = "Aiming";
        aiming.GetComponent<TargetAiming>().Aiming_End += On_Aim_End;
    }

    IEnumerator EOn_Aim_End()
    {
        Destroy(GameObject.Find("Aiming"));
        yield return new WaitForSeconds(0.5f);
        GameObject obj = Instantiate(Resources.Load<GameObject>("Lazer"));
        obj.name = "Lazer";
        obj.transform.SetParent(GameObject.Find("LazerStart").transform);
        obj.transform.localPosition = new Vector3(0, 0, -10);
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = new Vector3(10, 1, 1);
        StartCoroutine(EDestroy(5, GameObject.Find("Lazer")));
        yield return null;
    }

    private void On_Aim_End()
    {
        StartCoroutine(EOn_Aim_End());
        return;
    }

    IEnumerator EFalling(bool isMonday = true)
    {
        string sprite_load;
        sprite_load = isMonday ? "fall_monday" : "fall_wednesday";
        Sprite sprite = Resources.Load<Sprite>(sprite_load);

        for (int i = 0; i < 20; i++)
        {
            Vector3 v3 = Camera.main.ViewportToWorldPoint(Vector3.up);
            GameObject obj = Instantiate(Resources.Load<GameObject>("Fall"), new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 0)).x, v3.y + 2, 0), Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = sprite;
            obj.transform.localScale = Vector3.one * Random.Range(1f, 2f);
            obj.name = "Fall";
            yield return new WaitForSeconds(0.3f);
        }

        yield return null;
    }

    IEnumerator EChainSpear(int count)
    {
        GameObject player;
        GameObject chain;
        Vector3 dir;
        float angle;
        for (int i = 0; i < count; i++)
        {
            player = GameObject.FindWithTag("Player");
            chain = Instantiate(Resources.Load<GameObject>("Chain"),
                new Vector3(Random.Range(player.transform.position.x - 30, player.transform.position.x + 30), 30),
                Quaternion.identity);
            chain.name = "Chain";
            dir = player.transform.position;
            dir -= chain.transform.position;
            angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;
            chain.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

    public void ChainSpear(int count, int sync_count)
    {
        for (int i = 0; i < sync_count; i++)
            StartCoroutine(EChainSpear(count));
    }
    #endregion

    #region TUESDAY_BOSS_CODE
    public void LegAttack(int count)
    {
        GameObject player;
        player = GameObject.FindWithTag("Player");
        for (int i = 0; i < count; i++)
        {
            Instantiate(Resources.Load<GameObject>("Leg"),
                new Vector3(Random.Range(player.transform.position.x - 30, player.transform.position.x + 30), -5),
                Quaternion.Euler(0, 0, -90));
        }
    }

    public void RotatingSushi()
    {
        Instantiate(Resources.Load<GameObject>("Rotating_Sushi"),
            new Vector3(Camera.main.transform.position.x, GameObject.FindWithTag("Player").transform.position.y + 15.14272f - 5),
            Quaternion.identity);
    }
    #endregion

    #region WEDNESDAY_BOSS_CODE

    public void HandUp()
    {
        Instantiate(Resources.Load<GameObject>("HAND"),
            new Vector3(0, 0, 0),
            Quaternion.identity).GetComponent<Hand>().isUp = true;
    }

    #endregion

    #region THURSDAY_BOSS_CODE

    public void HandDown()
    {
        Instantiate(Resources.Load<GameObject>("HAND"),
            new Vector3(0, 0, 0),
            Quaternion.identity).GetComponent<Hand>().isUp = false;
    }

    IEnumerator ERocketPunch()
    {
        isLockon = true;

        BulletMove bm;

        List<int> type = new List<int>
        {
            1,0,1,0,0,1,0,0,1,0
        };

        for (int i = 0; i < 10; i++)
        {
            switch (type[i])
            {
                case 0:
                    bm = Instantiate(Resources.Load<BulletMove>("RocketPunch"), transform.position, Quaternion.identity);
                    bm.Dir = new Vector2(-1.5f, 0);
                    break;
                case 1:
                    bm = Instantiate(Resources.Load<BulletMove>("RocketPunch"), transform.position + new Vector3(0, -3), Quaternion.identity);
                    bm.Dir = new Vector2(-1.5f, 0);
                    break;
            }
            yield return new WaitForSeconds(2.5f);
        }

        isLockon = false;

        yield return null;
    }

    #endregion

    #region FRIDAY_BOSS_CODE

    IEnumerator EShootPattern(int type)
    {
        GameObject origin = Resources.Load<GameObject>("Friday_Rocket");
        GameObject temp;
        List<GameObject> objs = new List<GameObject>();

        switch (type)
        {
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    temp = Instantiate(origin, transform.position + new Vector3(7 * (i == 0 ? -1 : i == 1 ? 1 : i == 2 ? -1 : i == 3 ? 1 : 0), 7 * (i == 0 ? 1 : i == 1 ? 1 : i == 2 ? -1 : i == 3 ? -1 : 0)), Quaternion.Euler(0, 0, 45 * i));
                    temp.AddComponent<Tracking>().delay = 5;
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    temp = Instantiate(origin, transform.position + new Vector3(), Quaternion.Euler(0, 0, (45 / 2) * i + 67.5f - (22.5f / 2)));
                    BulletMove bm = temp.AddComponent<BulletMove>();
                    bm.Dir = Vector3.up;
                    bm.BulletSpeed = 30;
                    bm.isFriend = false;
                }
                break;
            case 3:
                objs.Clear();
                for (int i = 0; i < 3; i++)
                {
                    temp = Instantiate(origin, transform.position + new Vector3(), Quaternion.Euler(0, 0, (45 / 2) * i + 67.5f));
                    objs.Add(temp);
                    BulletMove bm = temp.AddComponent<BulletMove>();
                    bm.Dir = Vector3.up;
                    bm.BulletSpeed = 30;
                    bm.isFriend = false;
                }

                yield return new WaitForSeconds(1.5f);

                foreach (var obj in objs)
                {
                    Destroy(obj.GetComponent<BulletMove>());
                    Destroy(obj.GetComponent<Destroy>());
                    obj.AddComponent<Destroy>().time = 3;
                    obj.AddComponent<Tracking>().delay = 5;
                }
                break;
            case 4:
                for (int i = 0; i < 36; i++)
                {
                    temp = Instantiate(origin, transform.position + new Vector3(), Quaternion.Euler(0, 0, 10 * i));
                    BulletMove bm = temp.AddComponent<BulletMove>();
                    bm.Dir = Vector3.up;
                    bm.BulletSpeed = 30;
                    bm.isFriend = false;
                    yield return new WaitForSeconds(0.1f);
                }
                break;
        }

        yield return null;
    }

    #endregion
}

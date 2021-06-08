using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSushi : MonoBehaviour
{
    MovingPlatfrom platform;

    private void Start()
    {
        PatternStart();
    }

    public void PatternStart()
    {
        StartCoroutine(EInstantiate());
        StartCoroutine(ELazer());
    }

    IEnumerator ELazer()
    {
        Camera.main.GetComponent<Camera_Move>().following = false;
        GameObject obj;
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    {
                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, 9, -1);

                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, 5, -1);

                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, 1, -1);
                    }
                    break;
                case 1:
                    {
                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, 9, -1);

                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, 5, -1);

                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, -7, -1);

                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, -11, -1);
                    }
                    break;
                case 2:
                    {
                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, 1, -1);

                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, -3, -1);

                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, -7, -1);

                        obj = Instantiate(Resources.Load<GameObject>("Create_Effect"));
                        obj.name = "Create_Effect";
                        obj.transform.position = transform.position + new Vector3(25, -11, -1);
                    }
                    break;
            }
            yield return new WaitForSeconds(1);
            switch (i)
            {
                case 0:
                    {
                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, 9, 0);

                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, 5, 0);

                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, 1, 0);
                    }
                    break;
                case 1:
                    {
                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, 9, 0);

                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, 5, 0);

                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, -7, 0);

                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, -11, 0);
                    }
                    break;
                case 2:
                    {
                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, 1, 0);

                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, -3, 0);

                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, -7, 0);

                        obj = Instantiate(Resources.Load<GameObject>("Sushi_Lazer"));
                        obj.name = "Sushi_Lazer";
                        obj.transform.position = transform.position + new Vector3(0, -11, 0);
                    }
                    break;
            }
            yield return new WaitForSeconds(6);
        }
        yield return new WaitForSeconds(1);
        Camera.main.GetComponent<Camera_Move>().following = true;
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator EInstantiate()
    {
        platform = Instantiate(Resources.Load<MovingPlatfrom>("RotatingPlatfrom"), new Vector3(transform.position.x + 50 - 30.23199f, transform.position.y - 5), Quaternion.identity);
        platform.dir = Vector2.left;
        platform = Instantiate(Resources.Load<MovingPlatfrom>("RotatingPlatfrom"), new Vector3(transform.position.x + 50 - (30.23199f * 2), transform.position.y - 5), Quaternion.identity);
        platform.dir = Vector2.left;
        platform = Instantiate(Resources.Load<MovingPlatfrom>("RotatingPlatfrom"), new Vector3(transform.position.x - 50 + 30.23199f, transform.position.y + 3), Quaternion.identity);
        platform.dir = Vector2.right;
        platform = Instantiate(Resources.Load<MovingPlatfrom>("RotatingPlatfrom"), new Vector3(transform.position.x - 50 + (30.23199f * 2), transform.position.y + 3), Quaternion.identity);
        platform.dir = Vector2.right;
        for (int i = 0; i < 5; i++)
        {
            platform = Instantiate(Resources.Load<MovingPlatfrom>("RotatingPlatfrom"), new Vector3(transform.position.x + 50, transform.position.y - 5), Quaternion.identity);
            platform.dir = Vector2.left;
            platform = Instantiate(Resources.Load<MovingPlatfrom>("RotatingPlatfrom"), new Vector3(transform.position.x - 50, transform.position.y + 3), Quaternion.identity);
            platform.dir = Vector2.right;
            yield return new WaitForSeconds(3);
        }
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelMove : MonoBehaviour
{

    public GameObject[] Stage;

    public GameObject[] Day;

    public Camera Camera;
    private int key = 0;

    private int Cm_K = 0;
    public float Speed;

    private float PosY = 3.5f;
    private bool Sw_x = false;

    private bool Cm_x = false;

    float rot;
    Vector3 np;

    // private bool Sw_y = false;
    // private bool Sw_yy = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();

        SwitchOn();


    }

    void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (key == 0) return;

            Sw_x = true;

            key--;

            if ((key + 1) % 3 == 0)
            {
                Cm_x = true;
                Cm_K = ((key + 1) / 3) - 1;
                Debug.Log(Cm_K);
            }
            Debug.Log(key);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (key == 14) return;

            Sw_x = true;

            key++;

            if (key % 3 == 0)
            {
                Cm_x = true;
                Cm_K = key / 3;
                Debug.Log(Cm_K);
            }
            Debug.Log(key);
        }
        // else if(Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     if(key == 2)
        //     {
        //         Sw_y = true;
        //         Sw_yy = false;
        //         key++;
        //         Debug.Log(key);
        //     }
        // }
        // else if(Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     if(key == 3)
        //     {
        //         Sw_y = true;
        //         Sw_yy = true;
        //         key--;
        //         Debug.Log(key);
        //     }
        // }
    }

    void SwitchOn()
    {
        if (Sw_x)
        {
            Vector3 TargetPos = Stage[key].transform.position;
            //Debug.Log(key);
            TargetPos.y = transform.position.y;

            float len = Vector3.Distance(TargetPos, gameObject.transform.position);
            float ds = Speed * Time.deltaTime;
            Vector3 cha = (TargetPos - transform.position);

            if (len < ds)
            {
                gameObject.transform.position = TargetPos;
                Sw_x = false;
            }
            else
            {
                float per = ds / len;
                np = cha * per;

                rot += Time.deltaTime;

                gameObject.transform.localEulerAngles = new Vector3(0, 0, (np.x > 0 ? -1 : 1) * rot * 720);
                gameObject.transform.position += new Vector3(np.x, 0, 0);
            }
        }
        else
        {
            gameObject.transform.localEulerAngles = Vector3.Lerp(gameObject.transform.localEulerAngles, new Vector3(0, 0, (np.x > 0 ? 0 : 0)), Time.deltaTime);
        }
        if (Cm_x)
        {
            Vector3 TargetPos = Day[Cm_K].transform.position;

            float len = Vector3.Distance(TargetPos, Camera.transform.position);
            float ds = Speed * 2 * Time.deltaTime;
            Vector3 cha = (TargetPos - Camera.transform.position);

            if (len < ds)
            {
                Camera.transform.position = TargetPos;
                Cm_x = false;
            }
            else
            {
                float per = ds / len;
                Vector3 np = cha * per;


                Camera.transform.position += new Vector3(np.x, 0, 0);
            }

        }
        // else if(Sw_y)
        // {
        //     Vector3 TargetPos = Stage[key].transform.position;

        //     if(Sw_yy)
        //     TargetPos.y = 3.5f;
        //     else
        //     TargetPos.y = -1.5f;

        //     Debug.Log(key);
        //     //TargetPos.y = transform.position.y;

        //     float len = Vector3.Distance(TargetPos, gameObject.transform.position);
        //     float ds = Speed * Time.deltaTime;
        //     Vector3 cha = (TargetPos - transform.position);

        //     if(len < ds)
        //     {
        //         gameObject.transform.position = TargetPos;
        //         Sw_y = false;
        //     }
        //     else
        //     {
        //         float per = ds / len;
        //         Vector3 np = cha * per;

        //         gameObject.transform.position += new Vector3(0, np.y, 0);
        //     }
        // }
    }
}

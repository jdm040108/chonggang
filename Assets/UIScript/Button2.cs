using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    public static bool LightCheck2;
    // Start is called before the first frame update
    void OnMouseOver()
    {
        LightCheck2 = true;
    }

    void OnMouseExit()
    {
        LightCheck2 = false;
    }
}

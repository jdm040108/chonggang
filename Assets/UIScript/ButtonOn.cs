using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOn : MonoBehaviour
{
    public static bool LightCheck;
    // Start is called before the first frame update
    void OnMouseOver()
    {
        LightCheck = true;
    }

    void OnMouseExit()
    {
        LightCheck = false;
    }
}

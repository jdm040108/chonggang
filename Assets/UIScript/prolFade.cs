using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prolFade : MonoBehaviour
{
    // Start is called before the first frame update
    public static int prolStep = 0;

    bool Check;
    float NextTime;
    float fade = 1f;

    public static float TimeCheck;
    GameObject FadePlane;
    CanvasRenderer CanvasRenderer;
    AudioSource AudioSource;
    void Start()
    {
        FadePlane = GameObject.Find("FadeIn");
        CanvasRenderer = FadePlane.GetComponent<CanvasRenderer>();
        AudioSource = GetComponent<AudioSource>();
        NextTime = Time.time - 1f;
        Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(NextTime + TimeCheck < Time.time)
        {
            prolStep = 2;
            NextTime = Time.time;
        }

        switch(prolStep)
        {
            case 0:
                fade -= Time.deltaTime;
                if(fade <= 0)
                {
                    fade = 0;
                    prolStep = 4;
                }
                break;
            case 2:
                fade += Time.deltaTime;
                if(fade >= 1)
                {
                    fade = 1;
                    prolStep = 0;   
                    prolManager.Show++;
                    EndManager.EndShow++;
                }
                break;
        }

        CanvasRenderer.SetAlpha(fade);
    }
}

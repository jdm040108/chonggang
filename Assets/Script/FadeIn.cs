using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Step = 0;

    float fade = 1f;

    
    GameObject FadePlane;
    CanvasRenderer CanvasRenderer;
    AudioSource AudioSource;
    void Start()
    {
        FadePlane = GameObject.Find("FadeIn");
        CanvasRenderer = FadePlane.GetComponent<CanvasRenderer>();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(Step)
        {
            case 0:
                fade -= Time.deltaTime;
                if(fade <= 0)
                {
                    fade = 0;
                    Step = 1;
                    FadePlane.SetActive(false);
                }
                break;
            case 2:
                fade += Time.deltaTime;
                if(fade >= 1)
                {
                    Step = 3;
                    GameManager.instance.ChangeScene("Prol");
                }
                break;
        }

        AudioSource.volume = 1.0f - fade;
        CanvasRenderer.SetAlpha(fade);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeFuck : MonoBehaviour
{
    CanvasRenderer canvasRenderer;

    float fade = 0f;

    int Step = 2;

    // Start is called before the first frame update
    void Start()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(Step)
        {
            case 0:
                fade -= Time.deltaTime / 3;
                if(fade <= 0)
                {
                    fade = 0;
                    Step = 4;
                }
                break;
            case 2:
                fade += Time.deltaTime / 1;
                if(transform.localScale.x < 1.5f || transform.localScale.y < 1.5f)
                {
                   transform.localScale += new Vector3(0.05f, 0.05f, 0); 
                }
                if(fade >= 1)
                {
                    fade = 1;
                    Step = 0;
                }
                break;
        }


        canvasRenderer.SetAlpha(fade);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    AudioSource bgm;
    
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.volume = 0.1f;
    }
}

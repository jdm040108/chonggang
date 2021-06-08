using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance = null;

    static Job curJob;
    public Job CurJob { get { return curJob; } set { curJob = value; } }

    private void Start()
    {
        Instance = this;
    }

    public enum Job
    {
        Counter,
        Reaper,
        Striker,
        Jupiter,
    }
}

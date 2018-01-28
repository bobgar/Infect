using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeGoal : Goal
{

    public float timeLimitSeconds;

    public GameObject goalUI;
    public Text text;

    private float _startTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (text)
        {
            text.text = (int)(timeLimitSeconds - (Time.time - _startTime)) + "s";
        }
    }

    public override void AddUI(Transform t, int x)
    {
        var g = GameObject.Instantiate(goalUI);
        g.transform.parent = t;
        g.transform.localPosition = new Vector3(x, 0);
        text = g.GetComponentInChildren<Text>();
    }

    public override bool IsComplete()
    {
        if(Time.time-_startTime < timeLimitSeconds)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberObjectGoal : Goal
{

    //Number of objects to threshold on
    public int objectGoal;
    //Default to less-than check
    public bool lessThanOrEqualTo = true;
    public GameObject goalUI;
    private Gauge gauge;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gauge.SetText(GoalManager.instance.objectCount + " goal " + objectGoal);
        gauge.SetPercent((GoalManager.instance.objectCount*1f) / (1f*GoalManager.instance.initalObjectCount));
    }

    public override void AddUI(Transform t, float x, float y)
    {
        GameObject g = GameObject.Instantiate(goalUI);
        g.transform.parent = t;
        g.transform.localPosition = new Vector3(x , y);
        gauge = g.GetComponent<Gauge>();
        gauge.SetText(GoalManager.instance.objectCount + " goal "+objectGoal);
        gauge.SetPercent(1f);
        //g.GetComponentInChildren<Text>().text = (lessThanOrEqualTo ? "<" : ">") + objectGoal;
    }

    public override bool IsComplete()
    {
        if(lessThanOrEqualTo &&  GoalManager.instance.objectCount <= objectGoal)
        {
            return true;
        }
        else if(!lessThanOrEqualTo && GoalManager.instance.objectCount >= objectGoal)
        {
            return true;
        }
        return false;
    }
}

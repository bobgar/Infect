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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void AddUI(Transform t, int x)
    {
        var g = GameObject.Instantiate(goalUI);
        g.transform.parent = t;
        g.transform.localPosition = new Vector3(x, 0);
        g.GetComponentInChildren<Text>().text = (lessThanOrEqualTo ? "<" : ">") + objectGoal;
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

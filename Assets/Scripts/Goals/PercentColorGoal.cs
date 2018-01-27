﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentColorGoal : Goal {
    public Color disease;
    public float percentGoal;
    public bool isGreaterThan;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override bool IsComplete()
    {
        float per = 0;
        if (GoalManager.instance.colorCountDictionary.ContainsKey(disease))
        {
            int numColor = GoalManager.instance.colorCountDictionary[disease];
            int numTotal = GoalManager.instance.objectCount;
            per = numColor / numTotal;
        }

        if(isGreaterThan)
        {
            return per >= percentGoal;
        }
        else
        {
            return per <= percentGoal;
        }
    }
}
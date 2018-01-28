using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentColorGoal : Goal {
    public Color disease;
    public float percentGoal;
    public bool isGreaterThan;
    public GameObject goalUI;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void AddUI(Transform t, int x)
    {
        var g = GameObject.Instantiate(goalUI);
        g.transform.parent = t;
        g.transform.localPosition = new Vector3(x, 0);
        g.GetComponent<Image>().color = disease;
        g.GetComponentInChildren<Text>().text = (isGreaterThan ? ">" : "<") + percentGoal;
    }

    public override bool IsComplete()
    {
        
        float per = 0;
        //Debug.Log("color to Check: " + disease);
        if (GoalManager.instance.colorCountDictionary.ContainsKey(disease))
        {
            int numColor = GoalManager.instance.colorCountDictionary[disease];
            int numTotal = GoalManager.instance.objectCount;
            per = numColor * 1.0f / numTotal * 1.0f;
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

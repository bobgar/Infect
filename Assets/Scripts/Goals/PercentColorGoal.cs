using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentColorGoal : Goal {
    public Color disease;
    public float percentGoal;
    public bool isGreaterThan;
    public GameObject goalUI;
    private Gauge gauge;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gauge.SetText("");
        gauge.SetPercent(1f);

        if (GoalManager.instance.colorCountDictionary.ContainsKey(disease))
        {
            int numColor = GoalManager.instance.colorCountDictionary[disease];
            int numTotal = GoalManager.instance.objectCount;
            float per = numColor * 1.0f / numTotal * 1.0f;
            Debug.Log("per = " + per);
            gauge.SetPercent(per - .05f);
        }
        else
        {
            gauge.SetPercent(0);
        }
    }

    public override void AddUI(Transform t, float x, float y)
    {
        var g = GameObject.Instantiate(goalUI);
        gauge = g.GetComponent<Gauge>();
        //gauge.SetText(GoalManager.instance.objectCount + " goal " + objectGoal);
        gauge.SetText("");
        gauge.SetPercent(0f);
        g.transform.parent = t;
        g.transform.localPosition = new Vector3(x, y);
        gauge.SetColor(disease);
        //g.transform.localPosition = new Vector3(x, 0);
        //g.GetComponent<Image>().color = disease;
        //g.GetComponentInChildren<Text>().text = (isGreaterThan ? ">" : "<") + percentGoal;
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

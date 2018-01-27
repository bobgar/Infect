using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {

    public Goal[] goals;

    public static GoalManager instance;

    public int objectCount;
    public Dictionary<Color, int> colorCountDictionary = new Dictionary<Color, int>();

	// Use this for initialization
	void Start () {
        instance = this;

        Agent[] initialAgentArray = FindObjectsOfType<Agent>();
        GoalManager.instance.objectCount = initialAgentArray.Length;
	}
	
	// Update is called once per frame
	void Update () {

        int goalsComplete = 0;
        for(int i = 0; i < goals.Length; i++)
        {
            if(goals[i].IsComplete())
            {
                goalsComplete++;
            }
        }

        if(goalsComplete >= goals.Length)
        {
            Win();
        }
	}

    void Win()
    {
        Debug.Log("*********** WIN **************");
    }
}

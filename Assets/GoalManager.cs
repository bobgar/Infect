using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {
    public bool won;

    public Transform goalContainer;
    public Goal[] goals;

    public static GoalManager instance;

    public int objectCount;
    public Dictionary<Color, int> colorCountDictionary = new Dictionary<Color, int>();

    public GameObject winUI;

	// Use this for initialization
	void Start () {
        instance = this;

        Agent[] initialAgentArray = FindObjectsOfType<Agent>();
        GoalManager.instance.objectCount = initialAgentArray.Length;

        for (int i = 0; i < goals.Length; i++)
        {
            Debug.Log("Ading UI for Goal");
            goals[i].AddUI(goalContainer, i * 50);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (won)
            return;

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
        won = true;        
        winUI.SetActive(true);

        Rigidbody2D[] rigidBodyArray = FindObjectsOfType<Rigidbody2D>();
        for(int i = 0; i < rigidBodyArray.Length; i++)
        {
            rigidBodyArray[i].isKinematic = true;
            rigidBodyArray[i].velocity = Vector3.zero;
            rigidBodyArray[i].angularVelocity = 0;
        }
    }
}

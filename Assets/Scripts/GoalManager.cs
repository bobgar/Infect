﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour {
    public bool won;
    public bool lost;

    public Transform goalContainer;
    public Goal[] goals;

    public static GoalManager instance;

    public int objectCount;
    public int initalObjectCount;
    public Dictionary<Color, int> colorCountDictionary = new Dictionary<Color, int>();

    public GameObject winUI;
    public GameObject loseUI;

	// Use this for initialization
	void Start () {
        instance = this;

        Agent[] initialAgentArray = FindObjectsOfType<Agent>();
        objectCount = initialAgentArray.Length;
        initalObjectCount = initialAgentArray.Length;

        for (int i = 0; i < goals.Length; i++)
        {
            Debug.Log("Ading UI for Goal");
            goals[i].AddUI(goalContainer, 350, i * 70 + 25);
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
    }
    void Lose()
    {
        if(!won) {
            loseUI.SetActive(true);
            lost = true;
        }
    }
    public void CheckLose()
    {
        int count = 0;

        foreach(KeyValuePair<Color, int> entry in colorCountDictionary)
        {
            Debug.Log(entry.Value);
            if(entry.Value > 0) {
                count++;
            }
        }
        if(count == 0 )
        {

            for(int i = 0; i < this.GetComponent<Spawner>().diseaseButtons.Length; i++)
            {
                if(this.GetComponent<Spawner>().diseaseButtons[i].canUse())
                {
                    count++;
                }
            }   
        }
        if(count == 0){
            StartCoroutine(waitForWin());
        }

    }
    private IEnumerator waitForWin()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Lose();
        }
    }

    public void ReturnToLevelSelect()
    {
        SceneManager.LoadScene(0);
    }

}

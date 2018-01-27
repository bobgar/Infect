using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    protected bool isComplete = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void AddUI(Transform t)
    {

    }

    public virtual bool IsComplete()
    {
        return isComplete;
    }
}

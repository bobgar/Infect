using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    public Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        
        Vector2 startingSpeed = new Vector2(Random.Range(-5f,5f),Random.Range(-5f,5f));
        rigidBody.velocity = startingSpeed;
    }
	
	// Update is called once per frame
	void Update () {
		    
	}
}

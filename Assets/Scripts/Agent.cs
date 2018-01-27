using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    public SpriteRenderer sprite;
    public Rigidbody2D rigidBody;

    private bool _infected = false;

	// Use this for initialization
	void Start () {
        
        Vector2 startingSpeed = new Vector2(Random.Range(-5f,5f),Random.Range(-5f,5f));
        rigidBody.velocity = startingSpeed;
    }
	
	// Update is called once per frame
	void Update () {
		    
	}

    void OncollisionEnter2D(Collision2D coll)
    {
        if (IsInfected())
        {
            Collider2D c = coll.otherCollider;
            Agent a = c.gameObject.GetComponent<Agent>();
            if (!a.IsInfected())
            {
                Infect();
            }
        }
    }

    bool IsInfected()
    {
        return _infected;
    }

    void Infect()
    {
        _infected = true;
        sprite.color = Color.red;
    }
}

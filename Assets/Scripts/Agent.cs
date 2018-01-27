using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    public SpriteRenderer sprite;
    public Rigidbody2D rigidBody;

    public GameObject splitAgent;
    public int splitNum;

    public Disease disease;
    //private bool _infected = false;

	// Use this for initialization
	void Start () {
        
        Vector2 startingSpeed = new Vector2(Random.Range(-5f,5f),Random.Range(-5f,5f));
        rigidBody.velocity = startingSpeed;
    }
	
	// Update is called once per frame
	void Update () {
		    
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (IsInfected())
        {
            //Collider2D c = coll.otherCollider;
            Agent a = coll.gameObject.GetComponent<Agent>();

            //Debug.Log("object " + coll.gameObject.name);
            if (a && !a.IsInfected())
            {
                //Debug.Log("Infecting!");
                a.Infect(this.disease);
                a.Split();
                Split();

                GameObject.Destroy(this.gameObject);
            }
        }
    }

    public bool IsInfected()
    {
        return disease != null;
    }

    public void Split()
    {
        //Debug.Log("splitAgent: " + splitAgent);
        if (splitAgent != null)
        {
            //Debug.Log("splitNum: " + splitNum);
            for (int i = 0; i < splitNum; i++)
            {
                //Debug.Log("dividing!");
                GameObject splitObj = GameObject.Instantiate(splitAgent);
                splitObj.gameObject.transform.position = this.gameObject.transform.position + Random.onUnitSphere;
                Agent a = splitObj.GetComponent<Agent>();
                if(a && this.IsInfected())
                {
                    a.Infect(this.disease);
                }
            }
        }
        GameObject.Destroy(this.gameObject);
    }

    public void Infect(Disease d)
    {
        //_infected = true;
        disease = d;
        sprite.color = d.color;
        Debug.Log("disease deathtime = " + d.deathTime);
        if (d.deathTime != -1)
        {
            StartCoroutine(DieInTime(d.deathTime));
        }
    }

    IEnumerator DieInTime(int deathTime)
    {
        while (true)
        {
            float deathTimeInSeconds = deathTime / 1000f;
            Debug.Log("destroying in " + deathTimeInSeconds);
            yield return new WaitForSeconds(deathTimeInSeconds);
            Debug.Log("destroying now!");
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("DESTROYED");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    public SpriteRenderer sprite;
    public Rigidbody2D rigidBody;

    public GameObject splitAgent;
    public int splitNum;

    private Disease disease = null;
    //private bool _infected = false;

	// Use this for initialization
	void Start () {
        
        Vector2 startingSpeed = new Vector2(Random.Range(-5f,5f),Random.Range(-5f,5f));
        rigidBody.velocity = startingSpeed;
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
                GoalManager.instance.objectCount++;
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
        if(!GoalManager.instance.colorCountDictionary.ContainsKey(d.color))
        {
            GoalManager.instance.colorCountDictionary.Add(d.color, 1);
        }
        else
        {
            GoalManager.instance.colorCountDictionary[d.color]++;
        }
        sprite.color = d.color;
        Debug.Log("disease deathtime = " + d.deathTime);
        if (d.deathTime >= 0)
        {
            DieInTime(d.deathTime);
            //StartCoroutine(DieInTime(d.deathTime));
        }
    }

    private float _deathTime = -1;
    private float _startDeathTimer = -1;

    void DieInTime(int deathTime)
    {
        float deathTimeInSeconds = deathTime / 1000f;
        _deathTime = deathTimeInSeconds;
        _startDeathTimer = Time.time;
        /*while (true)
        {
            float deathTimeInSeconds = deathTime / 1000f;
            Debug.Log("destroying in " + deathTimeInSeconds);
            yield return new WaitForSeconds(deathTimeInSeconds);
            Debug.Log("destroying now!");
            GameObject.Destroy(this.gameObject);
        }*/
    }



    // Update is called once per frame
    void Update()
    {
        if(_deathTime >= 0)
        {
            var percent = (Time.time-_startDeathTimer) / _deathTime;
            if(percent > 1)
            {
                GameObject.Destroy(this.gameObject);
            }
            else if(percent > .5)
            {
                Color c = sprite.color;
                c.a = 1-((percent - .5f)*2);
                sprite.color = c;
            }
        }
    }

    private void OnDestroy()
    {
        Debug.Log("DESTROYED");
        GoalManager.instance.objectCount--;
        if (disease != null && GoalManager.instance.colorCountDictionary.ContainsKey(disease.color))
        {
            GoalManager.instance.colorCountDictionary[disease.color]--;
        }
    }
}

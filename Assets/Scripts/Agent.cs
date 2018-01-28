using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    public SpriteRenderer sprite;
    public SpriteRenderer border;
    public SpriteRenderer glow;

    public Rigidbody2D rigidBody;

    public GameObject splitAgent;
    public int splitNum;

    public Vector2 velocity;

    public bool isStationary;

    private Disease disease = null;
    //private bool _infected = false;

	// Use this for initialization
	void Start () {
        
        if(!isStationary && velocity.magnitude == 0.0f)
        {
            Vector2 startingSpeed = new Vector2(Random.Range(-2f,2f),Random.Range(-2f,2f));
            rigidBody.velocity = startingSpeed;

        } else if(isStationary) {
            rigidBody.velocity = new Vector2(0,0);
        } else {
            rigidBody.velocity = velocity;
        }
        
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
                if (SFXGloopAudio.instance != null)
                    SFXGloopAudio.instance.PlayGloop();
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
        border.color = d.boarderColor;
        glow.color = d.glowColor;
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
        if (GoalManager.instance.won)
            return;

        if (_deathTime >= 0)
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
    void FixedUpdate() {
        if(!isStationary && velocity.magnitude < 0.5f) {
            Vector2 randomSpeed = new Vector2(Random.Range(-2f,2f),Random.Range(-2f,2f));
            rigidBody.AddForce(randomSpeed);
        }
    }
    void OnBecameInvisible() {
        enabled = false;
    }

    private void OnDestroy()
    {
        GoalManager.instance.objectCount--;
        if (disease != null && GoalManager.instance.colorCountDictionary.ContainsKey(disease.color))
        {
            GoalManager.instance.colorCountDictionary[disease.color]--;
            if(GoalManager.instance.colorCountDictionary[disease.color] == 0) {
                GoalManager.instance.CheckLose();
            }
        }
    }
}

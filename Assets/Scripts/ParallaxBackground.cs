using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

    public SpriteRenderer s;
    public Vector3 velocity;
    private Vector3 _initPos;
    
	// Use this for initialization
	void Start () {
        _initPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += velocity;//new Vector3(.0025f, .0025f, 0f);

        if (velocity.x > 0)
        {
            if (this.transform.position.x > _initPos.x + (s.bounds.size.x / 5f))
            {
                this.transform.position = _initPos;
            }
        }
        else
        {
            if (this.transform.position.x < _initPos.x - (s.bounds.size.x / 5f))
            {
                this.transform.position = _initPos;
            }
        }

    }
}

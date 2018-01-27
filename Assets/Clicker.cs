using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {

  public int clicks = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
  {
  		if(clicks > 0 && Input.GetMouseButtonDown(0)) 
      {
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);             
          if(hit.collider !=null && hit.collider.tag == "Agent")
              {
                  Debug.Log ("infected"); 
                  clicks--;
                  hit.collider.gameObject.GetComponent<Agent>().Infect();
              }
              else
              {
                  Debug.Log ("No agent collider hit"); 
              }
     }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {

    //public Disease[] diseases = { new Disease(Color.red, 500), new Disease(Color.blue, 1000) };
    public static DiseaseButton curDiseaseButton;

    //public int clicks = 0;
    //public int Maxclicks = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
  		//if(clicks < Maxclicks && Input.GetMouseButtonDown(0)) 
        if(Input.GetMouseButtonDown(0) && curDiseaseButton != null && curDiseaseButton.canUse())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);             
            if(hit.collider !=null && hit.collider.tag == "Agent")
            {
                Debug.Log("obj hit");
                Agent a = hit.collider.gameObject.GetComponent<Agent>();
                Debug.Log(a);
                if (a && !a.IsInfected())
                {
                    Debug.Log("infected");
                    //a.Infect(diseases[clicks]);
                    a.Infect(curDiseaseButton.disease);
                    curDiseaseButton.Use();
                    //clicks++;
                }
            }
            else
            {
                Debug.Log ("No agent collider hit"); 
            }
        }
    }
}

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
            //first we get the ray represented by the mouse click. because its a perspective camera, 
            //the direction will change depending on where you click
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             
            //the ray origin is the position in world space on the 'front' plane of the camera. however
            //for your game we need to go forwards to the plane of your objects. I am going to assume
            //that is z==0 for now, so...
            float z_plane_of_2d_game = 0;
            Vector3 pos_at_z_0 = ray.origin + ray.direction * (z_plane_of_2d_game - ray.origin.z) / ray.direction.z;
             
            //now we have a 3D point on the correct plane, we can continue with your code
            Vector2 point = new Vector2(pos_at_z_0.x,pos_at_z_0.y);
            RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);
            if(hit.collider !=null && hit.collider.tag == "Agent")
            {
                Debug.Log("obj hit");
                Agent a = hit.collider.gameObject.GetComponent<Agent>();
                Debug.Log(a);
                if (a && !a.IsInfected())
                {
                    if (SFXGloopAudio.instance != null)
                        SFXGloopAudio.instance.PlayClick();
                        //SFXGloopAudio.instance.PlayGloop();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public DiseaseButton diseaseButtonPrefab;
    public GameObject buttonBar;
    public DiseaseButton[] diseaseButtons;

    public DiseaseButton.DiseaseButtonSpec[] diseases;
    
    public GameObject circle;
    public GameObject triangle;
    public GameObject square;
	// Use this for initialization
    public int circleCount;
    public int triangleCount;
    public int squareCount;  
    

	void Start () {

        diseaseButtons = new DiseaseButton[diseases.Length];
        for(int i = 0; i < diseases.Length; i++)
        {
            DiseaseButton db = GameObject.Instantiate(diseaseButtonPrefab);
            diseaseButtons[i] = db;
            db.transform.parent = buttonBar.transform;
            db.uses = diseases[i].uses;
            db.disease = diseases[i].disease;
            db.transform.localPosition = new Vector3(i * 50 + 50, 0);
        }


        for (int i = 0; i < circleCount; i++) {
            Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Instantiate(circle, randomPositionOnScreen, Quaternion.identity);
        }
        for (int i = 0; i < triangleCount; i++) {
            Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Instantiate(triangle, randomPositionOnScreen, Quaternion.identity);
        }
        for (int i = 0; i < squareCount; i++) {
            Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Instantiate(square, randomPositionOnScreen, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

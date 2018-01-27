using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject circle;
    public GameObject triangle;
    public GameObject square;
	// Use this for initialization
    public int circleCount;
    public int triangleCount;
    public int squareCount;

	void Start () {
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

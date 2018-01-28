using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberArray : MonoBehaviour {

    public Image[] numberArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetNumber(int num)
    {
        for (int i = 0; i < numberArray.Length; i++)
        {
            if (i != num)
            {
                numberArray[i].gameObject.SetActive(false);
            }
            else
            {
                numberArray[i].gameObject.SetActive(true);
            }
        }
    }
}

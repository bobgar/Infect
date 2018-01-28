using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberArray : MonoBehaviour {

    public int startingValue;
    public Color startingTint;
    public Image[] numberArray;

	// Use this for initialization
	void Awake () {
        SetNumber(startingValue);
        if(startingTint.a != 0)
        {
            TintNumber(startingTint);
        }
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

    public void TintNumber(Color c)
    {
        for (int i = 0; i < numberArray.Length; i++)
        {
            numberArray[i].color = c;//.GetComponent<SpriteRenderer>().color = c;
        }
    }
}

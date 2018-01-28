using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseButton : MonoBehaviour {
    
    [System.Serializable]
    public class DiseaseButtonSpec
    {
        public Disease disease;
        public int uses;
    }

    public Sprite[] DiseaseImages;
    private Color[] _colorToImageArray = {Color.green, Color.yellow, Color.red };
 
    public Button button;
    public NumberArray numberArray;

    private int _uses;
    private Disease _disease;    

    public int uses
    {
        get { return _uses; }
        set {
            _uses = value;
            numberArray.SetNumber(uses);
            //button.GetComponentInChildren<Text>().text = "" + uses;
        }
    }

    public Disease disease
    {
        get { return _disease; }
        set {
            _disease = value;
            /*ColorBlock colors = button.colors;
            colors.normalColor = disease.color;
            button.colors = colors;*/
            int i = 0;
            while(i < _colorToImageArray.Length)
            {
                if (_colorToImageArray[i] == _disease.color)
                    break;
                i++;
            }
            button.image.sprite = DiseaseImages[i];
        }
    }

	// Use this for initialization
	void Start () {        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDiseaseButtonClick()
    {
        Clicker.curDiseaseButton = this;
    }

    public bool canUse()
    {
        return uses > 0;
    }

    public void Use()
    {
        uses--;
        if (uses <= 0)
        {
            this.button.interactable = false;
        }
        numberArray.SetNumber(uses);
        //button.GetComponentInChildren<Text>().text = ""+uses;// "uses: " + uses + "\ntime: " + (disease.deathTime / 1000f);        
    }
}

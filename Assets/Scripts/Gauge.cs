using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour {

    public Image background;
    public Image foreground;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}

    private float _p = 0f;

	// Update is called once per frame
	void Update () {
        /*_p += .001f;
        if (_p > 1f)
            _p = 0;
        SetPercent(_p);*/
	}

    public void SetText(string t)
    {
        text.text = t;
    }

    public void SetPercent(float p)
    {
        _p = p;
        foreground.SetClipRect(new Rect(background.gameObject.transform.localPosition.x, background.gameObject.transform.localPosition.y, background.rectTransform.rect.width, background.rectTransform.rect.height * p), true);
    }
}

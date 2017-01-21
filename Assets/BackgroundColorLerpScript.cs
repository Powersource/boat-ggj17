using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorLerpScript : MonoBehaviour {

    public Color myStartColor;
    public Color myTargetColor;
    private Color myCurrentBackgroundColor;
    private float myLerpTime = 0;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().color = myStartColor;
        myCurrentBackgroundColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
       myLerpTime += (Time.deltaTime)*.0000075f;
       myCurrentBackgroundColor = Color.Lerp(myCurrentBackgroundColor, myTargetColor,myLerpTime);
       gameObject.GetComponent<SpriteRenderer>().color = myCurrentBackgroundColor;
	}
}

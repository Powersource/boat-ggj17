﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour {

    private bool grow = false;
    public Text myScoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void UpdateScore(int aNewScore)
    {
        myScoreText.text = "Score: " + aNewScore.ToString();
    }
}

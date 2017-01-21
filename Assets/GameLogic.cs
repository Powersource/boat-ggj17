﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
    public GameObject myFishToSpawn;
	public GameObject wavePrefab;

    public float minSpawnDelay = 1.5f;
    public float maxSpawnDelay = 2.5f;
    private float myNextSpawnDelay = 1f;
    private float mySpawnTimer;

    private float myMinYSpawn = -4.5f;
    private float myMaxYSpawn = -2;

    private int myScore = 0;

    private GameObject myGUIScoreText;
    public Text myScoreText;

	private GameObject waves;
	private float waveWidth = 140/100f; // 100 pixels per unit

	// Use this for initialization
	void Start () {
        //set myMinYSpawn and myMaxYSpawn depending on screen size
        myGUIScoreText = GameObject.FindGameObjectWithTag("GUIScoreText");
        
		waves = new GameObject ("waves");
		for (int i = 0; i < 20; i++) {
			Debug.Log ("i: " + i);
			GameObject newWave = (GameObject)Instantiate (wavePrefab);
			newWave.transform.localPosition = new Vector2 (i * waveWidth - 10 * waveWidth, 0);
			newWave.transform.parent = waves.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {

        mySpawnTimer += Time.deltaTime;

        if (mySpawnTimer > myNextSpawnDelay)
        {
            myNextSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            mySpawnTimer = 0;

            
            GameObject newFish = (GameObject)Instantiate(myFishToSpawn);
            newFish.transform.position = new Vector3(16, Random.Range(myMinYSpawn, myMaxYSpawn));
        }


	}

	void FixedUpdate() {
		updateWaves ();
	}

	void updateWaves() {
		for (int i = 0; i<20; i++) {
			GameObject child = waves.transform.GetChild (i).gameObject;
			child.transform.Translate (Vector2.left * 0.1f);
			if (child.transform.position.x < -10 * waveWidth) {
				child.transform.Translate (Vector2.right * 20f * waveWidth);
			}
		}
	}

    void UpdateScore(int aAddToScore)
    {
        myScore += aAddToScore;
        myScoreText.SendMessage("UpdateScore", myScore);
        //Debug.Log(myScore);
    }
}

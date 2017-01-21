using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
    public GameObject myFishToSpawn;

    public float minSpawnDelay = 1.5f;
    public float maxSpawnDelay = 2.5f;
    private float myNextSpawnDelay = 1f;
    private float mySpawnTimer;

    private float myMinYSpawn = -4.5f;
    private float myMaxYSpawn = -2;

    private int myScore = 0;

    private GameObject myGUIScoreText;
    public Text myScoreText;

	// Use this for initialization
	void Start () {
        //set myMinYSpawn and myMaxYSpawn depending on screen size
        myGUIScoreText = GameObject.FindGameObjectWithTag("GUIScoreText");
        
	}
	
	// Update is called once per frame
	void Update () {

        mySpawnTimer += Time.deltaTime;

        if (mySpawnTimer > myNextSpawnDelay)
        {
            myNextSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            mySpawnTimer = 0;

            
            GameObject newFish = (GameObject)Instantiate(myFishToSpawn);
            newFish.transform.position = new Vector3(13, Random.Range(myMinYSpawn, myMaxYSpawn));
        }


	}

    void UpdateScore(int aAddToScore)
    {
        myScore += aAddToScore;
        myScoreText.SendMessage("UpdateScore", myScore);
        //Debug.Log(myScore);
    }
}

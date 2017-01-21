using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
    public GameObject myFishToSpawn;
	public GameObject wavePrefab;
	public GameObject birdPrefab;

    public float minSpawnDelay = 1.5f;
    public float maxSpawnDelay = 2.5f;
    private float myNextSpawnDelay = 1f;
    private float mySpawnTimer;

    private float myMinYSpawn = -3.5f;
    private float myMaxYSpawn = -2.5f;

    private int myScore = 0;

    private GameObject myGUIScoreText;
    public Text myScoreText;

	private GameObject waves;
	private float waveWidth = 1040/100f; // 100 pixels per unit
	private float waveSpeed = 0.03f;
	private float waveY = -2;

	// Boat
	private GameObject boat;
	private Vector2 driveDir = Vector2.zero;
	private float boatSpeed = 0.08f;

	private GameObject gameOver;

	// Use this for initialization
	void Start () {
        //set myMinYSpawn and myMaxYSpawn depending on screen size
        myGUIScoreText = GameObject.FindGameObjectWithTag("GUIScoreText");
        
		waves = new GameObject ("waves");
		for (int i = 0; i < 20; i++) {
			GameObject newWave = (GameObject)Instantiate (wavePrefab);
			newWave.transform.localPosition = new Vector2 (i * waveWidth - 10 * waveWidth, waveY);
			newWave.transform.parent = waves.transform;
		}

		boat = GameObject.Find ("boat");

		gameOver = GameObject.Find ("gameOver");

		gameOver.SetActive(false);
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

			//Spawn a bird as well, maybe move this into its own thing
			GameObject newBird = (GameObject) Instantiate(birdPrefab);
			// This only affects the x
			newBird.transform.position = new Vector2 (16, Random.Range (myMinYSpawn + 5, myMaxYSpawn + 5));
        }

		driveDir = new Vector2(Input.GetAxisRaw ("Horizontal"), 0);
	}

	void FixedUpdate() {
		updateWaves ();
		steerBoat ();
	}

	void updateWaves() {
		for (int i = 0; i<20; i++) {
			GameObject child = waves.transform.GetChild (i).gameObject;
			child.transform.Translate (Vector2.left * waveSpeed);
			if (child.transform.position.x < -10 * waveWidth) {
				child.transform.Translate (Vector2.right * 20f * waveWidth);
			}
		}
	}

	void steerBoat() {
		boat.transform.Translate (driveDir * boatSpeed);
	}

    void UpdateScore(int aAddToScore)
    {
        myScore += aAddToScore;
        myScoreText.SendMessage("UpdateScore", myScore);
        //Debug.Log(myScore);
    }

	public void die() {
		gameOver.SetActive(true);
	}

	public void restartLevel() {
		Time.timeScale = 1;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("scene0");
	}
}

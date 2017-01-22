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

    public float minBirdSpawnDelay = 1.5f;
    public float maxBirdSpawnDelay = 3.0f;
    public float earlyExtraDelay = 2.0f;

    public float beforeSpawnBirdsDelay = 5.0f;

    public AudioClip standardFishAudio;
    public AudioClip goldFishAudio;

    private AudioClip myPickupAudio;
    private AudioSource myAudioSource;

    private bool spawnBirds = false;
    private float myNextSpawnDelay = 1f;
    private float myNextBirdSpawnDelay = 1f;
    private float mySpawnTimer;
    private float myBirdSpawnTimer;

    private float myMinYSpawn = -3.5f;
    private float myMaxYSpawn = -2.5f;

    private int myScore = 0;

    private GameObject myGUIScoreText;
    public Text myScoreText;

	private GameObject waves;
	private float waveWidth = 1039/100f; // 100 pixels per unit
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

        myAudioSource = gameObject.GetComponent<AudioSource>();

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
			
        }

        myBirdSpawnTimer += Time.deltaTime;

        if (spawnBirds)
        {
            if (myBirdSpawnTimer > myNextBirdSpawnDelay)
            {
                GameObject newBird = (GameObject)Instantiate(birdPrefab);
                // This only affects the x
                newBird.transform.position = new Vector2(16, Random.Range(myMinYSpawn + 5, myMaxYSpawn + 5));
                myNextBirdSpawnDelay = Random.Range(minBirdSpawnDelay, maxBirdSpawnDelay)+earlyExtraDelay;
                myBirdSpawnTimer = 0;

                if (earlyExtraDelay > 0)
                    earlyExtraDelay -= 0.5f;
            }
        }

        else
        {
            beforeSpawnBirdsDelay -= Time.deltaTime;
            if (beforeSpawnBirdsDelay < 0)
                spawnBirds = true;
        }

		driveDir = new Vector2(Input.GetAxisRaw ("Horizontal"), 0);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameExit();
        }
            
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
        if (aAddToScore == 50)
            myAudioSource.PlayOneShot(goldFishAudio,0.45f);
        else
            myAudioSource.PlayOneShot(standardFishAudio,0.85f);

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

    public int getScore()
    {
        return myScore;
    }

    public void gameExit()
    {
        Application.Quit();
    }
}

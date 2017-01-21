using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullAI : MonoBehaviour {

	private float flySpeed = 0.04f;
	private float birdY = 1.5f;

	private float magnitude = 0.5f;
	private int offset = 1;
	private Vector3 axis;


	private GameObject myGameLogic;
	private float myKillX;
	private int myScoreValue;

	// Use this for initialization
	void Start () {
		//make dynamic based on camera bounds!
		myKillX = -14;
		myGameLogic = GameObject.FindGameObjectWithTag("GameLogic").gameObject;
		myScoreValue = Random.Range(1, 11);

		offset = Random.Range(1, 5);
	}


	void FixedUpdate () {

		transform.position = new Vector2(transform.position.x - flySpeed, (Mathf.Sin(transform.position.x* magnitude+offset  ) + birdY));

		if(transform.position.x < myKillX)
		{
			Destroy(gameObject);
			//Also change to be dynamic based on camera boundries
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Boat dead");
		Time.timeScale = 0;
		myGameLogic.GetComponent<GameLogic> ().die ();

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
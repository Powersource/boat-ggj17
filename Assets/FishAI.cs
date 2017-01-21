using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour {

    private float mySwimSpeed = 0.05f;
    public GameObject myParticleSystemPrefab;

    private float frequency = 11.1f;
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

        
        
        switch(myScoreValue)
        {
            case 1:
            case 2:
            case 3:

                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                myScoreValue = 10;
                magnitude = 0.3f;
                break;

            case 4:
            case 5:
            case 6:

                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                myScoreValue = 15;
                magnitude = 0.5f;
                break;

            case 7:
            case 8:

                gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                myScoreValue = 20;
                magnitude = 0.8f;
                break;

            
            case 9:

                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                myScoreValue = 30;
                magnitude = 1;
                break;

            case 10:

                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                myScoreValue = 50;
                magnitude = 1.1f;
                break;
        }
        
	}
	

	void FixedUpdate () {

        transform.position = new Vector2(transform.position.x - mySwimSpeed, (Mathf.Sin(transform.position.x* magnitude+offset  )-2));
        
        if(transform.position.x < myKillX)
        {
            Destroy(gameObject);
            //Also change to be dynamic based on camera boundries
        }

        if (transform.position.x < 0)
        {
            GameObject newParticleSystem = (GameObject)Instantiate(myParticleSystemPrefab);
            Destroy(gameObject);
            //Also change to be dynamic based on camera boundries
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        myGameLogic.SendMessage("UpdateScore", myScoreValue);
        GameObject newParticleSystem = (GameObject)Instantiate(myParticleSystemPrefab);
        newParticleSystem.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour {

    public float mySwimSpeed = 1f;
    private GameObject myGameLogic;
    private float myKillX;
    private int myScoreValue;

	// Use this for initialization
	void Start () {
        //make dynamic based on camera bounds!
        myKillX = -14;
        myGameLogic = GameObject.FindGameObjectWithTag("GameLogic").gameObject;
        myScoreValue = Random.Range(1, 11);
        
        switch(myScoreValue)
        {
            case 1:
            case 2:
            case 3:

                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                myScoreValue = 10;
                break;

            case 4:
            case 5:
            case 6:

                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                myScoreValue = 15;
                break;

            case 7:
            case 8:

                gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                myScoreValue = 20;
                break;

            
            case 9:

                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                myScoreValue = 30;
                break;

            case 10:

                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                myScoreValue = 50;
                break;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-mySwimSpeed, 0, 0);

        if(transform.position.x < myKillX)
        {
            Debug.Log("Fish destroying itself...");
            Destroy(gameObject);
            //Also change to be dynamic based on camera boundries
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        myGameLogic.SendMessageUpwards("UpdateScore", myScoreValue);
        //Debug.Log(myScoreValue);
        Destroy(gameObject);
    }
}

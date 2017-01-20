using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour {

    public float mySwimSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-mySwimSpeed, 0, 0);

        if(transform.position.x < -14)
        {
            //Destroy
            //Also change to be dynamic based on camera boundries
        }
	}
}

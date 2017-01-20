using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptTEMP : MonoBehaviour {
    private float timer = 0.0f;
    private int direction = 1;
    private float smoothifier = 0.007f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 5){
            direction = direction * -1;
            timer = 0;
        }


        
        gameObject.transform.Translate(0, direction* smoothifier, 0);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishWobbler : MonoBehaviour {
    private float myWobbleChange = 0.03f;
    private float myCurrentWobble = 2.0f;
    private float myTargetWobble = 1.5f;
    private float minWobble = 1.9f;
    private float maxWobble = 2.3f;

	// Use this for initialization
	void Start () {
        myCurrentWobble = gameObject.transform.localScale.x;
        minWobble = Random.Range(1.7f, 1.9f);
        maxWobble = Random.Range(2.1f, 2.3f);
    }

    // Update is called once per frame
    void Update() {
        myCurrentWobble = gameObject.transform.localScale.x;

        if (myCurrentWobble > maxWobble)
        {
            myTargetWobble = minWobble;
            myWobbleChange = myWobbleChange*-1;

        }

        if (myCurrentWobble < minWobble)
        { 
            myTargetWobble = maxWobble;
            myWobbleChange = myWobbleChange * -1;

        }


        transform.localScale += new Vector3(myWobbleChange, 0,0);

	}
}

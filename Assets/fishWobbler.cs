using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishWobbler : MonoBehaviour {
    private float myWobbleChange = 0.03f;
    private float myCurrentWobble = 2.0f;
    private float myTargetWobble = 1.5f;
    private float minWobble = 2f;
    private float maxWobble = 2.2f;

	// Use this for initialization
	void Start () {
        myCurrentWobble = gameObject.transform.localScale.x;
	}

    // Update is called once per frame
    void Update() {
        myCurrentWobble = gameObject.transform.localScale.x;

        if (myCurrentWobble > 2.5f)
        {
            myTargetWobble = minWobble;
            myWobbleChange = myWobbleChange*-1;

        }

        if (myCurrentWobble < 1.5f)
        { 
            myTargetWobble = maxWobble;
            myWobbleChange = myWobbleChange * -1;

        }


        transform.localScale += new Vector3(myWobbleChange, 0,0);

	}
}

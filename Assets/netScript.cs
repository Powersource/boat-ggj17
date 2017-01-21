using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netScript : MonoBehaviour {

    public float netMoveSpeed = 0.1f;
    public float moveSpeedFalloff = 0.95f;
    private float moveSpeed;


	void Start () {
        //set netMoveSpeed based on screen height!
	}
	

	void Update () {
        if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.position.y > -4)
        {
            moveSpeed = netMoveSpeed * -1;
        }

        if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.localPosition.y > 0.5)
        {
            moveSpeed = netMoveSpeed * 1;
        }

        moveSpeed = moveSpeed * moveSpeedFalloff;
        gameObject.transform.Translate(0, moveSpeed, 0);


    }
}

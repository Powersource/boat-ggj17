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
		moveSpeed = netMoveSpeed * Input.GetAxisRaw ("Vertical");

        moveSpeed = moveSpeed * moveSpeedFalloff;
        gameObject.transform.Translate(0, moveSpeed, 0);


    }
}

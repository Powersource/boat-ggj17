using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSounds : MonoBehaviour {

    public AudioClip mySplashSound1;
    public AudioClip mySplashSound2;
    private AudioSource myAudioSource;

    private float mySoundTimer = 0;
    private float mySoundDelay = 0.5f;
    
	// Use this for initialization
	void Start () {
        myAudioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        mySoundTimer += Time.deltaTime;
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (mySoundTimer > mySoundDelay)
        {
            if(Random.Range(0,1) < 0.5f)
                myAudioSource.PlayOneShot(mySplashSound1);
            else
                myAudioSource.PlayOneShot(mySplashSound2);
            mySoundTimer = 0;
        }
    }
}

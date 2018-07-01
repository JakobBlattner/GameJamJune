using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawnController : MonoBehaviour {

    private float startTime;
    public GameObject[] asteroids;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.time - startTime >= 5000)
        {
            //let random asteroid spawn
            //Instantiate();
        }
	}
}

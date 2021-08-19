using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fifteenMunitesBefore : MonoBehaviour {

	//Time for waiting (This is about movement of the robot)
	public bool startTime = false;
	public float waitinglTime = 0;
	public float storeOfWaitingTime = 5f;
	public float decreasingTime = 0.1f;


	public string nextLevel;

	// Use this for initialization
	void Start () {
		waitinglTime = storeOfWaitingTime;
	}
	
	// Update is called once per frame
	void Update () {

		//Time codes
		if (startTime == true) {

			waitinglTime -= decreasingTime;
			if (waitinglTime <= 0) {
				waitinglTime = 0;
				startTime = false;
			}
		} else if (startTime == false && waitinglTime <= 0) {
			//Write what we wanna do
			Application.LoadLevel(nextLevel);
			}

		}



}

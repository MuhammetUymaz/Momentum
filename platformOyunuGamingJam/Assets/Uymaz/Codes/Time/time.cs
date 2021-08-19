using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class time : MonoBehaviour {

	public float totalTime; //Bound time
	public float passingTime; //Time between total time and when we start map
	public float beginningTime; //When we start map
	public float remainTime;

	//Setting the time
	public bool firstScene;

	//Last scene
	public bool lastScene;



	//Open this Pannel: Play Again Completely
	public GameObject playAgainCompletelyPanel;


	// Use this for initialization
	void Start () {
		//WHEN WE ARE ıN THE FıRST SCENE
		if (firstScene == true) {
			PlayerPrefs.SetFloat("remainTime", 900);
		}

		beginningTime = Time.time; //Get the beginning time

		totalTime = PlayerPrefs.GetFloat("remainTime");

		if (lastScene == true) {
			totalTime = 120;
		}

		//Below line is not important
		//PlayerPrefs.SetFloat ("remainTime", 65);
	}
	
	// Update is called once per frame
	void Update () {

		passingTime = Time.time - beginningTime; //passing Time

		remainTime = (totalTime - (passingTime));

		float second = remainTime % 60;
		int minute = (int)remainTime / 60;

		//Time Shower
		//gameObject.GetComponent<Text> ().text = "Time: " + (totalTime - (passingTime)).ToString("F1"); //Show it
		gameObject.GetComponent<Text> ().text = "Time: " + minute.ToString("F0") + " : " + second.ToString("F0"); //Show it

		//Time ups
		if (remainTime <= 0) {
			playAgainCompletelyPanel.SetActive (true);

			//Delete this code file
			Destroy(gameObject.GetComponent<time>());
		}
			

		//When we pass the level
	//	if (Input.GetKey (KeyCode.O)) {
	//		PlayerPrefs.SetFloat ("remainTime", remainTime); //WRITE THIS CODE FOR NEXT LEVEL
	//	}
	}
}

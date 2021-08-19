using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardCode : MonoBehaviour {

	public float movingSpeed;
	public float jumpPower;
	public float pushingValue;


	//Next Level
	public string nextLevel;

	void Start()
	{
		if (GameObject.Find ("Camera") != null) {
			GameObject.Find ("Camera").GetComponent<AudioSource> ().time = PlayerPrefs.GetFloat ("musicTime");	
		}
	}

	public void clickingOnTheCard()
	{
		//Entering the value
		PlayerPrefs.SetFloat("movingSpeed", movingSpeed);
		PlayerPrefs.SetFloat("jumpingPower", jumpPower);
		PlayerPrefs.SetFloat("pushingValue", pushingValue);
	
		if (GameObject.Find ("Camera") != null) {
			PlayerPrefs.SetFloat ("musicTime", GameObject.Find ("Camera").GetComponent<AudioSource> ().time);	
		}


		//ADD SOUND EFFECT 

		//Go to next level
		Application.LoadLevel(nextLevel);

	}


}

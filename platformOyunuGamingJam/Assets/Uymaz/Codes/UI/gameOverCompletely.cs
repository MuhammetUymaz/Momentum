using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverCompletely : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Click()
	{
		///////
		/// //Time
		PlayerPrefs.SetFloat("remainTime", 15);
	
		//Player
		PlayerPrefs.SetFloat ("movingSpeed", 0);
		PlayerPrefs.SetFloat ("jumpingPower", 0);
		PlayerPrefs.SetFloat ("pushingValue", 0);

		//Music
		if (GameObject.Find ("Camera") != null) {
			PlayerPrefs.SetFloat ("musicTime", GameObject.Find ("Camera").GetComponent<AudioSource> ().time);
		}

		Application.LoadLevel ("selectingCard1");
	}
}

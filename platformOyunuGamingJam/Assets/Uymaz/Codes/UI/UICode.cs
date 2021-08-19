using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICode : MonoBehaviour {

	public GameObject pause;
	public GameObject play;
	public GameObject quit;
	public string levelName;
	public GameObject Camera;

	public void Pause(){
		Time.timeScale = 0;
		play.SetActive (true);
		gameObject.SetActive (false);
		quit.SetActive (true);
		//ADD SOUND
	
	}

	public void Play(){
		Time.timeScale = 1;
		pause.SetActive (true);
		quit.SetActive (false);

		if (GameObject.Find ("Information") != null) {
			GameObject.Find ("Information").SetActive (false);
		}

		gameObject.SetActive (false);

		//ADD SOUND
	}

	public void Quit() {
		PlayerPrefs.SetFloat ("musiTime", 0);
		Application.Quit ();
	}

	public void Restart(){
		Application.LoadLevel (levelName);
		PlayerPrefs.SetFloat ("musicTime", Camera.GetComponent<AudioSource> ().time);
		//ADD SOUND
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevelDoor : MonoBehaviour {

	public string nextLevel;
	public GameObject Camera;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "player") {
			
			//ADD Sound
			PlayerPrefs.SetFloat ("musicTime", Camera.GetComponent<AudioSource> ().time);
			Application.LoadLevel(nextLevel);


		}
	}
}

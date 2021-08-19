using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class nextWritten : MonoBehaviour {

	public string[] story;
	int i = 1;

	public GameObject written;
	public string nextScene; 

	public void Click(){

		if (i < story.Length) {
			written.GetComponent<Text> ().text = story [i];
			i++;
		} else if (i >= story.Length) {
			//Start GAME (GO TO FıST CARD SCENE)

			Application.LoadLevel (nextScene);

		}



		


	}


}

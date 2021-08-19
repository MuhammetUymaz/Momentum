using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerHealthWritten : MonoBehaviour {

	public GameObject player;
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<playerMovement> ().playerHealth > 0) {
			gameObject.GetComponent<Text> ().text = "Health: " + player.GetComponent<playerMovement> ().playerHealth.ToString();
		}

	}
}

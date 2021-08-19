using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootCode : MonoBehaviour {

	public float speed;
	public float jump;
	public float pushingValue; 

	//Text
	public GameObject textObject;

	//Time for the text
	public bool startTime = false;
	public float totalTime = 5f;
	public float decreasingTime = 0.1f;

	//Animation , if it exists
	public Animator animator;


	void Update()
	{
		//Time codes
		if (startTime == true) {
			totalTime -= decreasingTime;
			if (totalTime <= 0) {
				totalTime = 0;
				startTime = false;
			}
		} else if (startTime == false && totalTime <= 0) {
			//Write what we wanna do

			//If there isn't an animation
			if (animator == null) {
				Destroy (gameObject);
			} 
			//If there is
			else {
				textObject.SetActive (false);
				animator.SetBool ("closed", true); //The loot (treasure) will be closed
			}

		}
	}

	//Collision
	void OnTriggerEnter2D(Collider2D other)
	{
		//When it crushes the block etc
		if (other.tag == "player") {

			//Add them to player's properties
			PlayerPrefs.SetFloat("movingSpeed", PlayerPrefs.GetFloat("movingSpeed") + speed);
			PlayerPrefs.SetFloat("jumpingPower", PlayerPrefs.GetFloat("jumpingPower") + jump);
			PlayerPrefs.SetFloat("pushingValue", PlayerPrefs.GetFloat("pushingValue") + pushingValue);

			textObject.SetActive (true);


			Destroy (gameObject.GetComponent<BoxCollider2D> ());

			//If there is no animator (so there is no animation)
			if (animator == null) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = null;
			} else {
				//Start the opening animation
				animator.SetBool ("opened", true);
			}

			startTime = true;


			//ADD SOUND EFFECT
		}



	}
		

}

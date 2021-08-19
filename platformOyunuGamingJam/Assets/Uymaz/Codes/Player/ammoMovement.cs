using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoMovement : MonoBehaviour {

	public float damageForPlayer = 10;
	public float damageForRobot = 20;


	//WE USE SAME CODES FOR BULLET OF ROBOT AND AMMO OF THE PLAYER
	//Collision

	void Update()
	{
		//Ammos will be destroyed after 1.5 sn from they will be made
		//Destroy (gameObject, 5f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//When it crushes the block etc
		if (other.tag == "ground") {

			Destroy (gameObject);
		}

		//WHEN CRUSHES WITH ROBOT
		if (other.tag == "robotBody" && gameObject.name == "ammoPlayer") {

			////////Write what you wanna do

			//Dont forget. Robot and player use same ammo. So we need to be sure the ammo doesnt belong the robot
			//if (gameObject.GetComponentInParent<GameObject> ().tag == "player") {
				Debug.Log ("ok");
				other.GetComponentInParent<robotCode> ().robotHealth -= damageForRobot;
				Destroy (gameObject);
			//}


		}

		//WHEN CRUSHES WITH PLAYER
		if (other.tag == "player" && gameObject.name == "robotBullet") {
		
			////////Write what you wanna do
			other.GetComponent<playerMovement>().playerHealth -= damageForPlayer;

			Destroy (gameObject);

		}

	}


}

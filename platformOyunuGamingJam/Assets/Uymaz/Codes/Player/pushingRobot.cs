using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushingRobot : MonoBehaviour {
	public float backImpulse = 0.001f;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "robotHeads") {

			GameObject.Find ("player").GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, backImpulse));

			//Damage
			other.GetComponentInParent<robotCode>().robotHealth -= PlayerPrefs.GetFloat("pushingValue");

			//Sound Effect : Pushing On Sound

		}
	}

}

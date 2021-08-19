using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {


	//Boundeds of the camera
	public float screenLeftLimit;
	public float screenRightLimit;
	public float screenUpLimit;
	public float screenDownLimit;

	//Camera speed
	public float cameraSpeed;

	//Player
	public GameObject player;

	//Distance between camera and the player
	public float distanceHorizontal;
	public float distanceVertical;

	//Son level
	public bool lastLevel;

	// Use this for initialization
	void Awake(){
		if (lastLevel == true) {
			Time.timeScale = 0;
		}
	}

	void Start () {

		gameObject.GetComponent<AudioSource> ().time = PlayerPrefs.GetFloat ("musicTime");

	}
	
	// Update is called once per frame
	void Update () {

		//Horizontal Movement
		if (gameObject.transform.position.x - player.transform.position.x < distanceHorizontal - 0.02f && gameObject.transform.position.x < screenRightLimit && player.transform.eulerAngles.y == 0) {
			gameObject.transform.position += new Vector3 (cameraSpeed, 0, 0);

			//Check the camera's position's x.
			if (gameObject.transform.position.x >= screenRightLimit) {
				gameObject.transform.position = new Vector3 (screenRightLimit, gameObject.transform.position.y, gameObject.transform.position.z);
			}

		} 
		else if (gameObject.transform.position.x - player.transform.position.x > -distanceHorizontal /* (-1f*distanceHorizontal*2f)*/ + 0.02f && gameObject.transform.position.x > screenLeftLimit && player.transform.eulerAngles.y == 180) {
			gameObject.transform.position -= new Vector3 (cameraSpeed, 0, 0);

			//Check the camera's position's x.
			if (gameObject.transform.position.x <= screenLeftLimit) {
				gameObject.transform.position = new Vector3 (screenLeftLimit, gameObject.transform.position.y, gameObject.transform.position.z);
			}

		}

		//Vertical Movement

		if (gameObject.transform.position.y - player.transform.position.y < distanceVertical - 0.02f && gameObject.transform.position.y < screenUpLimit) {
			gameObject.transform.position += new Vector3 (0, cameraSpeed, 0);


			//Check the camera's position's x.
			if (gameObject.transform.position.y >= screenUpLimit) {
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, screenUpLimit, gameObject.transform.position.z);
			}
		}
		 if (gameObject.transform.position.y - player.transform.position.y > -distanceVertical*2f /*(-1f*distanceVertical*1.2f)*/  + 0.02f && gameObject.transform.position.y > screenDownLimit) {
			gameObject.transform.position -= new Vector3 (0, cameraSpeed, 0);

			//Check the camera's position's x.
			if (gameObject.transform.position.y <= screenDownLimit) {
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, screenDownLimit, gameObject.transform.position.z);
			}

		}



		



	}
}

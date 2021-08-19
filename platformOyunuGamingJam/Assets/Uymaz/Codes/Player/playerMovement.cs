using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	//Initial Values
	public float movingSpeed;
	public float jumpingPower;
	public float pushingValue;

	public Transform pushingObjectTransform;

	//Components
	Rigidbody2D playerRB;
	Animator animator;

	//Ammo
	public GameObject ammo;
	public float ammoSpeed;
	public Transform muzzle;
	public float canShoot; //We need to wait for we can shoot again
	public float waitingForShooting;

	//Health
	public float playerHealth = 100;

	//Restart Button
	public GameObject restart;


	//Tired
	/*
	public float currentTired = 0;
	public float changinCurrentTired = 0.05f; //We increase or decrease the currentTired. And currentTired can be equal to currentValue, or not.
	public float decreasingSpeed = 0.0001f;
	public GameObject heart; 
	public int increasingHeartSpeed = 1;
	public bool playerTired = false; //When player is tired, he cant go. HE CANT RUN, HE CANT FIRE, HE CANT JUMP
*/
	// Use this for initialization
	void Start () {
		//DELETE THESE LINES! (LATER)
		PlayerPrefs.SetFloat("movingSpeed", 1.5f);
		PlayerPrefs.SetFloat("jumpingPower", 3f);
		PlayerPrefs.SetFloat("pushingValue", 30);


		//Rigidbody
		playerRB = gameObject.GetComponent<Rigidbody2D>();

		//Animator
		animator = gameObject.GetComponent<Animator>();


		  //Player prefs' names are same with their public values
		movingSpeed = PlayerPrefs.GetFloat("movingSpeed");
		jumpingPower = PlayerPrefs.GetFloat ("jumpingPower");
		pushingValue = PlayerPrefs.GetFloat ("pushingValue");

	}
	
	// Update is called once per frame
	void Update () {

		//DONT FORGET TO ADD RUN ANIMATION!

		//Moving right
		if (Input.GetKey (KeyCode.D)) {
			//Velocit
			playerRB.velocity = new Vector2 (movingSpeed, playerRB.velocity.y);
			//playerRB.AddForce(new Vector2(movingSpeed, 0), ForceMode2D.Impulse);


			//If we look at left, we need to look at right
			if (gameObject.transform.eulerAngles.y != 0) {
				gameObject.transform.eulerAngles = new Vector3 (0, 0, 0);

			}
				
			//Animation: Movement
			animator.SetBool("IdleRunning", true);
		}


		//DONT FORGET TO ADD RUN ANIMATION!

		//Moving left
			if(Input.GetKey(KeyCode.A))
		{
			//Velocit
			playerRB.velocity = new Vector2(-movingSpeed,playerRB.velocity.y);
			//playerRB.AddForce(new Vector2(-movingSpeed, 0), ForceMode2D.Impulse);

			//If we look at right, we need to look at left
			if (gameObject.transform.eulerAngles.y != 180) {
				gameObject.transform.eulerAngles = new Vector3(0,180,0);
			}
				
			//Animation: Movement
			animator.SetBool("IdleRunning", true);
		}

		//We may be able to write code for after shooting when we run
		if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {

		}


		//Animation Stopping: Movement
		if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
			animator.SetBool ("IdleRunning", false);
		}



		//Firing
			if (Input.GetKeyDown (KeyCode.Space) && canShoot <= 0) {

			//If the player looks at right
			if (gameObject.transform.eulerAngles.y == 0) {

				//Animation for shooting
				animator.SetBool("IdleShooting", true);

				GameObject newAmmo =  Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
			//	newAmmo.GetComponent<GameObject>().name = "ammoPlayer";
				newAmmo.name = "ammoPlayer";
				Rigidbody2D ammoRB = newAmmo.GetComponent<Rigidbody2D> ();

				if(transform.localScale.x == 1)
					newAmmo.transform.localScale /= 2f;


				//The ammo will be pushed
				ammoRB.AddForce(new Vector2(ammoSpeed, 0), ForceMode2D.Impulse); 



				//Waiting for shooting
				canShoot = waitingForShooting;

			}

			//If the player looks at right
			if (gameObject.transform.eulerAngles.y == 180) {
				
				GameObject newAmmo =  Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
				Rigidbody2D ammoRB = newAmmo.GetComponent<Rigidbody2D> ();

				//The ammo will be pushed
				ammoRB.AddForce(new Vector2(-ammoSpeed, 0), ForceMode2D.Impulse); 

				//Waiting for shooting
				canShoot = waitingForShooting;

			}
		}

		//Firing: Decreasing waiting time for we can shoot again
		if (canShoot > 0) {
			canShoot -= 0.1f;
		}

		//Animation stopping: Shooting
		if(!Input.GetKey(KeyCode.Space) && GameObject.Find("ammoPlayer") == null){
			animator.SetBool("IdleShooting", false);
		}


		//DEATH
		if (playerHealth <= 0) {

			animator.SetBool ("Death", true);

			restart.SetActive (true);

			Destroy (gameObject.GetComponent<Rigidbody2D> ());
			Destroy (gameObject, 1f);

			//ADD SOUND EFFECT
		
			//SHOW THE PANNEL

		}

		//To Jump
		if(Input.GetKeyDown(KeyCode.W))
		{
			//Check the ground
			if(Physics2D.Raycast(pushingObjectTransform.position, Vector2.down, 0.1f, 1 << 8))
			{
				Debug.Log("Jumping is working!");
				//We can jump
					//Animation: Jumping
					animator.SetBool("IdleJumping", true);

					playerRB.velocity += new Vector2 (0, jumpingPower);
			}
		}

	}
	/*
	void OnTriggerStay2D(Collider2D other)
	{
		//When we touches ground, we can jump
		if (other.tag == "ground") {

			//DONT FORGET TO ADD JUMP ANIMATION

			//We can jump
			if (Input.GetKeyDown (KeyCode.W)) {
				//Animation: Jumping
				animator.SetBool("IdleJumping", true);

				playerRB.velocity += new Vector2 (0, jumpingPower);
			}
		}
	}
	*/

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "ground") {
			animator.SetBool ("IdleJumping", false);
		}
	}
	

	/*
	void tiredFuntion()
	{
		//Tired value
		currentTired += changinCurrentTired; //Increase it

		//If it is half of the total currentTired
		if (currentTired >= tiredValue / 2) {
			if (movingSpeed >= 0) {
				movingSpeed -= decreasingSpeed;
			}
			if (movingSpeed <= 0) {
				movingSpeed = 0;
			}

		}

		//Heart Voice

		if (currentTired >= tiredValue * 4f / 5f) {

			if (heart.GetComponent<AudioSource> ().isPlaying == false) {
				heart.GetComponent<AudioSource> ().Play ();
			}
			heart.GetComponent<AudioSource> ().priority += 3* increasingHeartSpeed;

		} else if(currentTired < tiredValue * 4f/5f && heart.GetComponent<AudioSource>().isPlaying == true) {
			heart.GetComponent<AudioSource> ().Stop ();
		}

		//When the player is tired totaly
		if (currentTired >= tiredValue) {
			playerTired = true;
		}
	}*/

	/*
	void restingFunction()
	{
	//	Debug.Log ("Start To Rest");
		//When he has a rest
		currentTired -=  2f*changinCurrentTired;

		//Heart will be slowing
		if (currentTired <= tiredValue / 2) {
			heart.GetComponent<AudioSource> ().priority -= increasingHeartSpeed;
		}

		//When he rests completely
		if (currentTired <= 0) {
			
			playerTired = false;
			//Refresh the moving speed with same initial moving speed value
			movingSpeed = PlayerPrefs.GetFloat ("movingSpeed");
		}
	}
*/

}

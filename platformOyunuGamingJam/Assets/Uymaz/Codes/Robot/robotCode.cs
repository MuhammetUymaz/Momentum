using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;


public class robotCode : MonoBehaviour {
	
	//Speed
	public float speed;
	public GameObject leftLimitedObject;
	public GameObject rightLimitedObject;
	public float limitedTolerans;
	public float rightBorder;
	public float leftBorder;

	//Health
	public float robotHealth = 100;

	//Components
	Rigidbody2D rb;
	Animator animator;

	//Time for shooting (It is about firing of the robot)
	public float rightNow;
	public float targetTime = 1f;
	public bool shootingPeriodStart = false;

	//Firing
	public GameObject bullet;
	public float bulletSpeed = 5;
	public GameObject muzzle;

	//Time for waiting (This is about movement of the robot)
	public bool startTime = false;
	public float waitinglTime = 0;
	public float storeOfWaitingTime = 5f;
	public float decreasingTime = 0.1f;
	//public bool onceStartAnimation= false;

	// Use this for initialization
	void Start () {
		//Rigidbody
		rb = gameObject.GetComponent<Rigidbody2D>();
		//Animator
		animator = gameObject.GetComponent<Animator>();
		waitinglTime = storeOfWaitingTime;


		//The borders
		rightBorder = rightLimitedObject.transform.position.x;
		leftBorder = leftLimitedObject.transform.position.x;

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (animator.GetBool ("Walking"));

		//When the robot looks at right and he doenst wait
		if (gameObject.transform.eulerAngles.y == 0 && animator.GetBool("Walking") == true && animator.GetBool("Shooting") == false) {
			//gameObject.transform.position += new Vector3 (speed, 0, 0);
		//	Debug.Log("koşuyor");
			rb.velocity = new Vector2 (speed, rb.velocity.y);

		} else if (gameObject.transform.eulerAngles.y == 180 && animator.GetBool("Walking") == true && animator.GetBool("Shooting") == false) {
			rb.velocity = new Vector2 (-speed, 0);
		}

		//When the player moves right (direnction = 0) && the player's position.x is equal to or bigger than rightPolarPosition.x;
		if (gameObject.transform.eulerAngles.y == 0 && gameObject.transform.position.x + limitedTolerans >= rightBorder) {
			//	float distance = rightBorder - leftBorder;
			//	leftBorder = gameObject.transform.position.x - distance;

			//Setting the time
			if (waitinglTime >= storeOfWaitingTime)
			{

				startTime = true;
				waitinglTime = storeOfWaitingTime;
			}


			//Walking animation, The robot will rest
			animator.SetBool("Walking", false);

		}
		//When the player moves left (direnction = 1) && the player's position.x is equal to or smaller than leftPolarPosition.x;
		else if (gameObject.transform.eulerAngles.y == 180 && gameObject.transform.position.x - limitedTolerans <= leftBorder) {

			//float distance = leftBorder - rightBorder;
			//rightBorder = gameObject.transform.position.x - distance;

			//Setting the time
			if (waitinglTime >= storeOfWaitingTime)
			{

				startTime = true;
				waitinglTime = storeOfWaitingTime;
			}

			//Walking animation, The robot will rest
			animator.SetBool("Walking", false);

		}

		//Time codes
		if (startTime == true) {

			waitinglTime -= decreasingTime;
			if (waitinglTime <= 0) {
				waitinglTime = 0;
				startTime = false;
			}
		} else if (startTime == false && waitinglTime <= 0) {
			//Write what we wanna do
			if (gameObject.transform.eulerAngles.y == 0) {
				gameObject.transform.eulerAngles = new Vector3 (0, 180, 0); //We need to return, left
			} else if (gameObject.transform.eulerAngles.y == 180) {
				gameObject.transform.eulerAngles = new Vector3 (0, 0, 0); //We need to return, left
			}

			//Walking animation, The robot will walk
			waitinglTime = storeOfWaitingTime;
			animator.SetBool("Walking", true);

		}

		if (shootingPeriodStart == true) {



			//When time ups
			if ((rightNow + targetTime) - Time.time <= 0) {
				//What you wanna do

				//!!!WE wanna make a new bullet
				GameObject newBullet = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);

				if(transform.localScale.x < 0.16f)
					newBullet.transform.localScale /= 2f;

				Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D> ();
				if (gameObject.transform.eulerAngles.y == 0) {
					newBulletRB.AddForce (new Vector2 (bulletSpeed, 0), ForceMode2D.Impulse);
				}
				else if(gameObject.transform.eulerAngles.y == 180)
				{
					newBulletRB.AddForce (new Vector2 (-bulletSpeed, 0), ForceMode2D.Impulse);
				}
				//

				rightNow = Time.time; //Its loop

			}


		}

		//Death
		if (robotHealth <= 0) {
			animator.SetBool ("death", true);
			if (gameObject.name == "robotA") {
				Application.LoadLevel ("fifteenMinutesBefore");
			} else if (gameObject.name == "robotB") {
				Application.LoadLevel ("devamEdecek");
			}
			Destroy (gameObject, 1.3f);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "player") {
			animator.SetBool ("Shooting", true);
			shootingPeriodStart = true;
			rightNow = Time.time;

			//!!!WE wanna make a new bullet
			GameObject newBullet = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
			newBullet.name = "robotBullet";
			Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D> ();
			if (gameObject.transform.eulerAngles.y == 0) {
				newBulletRB.AddForce (new Vector2 (bulletSpeed, 0), ForceMode2D.Impulse);
			}
			else if(gameObject.transform.eulerAngles.y == 180)
			{
				newBulletRB.AddForce (new Vector2 (-bulletSpeed, 0), ForceMode2D.Impulse);
			}




		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "player") {
			animator.SetBool ("Shooting", false);
			shootingPeriodStart = false;
		}
			
	}



}

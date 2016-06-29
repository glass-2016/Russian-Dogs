using UnityEngine;
using System.Collections;

public class Pigeon : MonoBehaviour {

	//public float startwalkSpeed = 2.0f;
	//public float startwallLeft = 0.0f;
	//public float startwallRight = 5.0f;
	//public float startwalkingDirection = 1.0f;

	public float walkSpeed = 2.0f;
	public float wallLeft = 0.0f;
	public float wallRight = 5.0f;
	public float walkingDirection = 1.0f;

	public float _flight;
	public bool _groundAnimal;


	public Collider2D flightcollider;

	Vector3 walkAmount;

	void Start(){
		flightcollider = this.GetComponentInChildren<Collider2D> ();

		//walkSpeed = startwalkSpeed;
		//wallLeft = startwallLeft;
		//wallRight = startwallRight;
		//walkingDirection = startwalkingDirection;

	

	
	}

	// Update is called once per frame
	void Update () {

		if (walkSpeed > 0) {
			
			Animator pigeonanim = this.GetComponentInChildren<Animator> ();
			pigeonanim.SetBool ("isFlying", true);
		
		}

		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		if (walkingDirection > 0.0f && transform.position.x >= wallRight)
			walkingDirection = -1.0f;
		else if (walkingDirection < 0.0f && transform.position.x < wallLeft)
			walkingDirection = 1.0f;
		transform.Translate(walkAmount);

		CheckPlayerProximity ();

	}

	void OnTriggerStay (Collider other)
	{
	
		if (other.tag == "Player") {
			if (other.GetComponentInChildren<Bark> ()._bark) {

				Flee ();

			}
	
		}
	}

	void CheckPlayerProximity()
	{

		GameObject player = GameObject.FindWithTag ("Player");
		if (player == null)	return;

		Vector2 playerPos;
		playerPos.x = player.transform.position.x;
		playerPos.y = player.transform.position.y;

		if (flightcollider.OverlapPoint (playerPos)) 
		{
			Debug.Log ("You should flee, stupid pigeon");
			Flee ();
		}

	}

	void Flee()
	{
		AudioClip flight = Resources.Load ("pigeon_fly") as AudioClip;
		AudioSource audioflight = this.GetComponent<AudioSource> ();
		audioflight.clip = flight;
		audioflight.volume = 1f;
		audioflight.loop = false;
		audioflight.Play ();


		GetComponent<Rigidbody> ().useGravity = _groundAnimal;

		walkAmount.y = walkingDirection * walkSpeed * Time.deltaTime * _flight;

		walkSpeed = 15f;
		wallLeft = 500.0f;
		wallRight = 500.0f;
		walkingDirection = Random.Range (0f, 1f);

		Animator pigeonanim = this.GetComponentInChildren<Animator> ();
		pigeonanim.SetBool ("isFlying", true);
	}
}

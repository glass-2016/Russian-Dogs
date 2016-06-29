using UnityEngine;
using System.Collections;

public class EnemyDog : MonoBehaviour {



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

	Vector3 walkAmount;

	bool isGrowling;
	bool isFleeing = false;
	bool isEating = false;

	Collider2D lineofsight;
	SpriteRenderer enemydogsr;
	GameObject player;
	Animator enemydoganim;
	AudioSource growl;

	void Start(){
		growl = this.GetComponent<AudioSource> ();
		lineofsight = this.GetComponentInChildren<Collider2D> ();
		enemydogsr = this.GetComponentInChildren<SpriteRenderer> ();
		player = GameObject.FindWithTag ("Player");
		enemydoganim = this.GetComponentInChildren<Animator> (); 

		//walkSpeed = startwalkSpeed;
		//wallLeft = startwallLeft;
		//wallRight = startwallRight;
		//walkingDirection = startwalkingDirection;




	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("Is Eating :" + isEating);
		
		FoodCheck ();

		if (!isEating && !isFleeing) {
			PlayerCheck ();
			if (isGrowling) {
				Growl ();
			}
				else 
				{
					enemydoganim.SetBool ("isWait", false);
					growl.mute = true;
				}
		}
			

		if (!isGrowling) 
		{
			walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
			if (walkingDirection > 0.0f && transform.position.x >= wallRight) {
				walkingDirection = -1.0f;
				enemydogsr.flipX = true;
			} else if (walkingDirection < 0.0f && transform.position.x < wallLeft) {
				walkingDirection = 1.0f;
				enemydogsr.flipX = false;
			}
			transform.Translate (walkAmount);
		}

		if (isFleeing) 
		{
			Flee ();

		}


	}
		

	void Flee()
	{
		isFleeing = true;
		GetComponent<Rigidbody> ().useGravity = _groundAnimal;

		walkAmount.y = walkingDirection * walkSpeed * Time.deltaTime * _flight;

		walkSpeed = 10f;
		wallLeft = 500.0f;
		wallRight = 500.0f;

		if (this.transform.position.x > player.transform.position.x) {
			walkingDirection = 1;
			enemydogsr.flipX = false;
		} else 
		{
			Debug.Log ("Fuite vers la gauche");
			walkingDirection = -1;
			enemydogsr.flipX = true;
		}

	}

	void PlayerCheck()
	{

		if (player == null)	return;

		Vector2 playerPos;
		playerPos.x = player.transform.position.x;
		playerPos.y = player.transform.position.y;

		if (lineofsight.OverlapPoint (playerPos)) 
		{
			isGrowling = true;


			if (player.GetComponentInChildren<Bark> ()._bark) 
			{
				isGrowling = false;
				enemydoganim.SetBool ("isWait", false);
				growl.mute = true;
				this.GetComponent<Rigidbody> ().isKinematic = false;

				Flee ();

			}
		}

		else
		{
			enemydoganim.SetBool ("isWait", false);
			isGrowling = false;
			growl.mute = true;
			this.GetComponent<Rigidbody> ().isKinematic = false;
		}


	}

	void FoodCheck()
	{
		Transform itemContainer = GameObject.Find ("ItemContainer").GetComponent<Transform>();
		foreach (Transform item in itemContainer) 
		{
			Vector2 itemPos;
			itemPos.x = item.transform.position.x;
			itemPos.y = item.transform.position.y;


			if (lineofsight.OverlapPoint (itemPos)) 
			{
				Debug.Log ("Other dog sees object "+item.name);
				GameObject itemID = item.gameObject;
				bool edible = itemID.GetComponent<ObjectClass> ()._edible;
				if (edible = true) 
				{
					isEating = true;
					Eat (itemID);
				}
			}
		}



	}

	void Eat (GameObject item)
	{
		this.GetComponent<Rigidbody> ().isKinematic = true;
		if (item.transform.position.x > this.transform.position.x) 
		{
			walkingDirection = 1;
			enemydogsr.flipX = false;
			wallRight = item.transform.position.x+1f;
		}

		if (item.transform.position.x < this.transform.position.x) 
		{
			walkingDirection = -1;
			enemydogsr.flipX = true;
			wallLeft = item.transform.position.x-1f;
		}

		if (Mathf.RoundToInt(item.transform.position.x) == Mathf.RoundToInt(this.transform.position.x)) 
		{
			Debug.Log ("Ate that");
			Destroy (item);
			isEating = false;
			Flee ();
		}
	}

	void Growl()
	{
		if (player.transform.position.x > this.transform.position.x) {
			walkingDirection = 1;
			enemydogsr.flipX = false;
		} else if(player.transform.position.x < this.transform.position.x)
		{
			walkingDirection = -1;
			enemydogsr.flipX = true;
		}
		growl.mute = false;
		enemydoganim.SetBool ("isWait", true);
		this.GetComponent<Rigidbody> ().isKinematic = true;
		if (!growl.isPlaying) 
		{

			growl.Play ();

		}
	}
		

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarAnimations : MonoBehaviour 
{
	public GameObject PlayerSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		SpriteRenderer playersr = PlayerSprite.GetComponent<SpriteRenderer> ();
		Animator playeranim = PlayerSprite.GetComponent<Animator> ();

		//flipping the player sprite depending on direction
		if (Manager.player_direction == "left") 
		{

			playersr.flipX = true;

		} 
		else 
		{
			playersr.flipX = false;
		}

		//setting the wait animation
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
			playeranim.SetBool ("isWalking", true);
		} 
		else 
		{
			playeranim.SetBool ("isWalking", false);
		}

		if(AvatarMove.IsJumping)
		{
			playeranim.SetBool ("isJumping", true);
		}
		else
		{
			playeranim.SetBool ("isJumping", false);
		}

		playeranim.SetBool ("isCarrying", Manager.player_iscarrying);
	
	}
}

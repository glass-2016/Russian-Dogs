using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

	public static List<Sprite> s_iconsL = new List<Sprite>();
	public List<Sprite> _iconsL = new List<Sprite>();

	public static List<string> s_scentL= new List<string>();
	public List<string> _scentL = new List<string>();

	//reads the direction the player is facing and moving towards. Either "left" or "right".
	public static string player_direction;
	public static int player_platformlevel;
	public static bool player_iscarrying;

	public GameObject player;

	// Use this for initialization
	void Start () {

		s_iconsL = _iconsL;
		s_scentL = _scentL;
	
	}
	
	// Update is called once per frame
	void Update () {

		//Reading input direction to determine various data (camera position, player sprite, etc)
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
			float dir = Input.GetAxis ("Horizontal");
			if(dir <= 0)
			{
				player_direction = "left";
			}
			else
			{
				player_direction = "right";
			}
		}

		//reading the platform level on which the player is
		if (player == null)	return;

		if (player.transform.position.y < 0) 
		{
			player_platformlevel = 1;
		}

		if (player.transform.position.y >= 0 && player.transform.position.y < 3) 
		{
			player_platformlevel = 2;
		}

		if (player.transform.position.y >= 3) 
		{
			player_platformlevel = 3;
		}

		Debug.Log (player_platformlevel);
	
	}
}

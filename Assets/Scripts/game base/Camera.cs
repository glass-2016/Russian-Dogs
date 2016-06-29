using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	
	public GameObject camera;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)	return;

		var camPos = player.transform.position;
		camPos.z = -10;
		camPos.y = camPos.y + 3;

		//horizontal : camera flip to the left
		if (Manager.player_direction == "left") 
		{
			float xGoal = player.transform.position.x -4 ;
			camPos.x = Mathf.Lerp (camera.transform.position.x, xGoal, 0.04f);
		} 
		else 
			// horizontal : camera flip to the right
		{
			float xGoal = player.transform.position.x +4 ;
			camPos.x = Mathf.Lerp (camera.transform.position.x, xGoal, 0.04f);
		}

		switch (Manager.player_platformlevel) 
		{
		case 1:
			{
				float yGoal = 0;
				camPos.y = Mathf.Lerp (camera.transform.position.y, yGoal, 0.03f);
			}
			break;

		case 2:
			{
				float yGoal = player.transform.position.y;
				camPos.y = Mathf.Lerp (camera.transform.position.y, yGoal, 0.03f);
			}
			break;
		case 3:
			{
				float yGoal = player.transform.position.y - 2;
				camPos.y = Mathf.Lerp (camera.transform.position.y, yGoal, 0.03f);
			}
			break;

		default:
			break;
		}

		//mouvement final
		camera.transform.position = (camPos);


	} 
		
}

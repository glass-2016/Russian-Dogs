using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour 
{
	public static int lastlevel = 0;
	public string Scene;


	void Start()

	{
		Debug.Log (lastlevel);
		if (lastlevel > 0 & SceneManager.GetActiveScene ().name == "Level ") {
			GameObject.FindWithTag ("Player").transform.position = new Vector3 (38, -1, 0);
		}
	}
	void OnTriggerEnter (Collider other)
	{

		if (other.CompareTag ("Player")) 
		{
			Debug.Log ("Player here");
			SceneManager.LoadScene(Scene);
			lastlevel++;
		}


	}

}

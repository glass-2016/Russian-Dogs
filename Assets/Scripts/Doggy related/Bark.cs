using UnityEngine;
using System.Collections;

public class Bark : MonoBehaviour {

	public bool _bark;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E) && !GetComponent<PickUp> ()._baballe) {
		
			print ("WROUF! WROUF!");
			AudioClip bark = Resources.Load ("barking") as AudioClip;
			AudioSource audiobark = this.GetComponent<AudioSource> ();
			audiobark.clip = bark;
			audiobark.Play ();
			_bark = true;
		
		} else { 
			_bark = false;
		}
	
	}
}

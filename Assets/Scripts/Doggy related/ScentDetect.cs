using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScentDetect : MonoBehaviour {

	private Collider2D selfcollider;

	private bool isSmelling;

	public GameObject trail;
	public GameObject trailContainer;
	public Color trailColor;


	float trailTimer;

	// Use this for initialization
	void Start () 
	{
		this.selfcollider = this.GetComponentInChildren<Collider2D>();
		trail = Resources.Load<GameObject> ("ScentTrail");
		trailContainer = GameObject.Find ("ScentTrailContainer");
			

	}
	
	// Update is called once per frame
	void Update ()
	{
		//detecting overlap between object smell collider and player smell collider
		GameObject player = GameObject.FindWithTag ("Player");
		if (player == null)	return;

		Vector2 playerPos;
		playerPos.x = player.transform.position.x;
		playerPos.y = player.transform.position.y;

		Vector2 selfPos;
		selfPos.x = this.transform.position.x;
		selfPos.y = this.transform.position.y;

		if (this.selfcollider.OverlapPoint (playerPos)) {
			isSmelling = true;
		} else if (!this.selfcollider.OverlapPoint (playerPos))
		{
			isSmelling = false;
		}

		//smell trail
		if (isSmelling) {
			trailTimer = trailTimer + Time.deltaTime;

			if (trailTimer >= 1f) {
				trailTimer = 0;
				GameObject t = Instantiate (trail);
				Vector3 midPoint;
				midPoint.x = Mathf.Lerp (selfPos.x, playerPos.x, 0.75f);
				midPoint.y = Mathf.Lerp (selfPos.y, playerPos.y, 0.75f);
				midPoint.z = 0;

				t.name = ("Trail" + this.name);
				Debug.Log ("New trail " + t.name);
				t.transform.position = midPoint;
				t.transform.parent = trailContainer.transform;

				ParticleSystem parentparticles = this.GetComponent<ParticleSystem> ();
				ParticleSystem trailparticles = t.GetComponent<ParticleSystem> ();

				var colP = parentparticles.startColor;
				var colT = trailparticles.startColor;



				trailparticles.startColor = colP; 

			
			}
			


		}

		if (!isSmelling) {
			Destroy (GameObject.Find ("Trail" + this.name));
			Debug.Log ("Trail destroyed");

		}

		if (Mathf.RoundToInt(playerPos.x) == Mathf.RoundToInt(selfPos.x)) 
		{
			Destroy (GameObject.Find ("Trail" + this.name));
		}
			
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnNpc : MonoBehaviour {

	public float minX;
	public float minY;
	public float maxX;
	public float maxY;
	public float minW;
	public float maxW;
	public int _count;

	public GameObject _npc;

	public float chrono;

	public List<GameObject> NPCS = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	chrono = Random.Range (minW, maxW);
			
	}
	
	// Update is called once per frame
	void Update () {

		chrono -= Time.deltaTime;

		if (chrono <= 0  &&  NPCS.Count < _count) {

			GameObject newNPC = (GameObject)Instantiate (_npc, new Vector3 (Random.Range (minX, maxX), Random.Range (minY, maxY), 0), Quaternion.identity);
			NPCS.Add (newNPC);
			newNPC.transform.parent = GameObject.Find ("NPCs").transform;

			if (newNPC.name.Contains ("Pigeon")) {

				_npc.GetComponent<Pigeon> ().walkSpeed = Random.Range (0, 5);
				_npc.GetComponent<Pigeon> ().wallLeft = Random.Range (-50, 0);
				_npc.GetComponent<Pigeon> ().wallRight = Random.Range (0, 40);

			}
		 chrono = Random.Range (minW, maxW);
		}
	}
		
}

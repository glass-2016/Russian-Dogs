using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PickUp : MonoBehaviour {

	public bool _holding;
	public bool _baballe;
	public GameObject _pick;

	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {

		if (other.tag == "item" && _pick == null) {
			_pick = other.gameObject;
		}

		if (other.tag == "Enemy" && _baballe) 
		{
			Debug.Log ("I WILL TAKE YOUR FOOD");
			_pick.GetComponent<ObjectClass> ()._carried = false;
			//_pick.transform.parent = null;
			_pick.GetComponentInChildren<MeshRenderer> ().enabled = true;
			_pick = null;
			_baballe = false;
		}


	}

		void  Update () {

		Manager.player_iscarrying = _baballe;
		

		if (Input.GetKeyDown (KeyCode.R)) {

			_holding = !_holding;

					}

		if (_pick == null) {
			return;
		}
			if (_pick.GetComponent<ObjectClass> ()._pickable && _holding) {

				//_pick.transform.parent = this.transform;
				_pick.GetComponentInChildren<MeshRenderer> ().enabled = false;
				_baballe = true;
			// Manager.player_ispickup = true;
			_pick.GetComponent<ObjectClass> ()._carried = true;

			if (_pick.GetComponent<ObjectClass> ()._carried == true) {
				_pick.transform.position = new Vector3 (GameObject.FindWithTag ("Player").transform.position.x + 2.25f,GameObject.FindWithTag ("Player").transform.position.y, 0);


			}

			if (_pick.name == "Baballe") {

				_pick.GetComponent<SphereCollider> ().enabled = false;

			}



			//eating stuff
				if (Input.GetKey (KeyCode.E) && _pick.GetComponent<ObjectClass> ()._edible) {
				
					GetComponent<ObjectClass> ()._health += _pick.GetComponent<ObjectClass> ()._health;
					AudioClip eat = Resources.Load ("eat") as AudioClip;
					AudioSource audioeat = this.GetComponent<AudioSource> ();
					audioeat.clip = eat;
					audioeat.Play ();
					_pick.GetComponent<ScentInfo>()._icon.GetComponentInChildren<Image> ().enabled = false;
					Destroy (_pick);
					_pick = null;
					_holding = false;
					_baballe = false;

					}

		} else if(!_holding){
			_pick.GetComponent<ObjectClass> ()._carried = false;
				//_pick.transform.parent = null;
			if(_pick.GetComponentInChildren<MeshRenderer> () == null) return;
				_pick.GetComponentInChildren<MeshRenderer> ().enabled = true;

			if (_pick.name == "Baballe") {

				_pick.GetComponent<SphereCollider> ().enabled = true;


			}
				_pick = null;
				_baballe = false;



			}

	}
}
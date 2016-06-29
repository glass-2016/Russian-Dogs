using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScentInfo : MonoBehaviour {

	public GameObject _icon;


	void OnTriggerStay (Collider other) {

		if (other.tag == "Player") {
			
			for (int i = 0; i < Manager.s_scentL.Count; i++) {


				if (this.name == Manager.s_scentL [i]) {
					_icon.GetComponentInChildren<Image> ().enabled = true;
					_icon.GetComponentInChildren<Image> ().overrideSprite = Manager.s_iconsL[i] as Sprite;
				}

			}
					
		}
	
	}

	void OnTriggerExit (Collider other){
	
		if (other.tag == "Player") {
		
			_icon.GetComponentInChildren<Image> ().enabled = false;
		
		}
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public GameObject _doggy;
	public Text _text;

	bool fastWavesStarted = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (_doggy == null) {
			
			StartCoroutine (reBoot ());

			if(fastWavesStarted == false){
				
			StartCoroutine (reStart());
			fastWavesStarted = true;

			}
		
		}
	
	}

	IEnumerator reStart(){
		  

		_text.text = "Your Doggy went too hungry. Poor Doggy :c ";

		yield return new WaitForSeconds(5);

		_text.text = "Click anywhere to restart";




	}

	IEnumerator reBoot(){

		yield return new WaitForSeconds(4);
	
		if (Input.GetMouseButtonDown (0)) {

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}
	
	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hunger : MonoBehaviour {

	public float _start_chrono;
	public float _chrono;
	public Image _icon;
	public Color _color;

	private float _starthealth;

	// Use this for initialization
	void Start () {

		_chrono = _start_chrono;
		_starthealth = GetComponent<ObjectClass> ()._health;
	
	}
	
	// Update is called once per frame
	void Update () {

		_chrono -= Time.deltaTime;

		if (_chrono <= 0) {
			GetComponent<ObjectClass> ()._health -= 1;
			_chrono = _start_chrono;
		}

		if (GetComponent<ObjectClass> ()._health == 0) {
		
			Destroy (this.gameObject);
		
		}
		_color = new Color (1, 0, 0, ((25.5f * (_starthealth - GetComponent<ObjectClass> ()._health))/255));
		_icon.material.color = _color;
	
	}
}

using UnityEngine;
using System.Collections;


public class ObjectClass: MonoBehaviour {

	public string _name;

	public bool _edible;
	public bool _pickable;
	public bool _carried;

	public int _health;


	// Use this for initialization
	void Start ()
	{

		this.name = _name;
	
	}
}

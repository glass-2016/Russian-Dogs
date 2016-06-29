using UnityEngine;
using System.Collections;

public class Killzone : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		
		if (other.CompareTag ("Enemy") || other.CompareTag("Pigeon")) 
		{
			Destroy (other.gameObject);
		}
	}
}

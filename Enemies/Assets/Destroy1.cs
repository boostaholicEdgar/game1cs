using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy1 : MonoBehaviour 
{


	public GameObject explosion;
	void OnTriggerEnter(Collider other)
	{
		Instantiate (explosion, transform.position, transform.rotation);
		Debug.Log (other.name);
		Destroy (other.gameObject);
		Destroy (gameObject);

	}
}

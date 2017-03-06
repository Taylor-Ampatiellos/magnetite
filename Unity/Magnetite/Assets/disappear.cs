using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour {

	private void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Magnetic") { 
			Destroy (transform.gameObject);
		}
	}
}

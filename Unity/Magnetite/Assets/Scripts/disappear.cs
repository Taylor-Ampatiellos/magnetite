using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour {

	private void OnTriggerEnter (Collider collision)
	{
		if (collision.gameObject.tag == "Magnetic") { 
			//Magnetic magnet = collision.GetComponent<Magnetic> ();
			//magnet.SetPolarityOrDeactivate (true);
			Destroy (transform.gameObject);
		} /*else if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "MainCamera") { 
			Destroy (transform.gameObject);
		}*/
	}
}

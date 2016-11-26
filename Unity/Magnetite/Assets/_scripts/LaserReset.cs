using UnityEngine;
using System.Collections;

public class LaserReset : MonoBehaviour {

	Vector3 check;
		
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Laser") { //Or whatever
			transform.position = check;
		}

		if (other.gameObject.tag == "checkpoint") { //Or whatever
			check = other.transform.position;
		}
	}
}

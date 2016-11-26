using UnityEngine;
using System.Collections;

public class LaserReset : MonoBehaviour {

	// Use this for initialization

	
		void OnTriggerEnter(Collider other) {
			if(other.gameObject.tag == "Laser") { //Or whatever
				transform.position = new Vector3(-7, 8, -73);
			}

		}

	
}

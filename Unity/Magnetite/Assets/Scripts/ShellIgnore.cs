using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellIgnore : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Physics.IgnoreCollision (GetComponent<Collider> (), GetComponentInParent<Collider> ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

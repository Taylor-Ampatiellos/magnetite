using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{
	Vector3 grav;
	Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		grav = new Vector3 (0, -9.8f, 0);
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		rb.AddForce (grav);
	}
}


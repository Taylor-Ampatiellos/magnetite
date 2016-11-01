using UnityEngine;
using System.Collections;

public class Magnetic : MonoBehaviour
{
	public int magForce;

	public Material positive, negative;

	float m_Radius = 10;
	float m_Force = 0;
	const string MAGNETIC_FIELD = "Magnetic Field";

	public bool isPos = true;


	void OnTriggerStay (Collider other)
	{
		if (other.CompareTag (MAGNETIC_FIELD)) {
			Vector3 dir = other.transform.position - this.transform.position;
			//Debug.Log (dir);
			Vector3 force = (5 - dir.magnitude) * dir.normalized * magForce;

			bool otherIsPos = other.GetComponent<Magnetic> ().isPos;
			if (isPos ^ otherIsPos) {
				force *= -1;
			}
				
			//	Debug.Log (force);
			other.attachedRigidbody.AddForce (force);
		}
	}

	void FixedUpdate ()
	{
		GameObject parent = this.transform.parent.gameObject;
		if (parent != null) {
			parent.GetComponent<Renderer> ().material = (isPos ? positive : negative);
		}
	}
}
using UnityEngine;
using System.Collections;

public class MagneticField : MonoBehaviour
{
	const string MAGNETIC_FIELD = "Magnetic Field";
	public int magForce = 7;

	void OnTriggerStay (Collider other)
	{
		if (other.CompareTag (MAGNETIC_FIELD)) {
			Magnetic magnet = transform.parent.GetComponent<Magnetic> ();
			Magnetic otherMagnet = other.transform.parent.GetComponent<Magnetic> ();

			if (magnet.IsActive && otherMagnet.IsActive) {
				Vector3 dir = other.transform.position - this.transform.position;
				Vector3 force = (5 - dir.magnitude) * dir.normalized * magForce;

				if (!magnet.SamePolarityAs (otherMagnet)) {
					force *= -1;
				}

				other.attachedRigidbody.AddForce (force);
			}
		}
	}
}

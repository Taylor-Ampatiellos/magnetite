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
				Vector3 dir, force;
				BoxCollider bc = GetComponent<BoxCollider> ();
				if (bc != null) {
					float ax = Mathf.Abs (bc.size.x);
					float ay = Mathf.Abs (bc.size.y);
					float az = Mathf.Abs (bc.size.z);

					if (ax < ay && ax < az) { // x is smallest
						dir = new Vector3 (bc.size.x, 0, 0);
					} else if (ay < az) { // y is smallest
						dir = new Vector3 (0, bc.size.y, 0);
					} else { // z is smallest
						dir = new Vector3 (0, 0, bc.size.z);
					}
				} else {
					dir = other.transform.position - this.transform.position;
				}

				force = (5 - dir.magnitude) * dir.normalized * magForce;

				if (!magnet.SamePolarityAs (otherMagnet)) {
					force *= -1;
				}

				other.attachedRigidbody.AddForce (force);
			}
		}
	}
}

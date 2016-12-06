using UnityEngine;
using System.Collections;

public class MagneticField : MonoBehaviour
{
	const string MAGNETIC_FIELD = "Magnetic Field";
	public int magForce = 7;

	void OnTriggerStay (Collider other)
	{
		if (other.CompareTag (MAGNETIC_FIELD) && other.attachedRigidbody != null) {
			Magnetic magnet = transform.parent.GetComponent<Magnetic> ();
			Magnetic otherMagnet = other.transform.parent.GetComponent<Magnetic> ();

			if (magnet.IsActive && otherMagnet.IsActive) {
				Vector3 dir, force;
				BoxCollider bc = GetComponent<BoxCollider> ();

				dir = other.transform.position - this.transform.position;
				if (bc != null) {
					float ax = Mathf.Abs (magnet.transform.lossyScale.x);
					float ay = Mathf.Abs (magnet.transform.lossyScale.y);
					float az = Mathf.Abs (magnet.transform.lossyScale.z);

					float mag = Mathf.Abs (dir.magnitude);
					if (ax < ay && ax < az) { // x is smallest
						mag = other.transform.position.x - this.transform.position.x;
						dir = new Vector3 (mag, 0, 0);
					} else if (ay < az) { // y is smallest
						mag = other.transform.position.y - this.transform.position.y;
						dir = new Vector3 (0, mag, 0);
					} else { // z is smallest
						mag = other.transform.position.z - this.transform.position.z;
						dir = new Vector3 (0, 0, mag);
					}
				}
				//Debug.DrawRay (magnet.transform.position, dir);

				force = (Mathf.Abs (6 - dir.magnitude)) * dir.normalized * magForce;

				if (!magnet.SamePolarityAs (otherMagnet)) {
					force *= -1;
				}

				if (other.attachedRigidbody != null) { 
					other.attachedRigidbody.AddForce (force);
				} else {
					Debug.LogError ("Magnetic field " + other.name + " with parent " + other.transform.parent.name + " does not have a magnet");
				}
			}
		}
	}
}

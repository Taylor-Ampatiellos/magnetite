using UnityEngine;
using System.Collections;

public class ShootWeapon : MonoBehaviour
{
	void Update ()
	{
		RaycastHit hit;
		Debug.DrawRay (transform.position, transform.forward * 35);

		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast (transform.position, transform.forward, out hit, 35)) {
				if (hit.transform.tag == "Magnetic") {
					Magnetic child = hit.transform.GetChild (0).gameObject.GetComponent<Magnetic> ();
					child.isPos = !child.isPos;
				}
			}
		}
	}
}
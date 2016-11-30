using UnityEngine;
using System.Collections;

public class emitlaser : MonoBehaviour {

	public float weaponRange = 50f;
	public Transform gunEnd;

	private LineRenderer laserLine;

	void Start () {
		laserLine = GetComponent<LineRenderer> ();
	}

	void Update () {
			Vector3 rayOrigin = new Vector3 (5, 5, 5);
			RaycastHit hit;

			laserLine.SetPosition (0, gunEnd.position);

			if (Physics.Raycast (rayOrigin, transform.forward, out hit, weaponRange)) {
				laserLine.SetPosition (1, hit.point);
			} else {
				laserLine.SetPosition (1, rayOrigin + (transform.forward * weaponRange));
			}
	}
}
﻿using UnityEngine;
using System.Collections;

public class ShootJustRed : MonoBehaviour
{
	void Update ()
	{
		RaycastHit hit;
		Debug.DrawRay (transform.position, transform.forward * 35);

		if (Input.GetMouseButtonDown (1)) {
			if (Physics.Raycast (transform.position, transform.forward, out hit, 35)) {
				Magnetic magnet = hit.transform.gameObject.GetComponent<Magnetic> ();
				if (magnet != null) {
					magnet.SetPolarityOrDeactivate (false);
				}
			}
		}
	}
}
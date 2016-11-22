using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class ShootWeapon : MonoBehaviour
{
	public bool canShootBlue = true;
	public bool canShootRed = true;

	public AudioClip blueSound;
	public AudioClip redSound;
	public AudioClip deactivateSound;

	void Update ()
	{
		RaycastHit hit;
		Debug.DrawRay (transform.position, transform.forward * 35);

		if (Input.GetMouseButtonDown (0) && canShootBlue) {
			if (Physics.Raycast (transform.position, transform.forward, out hit, 35)) {
				Magnetic magnet = hit.transform.gameObject.GetComponent<Magnetic> ();
				if (magnet != null) {
					if (magnet.SetPolarityOrDeactivate (true)) {
						PlaySound (blueSound);
					} else {
						PlaySound (deactivateSound);
					}

				}
			}
		} else if (Input.GetMouseButtonDown (1) && canShootRed) {
			if (Physics.Raycast (transform.position, transform.forward, out hit, 35)) {
				Magnetic magnet = hit.transform.gameObject.GetComponent<Magnetic> ();
				if (magnet != null) {
					if (magnet.SetPolarityOrDeactivate (false)) {
						PlaySound (redSound);
					} else {
						PlaySound (deactivateSound);
					}
				}
			}
		}
	}

	void PlaySound (AudioClip sound)
	{
		AudioSource audioSource = GetComponentInParent<FirstPersonController> ().freeAudioSource ();
		audioSource.clip = sound;
		audioSource.Play ();
	}
}
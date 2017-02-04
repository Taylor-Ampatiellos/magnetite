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

	public changeImage change;

	void Update ()
	{
		int mask = 1 << 8;
		mask = ~mask;
		RaycastHit hit;
		Debug.DrawRay (transform.position, transform.forward * 50);

		if (Physics.Raycast (transform.position, transform.forward, out hit, 50, mask)) {
			Magnetic magnet = hit.transform.gameObject.GetComponent<Magnetic> ();
			notChangable cantchange = hit.transform.gameObject.GetComponent<notChangable> ();
			if (magnet != null && cantchange == null) {
				change.SetImage1 ();
				if (Input.GetMouseButtonDown (0) && canShootBlue) {
					if (magnet.SetPolarityOrDeactivate (true)) {
						PlaySound (blueSound);
					} else {
						PlaySound (deactivateSound);
					}
				} else if (Input.GetMouseButtonDown (1) && canShootRed) {
					if (magnet.SetPolarityOrDeactivate (false)) {
						PlaySound (redSound);
					} else {
						PlaySound (deactivateSound);
					}
				}
			} else {
				change.SetImage2 ();
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
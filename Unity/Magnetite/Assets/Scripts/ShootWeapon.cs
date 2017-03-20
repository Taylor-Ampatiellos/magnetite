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

	//private Camera fpsCam;   
	private LineRenderer laserLine;
	private WaitForSeconds shotDuration = new WaitForSeconds(2.00f);
	public Transform gunEnd;

	public GameObject projectileB;
	public GameObject projectileR;
	public Transform Spawnpoint;
	public int speed;

	void Start () 
	{
		laserLine = GetComponent<LineRenderer>();
		//fpsCam = GetComponentInParent<Camera>();
	}

	void Update ()
	{
		int mask = 1 << 8;
		mask = ~mask;
		RaycastHit hit;
		Debug.DrawRay (transform.position, transform.forward * 30);

		if (Physics.Raycast (transform.position, transform.forward, out hit, 55, mask)) {
			float dist = Vector3.Distance(Spawnpoint.position, hit.point);
			Magnetic magnet = hit.transform.gameObject.GetComponent<Magnetic> ();
			notChangable cantchange = hit.transform.gameObject.GetComponent<notChangable> ();
			if (magnet != null && cantchange == null) {
				change.SetImage1 ();
				if (Input.GetMouseButtonDown (0) && canShootBlue) {
					StartCoroutine (ShotEffectB (magnet, dist));

				} else if (Input.GetMouseButtonDown (1) && canShootRed) {
					StartCoroutine (ShotEffectR (magnet, dist));

				}
			} else {
				change.SetImage2 ();
			}
		}

		if (Physics.Raycast (transform.position, transform.forward, out hit, 55, mask)) {
			float dist = Vector3.Distance (Spawnpoint.position, hit.point);

			if (Input.GetMouseButtonDown (0) && canShootBlue) {
				GameObject newproj = Instantiate (projectileB, Spawnpoint.position, Spawnpoint.rotation) as GameObject;
				newproj.GetComponent<Rigidbody> ().velocity = (hit.point - transform.position).normalized * 55;
				StartCoroutine (des (dist, newproj));
			}

			if (Input.GetMouseButtonDown (1) && canShootRed) {
				GameObject newproj = Instantiate (projectileR, Spawnpoint.position, Spawnpoint.rotation) as GameObject;
				newproj.GetComponent<Rigidbody> ().velocity = (hit.point - transform.position).normalized * 55;
				StartCoroutine (des (dist, newproj));
			}
		}
	}

	private IEnumerator ShotEffectB(Magnetic magnet, float dist)
	{
		yield return new WaitForSeconds(dist/speed);
		if (magnet.SetPolarityOrDeactivate (true)) {
			PlaySound (blueSound);
		} else {
			PlaySound (deactivateSound);
		}
	}

	private IEnumerator ShotEffectR(Magnetic magnet, float dist)
	{
		yield return new WaitForSeconds(dist/speed);
		if (magnet.SetPolarityOrDeactivate (false)) {
			PlaySound (redSound);
		} else {
			PlaySound (deactivateSound);
		}
	}

	private IEnumerator des(float dist, GameObject proj)
	{
		yield return new WaitForSeconds(dist/speed);
		Destroy (proj);
	}

	void PlaySound (AudioClip sound)
	{
		AudioSource audioSource = GetComponentInParent<FirstPersonController> ().freeAudioSource ();
		audioSource.clip = sound;
		audioSource.Play ();
	}
}


// LASER BEAM //

/*void LateUpdate ()
	{


		if (Input.GetButtonDown("Fire1")) 
		{

			StartCoroutine (ShotEffect());

			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

			RaycastHit hit2;

			laserLine.SetPosition (0, gunEnd.position);

			if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit2, 100))
			{
				laserLine.SetPosition (1, hit2.point);
			}
			else
			{
				laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * 100));
			}
		}
	}*/
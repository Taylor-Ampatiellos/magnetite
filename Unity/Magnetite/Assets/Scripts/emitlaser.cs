using UnityEngine;
using System.Collections;

public class emitlaser : MonoBehaviour {

	public float weaponRange = 50f;
	public Transform gunEnd;

	private LineRenderer laserLine;

	LaserReset player;

	void Start () {
		laserLine = GetComponent<LineRenderer> ();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<LaserReset>();
	}

	void Update () {
			int mask = 1 << 8;
			mask = ~mask;
			Vector3 rayOrigin = transform.position;
			RaycastHit hit;

			laserLine.SetPosition (0, gunEnd.position);

			if (Physics.Raycast (rayOrigin, transform.forward, out hit, weaponRange, mask)) {
			if (hit.transform.tag == "Player") { 
				player.Reset ();
			}

				laserLine.SetPosition (1, hit.point);
			} else {
				laserLine.SetPosition (1, rayOrigin + (transform.forward * weaponRange));
			}
	}
}
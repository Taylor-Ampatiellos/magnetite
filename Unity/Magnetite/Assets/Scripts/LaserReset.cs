using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LaserReset : MonoBehaviour {

	GameObject pos;
	Collider collider = null;
	float plat_x;
	float plat_z;
	float plat_change_x;
	float plat_change_z;

	void Start() {
		pos = GameObject.FindGameObjectWithTag("PlayerPosition");
		transform.position = pos.GetComponent<playerposition> ().spawn;
		transform.localEulerAngles = pos.GetComponent<playerposition> ().rotation;
		pos.GetComponent<playerposition> ().spawn = transform.position;
		pos.GetComponent<playerposition> ().rotation = transform.localEulerAngles;
	}

	/*void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Magnetic") { 
			Debug.Log ("ERERE");
			other.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
		}
	}*/

	void OnTriggerEnter(Collider other) {
		DontDestroyOnLoad (pos);

		if (other.gameObject.tag == "Laser") { 
			Scene scene = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (scene.name);
			collider = other;
		}

		if (other.gameObject.tag == "checkpoint") { 
			Debug.Log ("TEST");
			Destroy(GameObject.FindGameObjectWithTag ("text"));
			pos.GetComponent<playerposition> ().spawn = other.transform.position;
			collider = other;
		}

		if (other.gameObject.tag == "Platform") { 
			collider = other;
			plat_x = other.transform.position.x;
			plat_z = other.transform.position.z;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Platform") {
			collider = null;
		}
	}

	void Update() {
		if (collider != null) {
			if (collider.gameObject.tag == "Platform") { 
				plat_change_x = collider.transform.position.x - plat_x;
				plat_change_z = collider.transform.position.z - plat_z;

				transform.position = new Vector3 (transform.position.x + plat_change_x, transform.position.y, transform.position.z + plat_change_z);

				plat_x = collider.transform.position.x;
				plat_z = collider.transform.position.z;

			}
		}
	}

	public void Reset() {
		DontDestroyOnLoad (pos);
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}
}

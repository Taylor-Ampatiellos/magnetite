using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LaserReset : MonoBehaviour {

	GameObject pos;

	void Start() {
		pos = GameObject.FindGameObjectWithTag("PlayerPosition");
		transform.position = pos.GetComponent<playerposition> ().check;
	}

	void OnTriggerEnter(Collider other) {
		DontDestroyOnLoad (pos);

		if (other.gameObject.tag == "Laser") { //Or whatever
			transform.position = pos.GetComponent<playerposition> ().check;
			Scene scene = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (scene.name);
		}

		if (other.gameObject.tag == "checkpoint") { //Or whatever
			pos.GetComponent<playerposition> ().check = other.transform.position;
		}
	}
}

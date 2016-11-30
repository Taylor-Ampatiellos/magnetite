﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LaserReset : MonoBehaviour {

	GameObject pos;

	void Start() {
		pos = GameObject.FindGameObjectWithTag("PlayerPosition");
		transform.position = pos.GetComponent<playerposition> ().spawn;
		pos.GetComponent<playerposition> ().spawn = transform.position;
	}

	void OnTriggerEnter(Collider other) {
		DontDestroyOnLoad (pos);

		if (other.gameObject.tag == "Laser") { 
			Scene scene = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (scene.name);
		}

		if (other.gameObject.tag == "checkpoint") { 
			pos.GetComponent<playerposition> ().spawn = other.transform.position;
		}
	}
}

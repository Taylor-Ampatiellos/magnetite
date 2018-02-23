using UnityEngine;
using System.Collections;

// Script attached to buttons
// Controls opening of doors
public class DoorController : MonoBehaviour
{

	public GameObject Door;
	public GameObject Button;
	public bool IsOpening;

	[HideInInspector]
	public AudioSource buttonAudioSource;
	public AudioSource doorAudioSource;

	void Update ()
	{
		if (IsOpening == true) {
			Door.transform.Translate (Vector3.up * Time.deltaTime/9 * 10);
		}
		if (Door.transform.position.y > 7.5f) {
			IsOpening = false; 
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "Magnetic") {
			IsOpening = true;
			Door.GetComponent<AudioSource>().Play ();
			Button.GetComponent<AudioSource>().Play ();
		}
	}
}
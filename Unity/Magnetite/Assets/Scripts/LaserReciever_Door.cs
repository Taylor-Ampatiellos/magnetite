using UnityEngine;
using System.Collections;

public class LaserReciever_Door : MonoBehaviour
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

	public void OpenDoor ()
	{
		IsOpening = true;
		Door.GetComponent<AudioSource> ().Play ();
		Button.GetComponent<AudioSource> ().Play ();
		
	}
}
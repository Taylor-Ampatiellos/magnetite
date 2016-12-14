using UnityEngine;
using System.Collections;

public class DoorSounds : MonoBehaviour
{

	public AudioClip buttonSound;
	public AudioClip doorSound;

	void Start ()
	{
		DoorController[] dcs = FindObjectsOfType (typeof(DoorController)) as DoorController[];
		foreach (DoorController dc in dcs) {
			dc.buttonAudioSource = dc.gameObject.AddComponent<AudioSource> ();
			dc.buttonAudioSource.clip = buttonSound;

			dc.doorAudioSource = dc.gameObject.AddComponent<AudioSource> ();
			dc.doorAudioSource.clip = doorSound;
		}
	}
}

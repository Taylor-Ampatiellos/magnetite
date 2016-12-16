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
			dc.doorAudioSource = dc.gameObject.AddComponent<AudioSource> ();
			dc.doorAudioSource.clip = buttonSound;

			dc.doorAudioSource = dc.gameObject.AddComponent<AudioSource> ();
			dc.doorAudioSource.clip = doorSound;
		}
	}
}

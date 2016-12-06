using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
	public string targetLevelName;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			SceneManager.LoadScene (targetLevelName);
			Scene s = SceneManager.GetSceneByName (targetLevelName);
			playerposition pos = GameObject.FindGameObjectWithTag ("PlayerPosition").GetComponent<playerposition> ();
			pos.spawn = new Vector3 (0, 0, 6);
			SceneManager.SetActiveScene (s);
		}
	}

}

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
			pos.spawn = new Vector3 (other.transform.position.x + 32.36f, other.transform.position.y - 5.44f, other.transform.position.z + 154.97f);
			pos.rotation = new Vector3 (other.transform.localEulerAngles.x, other.transform.localEulerAngles.y, other.transform.localEulerAngles.z);
			SceneManager.SetActiveScene (s);
		}
	}

}

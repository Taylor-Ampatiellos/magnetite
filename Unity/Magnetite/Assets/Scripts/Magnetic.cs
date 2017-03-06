using UnityEngine;
using System.Collections;

public class Magnetic : MonoBehaviour
{
	[Header ("Properties")]
	public bool IsPositive = true;
	public bool IsActive = true;

	[Header ("Materials")]
	public Material Positive;
	public Material Negative;
	public Material Inactive;

	void Start ()
	{
		updateMaterial ();
	}

	void updateMaterial ()
	{
		Material newMaterial = Inactive;
		if (IsActive) {
			newMaterial = (IsPositive ? Positive : Negative);
		}
		GetComponent<Renderer> ().material = newMaterial;
	}

	/*private void OnTriggerEnter (Collider collision)
	{
		if (collision.gameObject.tag == "pbullet") {
			SetPolarityOrDeactivate (true);
			Destroy (collision.gameObject);
		}
	}*/

	public bool SamePolarityAs (Magnetic other)
	{
		return IsPositive == other.IsPositive;
	}

	public bool TogglePolarity ()
	{
		IsPositive = !IsPositive;
		updateMaterial ();
		return IsPositive;
	}

	public void Deactivate ()
	{
		IsActive = false;
		updateMaterial ();
	}

	public void Activate ()
	{
		IsActive = true;
		updateMaterial ();
	}

	// returns true  if polarity was set
	//         false if magnet was deactivated
	public bool SetPolarityOrDeactivate (bool polarity)
	{
		bool settingPolarity = IsPositive != polarity;
		if (settingPolarity) {
			IsPositive = polarity;
			IsActive = true;
		} else {
			if (IsActive) {
				IsActive = false;
			} else {
				IsActive = true;
				settingPolarity = true;
			}
		}
		updateMaterial ();
		return settingPolarity;
	}
}
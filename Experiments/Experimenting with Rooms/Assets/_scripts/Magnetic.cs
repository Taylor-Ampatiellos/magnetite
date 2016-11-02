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

	// returns true  if polarity was set
	//         false if magnet was deactivated
	public bool SetPolarityOrDeactivate (bool polarity)
	{
		bool settingPolarity = IsPositive != polarity;
		if (settingPolarity) {
			IsPositive = polarity;
			IsActive = true;
		} else {
			IsActive = !IsActive;
		}
		updateMaterial ();
		return settingPolarity;
	}
}
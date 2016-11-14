using UnityEngine;
using System.Collections;

public class FieldRenderer : MonoBehaviour
{
	public bool RenderMagneticFields = false;

	void Start ()
	{
		updateMeshRenderers ();
	}

	void OnGUI ()
	{
		updateMeshRenderers ();
	}

	private void updateMeshRenderers ()
	{
		MagneticField[] fields = FindObjectsOfType (typeof(MagneticField)) as MagneticField[];
		foreach (MagneticField field in fields) {
			field.gameObject.GetComponent<MeshRenderer> ().enabled = RenderMagneticFields;
		}
	}
}

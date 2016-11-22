using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public GameObject Door;
	public bool IsOpening;

	void Update(){
		if(IsOpening == true){
			Door.transform.Translate(Vector3.up*Time.deltaTime*10);
		}
		if(Door.transform.position.y > 10f){
			IsOpening = false; 
		}
	}
	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "Magnetic")
			IsOpening = true;
	}    
}
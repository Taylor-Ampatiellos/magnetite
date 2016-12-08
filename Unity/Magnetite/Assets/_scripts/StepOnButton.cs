using UnityEngine;
using System.Collections;

public class StepOnButton : MonoBehaviour {

	public GameObject Door;
	public bool IsOpening;

	void Update(){
		if(IsOpening == true){
			Door.transform.Translate(Vector3.down*Time.deltaTime*20);
		}
		if(Door.transform.position.y > 300){
			IsOpening = false; 
		}
	}
	void OnTriggerEnter (Collider collider)
	{
		if(collider.gameObject.tag == "Player") {
			IsOpening = true;
	}    

}
}

using UnityEngine;
using System.Collections;

public class DownAndUp : MonoBehaviour {

	public float delta = 5f;  // Amount to move left and right from the start point
	    public float speed = 0.7f; 
	    private Vector3 startPos;

	    void Start () {
		        startPos = transform.position;
		    }

	    void Update () {
		        Vector3 v = startPos;
		        v.y += delta * Mathf.Sin (Time.time * speed);
		        transform.position = v;
		    }
} 

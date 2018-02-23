using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeImage : MonoBehaviour {

	Image myImageComponent;
	public Sprite myFirstImage; //Drag your first sprite here in inspector.
	public Sprite mySecondImage; //Drag your second sprite here in inspector.

	RaycastHit hit;

	void Start() //Let's start by getting a reference to our image component.
	{
		myImageComponent = GetComponent<Image>(); // Our image component is the one attached to this gameObject.
	}

	public void SetImage1() //method to set our first image
	{
		myImageComponent.sprite = myFirstImage;
	}

	public void SetImage2() //method to set our second image
	{
		myImageComponent.sprite = mySecondImage;
	}
}
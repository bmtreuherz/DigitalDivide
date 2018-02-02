using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script was inspired by a tutorial by Timmy Kokke
[RequireComponent(typeof(CharacterController))]
public class Walk : MonoBehaviour {

	CharacterController characterController;

	[Range(0f, 90f)]
	public float LookAngle = 30f;

	[Range(0f, 5f)]
	[Tooltip("Walking speed")]
	public float Speed = 3f;

	public Camera camera;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.transform.eulerAngles.x >= LookAngle &&
		    camera.transform.eulerAngles.x < 90) {
			characterController.SimpleMove (camera.transform.forward * Speed);
		}
	}
}


// At 35:11 of TechDays 2017 - Timmy Kokke - VR in a Box
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_Paralax : MonoBehaviour {

	private Vector3 anchor;
	public float paralaxFactor;

	private void Awake(){

		anchor = transform.position;
	}

	private void LateUpdate(){

		transform.position = anchor + (Camera_Controller.relativeCamPos * paralaxFactor);

		transform.position = new Vector3 (transform.position.x, transform.position.y, 10.0f);
	}
}

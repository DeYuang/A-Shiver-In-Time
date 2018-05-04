using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

	static public Transform camTrans;
	static public Vector3 relativeCamPos;

	private Vector3 startPos;

	public Transform target;
	public Vector3 offset;
	public float maxCameraSpeed = 1.0f;

	public AnimationCurve responseCurve;
	public float distanceMultiplier = 1.0f;

	private void Awake(){

		camTrans = transform;
		startPos = transform.position;
	}

	private void LateUpdate(){

		Vector3 targetPos = target.position + offset;
		transform.position = Vector3.Lerp(Vector3.MoveTowards(transform.position, targetPos, maxCameraSpeed * Time.deltaTime), targetPos, responseCurve.Evaluate(Vector3.Distance(transform.position + offset, targetPos) * distanceMultiplier) * Time.deltaTime);
	
		relativeCamPos = transform.position - startPos;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_Corpse : MonoBehaviour {

	private Rigidbody rb;
	public float flipTime;
	public float flipSpeed;
	public float verticalLaunchSpeed = 10.0f;

	private void Awake () {

		rb = gameObject.GetComponent<Rigidbody> ();

		if(Random.value > 0.5)
			flipSpeed = -flipSpeed;
	}

	public void InitVelocity(Vector3 inheritedVelocity){

		rb.velocity = new Vector3 (inheritedVelocity.x, verticalLaunchSpeed, 0.0f);
	}

	private void OnCollisionEnter(Collision other){

		Destroy (this);
	}

	private void Update () {

		flipTime -= Time.deltaTime;

		Vector3 angles = transform.eulerAngles;
		rb.rotation = Quaternion.Euler (angles.x, angles.y, angles.z + (flipSpeed * Time.deltaTime));

		if (flipTime < 0.0f)
			Destroy (this);

	}
}

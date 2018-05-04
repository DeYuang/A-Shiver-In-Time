using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_KillClock : MonoBehaviour {

	public float killTimer = 1.0f;

	private void Update () {

		killTimer -= Time.deltaTime;
		if (killTimer < 0.0f)
			Destroy (gameObject);
	}
}

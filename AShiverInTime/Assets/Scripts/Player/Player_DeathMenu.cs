using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DeathMenu : MonoBehaviour {

	private void LateUpdate () {

		if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2") || Input.GetButtonDown ("Start") || Input.GetButtonDown ("Select"))
			Level_Manager.ResetLevel ();
	}
}

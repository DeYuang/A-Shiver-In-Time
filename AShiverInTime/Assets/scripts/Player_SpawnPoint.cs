using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_SpawnPoint : MonoBehaviour {

	static public RigidBody rb;
	static public bool spawnPointSet = false;
	static public Vector3 spawnPoint;

	private void Start(){

		spawnPoint = transform.position;
		spawnPointSet = true;
		rb = getComponent<Rigidbody2D>();
	}

	static public void ResetPlayerPosition(){

		if (!spawnPointSet) {
			Debug.LogError ("Player_SpawnPoint.ResetPlayerPosition() Error: You tried to reset the player before a spawnpoint was set!");
			return;
		}
		if (!trans) {
			Debug.LogError ("Player_SpawnPoint.ResetPlayerPosition() Error: You tried to reset the player before a player Transform was set!\r\nHave you placed the Player_SpawnPoint script on the player character?");
			return;
		}

		TeleportPlayer (spawnPoint);
	}

	static public void TeleportPlayer(Vector3 position){

		rb.position = position;
		rb.velocity = Vector3.zero;
	}
}

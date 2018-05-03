﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour {

	static public Level_Manager instance;
	public GameObject player;
	public GameObject deathMenu;
	public float levelTime = 10.0f;

	public float killY = -10.0f;

	private void Awake(){

		if (!instance)
			instance = this;
		else
			Destroy (this);
	}

	static public void ResetLevel(){

		if (!instance.player.activeInHierarchy)
			instance.player.SetActive (true);

		Pickup_Manager.ResetPickups ();
		Player_LevelWallet.grandTotalPickups = 0;

		Player_LevelWallet.SetLevel (0);
		Player_SpawnPoint.ResetPlayerPosition ();

		if (instance.deathMenu.activeInHierarchy)
			instance.deathMenu.SetActive (false);

		Controller.ResetTimer ();
	}

	static public void OnPlayerDied(){

		if(!instance.deathMenu.activeInHierarchy)
			instance.deathMenu.SetActive(true);
	}
}

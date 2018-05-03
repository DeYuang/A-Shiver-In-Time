using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour {

	static public void ResetLevel(){

		Pickup_Manager.ResetPickups ();
		Player_LevelWallet.grandTotalPickups = 0;

		Player_LevelWallet.SetLevel (0);
		Player_SpawnPoint.ResetPlayerPosition ();
	}
}

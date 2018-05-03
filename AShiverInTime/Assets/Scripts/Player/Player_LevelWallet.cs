using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LevelWallet : MonoBehaviour {

	static public Player_LevelWallet instance;
	static public int currentLevel = 0;
	static public int grandTotalPickups = 0;

	public int[] levelValues;
	public int maxLevel = 5;


	private void Awake(){

		instance = this;

		#if UNITY_EDITOR
		if (levelValues.Length != maxLevel) {
			Debug.LogWarning ("Player_LevelWallet.cs warning: not all levels have levelup values!", this);
			if (levelValues.Length > maxLevel) {
				for (int count = levelValues.Length; count-- > maxLevel;)
					levelValues [count] = Mathf.Max (levelValues [maxLevel - 1], levelValues [count]);
			}
		}
		#endif
	}

	static public void IncrementPickupCounter(int amount = 1){

		grandTotalPickups += amount;
		while (instance.levelValues[currentLevel] <= grandTotalPickups) {
			// level up!
			SetLevel(currentLevel + 1);
		}
	}

	static public void SetLevel(int level){

		currentLevel = level;

		// TODO: level up abilities
	}
}

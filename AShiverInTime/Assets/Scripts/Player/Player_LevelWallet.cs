using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LevelWallet : MonoBehaviour {

	static public Player_LevelWallet instance;
	static public int currentLevel = 0;
	static public int grandTotalPickups = 0;

	private Controller player;

	public int[] levelValues;
	public int maxLevel = 5;

	public int[] maxJumps;
	public float[] moveSpeed;
	public float[] jumpForce;

	static public int PickupsRequiredForNextLevel(){

		if(currentLevel > 0)
			return (instance.levelValues [currentLevel] - instance.levelValues [currentLevel - 1]);
		return instance.levelValues [currentLevel];
	}

	static public int GetTotalPickupsRequiredForLevel(int level){

		return instance.levelValues [level];
	}

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

		player = GetComponent<Controller> ();
		SetLevel (0);
	}

	static public void IncrementPickupCounter(int amount = 1){

		grandTotalPickups += amount;
		while (grandTotalPickups >= instance.levelValues[currentLevel]) {
			// level up!
			SetLevel(currentLevel + 1);
		}
	}

	static public void SetLevel(int level){

		currentLevel = level;

		// Level up abilities
		instance.player.baseSpeed = instance.moveSpeed[level];
		instance.player.jumpPower = instance.jumpForce [level];
		instance.player.maxJumps = instance.maxJumps[level];
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Manager : MonoBehaviour {

	static public Pickup_Manager instance;

	public List<GameObject> levelPickups = new List<GameObjects>();

	static public void RegisterPickup(GameObject pickup){

		if (!levelPickups.Contains (pickup))
			levelPickups.Add (pickup);
	}

	static public void UnregisterPickup(GameObject pickup){

		int iterationGuard = 8;
		while (levelPickups.Contains (pickup)) {
			levelPickups.Remove (pickup);
			if (iterationGuard-- < 0) {
				#if UNITY_EDITOR
				debug.logError ("Pickup_Manager.cs Unregister Error: instance is in the array more than 8 times!", instance);
				#endif
				return;
			}
		}
	}

	static public void ResetPickups(){

		GameObject currentObject;
		for (int count = levelPickups.Count; count-- > 0;) {
			currentObject = levelPickups [count];
			if (!currentObject) {
				UnregisterPickup (currentObject);
				continue;
			}
			if (!currentObject.activeInHierarchy)
				currentObject.SetActive (true);
		}
	}
}

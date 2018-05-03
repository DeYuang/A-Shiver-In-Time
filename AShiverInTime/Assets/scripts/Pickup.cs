using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour {

	public int pickupValue = 1;

	public void ActivatePickup(){

		// Increment level counter and get rid of the pickup
		Player_LevelWallet.IncrementPickupCounter(pickupValue);
		SetActive (false);
	}

	private void OnCollisionEnter(Collider other){

		if(other.CompareTag("Player"))
			ActivatePickup();
	}

	private void Awake(){
		
		Pickup_Manager.RegisterPickup (gameObject);
	}
}

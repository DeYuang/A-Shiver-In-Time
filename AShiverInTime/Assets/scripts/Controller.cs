using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour {

    BoxCollider2D playerCollider;
    Rigidbody2D playerRigidBody;


	// Use this for initialization
	void Awake () {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if()//a
        {

        }
        else if ()//b
        {

        }
        
        if()//left or right
        {

        }
        else if()//up
        {

        }
        else if()//down
        {

        }

	}
}

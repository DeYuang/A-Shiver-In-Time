﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour {

    BoxCollider2D playerCollider;
    Rigidbody2D playerRigidBody;

    public float gravity = 1f;
    public float baseSpeed = 1f;
    public float jumpPower = 1f;
    public float drag = 1f;
    public float runModifier = 2f;
    Vector3 movement;

    public float playerSpriteWidth = 1f;
    public float playerSpriteLength = 1f;

    // Use this for initialization
    void Awake () {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        movement = new Vector3(Mathf.Clamp(movement.x, -baseSpeed, baseSpeed), Mathf.Clamp(movement.y, -gravity, jumpPower),0f);
	}

    void CastRays()
    {
        for (int i = -1; i < 2; i++)
        {
            Debug.DrawRay(new Vector3(gameObject.transform.position.x + (i*(playerSpriteWidth / 3)),gameObject.transform.position.y - (playerSpriteLength / 2),0f ),Vector2.down* 0.5f, Color.red);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonDown("Fire2"))//a
        {
            Debug.Log("A");
            movement.y += jumpPower;
        }

        if (Input.GetButtonDown("Fire1"))//b
        {
            Debug.Log("B");
        }

        if (Input.GetButtonDown("Start"))//start
        {
            Debug.Log("START");
        }

        if(Input.GetButtonDown("Select"))//select
        {
            Debug.Log("SELECT");
        }
        
        if(Input.GetAxisRaw("Horizontal") != 0f)//left or right
        {
            float direction = 0f;
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1f;
            }
            else
            {
                direction = -1f;
            }
            Debug.Log("HORIZONTAL");
            movement.x += direction * baseSpeed;
        }

        if(Input.GetAxisRaw("Vertical") > 0f)//up
        {
            Debug.Log("UP");
        }
        else if(Input.GetAxisRaw("Vertical") < 0f)//down
        {
            Debug.Log("DOWN");
        }

        //slowdown and gravity
        if(movement.x > 0)
        {
            movement.x -= drag;
        }
        else if(movement.x < 0)
        {
            movement.x += drag;
        }
		if(movement.y > 0f)
		{
			movement.y -= drag;
		}
        //movement.y -= gravity;

        transform.Translate(movement * Time.deltaTime);
	}
}

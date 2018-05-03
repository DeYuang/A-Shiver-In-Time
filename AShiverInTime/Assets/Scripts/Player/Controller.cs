using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour {

    BoxCollider playerCollider;
    Rigidbody playerRigidBody;

    public float verticalDrag = 1f;
    public float baseSpeed = 1f;
    public float jumpPower = 1f;
    public float drag = 1f;
    public float runModifier = 2f;
    Vector3 movement;
    
    // Use this for initialization
    private void Awake () {
        playerCollider = GetComponent<BoxCollider>();
        playerRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	private void Update () {

		Vector2 input = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if(Input.GetButtonDown("Fire2"))//a
        {
            Debug.Log("A");
            movement.y += jumpPower;
            playerRigidBody.velocity = Vector3.zero;
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
        
		const float deadzone = 0.1f;
		if(Mathf.Abs(input.x) > deadzone)//left or right
        {
            float direction = 0f;
			if (input.x > 0f)
            {
                direction = 1f;
				Debug.Log("right");
            }
            else
            {
                direction = -1f;
				Debug.Log("left");
            }
            
            movement.x += direction * baseSpeed;
        }

		if (Mathf.Abs (input.y) > deadzone) {
			if (input.y > 0f) {//up
				Debug.Log ("Up");
			} else {
				Debug.Log ("Down");
			}
		}

        //slowdown and gravity
        if(movement.x > 0f)
        {
            movement.x -= drag * Time.deltaTime;
        }
        else if(movement.x < 0f)
        {
            movement.x += drag * Time.deltaTime;
        }
		if(movement.y > 0f)
		{
			movement.y -= verticalDrag * Time.deltaTime;
		}

        movement = new Vector3(Mathf.Clamp(movement.x, -baseSpeed, baseSpeed), Mathf.Clamp(movement.y, Physics.gravity.y, jumpPower),0f);
        playerRigidBody.position = transform.position + (movement * Time.deltaTime);
	}
}

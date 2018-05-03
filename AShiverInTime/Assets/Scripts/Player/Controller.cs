using System.Collections;
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

    public int horizontalRays = 4;
    public int verticalRays = 4;

    [HideInInspector]
    public float horizontalRaySpace;
    [HideInInspector]
    public float verticalRaySpace;
    [HideInInspector]
    public float skinWidth = 0.015f;


    // Use this for initialization
    private void Awake () {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigidBody = GetComponent<Rigidbody2D>();
	}

    private void CastRays()
    {
        Bounds bounds = playerCollider.bounds;
        bounds.Expand(skinWidth * -2f);

        horizontalRays = Mathf.Clamp(horizontalRays, 2, int.MaxValue);
        verticalRays = Mathf.Clamp(verticalRays, 2, int.MaxValue);

        horizontalRaySpace = bounds.size.y / (horizontalRays - 1f);
        verticalRaySpace = bounds.size.x / (verticalRays - 1f);
    }
	
	// Update is called once per frame
	private void Update () {
	
		Vector2 input = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

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
            movement.x -= drag;
        }
        else if(movement.x < 0f)
        {
            movement.x += drag;
        }
        movement.y -= gravity;

		movement = new Vector3(Mathf.Clamp(movement.x, -baseSpeed, baseSpeed), Mathf.Clamp(movement.y, -gravity, jumpPower),0f);
        transform.Translate(movement * Time.deltaTime);
	}
}

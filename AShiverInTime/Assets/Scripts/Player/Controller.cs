using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player_SpriteController))]
public class Controller : MonoBehaviour {

	static public Controller instance;
    BoxCollider playerCollider;
    Rigidbody playerRigidBody;
	private Player_SpriteController spriteController;

    public float verticalDrag = 1f;
    public float baseSpeed = 1f;
    public float jumpPower = 1f;
    public float drag = 1f;
    public float runModifier = 2f;
    Vector3 movement;

	public float jumpingAnimationTime = 1f/30f;
	private float jumpingTimer;

	public float fallingSpeedTreshold = -0.1f;
	public float duckTimer = 0.0f;

	public GameObject playerCorpsePrefab;

	static public float levelTimer;

	private int jumpCounter = 0;
	public int maxJumps = 2;

	public GameObject smokePuffJump;
	public GameObject smokePuffLand;
    
    // Use this for initialization
    private void Awake () {
        playerCollider = GetComponent<BoxCollider>();
        playerRigidBody = GetComponent<Rigidbody>();
		spriteController = GetComponent<Player_SpriteController> ();
		instance = this;

		ResetTimer ();
		ResetPlayer ();
	}

	public void Die(){

		if(levelTimer < 0.0f)
			levelTimer = 0.0f;

		gameObject.SetActive (false);
		GameObject temp = Instantiate (playerCorpsePrefab, transform.position, transform.rotation) as GameObject;
		temp.GetComponent<Player_Corpse> ().InitVelocity(movement);

		Level_Manager.OnPlayerDied ();
	}

	public void ResetPlayer(){

		jumpCounter = 2;
	}

	// Update is called once per frame
	private void Update () {

		bool isGrounded = Mathf.Abs (playerRigidBody.velocity.y) < 0.05f;
		if (isGrounded) {
			if (jumpCounter != 0) {
				jumpCounter = 0;
				Instantiate (smokePuffLand, transform.position + new Vector3(0.0f,0.0f,-2.0f), Quaternion.identity);
			}
			playerRigidBody.velocity = Vector3.zero;

		}
		
		Vector2 input = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if(Input.GetButtonDown("Fire2") && jumpCounter < maxJumps)//a
        {
            Debug.Log("A");
            movement.y += jumpPower;
            playerRigidBody.velocity = Vector3.zero;
			jumpingTimer = jumpingAnimationTime;
			jumpCounter++;
			Instantiate (smokePuffJump, transform.position + new Vector3(0.0f,0.0f,-2.0f), Quaternion.identity);
        }

        if (Input.GetButtonDown("Fire1"))//b
        {
            Debug.Log("B");
			Die ();

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
                direction = 1f;
            else
                direction = -1f;
            
            movement.x += direction * baseSpeed;
        }

        // Drag
        if(movement.x > 0f)
			movement.x = Mathf.Max(movement.x - (drag * Time.deltaTime), 0.0f);
        else if(movement.x < 0f)
			movement.x = Mathf.Min(movement.x + (drag * Time.deltaTime), 0.0f);
		if(movement.y > 0f)
			movement.y = Mathf.Max(movement.y - (verticalDrag * Time.deltaTime), 0.0f);

        movement = new Vector3(Mathf.Clamp(movement.x, -baseSpeed, baseSpeed), Mathf.Clamp(movement.y, Physics.gravity.y, jumpPower),0f);
        playerRigidBody.position = transform.position + (movement * Time.deltaTime);

		//Animation block
		jumpingTimer -= Time.deltaTime;
		if (jumpingTimer > 0.0f)
			spriteController.SetAnimation (AnimationState.jumping);
		else if (playerRigidBody.velocity.y < fallingSpeedTreshold)
			spriteController.SetAnimation (AnimationState.falling);
		else {
			if (Mathf.Abs (movement.x) > 0.0f)
				spriteController.SetAnimation (AnimationState.walking);
			else if (input.y < -deadzone) {
				spriteController.SetAnimation (AnimationState.ducking);
				duckTimer += Time.deltaTime;
			}
			else
				spriteController.SetAnimation (AnimationState.idle);
		}

		if (spriteController.GetAnimationState () != AnimationState.ducking)
			duckTimer = 0.0f;

		if (input.x > deadzone) 
			spriteController.SetFacing (false);
		else if (input.x < -deadzone) 
			spriteController.SetFacing (true);
			

		levelTimer -= Time.deltaTime;
		if (levelTimer < 0.0f || transform.position.y <= Level_Manager.instance.killY)
			Die ();
	}

	static public void ResetTimer(){

		levelTimer = Level_Manager.instance.levelTime;
	}
}

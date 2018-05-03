using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AnimationState : int { idle, walking, jumping, falling, ducking };

public class Player_SpriteController : MonoBehaviour {

	public SpriteRenderer sr;

	public Sprite idleFrame;
	public Sprite jumpFrame;
	public Sprite fallSprite;
	public Sprite duckFrame;
	public Sprite[] walkFrames;
	private int walkFrameID;
	public float walkAnimationFrameRate = 4.0f;
	private float walkTimer;
	private AnimationState currentState;

	public void SetAnimation(AnimationState animationState){

		if (currentState == animationState && currentState != AnimationState.walking)
			return;
		
		currentState = animationState;
		switch(animationState){

		case AnimationState.idle: {
				sr.sprite = idleFrame;
				break;
			}

		case AnimationState.jumping: {
				sr.sprite = jumpFrame;
				break;
			}

		case AnimationState.falling: {
				sr.sprite = fallSprite;
				break;
			}

		case AnimationState.ducking: {
				sr.sprite = duckFrame;
				break;
			}

		case AnimationState.walking: {

				walkTimer += Time.deltaTime;
				float maxTime = 1.0f / walkAnimationFrameRate;
				while (walkTimer > maxTime) {
					walkTimer -= maxTime;
					walkFrameID = (walkFrameID + 1) % walkFrames.Length;
				}
				sr.sprite = walkFrames[walkFrameID];
				break;
			}

		}
	}

	public void SetFacing(bool left){

		sr.flipX = left;
	}

	public AnimationState GetAnimationState(){

		return currentState;
	}
}

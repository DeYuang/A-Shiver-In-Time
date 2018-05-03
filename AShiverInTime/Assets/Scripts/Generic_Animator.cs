using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Generic_Animator : MonoBehaviour {

	private SpriteRenderer sr;

	private float timer;
	public float animationFrameRate = 8.0f;
	private int frameId;
	public Sprite[] animationFrames = new Sprite[0];

	private void Awake(){
		
		sr = GetComponent<SpriteRenderer> ();
	}

	private void Update () {

		timer += Time.deltaTime;
		float maxTime = 1.0f / animationFrameRate;
		while (timer > maxTime) {
			timer -= maxTime;
			frameId = (frameId + 1) % animationFrames.Length;
		}
		sr.sprite = animationFrames[frameId];
	}
}

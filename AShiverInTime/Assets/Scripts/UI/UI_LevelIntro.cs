using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelIntro : MonoBehaviour {

	public Text[] textElements;

	public AnimationCurve alphaCurve;
	private float progression = 1.0f;
	public float alphaSpeed = 1.0f;

	public float idleTime = 2.0f;
	private float idleClock;

	private void OnEnable(){

		progression = 1.0f;
		idleClock = idleTime;

		Text currentElement;
		Color currentColor;
		for (int count = textElements.Length; count-- > 0;) {
			currentElement = textElements [count];
			currentColor = currentElement.color;
			currentElement.color = new Color (currentColor.r, currentColor.g, currentColor.b,  1.0f);
		}
	}

	private void LateUpdate () {

		if (Time.frameCount == 0)
			return;

		idleClock -= Time.unscaledDeltaTime;
		if (idleClock > 0.0f)
			return;

		progression -= Time.unscaledDeltaTime * alphaSpeed;

		if (progression > 0.0f) {
			float alpha = alphaCurve.Evaluate (progression);
			Text currentElement;
			Color currentColor;
			for (int count = textElements.Length; count-- > 0;) {
				currentElement = textElements [count];
				currentColor = currentElement.color;
				currentElement.color = new Color (currentColor.r, currentColor.g, currentColor.b, alpha);
			}
		} 
		else
			gameObject.SetActive (false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour {

	public Text timerText;

	private void Awake(){

		if (!timerText)
			timerText = GetComponent<Text> ();
	}

	private void LateUpdate () {

		float timer = Controller.levelTimer;
		int seconds = Mathf.CeilToInt(timer);
		int wholeMinutes = Mathf.FloorToInt(timer / 60);
		seconds -= wholeMinutes * 60;

		if(seconds < 10)
			timerText.text = wholeMinutes + ":0" + seconds;
		else
			timerText.text = wholeMinutes + ":" + seconds;
	}
}

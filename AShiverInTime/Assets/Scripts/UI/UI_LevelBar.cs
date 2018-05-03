using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelBar : MonoBehaviour {

	public Image bar;
	public Text text;
	public Text levelText;
	public float cachedValue = 0.0f;
	public float sliderSpeed = 10.0f;

	private void LateUpdate () {

		int currentLevel = Player_LevelWallet.currentLevel;
		int pickupsToNextLevel = Player_LevelWallet.PickupsRequiredForNextLevel();

		int pickupsGot;
		if(Player_LevelWallet.currentLevel > 0)
			pickupsGot = Player_LevelWallet.grandTotalPickups - Player_LevelWallet.GetTotalPickupsRequiredForLevel(Player_LevelWallet.currentLevel- 1);
		else
			pickupsGot = Player_LevelWallet.grandTotalPickups;

		print (Player_LevelWallet.grandTotalPickups);
		
		text.text = pickupsGot+"/"+pickupsToNextLevel;
		float value = Mathf.Clamp01((float)pickupsGot/(float)pickupsToNextLevel);

		if (value < cachedValue)
			cachedValue = value;
		else
			cachedValue = Mathf.Lerp(cachedValue, value, sliderSpeed * Time.deltaTime);

		levelText.text = "power level " + (currentLevel + 1);

		bar.fillAmount = cachedValue;
	}
}

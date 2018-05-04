using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Tool_PlatformRectifier : MonoBehaviour {

	private void Update () {

		SpriteRenderer sr = GetComponentInChildren < SpriteRenderer > ();

		sr.size = new Vector2 (transform.localScale.x/3.0f, sr.size.y);

		#if !UNITY_EDITOR
		Destroy(this);
		#endif
	}
}

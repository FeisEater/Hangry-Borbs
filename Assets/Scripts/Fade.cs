using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	public float fadeTime;
	public float startTime;
	private bool fading;
	float t;

	// Use this for initialization
	void Start () {
		fading = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (fading) {
			t += Time.deltaTime * fadeTime;
			float a = Mathf.Lerp (1, 0, t);
			Color color = gameObject.GetComponent<SpriteRenderer> ().color;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (color.r, color.g, color.b, a);
			if (a == 0) {
				fading = false;
			}
		}
	}

	public void StartFade(){
		startTime = Time.time;
		fading = true;
	}
}

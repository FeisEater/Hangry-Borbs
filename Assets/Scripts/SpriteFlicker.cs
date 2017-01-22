using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlicker : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2;
	public float flickerTime;
	private float changeSpriteAtTime;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > changeSpriteAtTime) {
			if (gameObject.GetComponent<SpriteRenderer> ().sprite == sprite1) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = sprite2;
			}else {
				gameObject.GetComponent<SpriteRenderer> ().sprite = sprite1;
			}
			changeSpriteAtTime = Time.time + flickerTime;
		}
	}
}

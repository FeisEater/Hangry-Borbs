using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardKey : MonoBehaviour {

	public CharacterSelectController csController;
	public float pitch = 1;

	[HideInInspector]	public bool activePlayer;
	[HideInInspector]	public AudioClip audioClip1;
	[HideInInspector]	public AudioClip audioClip2;


	private Color pressedColor = new Color (0, 1, 0, 1);
	private Color defaultColor = new Color (1, 1, 1, 1);


	// Use this for initialization
	void Start () {
		pitch = Random.Range (0.5f, 2f);
		activePlayer = false;
		gameObject.GetComponent<SpriteRenderer> ().color = defaultColor;
		csController = gameObject.GetComponentInParent<CharacterSelectController> ();
		audioClip1 = (AudioClip)Resources.Load("Audio/yaas(edited)");
		audioClip2 = (AudioClip)Resources.Load("Audio/yas(edited)");
	}

	public void SetPressed(){
		if (activePlayer) {
			activePlayer = false;
			gameObject.GetComponent<SpriteRenderer> ().color = defaultColor;
			csController.SubtractPlayerReady ();
		} else {
			activePlayer = true;
			gameObject.GetComponent<SpriteRenderer> ().color = pressedColor;

			AudioSource audioSource = gameObject.GetComponent<AudioSource> ();

			int x = Mathf.FloorToInt (Random.Range (1.5f, 2.5f)); //x = 1 or 2

			if (x == 1) {
				audioSource.clip = audioClip1;
			}else {
				audioSource.clip = audioClip2;
			}
			audioSource.pitch = pitch;
			audioSource.Play ();
			csController.AddPlayerReady ();
		}
	}
}

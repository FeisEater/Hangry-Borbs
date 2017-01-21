using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardKey : MonoBehaviour {

	public bool activePlayer;
	public CharacterSelectController csController;

	private Color pressedColor = new Color (0, 1, 0, 1);
	private Color defaultColor = new Color (1, 1, 1, 1);


	// Use this for initialization
	void Start () {
		activePlayer = false;
		gameObject.GetComponent<SpriteRenderer> ().color = defaultColor;
		csController = gameObject.GetComponentInParent<CharacterSelectController> ();
	}

	public void SetPressed(){
		if (activePlayer) {
			activePlayer = false;
			gameObject.GetComponent<SpriteRenderer> ().color = defaultColor;
			csController.SubtractPlayerReady ();
		} else {
			activePlayer = true;
			gameObject.GetComponent<SpriteRenderer> ().color = pressedColor;
			gameObject.GetComponent<AudioSource> ().Play ();
			csController.AddPlayerReady ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectController : MonoBehaviour {

	public int playersReady;
	public int nextSceneIndex;

	[HideInInspector]public GameObject playerQ;
	[HideInInspector]public GameObject playerA;
	[HideInInspector]public GameObject playerZ;
	[HideInInspector]public GameObject playerC;
	[HideInInspector]public GameObject playerB;
	[HideInInspector]public GameObject playerM;
	[HideInInspector]public GameObject playerK;
	[HideInInspector]public GameObject playerP;
	[HideInInspector]public GameObject spaceSprite;

	[HideInInspector]private DataManager dataManager; 


	public Sprite Players0;
	public Sprite Players1;
	public Sprite Players2;
	public Sprite Players3;
	public Sprite Players4;
	public Sprite Players5;
	public Sprite Players6;
	public Sprite Players7;
	public Sprite Players8;


	// Use this for initialization
	void Start () {
		playerQ = GameObject.Find("letter_q");
		playerA = GameObject.Find("letter_a");
		playerZ = GameObject.Find("letter_z");
		playerC = GameObject.Find("letter_c");
		playerB = GameObject.Find("letter_b");
		playerM = GameObject.Find("letter_m");
		playerK = GameObject.Find("letter_k");
		playerP = GameObject.Find("letter_p");
		spaceSprite = GameObject.Find("letter_space");
		playersReady = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			playerQ.GetComponent<KeyboardKey> ().SetPressed ();
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			playerA.GetComponent<KeyboardKey> ().SetPressed ();
		} 

		if (Input.GetKeyDown (KeyCode.Z)) {
			playerZ.GetComponent<KeyboardKey> ().SetPressed ();
		} 

		if (Input.GetKeyDown (KeyCode.C)) {
			playerC.GetComponent<KeyboardKey> ().SetPressed ();
		} 

		if (Input.GetKeyDown (KeyCode.B)) {
			playerB.GetComponent<KeyboardKey> ().SetPressed ();
		} 

		if (Input.GetKeyDown (KeyCode.M)) {
			playerM.GetComponent<KeyboardKey> ().SetPressed ();
		} 

		if (Input.GetKeyDown (KeyCode.K)) {
			playerK.GetComponent<KeyboardKey> ().SetPressed ();
		} 

		if (Input.GetKeyDown (KeyCode.P)) {
			playerP.GetComponent<KeyboardKey> ().SetPressed ();
		}

		SpriteRenderer sr = spaceSprite.GetComponent<SpriteRenderer> ();
		switch (playersReady) 
		{
		case 0: 
			sr.sprite = Players0;
			break;
		case 1: 
			sr.sprite = Players1;
			break;
		case 2: 
			sr.sprite = Players2;
			break;
		case 3: 
			sr.sprite = Players3;
			break;
		case 4: 
			sr.sprite = Players4;
			break;
		case 5: 
			sr.sprite = Players5;
			break;
		case 6: 
			sr.sprite = Players6;
			break;
		case 7: 
			sr.sprite = Players7;
			break;
		case 8: 
			sr.sprite = Players8;
			break;
		}

		if (Input.GetKeyDown (KeyCode.Space) && playersReady != 0){
			dataManager.numberOfPlayers = playersReady;
			Application.LoadLevel(nextSceneIndex);
		}

	}

	public void AddPlayerReady(){
		playersReady++;
	}

	public void SubtractPlayerReady(){
		playersReady--;
	}
}

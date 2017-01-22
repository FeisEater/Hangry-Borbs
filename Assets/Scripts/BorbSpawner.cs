using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorbSpawner : MonoBehaviour {

	[HideInInspector] private DataManager dataManager; 
	[HideInInspector] GameObject[] borbs = new GameObject[9];

	//spawn positions for borbs
	Vector3[] spawnCoords = new Vector3[9]{
				new Vector3(0,0,0), //empty entry at index zero / not used
				new Vector3(100, 100, 0),
				new Vector3(346, 100, 0),
				new Vector3(593, 100, 0),
				new Vector3(840, 100, 0),
				new Vector3(1087, 100, 0),
				new Vector3(1334, 100, 0),
				new Vector3(1581, 100, 0),
				new Vector3(1820, 100, 0)
			};

	// Use this for initialization
	void Start () {
		//handle error if no data manager in scene
		bool[] activePlayers;
		try{
			dataManager = GameObject.Find ("SceneHandler").GetComponent<DataManager> ();
			activePlayers = dataManager.activePlayers;
		}catch{
			activePlayers = new bool[2]{false, true};
		}

		for (int i = 1; i < activePlayers.Length; i++) {
			if (activePlayers [i]) {
				borbs [i] = (GameObject)Instantiate (Resources.Load ("Borb"));
				borbs [i].GetComponent<Borb> ().playerId = i;
				borbs [i].transform.position = spawnCoords [i];

                borbs[i].GetComponent<Borb>().scoreText = GameObject.Find("score" + i).GetComponent<Text>();
                borbs[i].GetComponent<Borb>().baseScoreText = i + "'s score: ";
			}
        
		}
	}
}

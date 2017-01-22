using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//// <summary>
/// Data manager. This Game Object does not destroy at the loading of the new scene.
/// </summary>

public class DataManager : MonoBehaviour {

	[HideInInspector] public int numberOfPlayers;

	[HideInInspector] public bool[] activePlayers;// index 0 is unused. Player1's active state is in activePlayers[1].

    [HideInInspector] public Dictionary<string, int> scores;

	void Awake(){		
		Object.DontDestroyOnLoad (gameObject);

		//set defaults
		numberOfPlayers = 0;
		activePlayers = new bool[9];
		for (int i = 1; i < activePlayers.Length; i++) {
			activePlayers [i] = false;
		}
	}

	public void TooglePlayerActive(int playerId){
		//activate/deactivate players
		activePlayers [playerId] = !activePlayers [playerId];
	}

}

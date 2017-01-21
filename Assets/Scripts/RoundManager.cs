using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {
    public float timeLimit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLimit -= Time.deltaTime;
        if (timeLimit < 0)
            EndGame();
	}

    void EndGame()
    {
        //Change this to change level to main menu.
        Debug.Log("Game End");
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCredits : MonoBehaviour {

	public int goTo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Return))
			Application.LoadLevel(goTo);
    }
}

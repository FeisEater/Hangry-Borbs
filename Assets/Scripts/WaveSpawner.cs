using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	private GameObject wave;

	// Use this for initialization
	void Start () {
		SpawnWave ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W)) {
				var wm = wave.GetComponent<WaveMovement> ();
				wm.DoTheWave (1);
		}
	}

	void SpawnWave(){
		wave = (GameObject)Instantiate(Resources.Load("Wave"));
		wave.transform.Translate(new Vector3(0, 1080, 0));
	}
}

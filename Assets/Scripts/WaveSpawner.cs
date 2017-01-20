using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {



	// Use this for initialization
	void Start () {
		SpawnWave ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnWave(){
		GameObject wave = (GameObject)Instantiate(Resources.Load("Wave"));
		wave.transform.Translate(new Vector3(0, 1080, 0));
	}
}

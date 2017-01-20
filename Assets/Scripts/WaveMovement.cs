using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {
	
	public float waveSpeed;

	[HideInInspector]
	public float defaultWaveSpeed = 5;

	// Use this for initialization
	void Start () {
		if (waveSpeed == null) {
			waveSpeed = defaultWaveSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(new Vector3(0, waveSpeed,0));	
	}
}

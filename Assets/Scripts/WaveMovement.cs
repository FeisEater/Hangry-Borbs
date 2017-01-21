using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {
	
	public float waveSpeed;
	private float startTime;
	private bool waving;
	private bool waveDirectionFlag;

	// Use this for initialization
	void Start () {
		//init defaults
		if (waveSpeed == 0) {
			waveSpeed = 3;
		}
		startTime = 0;
		waving = true;
		waveDirectionFlag = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (waving) {
			float y = GetWavePosition ();
			gameObject.transform.Translate (new Vector3 (0, -y, 0));	
		}
	}

	void DoTheWave(){
		waving = true;
	}

	float GetWavePosition(){
		float waveTime = Time.time - startTime;
		float pos = Mathf.Sin(waveTime * waveSpeed) * 10.8f * waveSpeed;
		if (pos < 0) {
			waveDirectionFlag = false;
		}
		if (waveDirectionFlag == false && pos > 0) {
			pos = 0;
			waving = false;
		}
		Debug.Log (pos);
		return pos;
	}
}

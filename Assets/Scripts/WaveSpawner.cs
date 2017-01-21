using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public float maxWaveTime;
    public float minWaveTime;
    public float comboProbability;
    public int maxCombo;
    public int minCombo;
    public float minWaveLength;
    public float maxWaveLength;

    private float nextWave;
    private int combo;
    private bool lastWaveWasCombo;
    private GameObject wave;

	// Use this for initialization
	void Start () {
		SpawnWave ();
        nextWave = SetNextWave();
        combo = 0;
        lastWaveWasCombo = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (nextWave <= 0) {
			var wm = wave.GetComponent<WaveMovement> ();
            wm.DoTheWave(Random.Range(minWaveLength, maxWaveLength), combo > 0);
            nextWave = SetNextWave();
		}
        else
        {
            nextWave -= Time.deltaTime;
        }
	}

    float SetNextWave()
    {
        if (combo > 0)
        {
            combo--;
            return 2f;
        }
        bool doCombo = Random.value < comboProbability;
        if (doCombo && !lastWaveWasCombo)
        {
            combo = Random.Range(minCombo, maxCombo + 1) - 2;
            lastWaveWasCombo = true;
            return 2f;
        }
        lastWaveWasCombo = false;
        return Random.Range(minWaveTime, maxWaveTime);
    }

	void SpawnWave(){
		wave = (GameObject)Instantiate(Resources.Load("Wave"));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {
	
	public float waveSpeed;
	public float waveLength;
	private float startTime;
	public const float startPosition = 1080 + 100;

	private bool waving;
	private bool waveDirectionFlag;
    private bool spawnedItems;
	private GameObject foam;

	/// <summary>
	/// Call this when you want to do a wave. Attatch this to a wave-gameobject
	/// </summary>
	/// <param name="Length">Length of the wave. float between 0 and 1.</param>
	public void DoTheWave(float length){
		SetDefaults ();
		waveLength = length;
		waving = true;
		startTime = Time.time;
        spawnedItems = false;
	}

	// Use this for initialization
	void Start () {
		SetDefaults ();
	}

	//sets default values
	private void SetDefaults(){
		if (waveSpeed == 0) {
			waveSpeed = 3;
		}
		startTime = 0;
		waving = false;
		waveDirectionFlag = true;
		waveLength = 1;
		gameObject.transform.position = new Vector3 (0, startPosition, 0);
		if (foam != null) {
			Destroy (foam);
		}
		foam = (GameObject)Instantiate(Resources.Load("Foam"));
		foam.transform.position = gameObject.transform.position;
		foam.transform.parent = gameObject.transform;
	}

	void FixedUpdate () {
		if (waving) {
			float y = GetWavePosition ();
			Vector3 position = gameObject.transform.position + new Vector3 (0, y, 0);
			gameObject.transform.position = position;
		}
	}

	//calculates the y-position of the wave-gameobject
	float GetWavePosition(){		
		float waveTime = Time.time - startTime;
		float length = (startPosition / 100) * waveLength;
		float modifier = Mathf.Sin (waveTime * waveSpeed);

		float pos = modifier * length * waveSpeed;

		if (pos < 0) {
			waveDirectionFlag = false;
			foam.GetComponent<Fade> ().StartFade ();
		}
		if (waveDirectionFlag == false && pos > 0) {
			pos = 0;
			SetDefaults ();
		}

        if (waveTime > 0.5f && !spawnedItems)
        {
            Dictionary<string, int> items = new Dictionary<string, int>()
            {
                { "unused/boot", 5 },
                { "unused/poop", 10 },
                { "unused/fish", 3 },
            };
            ItemSpawner.SpawnItems(0, 1920, 1080, 1080 - waveLength * 1080, items);
            spawnedItems = true;
        }
        return -pos;
	}
}

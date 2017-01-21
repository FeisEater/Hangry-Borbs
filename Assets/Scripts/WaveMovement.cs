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
        TestSpawn();
	}

    void TestSpawn()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Dictionary<string, int> items = new Dictionary<string, int>()
            {
                { "unused/boot", 5 },
                { "unused/poop", 10 },
                { "unused/fish", 3 },
            };
            SpawnItems(0, 1920, 1080, 1080 - 512, items);
        }
    }

    void SpawnItems(float left, float right, float top, float bottom, Dictionary<string, int> items)
    {
        foreach (string type in items.Keys)
        {
            for (int i = 0; i < items[type]; i++)
            {
                for (int tries = 0; tries < 10; tries++)
                {
                    float x = Random.Range(left, right);
                    float y = Random.Range(bottom, top);
                    bool validPosition = true;
                    foreach (SpriteRenderer other in FindObjectsOfType<SpriteRenderer>())
                    {
                        Bounds placedItemsBounds = new Bounds(new Vector3(x, y, 0), new Vector3(64, 64, 0.1f));
                        if (other.bounds.Intersects(placedItemsBounds))
                        {
                            validPosition = false;
                            break;
                        }
                    }
                    if (validPosition)
                    {
                        Instantiate(Resources.Load(type), new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kotilo : MonoBehaviour {
    public float crabProbability;
    public Sprite crab;
	// Use this for initialization
	void Start () {
        if (Random.value < crabProbability)
        {
            GetComponent<Food>().points = 0;
            GetComponent<Item>().isOneWaveItem = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Food>().points == 0 && GetComponent<Food>().timeToEat <= 0.3f)
        {
            GetComponent<SpriteRenderer>().sprite = crab;
            GetComponent<Food>().timeToEat = 0.3f;
        }
	}
}

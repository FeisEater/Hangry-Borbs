using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kotilo : MonoBehaviour {
    public float crabProbability;
	// Use this for initialization
	void Start () {
        if (Random.value < crabProbability)
        {
            Debug.Log("hehe");
            GetComponent<Food>().points = 0;
            GetComponent<Item>().isOneWaveItem = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

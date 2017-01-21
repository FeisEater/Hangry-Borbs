using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildCard : MonoBehaviour {
    public float BadProbability;
    public int points;
    public float timeToEat;
	// Use this for initialization
	void Start () {
		if (Random.value < BadProbability)
        {
            GetComponent<Item>().isOneWaveItem = true;
        }
        else
        {
            Food food = gameObject.AddComponent<Food>();
            food.points = points;
            food.timeToEat = timeToEat;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

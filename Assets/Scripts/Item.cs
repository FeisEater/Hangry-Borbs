using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    private float time;
	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (time < 1)
        {
            time += Time.deltaTime * 2;
            GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, time);
        }
    }
}

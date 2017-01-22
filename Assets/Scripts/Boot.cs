using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : MonoBehaviour {
    public Sprite merisiili;
    public Sprite sausage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<Borb>() != null && GetComponent<Food>() == null)
            GetComponent<SpriteRenderer>().sprite = merisiili;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<Borb>() != null && GetComponent<Food>() != null)
            GetComponent<SpriteRenderer>().sprite = sausage;
    }
}

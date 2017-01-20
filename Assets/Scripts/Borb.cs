using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borb : MonoBehaviour {
    public float rotationSpeed;
    public float moveSpeed;

    private bool clockwise;
	// Use this for initialization
	void Start () {
        clockwise = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!Input.GetButton("Fire1"))
        {
            transform.Translate(Vector3.up * moveSpeed);
            if (clockwise)
                transform.Rotate(Vector3.forward, -rotationSpeed);
            else
                transform.Rotate(Vector3.forward, rotationSpeed);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            clockwise = !clockwise;
        }
	}
}

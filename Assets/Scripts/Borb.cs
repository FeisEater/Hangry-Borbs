using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borb : MonoBehaviour {
    public float rotationSpeed;
    public float moveSpeed;
    public int playerId;

    private bool clockwise;
	// Use this for initialization
	void Start () {
        clockwise = true;
	}
	
	// Update is called once per frame
	void Update () {
        string keyName = "Player" + playerId;
        if (!Input.GetButton(keyName))
        {
            transform.Translate(Vector3.up * moveSpeed);
            if (clockwise)
                transform.Rotate(Vector3.forward, -rotationSpeed);
            else
                transform.Rotate(Vector3.forward, rotationSpeed);
        }
        if (Input.GetButtonDown(keyName))
        {
            clockwise = !clockwise;
        }
	}
}

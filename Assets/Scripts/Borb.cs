using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borb : MonoBehaviour {
    public float rotationSpeed;
    public float moveSpeed;
    public int playerId;
    public float rightBorder;
    public float leftBorder;
    public float topBorder;
    public float bottomBorder;

    private bool clockwise;
    private string keyName;

	// Use this for initialization
	void Start () {
        clockwise = true;
        keyName = "Player" + playerId;
    }

    // Update is called once per frame
    void Update () {
        HandleButton();
        CheckBorder();
    }

    void HandleButton()
    {
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

    void CheckBorder()
    {
        if (transform.position.x > rightBorder)
        {
            transform.position = new Vector3(rightBorder, transform.position.y, 0);
            transform.rotation = Quaternion.Euler(0, 0, -transform.rotation.eulerAngles.z);
        }
        if (transform.position.x < leftBorder)
        {
            transform.position = new Vector3(leftBorder, transform.position.y, 0);
            transform.rotation = Quaternion.Euler(0, 0, -transform.rotation.eulerAngles.z);
        }
        if (transform.position.y < bottomBorder)
        {
            transform.position = new Vector3(transform.position.x, bottomBorder, 0);
            transform.rotation = Quaternion.Euler(0, 0, 180 - transform.rotation.eulerAngles.z);
        }
        if (transform.position.y > topBorder)
        {
            transform.position = new Vector3(transform.position.x, topBorder, 0);
            transform.rotation = Quaternion.Euler(0, 0, 180 - transform.rotation.eulerAngles.z);
        }
    }
}

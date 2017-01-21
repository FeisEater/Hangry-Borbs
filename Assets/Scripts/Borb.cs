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
    public float collisionForce;
    public float ramForce;
    public float collisionStunTime;
    public float waveWashStunTime;

    private bool clockwise;
    private string keyName;
    private bool stunned;
    private float curStunTime;
    private bool stopped;

	// Use this for initialization
	void Start () {
        clockwise = true;
        keyName = "Player" + playerId;
        stunned = false;
    }

    // Update is called once per frame
    void Update () {
        if (curStunTime > 0)
        {
            curStunTime -= Time.deltaTime;
        }
        else
        {
            stunned = false;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        HandleButton();
        CheckBorder();
        CheckWave();
    }

    void HandleButton()
    {
        if (stunned)
            return;
        stopped = Input.GetButton(keyName);
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

    void CheckWave()
    {
        GameObject wave = FindObjectOfType<WaveMovement>().gameObject;
        if (wave.transform.position.y < transform.position.y && !stunned)
        {
            stunned = true;
            curStunTime = waveWashStunTime;
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 3.5f * transform.position.y;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            float force = collisionForce;
            if (!coll.gameObject.GetComponent<Borb>().stopped)
            {
                stunned = true;
                if (curStunTime < collisionStunTime)
                    curStunTime = collisionStunTime;
            }
            else
                force = ramForce;
            coll.rigidbody.AddForce((coll.transform.position - transform.position).normalized * force, ForceMode2D.Impulse);
        }
    }
}

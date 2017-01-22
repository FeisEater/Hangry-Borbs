using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text scoreText;

    [HideInInspector] public int points;
    private bool clockwise;
    private string keyName;
    private bool stunned;
    private float curStunTime;
    private bool stopped;
    [HideInInspector] public Vector3 storedOffset;
    [HideInInspector] public bool dontCollide;


	//Sprites
	public Sprite sprite1Borb;
	public Sprite sprite2Borb;
	public Sprite sprite3Borb;
	public Sprite sprite4Borb;
	private int currentSpriteIndex;
	public Sprite[] borbSprites;
	public Sprite borbPeck;
	public Sprite borbStun;



	// Use this for initialization
	void Start () {
        clockwise = true;
        keyName = "Player" + playerId;
        stunned = false;
        points = 0;
		if (scoreText != null) {
			scoreText.text = "0";
		}
        dontCollide = false;

		borbSprites = new Sprite[4]{
			sprite1Borb,
			sprite2Borb,
			sprite3Borb,
			sprite4Borb
		};
    }

    // Update is called once per frame
    void Update () {
		
		//set sprite
		currentSpriteIndex++;
		if (currentSpriteIndex > 3) {
			currentSpriteIndex = 0;
		}
		gameObject.GetComponentInChildren<SpriteRenderer> ().sprite = borbSprites [currentSpriteIndex];
		if (stunned) {
			gameObject.GetComponentInChildren<SpriteRenderer> ().sprite = borbStun;
		} else if (stopped) {
			gameObject.GetComponentInChildren<SpriteRenderer> ().sprite = borbPeck;
		}
		gameObject.GetComponentInChildren<SpriteRenderer> ().flipX = !(transform.rotation.eulerAngles.z > 0 && transform.rotation.eulerAngles.z < 180);

        GetComponent<Rigidbody2D>().angularVelocity = 0;
        if (curStunTime > 0)
        {
            curStunTime -= Time.deltaTime;
        }
        else
        {
            stunned = false;
        }
        HandleButton();
		//AlternativeHandleButton();
        CheckBorder();
        CheckWave();
		if (scoreText != null) {
			scoreText.text = playerId + "'s score: " + points;
		}
    }

    void HandleButton()
    {
        //If we don't want the sprites to rotate, separate sprite to different gameObject and set it as child
        transform.GetChild(0).rotation = Quaternion.identity;
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

	void AlternativeHandleButton()
	{
		if (stunned)
			return;
		if (Input.GetButton(keyName)) {
			transform.Rotate (Vector3.forward, -rotationSpeed * 2);
		} else {
			transform.Translate(Vector3.up * moveSpeed);
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
        if (coll.gameObject.tag == "Player" && !coll.gameObject.GetComponent<Borb>().dontCollide && !dontCollide)
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
		else if (coll.gameObject.tag == "Obstacle"){
			float force = ramForce;
            stunned = true;
            if (curStunTime < collisionStunTime)
                curStunTime = collisionStunTime;
            gameObject.GetComponent<Rigidbody2D>().AddForce(
				(Vector2)(transform.position - coll.transform.position).normalized * force, ForceMode2D.Impulse);
		}
    }

    

    public bool CanEat()
    {
        return stopped && !stunned && !dontCollide;
    }


    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    public int points;
    public float timeToEat;

    private ArrayList consumers;
	// Use this for initialization
	void Start () {
        consumers = new ArrayList();
        GetComponent<Collider2D>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Borb consumer in consumers)
            if (consumer.CanEat())  Consume(consumer);
	}

    public void Consume(Borb player)
    {
        timeToEat -= Time.fixedDeltaTime;
        if (timeToEat < 0)
        {
            player.points += points;
            
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<Borb>() != null)
            consumers.Add(coll.gameObject.GetComponent<Borb>());
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<Borb>() != null)
            consumers.Remove(coll.gameObject.GetComponent<Borb>());
    }
}

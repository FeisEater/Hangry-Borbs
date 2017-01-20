using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisteet : MonoBehaviour {

    
    public int points;
 

    // Use this for initialization
    void Start () {

        points = 0;
		
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ananas") {
            points +=  10;
        }
        Destroy(other.gameObject);
        Debug.Log(points);
    }

    private void Update()
    {
       
    }
}

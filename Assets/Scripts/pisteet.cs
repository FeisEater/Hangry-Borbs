using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisteet : MonoBehaviour {

    public float kotiloaika;
    public int points;
 

    // Use this for initialization
    void Start () {

        points = 0;
		
	}

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ananas")
        {

            points += 10;
            Debug.Log(points);
            Destroy(collision.gameObject);
        }

        while (collision.gameObject.tag == "kotilo")
        {

            if (kotiloaika == 2)
            {
                points += 50;
                Debug.Log(points);
                Destroy(collision.gameObject);
            }
         }

   }

    private void Update()
    {
       
    }
}

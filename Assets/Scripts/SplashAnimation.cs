using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashAnimation : MonoBehaviour {
    private float alpha = 0;
    private float timer = 0;
	// Use this for initialization
	void Start () {
        GetComponent<Image>().color = new Color(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        GetComponent<Image>().color = new Color(alpha, alpha, alpha);
        if (timer < 1)
            alpha = timer;
        if (timer > 1 && timer < 4)
            alpha = 1;
        if (timer > 4)
            alpha = 1 - (timer - 4);
        if (timer > 5)
            Application.LoadLevel(1);
    }
}

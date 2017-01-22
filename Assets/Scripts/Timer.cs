using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLeft;

    public Text text;



    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Time Left:" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            Debug.Log("GAMEOVER");
            //Application.LoadLevel("gameOver");
        }
    }
}

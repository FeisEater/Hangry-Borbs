using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HighScore : MonoBehaviour {
	public int sceneIndex;

	// Use this for initialization
	void Start () {
        DataManager dm = FindObjectOfType<DataManager>();
        Text scoreText = GameObject.Find("Other score").GetComponent<Text>();
        Text winnerText = GameObject.Find("Winner Text").GetComponent<Text>();
        scoreText.text = "";
        winnerText.text = "";
        foreach (KeyValuePair<string, int> item in dm.scores.OrderBy(key => -key.Value))
        {
            if (winnerText.text == "")
                winnerText.text = "Key " + item.Key + " is a weiner, with " + item.Value + " points!";
            scoreText.text += "Key " + item.Key + " - " + item.Value + "\n";
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space))
            Application.LoadLevel(sceneIndex);
    }
}

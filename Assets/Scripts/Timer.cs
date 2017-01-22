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
            DataManager dm = FindObjectOfType<DataManager>();
            dm.scores = new Dictionary<string, int>();
            string idToKey = "_qazcbmkp";
            foreach (Borb plr in FindObjectsOfType<Borb>())
                dm.scores.Add(idToKey[plr.playerId].ToString(), plr.points);
            Application.LoadLevel(3);
        }
    }
}

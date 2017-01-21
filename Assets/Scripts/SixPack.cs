using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixPack : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Borb[] players = FindObjectsOfType<Borb>();
        Vector3 sum = Vector3.zero;
        foreach (Borb plr in players)
            sum += plr.transform.position / players.Length;
        foreach (Borb plr in players)
        {
            plr.transform.parent.position = sum;
            plr.storedOffset = plr.transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update () {
        /*Borb[] players = FindObjectsOfType<Borb>();
        Vector3 sum = Vector3.zero;
        foreach (Borb plr in players)
            sum += plr.transform.position / players.Length;
        foreach (Borb plr in players)
        {
            plr.transform.parent.position = sum;
            plr.transform.localPosition = plr.storedOffset;
        }*/
    }
}

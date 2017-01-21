using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixPack : MonoBehaviour {
    private ArrayList borbs;
    public float time;
	// Use this for initialization
	void Start () {
        borbs = new ArrayList();
    }

    // Update is called once per frame
    void Update () {
        if (borbs.Count > 0)
            time -= Time.deltaTime;
        if (time < 0)
        {
            foreach (Borb plr in borbs)
            {
                plr.transform.SetParent(null);
                plr.dontCollide = false;
            }
            Destroy(gameObject);
            return;
        }
        Vector3 sum = Vector3.zero;
        foreach (Borb plr in borbs)
            sum += (plr.transform.localPosition - plr.storedOffset);
        transform.position += sum.normalized * 6;
        foreach (Borb plr in borbs)
            plr.transform.localPosition = plr.storedOffset;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<Borb>() != null)
        {
            GetComponent<Item>().isOneWaveItem = false;
            borbs.Add(coll.GetComponent<Borb>());
            coll.GetComponent<Borb>().dontCollide = true;
            foreach (Borb plr in borbs)
            {
                plr.transform.SetParent(transform);
                plr.storedOffset = plr.transform.localPosition;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieScript : MonoBehaviour {
    public int nextSceneIndex;
    private MovieTexture movie;
    private bool canSkip;
	// Use this for initialization
	void Start () {
        movie = ((MovieTexture)GetComponent<RawImage>().mainTexture);
        movie.Play();
        canSkip = false;
    }

    // Update is called once per frame
    void Update () {
        if (!movie.isPlaying || (canSkip && Input.GetKeyDown(KeyCode.Space)))
        {
            Application.LoadLevel(nextSceneIndex);
        }
        if (Input.anyKeyDown)
        {
            canSkip = true;
            GameObject.Find("Skip Message").GetComponent<Text>().enabled = true;
        }
    }
}

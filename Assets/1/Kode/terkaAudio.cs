using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terkaAudio : MonoBehaviour {
    public GameObject audioMan;
	// Use this for initialization
	void Start () {
        if (FindObjectOfType<backsoundScript>())
            return;
        else
        {
            Instantiate(audioMan, transform.position, transform.rotation);
        }
	}
}

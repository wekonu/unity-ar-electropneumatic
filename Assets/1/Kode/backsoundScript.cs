using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backsoundScript : MonoBehaviour
{
    public AudioSource BGM;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(FindObjectsOfType<backsoundScript>().Length > 1)
        {
            Destroy(gameObject);
        };
    }
    public void changeBGM(AudioClip music)
    {
        if (BGM.clip.name == music.name)
            return;
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}

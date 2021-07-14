using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pendataanMula : MonoBehaviour {
    public string sound;
    public string cBoard;
    private backsoundScript theAM;
    GameObject inGameToggle;
    public bool muted;

    void Awake()
    {
        soundCheck();
        gameSkorCheck();
        kuisProgressCheck();
    }

    void Start()
    {
        inGameToggle = GameObject.Find("Toggle");
        theAM = FindObjectOfType<backsoundScript>();
        if (muted == false)
        {
            if (theAM.BGM.isPlaying)
                return;
            theAM.BGM.Play();
            inGameToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            theAM.BGM.Stop();
            inGameToggle.GetComponent<Toggle>().isOn = false;
        };
    }

    public void soundCheck()
    {
        if (PlayerPrefs.HasKey("sound"))
        {
            sound = PlayerPrefs.GetString("sound");
            if (sound == "enabled")
            {
                muted = false;
            };
            if (sound == "disabled")
            {
                muted = true;
            };
        }
        else
        {
            muted = false;
            PlayerPrefs.SetString("sound", "enabled"); PlayerPrefs.Save();
        };
    }

    public void gameSkorCheck()
    {
        if (PlayerPrefs.HasKey("gameScore"))
        {
            //do nothing
        }
        else
        {
            PlayerPrefs.SetString("gameScore", "0"); PlayerPrefs.Save();
        };
    }

    public void kuisProgressCheck()
    {
        if (PlayerPrefs.HasKey("kuisProgress"))
        {
            //do nothing
        }
        else
        {
            PlayerPrefs.SetString("kuisProgress", "0"); PlayerPrefs.Save();
        };
    }
}

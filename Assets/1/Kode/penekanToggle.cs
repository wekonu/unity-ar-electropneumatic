using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penekanToggle : MonoBehaviour {
    private backsoundScript theAM;
    public string sound;

    public void toggle(bool mantap)
    {
        theAM = FindObjectOfType<backsoundScript>();
        sound = PlayerPrefs.GetString("sound");
        if (mantap == true)
        {
            theAM.BGM.Play();
            PlayerPrefs.SetString("sound", "enabled"); PlayerPrefs.Save();
        };
        if (mantap == false)
        {
            theAM.BGM.Stop();
            PlayerPrefs.SetString("sound", "disabled"); PlayerPrefs.Save();
        };
    }
}

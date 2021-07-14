using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suaraStateChanger : MonoBehaviour {

    public void stateSuara(string state)
    {
        PlayerPrefs.SetString("sound", state);
    }
}

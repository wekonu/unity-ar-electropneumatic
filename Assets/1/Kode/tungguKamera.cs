using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tungguKamera : MonoBehaviour {
    public float delay;
    public string NewLevelString;
	// Use this for initialization
	void Start ()
    {
        //PlayerPrefs.SetString("kuisProgress", "0"); PlayerPrefs.Save();
        StartCoroutine(Tunggu());
        SceneManager.LoadScene("MenuUtama");
    }

    IEnumerator Tunggu()
    {
        yield return new WaitForSeconds(2);
    }
}

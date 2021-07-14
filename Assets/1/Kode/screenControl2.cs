using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenControl2 : MonoBehaviour {
    public void Quit()
    {
        Application.Quit();
    }

    public void switchTo(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void gotoURL(string url)
    {
        Application.OpenURL(url);
    }
}

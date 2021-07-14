using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class halamanUtama : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "home")
            {
                SceneManager.LoadScene("transitkeExit");
            }
            else if (SceneManager.GetActiveScene().name == "transitkeExit")
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene("home");
            }
        }
    }

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

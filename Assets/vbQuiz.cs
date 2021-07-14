using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbQuiz : MonoBehaviour, IVirtualButtonEventHandler {

    public string buttonName;
    public GameObject button;
    private GameManager manager;
    public GameObject threeDeeButton;

    // Use this for initialization
    void Start()
    {
        button = GameObject.Find(buttonName);
        button.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        threeDeeButton.SetActive(false);
    }
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        if (PlayerPrefs.GetString("kuisProgress") == "1")
        {
            manager = FindObjectOfType<GameManager>();
            threeDeeButton.SetActive(true);
            manager.UserSelectTrue();
        }
    }
}

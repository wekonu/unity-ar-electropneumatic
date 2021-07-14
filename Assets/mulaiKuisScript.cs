using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class mulaiKuisScript : MonoBehaviour, IVirtualButtonEventHandler {

    public string buttonName;
    public GameObject vbButtonMulai;
    public GameObject vbButtonBenar;
    public GameObject vbButtonSalah;
    private GameManager manager;
    public GameObject buttonBenar;
    public GameObject buttonSalah;
    public GameObject buttonMulai;
    private timerScript timer;

    //awake will be still called regardless the script is disabled
    void Awake()
    {
        vbButtonMulai = GameObject.Find(buttonName);
        vbButtonMulai.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //vbButtonBenar.SetActive(false); 
        buttonBenar.SetActive(false);
        //vbButtonSalah.SetActive(false); 
        buttonSalah.SetActive(false);
    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        buttonMulai.SetActive(false);
    }
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        if (PlayerPrefs.GetString("kuisProgress") == "0")
        {
            PlayerPrefs.SetString("kuisProgress", "1"); PlayerPrefs.Save();
            buttonBenar.SetActive(true);
            buttonSalah.SetActive(true);
            manager = FindObjectOfType<GameManager>();
            manager.GetRandomQuestion();
            timer = FindObjectOfType<timerScript>();
            timer.startCount();
        }
    }
}

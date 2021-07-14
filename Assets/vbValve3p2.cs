using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbValve3p2 : MonoBehaviour, IVirtualButtonEventHandler {

    public string buttonName;
    public GameObject button;
    public GameObject threeDeeButton;
    public Animator anim;
	// Use this for initialization
	void Start () {
        button = GameObject.Find(buttonName);
        anim.GetComponent<Animator>();
        button.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
	}

    public string animOnPressed;
    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        threeDeeButton.SetActive(false);
        anim.Play(animOnPressed);
    }
    public string animOnReleased;
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        anim.Play(animOnReleased);
        threeDeeButton.SetActive(true);
    }
	
}

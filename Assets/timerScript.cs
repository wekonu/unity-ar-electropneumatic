using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour {

    public float kuisTime;
    private float timeRemain;
    private GameManager manager;
    private float startTime;
    public bool useTimer = false;

    [SerializeField]
    private TextMesh timerText;

	// Use this for initialization
	void Awake () {
        //
	}
	
	// Update is called once per frame
	void Update () {
        if (useTimer == true)
        {
            timeRemain = startTime - Time.time;

            timerText.text = "Waktu tersisa: " + timeRemain.ToString("f0");

            if (timeRemain>0 && timeRemain<2)
            {
                timerText.text = "Waktu habis";
            };
            if (timeRemain < 0)
            {
                manager = FindObjectOfType<GameManager>();
                manager.removeQuestion();
                manager.GetRandomQuestion();
                startTime = Time.time + kuisTime;
            }
        }
	}

    public void startCount()
    {
        useTimer = true;
        startTime = Time.time + kuisTime;
        //StartCoroutine("LoseTime");
    }

    public void stopCount()
    {
        useTimer = false;
        //StopCoroutine("LoseTime");
    }
}

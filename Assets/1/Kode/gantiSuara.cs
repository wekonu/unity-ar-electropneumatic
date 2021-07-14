using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gantiSuara : MonoBehaviour
{
    private backsoundScript theAM;
    // Use this for initialization
    void Start()
    {
        stopMusic();
    }

    public void stopMusic()
    {
        theAM = FindObjectOfType<backsoundScript>();
        theAM.BGM.Stop();
    }

    public void playMusic()
    {
        theAM = FindObjectOfType<backsoundScript>();
        theAM.BGM.Play();
    }

    public void changeMusic(AudioClip audioTrack)
    {
        if (audioTrack != null)
            theAM.changeBGM(audioTrack);
    }
}

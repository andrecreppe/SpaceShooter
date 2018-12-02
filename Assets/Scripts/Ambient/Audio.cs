using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour 
{
    //Variables:
    public bool playSound = true;
    private bool pause;
    private bool option;

    public AudioSource music;


    //Main Functions:
    private void Update()
    {
        pause = Pause_Menu.isPaused;
        option = Option_Menu.music;

        if (pause && option)
            AudioListener.volume = 0f;
        else
            AudioListener.volume = 1f;  
    }
}

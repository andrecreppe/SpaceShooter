using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
    //Variables:
    public Text tintbtn, trackpadbt;

    public GameObject trackpad, trackpad_text, trackpad_title;
    public GameObject tilt, tilt_text, tilt_title;


    //Main Functions
    private void Start()
    {
        LoadTrackpad();
    }


    //Functions:
    public void ReturnIntro()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }

    public void LoadTrackpad()
    {
        tintbtn.color = new Color32(255, 0, 0, 145);
        trackpadbt.color = new Color32(0, 255, 0, 255);

        trackpad.SetActive(true);
        trackpad_text.SetActive(true);
        trackpad_title.SetActive(true);

        tilt.SetActive(false);
        tilt_text.SetActive(false);
        tilt_title.SetActive(false);
    }

    public void LoadTilt()
    {
        trackpadbt.color = new Color32(255, 0, 0, 145);
        tintbtn.color = new Color32(0, 255, 0, 255);
        
        trackpad.SetActive(false);
        trackpad_text.SetActive(false);
        trackpad_title.SetActive(false);

        tilt.SetActive(true);
        tilt_text.SetActive(true);
        tilt_title.SetActive(true);
    }
}

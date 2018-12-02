using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

    //Variables:
    public static bool isPaused = false;

    public GameObject pauseUI;
    public GameObject optionsGear;


    //Personal functions:
    public void Pause()
    {
        pauseUI.SetActive(true);
        optionsGear.SetActive(true);
        Time.timeScale = 0f; //stop the time = stop the game
        isPaused = true;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        optionsGear.SetActive(false);
        Time.timeScale = 1f; //resume the game
        isPaused = false;
    }

    public void Restart()
    {
        Scene jogo = SceneManager.GetActiveScene();
        SceneManager.LoadScene(jogo.name);

        Resume();
    }

    public void Exit()
    {
        isPaused = false;
        SceneManager.LoadScene("Intro");
    }
}

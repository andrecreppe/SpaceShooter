using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro_Controller : MonoBehaviour
{
    //Variables:
    public Text startText;
    public Text gameName;

    public float blink_time;


    //Main Functions:
    private void Start()
    {
        gameName.text = "SPACE\nSHOOTER";
        StartCoroutine("Blink");

        Time.timeScale = 1f;
    }

	/*
	 * PC VERSION == Start by a keyboard
     * 
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StopAllCoroutines();
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
    */

    //Coroutines:
    IEnumerator Blink()
    {
        while (true)
        {
            startText.text = "TOUCH TO START";
            yield return new WaitForSeconds(blink_time);
            startText.text = "";
            yield return new WaitForSeconds(blink_time);
        }
    }


    //Functions:
    public void GoToTutorial()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void StartGame()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}

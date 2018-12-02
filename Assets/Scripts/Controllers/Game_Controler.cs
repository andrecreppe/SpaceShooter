using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controler : MonoBehaviour
{
    //Variables:
    public GameObject[] lifes;
    public GameObject[] hazards;
    public GameObject player;
    public GameObject pwrupHazard;
    public GameObject restartButton;

    public Text scoreText;
    //public Text restartText;
    public Text gameOverText;
    public Text highscoreText;

    private bool gameOver;
    //private bool restart;

    public int hazardCount;

    private int highscore;
    private int score;
    private int times;
    private int lifeCount;

    public float startWait;
    public float spawnWait;
    public float waveWait;

    private float boundaryMin;
    private float boundaryMax;

    private string keyy = "High";


    //Main Functions:
    private void Start()
    {
        //restart = false;
        restartButton.SetActive(false);
        gameOver = false;
        gameOverText.text = "";

        boundaryMin = -5.0f;
        boundaryMax = 5.0f;

        lifeCount = 0;
        times = 0;
        score = 0;

        UpdateScore();

        if(PlayerPrefs.HasKey(keyy))
        {
            highscore = PlayerPrefs.GetInt(keyy);
            highscoreText.text = "High: " + highscore;
        }
        else
        {
            PlayerPrefs.SetInt(keyy, 0);
            highscoreText.text = "High: 0";
        }

        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

        if (gameOver)
            scoreText.text = "Final Score: " + score;
    }


    //Coroutines:
    IEnumerator SpawnWaves()
    {
        while(true) {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                times += 1;
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(boundaryMin, boundaryMax), 0.0f, 16.0f);
                Quaternion spawnRotation = Quaternion.identity;

                if(i == (hazardCount/2) && (times%3==0))
                    Instantiate(pwrupHazard, spawnPosition, spawnRotation);
                else
                    Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartButton.SetActive(true);
                //restart = true;
                break;
            }
        }
    }


    //Personal Functions:
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue) 
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        GameObject life = lifes[lifeCount];
        Destroy(life);
        lifeCount++;

        if (lifeCount == lifes.Length)
        {
            Destroy(player);
            gameOverText.text = "Game Over!";
            gameOver = true;

            if (score > highscore)
            {
                PlayerPrefs.SetInt(keyy, score);
                highscoreText.text = "Max: " + score;
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}

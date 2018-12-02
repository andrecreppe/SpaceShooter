using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_up : MonoBehaviour
{
    //Variables:
    public GameObject Player;
    public GameObject game;
    public GameObject Explosion;

    private PlayerControler playerControler;

    private Game_Controler gameControler;

    public int score;

    public float duration;


    //Main Functions:
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        game = GameObject.FindWithTag("GameController");

        playerControler = Player.GetComponent<PlayerControler>();
        gameControler = game.GetComponent<Game_Controler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bolt"))
        {
            StartCoroutine("Xablau");
        }
    }


    //Personal Functions:
    IEnumerator Xablau()
    {
        gameControler.AddScore(score);

        Instantiate(Explosion, transform.position, transform.rotation);
        transform.position = new Vector3(transform.position.x, -11.0f, transform.position.y);

        TurnOn();
        yield return new WaitForSeconds(5);
        TurnOff();
    }

    void TurnOn()
    {
        playerControler.pwrUP = true;
    }

    void TurnOff()
    {
        playerControler.pwrUP = false;
        Destroy(gameObject);
    }
}
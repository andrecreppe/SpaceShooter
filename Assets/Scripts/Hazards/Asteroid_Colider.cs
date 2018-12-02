using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Colider : MonoBehaviour
{
    //Variables:
    public GameObject explosion;
    public GameObject playerExplosion;

    private Game_Controler gameController;

    public int scoreValue;


    //Main Functions:
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<Game_Controler>();
        if (gameController == null)
            Debug.Log("Cannot find 'Game Controller' script");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
            return;

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        else
        {
            gameController.AddScore(scoreValue);
        }

        Destroy(gameObject);
    }
}

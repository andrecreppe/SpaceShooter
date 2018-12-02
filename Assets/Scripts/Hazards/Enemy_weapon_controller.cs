using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_weapon_controller : MonoBehaviour 
{
    //Variables:
    private AudioSource audioSource;

    public GameObject shot;

    public Transform shotSpawn;

    public float fireRate;
    public float delay;


    //Main Functions:
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        InvokeRepeating("Fire", delay, fireRate);
    }


    //Personal Functions:
    void Fire() 
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}

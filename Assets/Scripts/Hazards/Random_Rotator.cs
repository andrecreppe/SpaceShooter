using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Rotator : MonoBehaviour 
{
    //Variables:
    private Rigidbody rb;

    public float tumble;


    //Main Functions:
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}

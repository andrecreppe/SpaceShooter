using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
    //Variables:
    private Rigidbody rb;

    public float speed;


    //Main Functions:
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed;
    }
}

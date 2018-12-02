using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Mover : MonoBehaviour 
{
    //Variables:
    private Vector3 startPosition;

    public float scrollSpeed;


    //Main Functions:
    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newPosition =  Mathf.Repeat(Time.time * scrollSpeed, 30.0f);

        transform.position = startPosition + Vector3.forward * newPosition;
    }
}

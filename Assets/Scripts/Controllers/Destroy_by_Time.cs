using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_by_Time : MonoBehaviour 
{
    //Variables:
    public float lifetime;


    //Main Functions:
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}

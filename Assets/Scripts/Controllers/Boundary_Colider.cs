using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary_Colider : MonoBehaviour
{
    //Main Functions:
    private void OnTriggerExit(Collider other)
    { 
        if(other.CompareTag("Powerup"))
        {
            //
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}

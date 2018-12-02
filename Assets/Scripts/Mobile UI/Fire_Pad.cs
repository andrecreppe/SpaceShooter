using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Fire_Pad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Variables:
    private bool touched;
    private bool canFire;

    private int pointerID;


    //Main Functions:
    void Awake()
    {
        touched = false;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
            canFire = true;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerId == pointerID)
        {
            canFire = false;
            touched = false;
        }
    }


    //Personal Functions:
    public bool CanFire()
    {
        return canFire;
    }
}

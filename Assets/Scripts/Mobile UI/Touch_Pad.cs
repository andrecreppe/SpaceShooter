using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Touch_Pad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    //Variables:
    private bool touched;

    private int pointerID;

    public float sensib;

    private string keyy = "Sensib";

    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;

    public Slider slider;


    //Main Functions:
    void Awake()
    {
        touched = false;

        direction = Vector2.zero;

        if (!PlayerPrefs.HasKey(keyy))
        {
            PlayerPrefs.SetFloat(keyy, 0.115f);
            sensib = 0.115f;
            slider.value = sensib;
            //PlayerPrefs.Save();
        }
        else
        {
            sensib = PlayerPrefs.GetFloat(keyy);
            slider.value = sensib;
        }            
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
            origin = data.position;
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if(data.pointerId == pointerID)
        {
            Vector2 currentPosition = data.position;
            Vector2 directionRaw = currentPosition - origin;
            direction = directionRaw.normalized;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if(data.pointerId == pointerID)
        {
            direction = Vector2.zero;
            touched = false;
        }
    }


    //Personal Functions:
    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, sensib);
        return smoothDirection;
    }

    public void ChangeSensib(float num)
    {
        sensib = num;
        PlayerPrefs.SetFloat(keyy, num);
        //PlayerPrefs.Save();
    }
}

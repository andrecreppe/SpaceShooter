using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movment_Selector : MonoBehaviour {

    //Variables
    private string keyy = "Mov";    /*Prefs: Trackpad = 0, Tilt = 1*/

    private bool estado_drag = true;

    public Button botDr, botTil;
    private Text dragtxt, tilttxt;

    public GameObject calibrate;
    public GameObject sensib;

    public PlayerControler pc;


    //Main functions
    private void Awake()
    {
        if (!PlayerPrefs.HasKey(keyy))
        {
            PlayerPrefs.SetInt(keyy, 0);
            //PlayerPrefs.Save();

            changeControlDrag();

            calibrate.SetActive(false);
            sensib.SetActive(true);

            Debug.Log("no key");
            Debug.Log(PlayerPrefs.GetInt(keyy).ToString());
        }
        else
        {
            Debug.Log("has key");
            Debug.Log(PlayerPrefs.GetInt(keyy).ToString());

            int state = PlayerPrefs.GetInt(keyy);

            if (state == 1)
            {
                estado_drag = false;

                calibrate.SetActive(true);
                sensib.SetActive(false);

                changeControlDrag();
                changeControlTilt();
            }
            else
            {
                calibrate.SetActive(false);
                sensib.SetActive(true);

                changeControlDrag();
            }
        }
    }

    private void Start()
    {
        Executar();
    }


    //Functions:
    public void changeControlTilt()
    {
        if(estado_drag) //se estiver no drag ele vai pro tilt
        {
            Executar();
            estado_drag = false;

            dragtxt.color = new Color32(255, 0, 0, 145);
            tilttxt.color = new Color32(0, 255, 0, 255);

            botDr.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            botTil.GetComponent<Image>().color = new Color32(255, 255, 255, 50);

            PlayerPrefs.SetInt(keyy, 1);
            //PlayerPrefs.Save();

            pc.useTilt = true;

            calibrate.SetActive(true);
            sensib.SetActive(false);
        }
    }
    public void changeControlDrag()
    {
        if (!estado_drag) //se estiver no tilt ele vai pro dragpad
        {
            Executar();
            estado_drag = true;

            dragtxt.color = new Color32(0, 255, 0, 255);
            tilttxt.color = new Color32(255, 0, 0, 145);

            botDr.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
            botTil.GetComponent<Image>().color = new Color32(255, 255, 255, 0);

            PlayerPrefs.SetInt(keyy, 0);
            //PlayerPrefs.Save();

            pc.useTilt = false;

            calibrate.SetActive(false);
            sensib.SetActive(true);
        }
    }

    public void Recalibrar_Acelerometro() 
    {
        pc.CalibrateAccelerometer();
    }

    private void Executar()
    {
        botDr = botDr.GetComponent<Button>();
        dragtxt = (Text)botDr.GetComponentInChildren<Text>();

        botTil = botTil.GetComponent<Button>();
        tilttxt = (Text)botTil.GetComponentInChildren<Text>();
    }
}

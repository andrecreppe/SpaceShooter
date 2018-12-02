using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option_Menu : MonoBehaviour {

    //Variables:
    public static bool music = true;
    public static bool sfx = true;

    public GameObject menuUI;
    public GameObject gear;

    public Image Music_Img;
    public Image SFX_Img;

    public AudioSource musicSource;

    public Movment_Selector mov;


    //Main Functions:
    private void Start()
    {
        //Music_Img.GetComponent<Image>().color = new Color32(164, 255, 164, 255);
        //SFX_Img.GetComponent<Image>().color = new Color32(164, 255, 164, 255);
    }


    //Personal Functions:
    public void Options()
    {
        menuUI.SetActive(true);
        gear.SetActive(false);
    }

    public void Return()
    {
        menuUI.SetActive(false);
        gear.SetActive(true);
    }

    public void MuteSFX()
    {
        if (sfx)
        {
            sfx = false;
            //parar o som vindo dos prefabs


            SFX_Img.GetComponent<Image>().color = new Color32(255, 164, 164, 255);
        }
        else
        {
            sfx = true;
            //voltar com o som vindo dos prefabs


            SFX_Img.GetComponent<Image>().color = new Color32(164, 255, 164, 255);
        }
    }

    public void MuteMusic()
    {
        if(music)
        {
            music = false;
            musicSource.Stop();

            Music_Img.GetComponent<Image>().color = new Color32(255, 164, 164, 255);
        }
        else
        {
            music = true;
            musicSource.Play();

            Music_Img.GetComponent<Image>().color = new Color32(164, 255, 164, 255);
        }
    }

    public void Recalibrate()
    {
        mov.Recalibrar_Acelerometro();
    }
}

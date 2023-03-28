using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public GameObject buttonSoundON;
    public GameObject buttonSoundOFF;
    public TMP_Text soudText;
    public bool soundSwitcher = true;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
            {
            if (soundSwitcher)
            {
                GetComponent<AudioSource>().Pause();
                buttonSoundOFF.SetActive(true);
                buttonSoundON.SetActive(false);
                //soudText.text = "Music OFF";
                soundSwitcher = false;
            }
            else
            {
                GetComponent<AudioSource>().Play();
                buttonSoundOFF.SetActive(false);
                buttonSoundON.SetActive(true);
                //soudText.text = "Music ON";
                soundSwitcher = true;
            }
        }
    
    }

}

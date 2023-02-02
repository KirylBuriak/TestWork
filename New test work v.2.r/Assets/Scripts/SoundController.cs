using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Button button;
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
                soudText.text = "Music OFF";
                soundSwitcher = false;
            }
            else
            {
                GetComponent<AudioSource>().Play();
                soudText.text = "Music ON";
                soundSwitcher = true;
            }
        }
    
    }

}

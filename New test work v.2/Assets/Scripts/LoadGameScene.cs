using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameScene : MonoBehaviour
{
    public AudioSource clickButton;
    public AudioSource player;

    public Toggle easyChoise;
    public Toggle hardChoise;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMyGameScene()
    {
        if (easyChoise.isOn)
        {
            clickButton.Play();
            player.Stop();
            SceneManager.LoadScene(4);
        }

        if(hardChoise.isOn)
        {
            clickButton.Play();
            player.Stop();
            SceneManager.LoadScene(1);
        }
    }
}

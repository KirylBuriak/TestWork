using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    public AudioSource clickButton;
    public AudioSource player;

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
        clickButton.Play();
        player.Stop();
        SceneManager.LoadScene(1);
    }
}

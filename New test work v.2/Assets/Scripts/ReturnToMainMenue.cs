using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReturnToMainMenue : MonoBehaviour
{
    public GameResultDoc gameResult;
    public TMP_Text zombieKilledResult;
    public TMP_Text gameScore;

    // Start is called before the first frame update
    void Start()
    {
        zombieKilledResult.text = "Zombie Killed: " + gameResult.zombieKilledResult.ToString();
        gameScore.text = "Game Score: " + gameResult.totalGameScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenueScene()
    {
        SceneManager.LoadScene(0);
    }
}

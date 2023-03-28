using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DeadZombieManager : MonoBehaviour
{
    public TMP_Text killesZombieText;
    private int killZombieCounter = 0;
    public int gameGoal;
    public TMP_Text gameGoalText;
    public GameResultDoc resultDoc;
    public TMP_Text gameScore;
    private int scoreCounter = 0;

    public GameObject winGameMessage;

    private void Start()
    {
        killesZombieText.text = killZombieCounter.ToString();
        gameScore.text = scoreCounter.ToString();
        gameGoalText.text = gameGoal.ToString();
        EventAggregator.Subscribe<ZombieKillHeandler>(OnZombiekilledEvent);
        winGameMessage.SetActive(false);
    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<ZombieKillHeandler>(OnZombiekilledEvent);
    }

    private void OnZombiekilledEvent(object sender, ZombieKillHeandler zombieKilled)
    {
        killZombieCounter += 1;
        killesZombieText.text = killZombieCounter.ToString();
        resultDoc.zombieKilledResult = killZombieCounter;

        scoreCounter += Random.Range(0,100);
        gameScore.text = scoreCounter.ToString();
        resultDoc.totalGameScore = scoreCounter;

        if(killZombieCounter >= gameGoal)
        {
            EventAggregator.Post<PlayerEndGame>(this, new PlayerEndGame(true));
            winGameMessage.SetActive(true);
            StartCoroutine(LoadWinScene());

        }
    }

    private IEnumerator LoadWinScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }
}

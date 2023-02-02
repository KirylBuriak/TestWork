using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeadZombieManager : MonoBehaviour
{
    public TMP_Text killesZombieText;
    private int killZombieCounter = 0;
    public GameResultDoc resultDoc;

    private void Start()
    {
        killesZombieText.text = "Zombie Killed: " + killZombieCounter.ToString();
        EventAggregator.Subscribe<ZombieKillHeandler>(OnZombiekilledEvent);
    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<ZombieKillHeandler>(OnZombiekilledEvent);
    }

    private void OnZombiekilledEvent(object sender, ZombieKillHeandler zombieKilled)
    {
        killZombieCounter += 1;
        killesZombieText.text = "Zombie Killed: " + killZombieCounter.ToString();
        resultDoc.zombieKilledResult = killZombieCounter;
    }
}

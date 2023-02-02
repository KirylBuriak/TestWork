using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealsController : MonoBehaviour
{
    public float playerHealth;
    public Slider playerLifeLine;
    public List<GameObject> gameUIList;
    public List<GameObject> gameEndUIList;
    public AudioSource healSound;
   

    void Start()
    {
        playerLifeLine.maxValue = playerHealth;
        playerLifeLine.value = playerLifeLine.maxValue;
        EventAggregator.Subscribe<ZombieHitPlayer>(OnHitPlayer);
        EventAggregator.Subscribe<Healing>(OnHealingEvent);
        StartGameUI();


    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<ZombieHitPlayer>(OnHitPlayer);
        EventAggregator.Unsubscribe<Healing>(OnHealingEvent);
    }

    void Update()
    {
        if (playerLifeLine.value <= 0)
            EndGameUISwitcher();
    }

    private void OnHitPlayer(object sender, ZombieHitPlayer hit)
    {
        playerLifeLine.value -= hit.hitForce;
    }

    private void EndGameUISwitcher()
    {
        EventAggregator.Post<PlayerEndGame>(this, new PlayerEndGame());
        SceneManager.LoadScene(2);
    }
   

    public void StartGameUI()
    {

        foreach (var curUI in gameUIList)
        {
            curUI.SetActive(true);
        }

    }


    private void OnHealingEvent(object sender, Healing heal)
    {
        playerLifeLine.value = playerLifeLine.maxValue;
        healSound.Play();
    }
}

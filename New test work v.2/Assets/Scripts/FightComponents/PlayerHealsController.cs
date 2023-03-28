using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealsController : MonoBehaviour
{
    public float playerHealth;
    public Slider playerLifeLine;
    public TMP_Text lifeCondition; 
    public List<GameObject> gameUIList;
    public List<GameObject> gameEndUIList;
    public AudioSource healSound;

    public GameObject lostGameMessage;
   

    void Start()
    {
        playerLifeLine.maxValue = playerHealth;
        playerLifeLine.value = playerLifeLine.maxValue;
        lifeCondition.text = playerLifeLine.value.ToString() + "<#afd9e9>  / " + playerLifeLine.maxValue.ToString();
        EventAggregator.Subscribe<ZombieHitPlayer>(OnHitPlayer);
        EventAggregator.Subscribe<Healing>(OnHealingEvent);
        StartGameUI();

        lostGameMessage.SetActive(false);


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
        lifeCondition.text = playerLifeLine.value.ToString() + "<#afd9e9>  / " + playerLifeLine.maxValue.ToString();
    }

    private void EndGameUISwitcher()
    {
        EventAggregator.Post<PlayerEndGame>(this, new PlayerEndGame(false));
        lostGameMessage.SetActive(true);
        StartCoroutine(LoadLostScene());

    }
   

    public void StartGameUI()
    {

        foreach (var curUI in gameUIList)
        {
            curUI.SetActive(true);
        }

    }

    private IEnumerator LoadLostScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }


    private void OnHealingEvent(object sender, Healing heal)
    {
        playerLifeLine.value = playerLifeLine.maxValue;
        lifeCondition.text = playerLifeLine.value.ToString() + "<#afd9e9>  / " + playerLifeLine.maxValue.ToString();
        healSound.Play();
    }
}

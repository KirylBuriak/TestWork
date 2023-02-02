using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlayerGame : MonoBehaviour
{

    
    void Start()
    {
        EventAggregator.Subscribe<PlayerEndGame>(EndGame);   
    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<PlayerEndGame>(EndGame);
    }

    void Update()
    {
        EventAggregator.Post<PlayerPosition>(this, new PlayerPosition(gameObject.transform));
    }

    private void EndGame(object sender, PlayerEndGame end)
    {
        gameObject.SetActive(false);
    }
}

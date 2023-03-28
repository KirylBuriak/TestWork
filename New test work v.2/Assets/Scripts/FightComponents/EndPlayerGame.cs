using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlayerGame : MonoBehaviour
{

    
    void Start()
    {
        EventAggregator.Subscribe<PlayerEndGame>(EndGame);
        EventAggregator.Subscribe<Armor>(Reload);
    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<PlayerEndGame>(EndGame);
        EventAggregator.Unsubscribe<Armor>(Reload);
    }

    void Update()
    {
        EventAggregator.Post<PlayerPosition>(this, new PlayerPosition(gameObject.transform));

    }

    private void EndGame(object sender, PlayerEndGame end)
    {
        if(end.winGame)
            GetComponent<Opsive.Shared.Input.UnityInput>().DisableCursor = false;
        else if (!end.winGame)
        {
            GetComponent<Opsive.Shared.Input.UnityInput>().DisableCursor = false;
            gameObject.SetActive(false);
        }
    }

    public void Reload(object sender, Armor armor)
    {
        GetComponent<Opsive.UltimateCharacterController.Inventory.Inventory>().LoadDefaultLoadout();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBoxComp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Get Healing");
            EventAggregator.Post<Healing>(this, new Healing());
            Destroy(gameObject);
        }
    }
}

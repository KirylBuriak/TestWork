using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBoxComp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Get Healing");
            EventAggregator.Post<Armor>(this, new Armor());
            Destroy(gameObject);
        }
    }
}

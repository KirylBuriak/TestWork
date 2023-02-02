using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHit : MonoBehaviour
{
    
    public ZombieStats zombieStats;
    public bool hitIsOn = false;

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hitIsOn)
        {
            Debug.Log("Zombie Hit Player");
            EventAggregator.Post<ZombieHitPlayer>(this, new ZombieHitPlayer(zombieStats.attackForce));

        }
    }

  


}

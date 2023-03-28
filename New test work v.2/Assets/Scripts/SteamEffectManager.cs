using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamEffectManager : MonoBehaviour
{
    public GameObject steamEffect;
    public Transform steamPosition;
    public float steamTimer = 0f;
    public float pauseTime;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(CheckIfCountDownElapsed(pauseTime))
        {
            var curSteam = Instantiate(steamEffect, steamPosition.position, steamPosition.rotation);
            GetComponent<AudioSource>().Play();
            Destroy(curSteam, 3);
            steamTimer = 0;
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        steamTimer += Time.deltaTime;
        return (steamTimer >= duration);
    }
}

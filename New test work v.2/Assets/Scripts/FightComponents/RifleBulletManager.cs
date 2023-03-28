using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBulletManager : MonoBehaviour
{
   
    void OnEnable()
    {
        EventAggregator.Post<PlayerShot>(this, new PlayerShot());
    }

}

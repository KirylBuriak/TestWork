using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRifleFireController : MonoBehaviour
{
    public GameObject rifleBullet;
    public GameObject firePoint;
    public float bulletForce = 2000f;

    void Start()
    {
        EventAggregator.Subscribe<PlayerShot>(RifleShot);
    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<PlayerShot>(RifleShot);
    }

    void Update()
    {
        
    }

    private void RifleShot(object sender, PlayerShot shot)
    {
        var instBullet = Instantiate(rifleBullet, firePoint.transform.position, firePoint.transform.rotation);
        instBullet.GetComponent<Rigidbody>().AddForce(firePoint.transform.forward * bulletForce);
        gameObject.GetComponent<AudioSource>().Play();
    }

    
}

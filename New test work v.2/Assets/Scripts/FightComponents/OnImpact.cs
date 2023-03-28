using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpact : MonoBehaviour
{
    public GameObject groundEffect;
    public GameObject woodEffect;
    public GameObject zonmbieEffect;
    public GameObject zombiePowEffect;

    

    public float damage = 25f;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        if (collision.gameObject.tag == "Wood")
        {
            //Instantiate(woodEffect, contact.point, Quaternion.LookRotation(contact.normal * 90f));
            Instantiate(woodEffect, contact.point, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            //Instantiate(groundEffect, contact.point, Quaternion.LookRotation(contact.normal * 90f));
            Instantiate(groundEffect, contact.point, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Zombie")
        {
            var count = collision.gameObject.GetComponent<ZombieUIController>().zombieHitCounter += 1;
            var reload = collision.gameObject.GetComponent<ZombieUIController>().zombieHitReload;

            if (count < reload)
            {
                Instantiate(zonmbieEffect, contact.point, gameObject.transform.rotation);
            }
            else if (count >= reload)
            {
                Instantiate(zombiePowEffect, contact.point, gameObject.transform.rotation);
                collision.gameObject.GetComponent<ZombieUIController>().zombieHitCounter = 0;
            }
            
            collision.gameObject.GetComponent<ZombieUIController>().zombieModelUI.lifeLine.value -= 5f;
            Destroy(gameObject);
        }

    }
}

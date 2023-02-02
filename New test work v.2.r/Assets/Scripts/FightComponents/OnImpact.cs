using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpact : MonoBehaviour
{
    public GameObject groundEffect;
    public GameObject woodEffect;

    public float damage = 25f;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        if (collision.gameObject.tag == "Wood")
        {
            Instantiate(woodEffect, contact.point, Quaternion.LookRotation(contact.normal));
        }

        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(groundEffect, contact.point, Quaternion.LookRotation(contact.normal));
        }

        if (collision.gameObject.tag == "Zombie")
        {
            collision.gameObject.GetComponent<ZombieUIController>().zombieModelUI.lifeLine.value -= 5f;
            Destroy(gameObject);
        }

    }
}

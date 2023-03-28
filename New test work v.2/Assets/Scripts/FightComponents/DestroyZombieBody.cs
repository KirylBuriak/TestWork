using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZombieBody : MonoBehaviour
{
    public GameObject deadSmoke;

    void Start()
    {
        StartCoroutine(DestroyDeadZombie());
    }

    private IEnumerator DestroyDeadZombie()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(deadSmoke, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}

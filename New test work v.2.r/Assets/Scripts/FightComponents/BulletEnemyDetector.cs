using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletEnemyDetector : MonoBehaviour
{
    public bool targetHit = false;
    public float bulletLifeTime = 2f;
    public float rayCastDistance = 10f;
    public List<GameObject> hitList; 

    void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    void Update()
    {
        

        if (targetHit == false)
        {
            CheckEnemy();
        }
    }

    public void CheckEnemy()
    {
        RaycastHit hit;

       if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, rayCastDistance) && hit.collider.CompareTag("Zombie"))
        {

                Debug.Log("!!! You hit the enemy !!!");
                EventAggregator.Post<HitTheEnemy>(this, new HitTheEnemy(hit.collider.gameObject.GetComponent<ZombieUIController>().zombieNumber));
                targetHit = true;
                Destroy(gameObject);
            
        }

    }
}

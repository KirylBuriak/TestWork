using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieUIController : MonoBehaviour
{
    public int zombieNumber;
    public ZombieUIModel zombieModelUI;
    public ZombieStats zobieStats;
    private bool dieActionStart = false;
    public Transform player;
    public float force = 10f;
    public GameObject zombieDieGO;

    public int zombieHitCounter = 0;
    public int zombieHitReload = 10;


    void Start()
    {
        EventAggregator.Subscribe<HitTheEnemy>(ZombieGetHit);
        EventAggregator.Subscribe<PlayerPosition>(SetPlayerPosition);
    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<HitTheEnemy>(ZombieGetHit);
    }
  
    void Update()
    {
        if (zombieModelUI.lifeLine.value <= 0 && !dieActionStart)
        {
            
            EventAggregator.Post<NewZombie>(this, new NewZombie(zombieNumber));
            EventAggregator.Post<ZombieKillHeandler>(this, new ZombieKillHeandler());
            Vector3 diraction = gameObject.transform.position - player.position;
            var curZombie = Instantiate(zombieDieGO, gameObject.transform.transform.position, gameObject.transform.transform.rotation);
            curZombie.GetComponent<Rigidbody>().AddForce(diraction.normalized * force);
            Destroy(gameObject);


            dieActionStart = true;
            
        }
    }

    private IEnumerator StartDieAnime()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Animator>().SetBool("ZombieDied", true);

    }

    private void ZombieGetHit(object sender, HitTheEnemy enemy)
    {
        if (enemy.hitZombieNamber == zombieNumber)
        {
            
            zombieModelUI.lifeLine.value -= zobieStats.attackForce;

        }
    }

    private void SetPlayerPosition(object sender, PlayerPosition position)
    {
        player = position.playerPos;
    }


    public void ConstrainsPos()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
       
    }
   

}

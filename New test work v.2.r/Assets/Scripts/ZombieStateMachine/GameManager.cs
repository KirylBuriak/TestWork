using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum StatesNames
{
    RemainState,
    PatrolState,
    ChaseState,
    TargetScanner

}
public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform playerSpawn;
    public List<ZombieManager> zombiList;
    public List<ZombieWaypoints> ZombieWaypointsList;
    public int zombieCounter = 0;
    
    

    private void Awake()
    {
        PlayerSpawn();
    }

    void Start()
    {
        SpawnAllZombie();
        EventAggregator.Subscribe<NewZombie>(SinglZombieSpawn);
        
    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<NewZombie>(SinglZombieSpawn);
    }


    void Update()
    {
        
    }

    private void PlayerSpawn()
    {
        Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation); 

    }

    private void SpawnAllZombie()
    {
        foreach (var curZombie in zombiList)
        {
            curZombie.zombieInstance = Instantiate(curZombie.zombiePrefub, curZombie.spawnPoint.position, curZombie.spawnPoint.rotation);
            curZombie.SetupZombieAI(ZombieWaypointsList.FirstOrDefault(t => t.zombieNumber == curZombie.zombieNumber).wayPoints);
        }
        
    }

    private void SinglZombieSpawn(object sender, NewZombie zombie)
    {
        StartCoroutine(SpawnPause(zombie));
    }

    private IEnumerator SpawnPause(NewZombie zombie)
    {
        yield return new WaitForSeconds(15);
        SpawnNewZombie(zombie);

    }

    private void SpawnNewZombie(NewZombie zombie)
    {
        var curNewZombie = zombiList.FirstOrDefault(t => t.zombieNumber == zombie.newZombieNamber);
        curNewZombie.zombieInstance = Instantiate(curNewZombie.zombiePrefub, curNewZombie.spawnPoint.position, curNewZombie.spawnPoint.rotation);
        curNewZombie.SetupZombieAI(ZombieWaypointsList.FirstOrDefault(t => t.zombieNumber == zombie.newZombieNamber).wayPoints);

    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventHeandlers : MonoBehaviour
{
}

public class HitTheEnemy
{
    public int hitZombieNamber;

    public HitTheEnemy(int number)
    {
        hitZombieNamber = number;
    }

}

public class PlayerShot
    {    }

public class NewZombie
{
    public int newZombieNamber;

    public NewZombie(int number)
    {
        newZombieNamber = number;
    }
}

public class ZombieHitPlayer
{
    public float hitForce;

    public ZombieHitPlayer(float force)
    {
        hitForce = force;
    }
}

public class PlayerEndGame
        { }

public class Healing
{ }

public class ZombieKillHeandler
{ }

public class PlayerPosition
{
    public Transform playerPos;

    public PlayerPosition(Transform position)
    {
        playerPos = position;
    }

}


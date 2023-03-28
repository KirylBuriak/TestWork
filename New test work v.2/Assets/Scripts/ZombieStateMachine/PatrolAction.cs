using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{

    public override void Act(StateController controller)
    {
        Patrol(controller);
        
    }


    private void Patrol(StateController controller)
    {
        controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;

        //controller.startAttak = false;
        //controller.firstAttack = true;

        if (!controller.patrolSoundSwitcher)
        {
            controller.zombiePatrolSound.Play();
            controller.patrolSoundSwitcher = true;
            TurnOffOtherSounds(controller);
        }


        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;

        }

        
       
            controller.zombieAnimator.SetBool("ZombieIsGo", true);
            controller.zombieAnimator.SetBool("ZombieRun", false);
            controller.zombieAnimator.SetBool("ZombieAttack", false);

            controller.navMeshAgent.speed = 0.1f;
        

    }

    private void TurnOffOtherSounds(StateController controller)
    {
        controller.zombieChaseSound.Pause();
        controller.chaseSoundSwitcher = false;
        controller.zombieAttackSound.Pause();
        controller.attackSoundSwitcher = false;
    }

    
    
}

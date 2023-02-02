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
    }

    private void TurnOffOtherSounds(StateController controller)
    {
        controller.zombieChaseSound.Pause();
        controller.chaseSoundSwitcher = false;
        controller.zombieAttackSound.Pause();
        controller.attackSoundSwitcher = false;
    }
}

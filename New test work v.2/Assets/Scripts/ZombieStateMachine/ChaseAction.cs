using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]

public class ChaseAction : Action
{

    public override void Act(StateController controller)
    {
        Chase(controller); 
    }

    private void Chase(StateController controller)
    {
        if (!controller.chaseSoundSwitcher && !controller.zombieHitComp.hitIsOn)
        {
            controller.zombieChaseSound.Play();
            controller.chaseSoundSwitcher = true;
            TurnOffOtherSounds(controller);
        }

        if (!controller.startAttak)
        {
            controller.navMeshAgent.destination = controller.chaseTarget.position;

            controller.zombieAnimator.SetBool("ZombieIsGo", false);
            controller.zombieAnimator.SetBool("ZombieRun", true);
            controller.zombieAnimator.SetBool("ZombieAttack", false);

            controller.navMeshAgent.speed = 1f;
        }



    }

    private void TurnOffOtherSounds(StateController controller)
    {
        controller.zombiePatrolSound.Pause();
        controller.patrolSoundSwitcher = false;
        controller.zombieAttackSound.Pause();
        controller.attackSoundSwitcher = false;
    }
}

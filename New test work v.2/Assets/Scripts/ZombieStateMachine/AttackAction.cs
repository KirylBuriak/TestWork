using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]

public class AttackAction : Action
{
    private bool firstAttack = true;
    public override void Act(StateController controller)
    {
            Attack(controller);
    }

    private void Attack(StateController controller)
    {
        
        RaycastHit hit;
        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.zombieStats.attackRange, Color.red);
        

        if (Physics.SphereCast(controller.eyes.position, controller.zombieStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.zombieStats.attackRange) && hit.collider.CompareTag("Player"))
        {
            controller.gameObject.transform.LookAt(hit.collider.gameObject.transform);
            if (!controller.startAttak)
            {
                controller.zombieAnimator.SetBool("ZombieRun", false);
                controller.navMeshAgent.speed = 0f;
                controller.startAttak = true;
            }

            if (controller.firstAttack)
            {
                controller.navMeshAgent.speed = 0f;
                controller.zombieHitComp.hitIsOn = true;
                controller.zombieAnimator.SetBool("ZombieAttack", true);
                controller.zombieAnimator.SetBool("ZombieIsGo", false);
                controller.zombieAnimator.SetBool("ZombieRun", false);
                controller.firstAttack = false;

            }
            else if (controller.CheckIfCountDownElapsed(controller.zombieStats.attackRate))
            {
                //controller.zombieAnimator.SetBool("ZombieAttack", false);
                controller.navMeshAgent.speed = 0f;
                controller.zombieHitComp.hitIsOn = true;
                controller.zombieAnimator.SetBool("ZombieAttack", true);
                controller.zombieAnimator.SetBool("ZombieIsGo", false);
                controller.zombieAnimator.SetBool("ZombieRun", false);
                controller.stateTimerElapsed = 0f;

            }
            //else if(!controller.CheckIfCountDownElapsed(controller.zombieStats.attackRate))
            ////    controller.zombieAnimator.SetBool("ZombieAttack", false);
            ////    controller.zombieAnimator.SetBool("ZombieIsGo", false);
            ////    controller.zombieAnimator.SetBool("ZombieRun", false);

            if (!controller.attackSoundSwitcher)
            {
                //controller.zombieAttackSound.Play();
                controller.attackSoundSwitcher = true;
                TurnOffOtherSounds(controller);
            }
        }
        else
        {
           //controller.navMeshAgent.speed = 0.1f;
            controller.zombieHitComp.hitIsOn = false;
            controller.zombieAttackSound.Pause();
            controller.attackSoundSwitcher = false;
            firstAttack = true;
            controller.startAttak = false;
            controller.firstAttack = true;


        }

    }

    private void TurnOffOtherSounds(StateController controller)
    {
        controller.zombiePatrolSound.Pause();
        controller.patrolSoundSwitcher = false;
        controller.zombieChaseSound.Pause();
        controller.chaseSoundSwitcher = false;
        controller.startAttak = false;
    }
}

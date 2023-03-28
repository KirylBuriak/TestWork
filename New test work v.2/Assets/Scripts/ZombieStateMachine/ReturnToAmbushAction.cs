using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Ambush")]
public class ReturnToAmbushAction : Action
{
    public override void Act(StateController controller)
    {
        ReturnToAmbush(controller);

    }

    private void ReturnToAmbush(StateController controller)
    {
        var curDistance = Vector3.Distance(controller.wayPointList[0].position, controller.gameObject.transform.position);
        
        controller.ambushDistance = curDistance;

        if (curDistance >=2)
        {
            controller.navMeshAgent.destination = controller.wayPointList[0].position;
            controller.zombieAnimator.SetBool("ZombieIsGo", true);
            controller.zombieAnimator.SetBool("ZombieRun", false);
            controller.zombieAnimator.SetBool("ZombieAttack", false);

            controller.navMeshAgent.speed = 0.1f;
        }
        else
        {
            controller.zombieAnimator.SetBool("ZombieIsGo", false);
            controller.zombieAnimator.SetBool("ZombieRun", false);
            controller.zombieAnimator.SetBool("ZombieAttack", false);

            controller.navMeshAgent.speed = 0f;
        }
        

    }
}

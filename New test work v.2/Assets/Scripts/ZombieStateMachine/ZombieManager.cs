using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ZombieManager 
{
	public Color zombieColor;
	public Transform spawnPoint;
	public GameObject zombiePrefub;
	public int zombieNumber;
	[HideInInspector] public GameObject zombieInstance;

	private StateController stateController;
	private ZombieUIController zombieUI;
	
	public void SetupZombieAI(List<Transform> wayPointList)
	{
		stateController = zombieInstance.GetComponent<StateController>();
		stateController.Setup_SC_AI(true, wayPointList);
		stateController.navMeshAgent.avoidancePriority = zombieNumber;
		zombieUI = zombieInstance.GetComponent<ZombieUIController>();
		zombieUI.zombieNumber = zombieNumber;
		zombieUI.zombieModelUI.lifeLine.maxValue = stateController.zombieStats.health;
		zombieUI.zombieModelUI.lifeLine.value = zombieUI.zombieModelUI.lifeLine.maxValue;
		//zombieUI.zombieModelUI.zombieName.text = "Zombie " + zombieNumber.ToString();

	}

	
}

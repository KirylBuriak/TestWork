using Opsive.UltimateCharacterController.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public Animator zombieAnimator;
    public State curState;
    public State endGameState;
    public ZombieStats zombieStats;
    public Transform eyes;
    public State remainState;
    public GameObject targetScanner;
    public ZombieHit zombieHitComp;
    public AudioSource zombiePatrolSound;
    public bool patrolSoundSwitcher = false;
    public AudioSource zombieChaseSound;
    public bool chaseSoundSwitcher = false;
    public AudioSource zombieAttackSound;
    public bool attackSoundSwitcher = false;
    public bool startAttak = false;
    public bool firstAttack = true;

    public float ambushDistance;

    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public ZombieAttack sc_ZombieAttack;
    [HideInInspector] public int nextWayPoint = 0;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimerElapsed = 0;

    public bool aiActive;

    private void Awake()
    {
        sc_ZombieAttack = GetComponent<ZombieAttack>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    void Start()
    {
        //zombieAnimator.SetBool("ZombieIsGo", true);

        EventAggregator.Subscribe<PlayerEndGame>(OnGameEnd);
    }
    private void OnDisable()
    {
        EventAggregator.Unsubscribe<PlayerEndGame>(OnGameEnd);
    }

    void Update()
    {
        if (!aiActive)
            return;
        curState.UpdateState(this);
    }

    public void Setup_SC_AI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
    {
        wayPointList = wayPointsFromTankManager;
        aiActive = aiActivationFromTankManager;
        if (aiActive)
        {
            navMeshAgent.enabled = true; 
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (curState != null && eyes != null)
        {
            Gizmos.color = curState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, zombieStats.lookSphereCastRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            curState = nextState;
            OnExitState();
        }
    }
    
    private void OnGameEnd(object sender, PlayerEndGame game)
    {
        if (!game.winGame)
            TransitionToState(endGameState);
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimerElapsed += Time.deltaTime;
        return (stateTimerElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimerElapsed = 0;
    }
}

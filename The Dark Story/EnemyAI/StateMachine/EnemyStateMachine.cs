using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using StarterAssets;
using UnityEngine.Audio;

public class EnemyStateMachine : MonoBehaviour
{
    //state variables
    //[Header("Player References")]
    EnemyBaseState _currentState;
    EnemyStateFactory _states;

    //Player Reference
    [Header("------------------Player References------------------------")]
    public Transform playerTransform;
    public Vector3 lastPlayerTransform;
    public Transform playerRaycastTransform;
    public Transform enemy;
    public StarterAssetsInputs starterAssetsInputs;
    public CinemachineVirtualCamera playerFollowCamera;
    public AudioSource jumpScareEnemyCamera;
    public AudioClip jumpScareEnemyCameraClip;
    public EnemyAttackSensor enemyAttackSensor1;
    public EnemyAttackSensor enemyAttackSensor2;
    public RespawnPlayer respawnPlayer;
    public GameObject deathUI;
    public GameObject lowHealthPostProcessingGameObject;
    public GameObject lowHealthCameraGameObject;
    public CharacterController characterController;
    public FirstPersonController firstPersonController;
    [SerializeField]private Vector3 targetDistance;
    [SerializeField]private float playerDistance;
    [SerializeField]private float playerAngle;
    [SerializeField]private float minimumDistance;
    [SerializeField]private float minimumPlayerAngle;
    [SerializeField]private bool isInPlayerRange;
    [SerializeField]private bool isInPlayerSight;
    [SerializeField]private Vector3 playerDirection;

    [SerializeField]private EnemySensor enemySensor;
    public LayerMask raycastLayerMask;

    [SerializeField] private float attackDistance;

    //NavMeshAgent+Player+Animator
    [Header("--------------------Agent References-------------------------")]
    public NavMeshAgent agent;
    public Animator animator;
    public AudioSource enemyAudioSource;
    public AudioClip AttackClip;
    public AudioClip StickAttackClip;
    public Vector3 agentRespawnPosition;
    public bool _playedOnce;

    //Wandering References
    [Header("--------------------Wandering References-----------------")]
    public Transform[] WanderingLocations;
    public Transform newWanderingLocation;
    public bool getNewWanderingLocation;
    private int waitTime=1;
    private bool generateNew;
    EnemyStateMachine _enemyStateMachine;
    public float newWanderingLocationTime=0f;

    //Idle Referenses
    [Header("---------------------Idle References-------------------")]
    public float idleTime=0f;
    public bool isIdleTimeStarted=true;

    //CustomSpeedForBigMaps
    [Header("---------------------CustomSpeedReferencesForBigMaps---------------------")]
     public bool _isCustomSpeed = false;
     public float _newMoveSpeed;
     public float _newRunSpeed;

    //Getters & Setters
    //[Header("------------------------Getters/Setters----------------------------------")]
    public bool IsCustomSpeed { get { return _isCustomSpeed; } set { _isCustomSpeed = value; } }
    public bool PlayedOnce { get { return _playedOnce; } set { _playedOnce = value; } }
    public float NewMoveSpeed { get { return _newMoveSpeed; } set { _newMoveSpeed = value; } }
    public float NewRunSpeed { get { return _newRunSpeed; } set { _newRunSpeed = value; } }
    public EnemyBaseState CurrentState {get{return _currentState;} set{_currentState=value;}}
    public float IdleTime {get{return idleTime;} set{idleTime=value;}}
    public float NewWanderingLocationTime {get{return newWanderingLocationTime;} set{newWanderingLocationTime=value;}}
    public bool GenerateNew {get{return generateNew;} set{generateNew=value;}}
    public NavMeshAgent Agent {get{return agent;} set{agent=value;}}
    public Vector3 AgentRespawnPosition{get{return agentRespawnPosition;}set{agentRespawnPosition=value;}}
    public bool IsIdleTimeStarted{get{return isIdleTimeStarted;} set{isIdleTimeStarted=value;}}
    public StarterAssetsInputs StarterAssetsInputs{get{return starterAssetsInputs;} set{starterAssetsInputs=value;}}
    public RespawnPlayer RespawnPlayer{get{return respawnPlayer;}set{respawnPlayer=value;}}
    public EnemyAttackSensor EnemyAttackSensor1{get{return enemyAttackSensor1;}set{enemyAttackSensor1=value;}}
    public EnemyAttackSensor EnemyAttackSensor2{get{return enemyAttackSensor2;}set{enemyAttackSensor2=value;}}
    public Animator Animator {get{return animator;} set{animator=value;}}
    public GameObject DeathUI{get{return deathUI;} set{deathUI=value;}}
    public GameObject LowHealthPostProcessingGameObject{get{return lowHealthPostProcessingGameObject;} set{lowHealthPostProcessingGameObject=value;}}
    public GameObject LowHealthCameraGameObject{get{return lowHealthCameraGameObject;} set{lowHealthCameraGameObject=value;}}
    public FirstPersonController FirstPersonController{get{return firstPersonController;} set{firstPersonController=value;}}
    public CharacterController CharacterController{get{return characterController;}set{characterController=value;}}
    public EnemySensor EnemySensor {get{return enemySensor;} set{enemySensor=value;}}
    public Transform NewWanderingLocation {get{return newWanderingLocation;} set{newWanderingLocation=value;}}
    public bool GetNewWanderingLocation {get{return getNewWanderingLocation;} set{getNewWanderingLocation=value;}}
    
    public Transform PlayerTransform{get{return playerTransform;}set{playerTransform=value;}}
    public Vector3 LastPlayerTransform{get{return lastPlayerTransform;}set{lastPlayerTransform=value;}}
    public Transform PlayerRaycastTransform{get{return playerRaycastTransform;}set{playerRaycastTransform=value;}}
    public CinemachineVirtualCamera PlayerFollowCamera{get{return playerFollowCamera;}set{playerFollowCamera=value;}}
    public AudioSource JumpScareEnemyCamera { get{return jumpScareEnemyCamera;}set{jumpScareEnemyCamera=value;}}
    public AudioClip JumpScareEnemyCameraClip { get{return jumpScareEnemyCameraClip;}set{jumpScareEnemyCameraClip=value;}}
    public Transform Enemy{get{return enemy;}set{enemy=value;}}
    public float PlayerDistance{get{return playerDistance;}set{playerDistance=value;}}
    public float PlayerAngle{get{return playerAngle;}set{playerAngle=value;}}
    public float MinimumDistance{get{return minimumDistance;}set{minimumDistance=value;}}
    public float MinimumPlayerAngle{get{return minimumPlayerAngle;}set{minimumPlayerAngle=value;}}
    public bool IsInPlayerRange {get{return isInPlayerRange;} set{isInPlayerRange=value;}}
    public bool IsInPlayerSight {get{return isInPlayerSight;} set{isInPlayerSight=value;}}
    public Vector3 PlayerDirection {get{return playerDirection;} set{playerDirection=value;}}
    public float AttackDistance{get{return attackDistance;}set{attackDistance=value;}}
    public LayerMask RayCastLayerMask{get{return raycastLayerMask;}set{raycastLayerMask=value;}}
    public Transform[] WanderingLocationsArray
    {
        get { return WanderingLocations; }
    }
    public EnemyStateMachine enemyStateMachine{get{return _enemyStateMachine;}set{_enemyStateMachine=value;}}

    void Awake()
    {
        //setup State
        _states=new EnemyStateFactory(this);
        _currentState=_states.Idle();
        _currentState.EnterState();
    }

    void Update()
    {
        _currentState.UpdateState();
        playerDistance=Vector3.Distance(playerTransform.position,transform.position);
    }

    public void PlayAttackClip(){
        if (PlayedOnce == false)
        {
            enemyAudioSource.PlayOneShot(AttackClip);
            return;
        }
    }
    public void PlayStickAttackClip()
    {
        if (PlayedOnce == false)
        {
            enemyAudioSource.PlayOneShot(StickAttackClip);
            return;
        }
    }
    public void SetPlayedOnceToTrue()
    {
        PlayedOnce = true;
    }
}

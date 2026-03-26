using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Tarodev;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class DroneAIStateMachine : MonoBehaviour
{
    //state variables
    //[Header("Player References")]
    DroneAIBaseState _currentState;
    DroneAIStateFactory _states;

    [Header("Drone References")]
    [SerializeField] public HostileDronesScriptableObjects _hostileDronesScriptableObjects;
    [SerializeField] private EnemyHealthBarHandler _enemyHealthBarHandler;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _PlayerDistance;
    [SerializeField] private float _MaxPlayerDistance;
    [SerializeField] private float _MinPlayerDistance;
    [SerializeField] public RandomPathGenerator randomPathGenerator;
    [SerializeField] public DroneTowerHandler _droneTowerHandler;
    [SerializeField] public MeshRenderer _bodyMeshRenderer;
    [SerializeField] private UIhandler uihandler;
    private bool isUnderAttack = false;
    public Target _Player;


    //Getters & Setters
    //[Header("------------------------Getters/Setters----------------------------------")]
    public DroneAIBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Target Player { get { return _Player; } set { _Player = value; } }
    public float PlayerDistance { get { return _PlayerDistance; } set { _PlayerDistance = value; } }
    public float MinPlayerDistance { get { return _MinPlayerDistance; } set { _MinPlayerDistance = value; } }
    public float MaxPlayerDistance { get { return _MaxPlayerDistance; } set { _MaxPlayerDistance = value; } }
    public Rigidbody RB { get { return _rigidbody; } set { _rigidbody = value; } }
    public HostileDronesScriptableObjects droneStat { get { return _hostileDronesScriptableObjects; } set { _hostileDronesScriptableObjects = value; } }
    public EnemyHealthBarHandler enemyHealthBarHandler { get { return _enemyHealthBarHandler; } set { _enemyHealthBarHandler = value; } }

    void Awake()
    {
        //setup State
        _states = new DroneAIStateFactory(this);
        _currentState = _states.Wandering();
        _currentState.EnterState();
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState();
    }

    public void Damage(int dmgAmount)
    {
        if (_hostileDronesScriptableObjects.currentHealth <= dmgAmount)
        {
            _hostileDronesScriptableObjects.currentHealth -= dmgAmount;
            Die();
        }
        else
        {
            if (isUnderAttack == false)
            {
                _droneTowerHandler.AlertAllDrones();
            }
            _hostileDronesScriptableObjects.currentHealth -= dmgAmount;
            _enemyHealthBarHandler.enabled = true;
            _enemyHealthBarHandler.UpdateHealthBar(_hostileDronesScriptableObjects.baseHealth, _hostileDronesScriptableObjects.currentHealth);
        }
    }

    public void UnderAttackSignal()
    {
        if (isUnderAttack == false)
        {
            isUnderAttack = true;
        }
        if (isUnderAttack == true)
        {
            randomPathGenerator.objectToMove = null;
            randomPathGenerator.enabled = false;
            _currentState = _states.Chasing();
            _currentState.EnterState();
        }
        return;
        Debug.Log("I Got Your MSG!!!");
    }
    public void RetrieveSignal()
    {
        randomPathGenerator.objectToMove = transform.gameObject;
        randomPathGenerator.enabled = true;
        _currentState = _states.Wandering();
        _currentState.EnterState();
        return;
        Debug.Log("I Got Your MSG!!!");
    }

    private void Die()
    {
        Instantiate(_hostileDronesScriptableObjects.blastParticlesSystem, transform.position, Quaternion.identity);
        Item item = _hostileDronesScriptableObjects.lootTable.GetDrop();
        Instantiate(item.itemDrop, transform.position, Quaternion.identity);
        Destroy(_hostileDronesScriptableObjects);
        Destroy(gameObject);
        return;
    }
}

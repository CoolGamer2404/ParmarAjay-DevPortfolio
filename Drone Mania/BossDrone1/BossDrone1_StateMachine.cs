using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossDrone1_StateMachine : MonoBehaviour
{
    /////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////
    #region Public Variables
    public GameObject _player;
    public BossDrone_ScriptableObject _bossDroneStat;
    public int _currentPhase = 1;
    public bool _isMultiplayer = false;
    public int PhaseHealth;
    public Rigidbody _bossRB;
    public bool _isBossVulnarable = false;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////
    #region Serialized Private Variables
    [SerializeField]
    GameObject _bossDrone;

    [SerializeField]
    BossDrone1_HealthBarHandler _healthBarHandler;

    [SerializeField]
    float _dashSpeed = 5f;

    [SerializeField]
    float _rotationSpeed = 5f;

    [SerializeField]
    float _dashDistance = 5f;

    [SerializeField]
    Vector3 _initialDashPosition;

    [SerializeField]
    bool _isDashing = false;

    [SerializeField]
    string _boundryTag = "Boundry";

    [SerializeField]
    int _randomDashAmount = 1;

    [SerializeField]
    MeshFilter _arenaBaseMesh;

    [SerializeField]
    GameObject _missileAttackIndicator;

    [SerializeField]
    GameObject _asteroidAttackIndicator;

    [SerializeField]
    Bounds _arenaBaseBounds;

    [SerializeField]
    int _missilesAmount;

    [SerializeField]
    int _asteroidsAmount;
    
    [SerializeField]
    float _flyingHeight;
    [SerializeField]
    BossDrone_ProjectileShoot[] bossDrone_ProjectileShoots;

    #endregion
    /////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////
    #region Non-Serialized Private Variables
    BossDrone1_BaseState _currentState;
    BossDrone1_StateFactory _states;
    #endregion



    /////////////////////////<Getters/Setters>///////////////////////////
    public BossDrone1_BaseState CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }
    public GameObject BossDrone
    {
        get { return _bossDrone; }
        set { _bossDrone = value; }
    }
    public GameObject Player
    {
        get { return _player; }
        set { _player = value; }
    }
    public BossDrone_ScriptableObject BossDroneStat
    {
        get { return _bossDroneStat; }
        set { _bossDroneStat = value; }
    }
    public int CurrentPhase
    {
        get { return _currentPhase; }
        set { _currentPhase = value; }
    }
    public BossDrone1_HealthBarHandler HealthBarHandler
    {
        get { return _healthBarHandler; }
        set { _healthBarHandler = value; }
    }
    public bool IsMultiplayer
    {
        get { return _isMultiplayer; }
        set { _isMultiplayer = value; }
    }
    public Rigidbody BossRB
    {
        get { return _bossRB; }
        set { _bossRB = value; }
    }
    public float DashSpeed
    {
        get { return _dashSpeed; }
        set { _dashSpeed = value; }
    }
    public float RotationSpeed
    {
        get { return _rotationSpeed; }
        set { _rotationSpeed = value; }
    }
    public float DashDistance
    {
        get { return _dashDistance; }
        set { _dashDistance = value; }
    }
    public float FlyingHeight
    {
        get { return _flyingHeight; }
        set { _flyingHeight = value; }
    }
    public Vector3 InitialDashPosition
    {
        get { return _initialDashPosition; }
        set { _initialDashPosition = value; }
    }
    public bool IsDashing
    {
        get { return _isDashing; }
        set { _isDashing = value; }
    }
    public bool IsBossVulnarable
    {
        get { return _isBossVulnarable; }
        set { _isBossVulnarable = value; }
    }
    public string BoundryTag
    {
        get { return _boundryTag; }
        set { _boundryTag = value; }
    }
    public int RandomDashAmount
    {
        get { return _randomDashAmount; }
        set { _randomDashAmount = value; }
    }
    public MeshFilter ArenaBaseMesh
    {
        get { return _arenaBaseMesh; }
        set { _arenaBaseMesh = value; }
    }
    public Bounds ArenaBaseBounds
    {
        get { return _arenaBaseBounds; }
        set { _arenaBaseBounds = value; }
    }
    public GameObject MissileAttackIndicator
    {
        get { return _missileAttackIndicator; }
        set { _missileAttackIndicator = value; }
    }
    public GameObject AsteroidAttackIndicator
    {
        get { return _asteroidAttackIndicator; }
        set { _asteroidAttackIndicator = value; }
    }
    public int MissilesAmount
    {
        get { return _missilesAmount; }
        set { _missilesAmount = value; }
    }
    public int AsteroidsAmount
    {
        get { return _asteroidsAmount; }
        set { _asteroidsAmount = value; }
    }

    void Awake()
    {
        //setup State
        _states = new BossDrone1_StateFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
        _currentPhase = 1;
        SetupBossDroneData();
    }

    // Start is called before the first frame update
    void Start()
    {
        PhaseHealth = _bossDroneStat.baseHealth / 4;
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState();
    }

    //////////////////////////////////////////////////////////////////////////
    /////////   For Setting Up Data Of Boss Drone ScriptableObject   /////////
    //////////////////////////////////////////////////////////////////////////
    public void SetupBossDroneData()
    {
        //
    }

    //////////////////////////////////////////////////////////////////////////

    public void GiveDMG()
    {
        BossDrone_TakeDMG(1000);
    }

    public void BossDrone_TakeDMG(int dmg)
    {
        if (!IsBossVulnarable)
            return;

        if (_bossDroneStat.currentHealth > _bossDroneStat.baseHealth - PhaseHealth)
        {
            _currentPhase = 1;
        }
        if (
            _bossDroneStat.currentHealth <= _bossDroneStat.baseHealth - PhaseHealth
            && _bossDroneStat.currentHealth >= _bossDroneStat.baseHealth - PhaseHealth * 2
        )
        {
            _currentPhase = 2;
        }
        if (
            _bossDroneStat.currentHealth <= _bossDroneStat.baseHealth - PhaseHealth * 2
            && _bossDroneStat.currentHealth >= _bossDroneStat.baseHealth - PhaseHealth * 3
        )
        {
            _currentPhase = 3;
        }
        if (_bossDroneStat.currentHealth <= _bossDroneStat.baseHealth - PhaseHealth * 3)
        {
            _currentPhase = 4;
        }
        _bossDroneStat.currentHealth -= dmg;
        _healthBarHandler.UpdateHealthBar();
        return;
    }

    public void OnTriggerEnter(Collider coll)
    {
        CurrentState.HandleCollision(coll);
    }

    public void DoDash()
    {
        _currentState.ExitState();
        _currentState = _states.Dash();
        _currentState.EnterState();
    }

    public void SpawnMissiles()
    {
        _currentState.ExitState();
        _currentState = _states.ShootMissiles();
        _currentState.EnterState();
    }

    public void SpawnAsteroids()
    {
        _currentState.ExitState();
        _currentState = _states.ShootAsteroid();
        _currentState.EnterState();
    }

    public void ShootProjectilesA(){
        for (int i = 0; i < bossDrone_ProjectileShoots.Length; i++)
        {
            bossDrone_ProjectileShoots[i].Shoot();
        }
        return;
    }

    private Semaphore instatiateMissileTargetIndicatorSemaphore = new Semaphore(1, 1);

    public void InstantiateMissileTargetIndicator(Vector3 point)
    {
        instatiateMissileTargetIndicatorSemaphore.WaitOne();
        try
        {
            //Debug.Log("Instatiating Indicator");
            GameObject targetIndicator = Instantiate(
                _missileAttackIndicator,
                point,
                Quaternion.identity
            );
        }
        finally
        {
            instatiateMissileTargetIndicatorSemaphore.Release();
        }
    }

    private Semaphore instatiateAsteroidTargetIndicatorSemaphore = new Semaphore(1, 1);

    public void InstantiateAsteroidTargetIndicator(Vector3 point)
    {
        instatiateAsteroidTargetIndicatorSemaphore.WaitOne();
        try
        {
            //Debug.Log("Instatiating Indicator");
            GameObject targetIndicator = Instantiate(
                _asteroidAttackIndicator,
                point,
                Quaternion.identity
            );
        }
        finally
        {
            instatiateAsteroidTargetIndicatorSemaphore.Release();
        }
    }
}

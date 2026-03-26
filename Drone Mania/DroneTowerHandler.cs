using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Tarodev;
using UnityEngine;
using UnityEngine.UIElements;

public class DroneTowerHandler : MonoBehaviour
{

    [Header("DroneBaseData")]
    public TowerDifficultyLevel _towerDifficultyLevel;
    public TowerMode _towerMode;
    public GameObject[] dronePrefabs; // Array of drone prefabs for different types
    public GameObject dronePathSpawner;
    public HostileDronesScriptableObjects[] _hostileDroneStatsScriptableObjects;
    public GameObject[] spawnedDronePrefabs;

    [SerializeField] private GameObject _BlastParticlesSystem;
    [SerializeField] private float _towerRange = 5f;
    [SerializeField] private float _towerHeight = 5f;
    [SerializeField] private float _towerWarningRange = 5f;
    [SerializeField] private float _towerWarningHeight = 5f;
    [SerializeField] private bool _showRange;
    [SerializeField] private int minSpawnLimit = 1;
    [SerializeField] private int maxSpawnLimit = 5;
    [SerializeField] private float spawnProofRadius = 20f;
    [SerializeField] private float spawnProofHeight = 5f;
    [SerializeField] private GameObject _Tower;
    [SerializeField] private Target _playertarget;

    [SerializeField] private Transform _defenderDronesParent;
    [SerializeField] private Transform _defenderDronesPathParent;
    [SerializeField] private GameObject _dronepathSpawnerPrefab;
    [SerializeField] private GameObject _bullet;

    [SerializeField] private Material[] _mainBodyMaterials;

    [SerializeField] private LootTable _maimLootTable;


    [SerializeField] private float Distance;


    private int currentSpawnedDrones = 0;

    private GameObject spawnedpath;

    /// <summary>
    /// Add All Variables that are made in functions here in private for optimazion
    /// </summary>
    int numDronesToSpawn;
    GameObject randomDronePrefab, newDrone;
    HostileDronesScriptableObjects droneStats;
    RandomPathGenerator randomPathGenerator;
    DroneAIStateMachine droneAIStateMachine;
    Material[] _materials;

    public enum TowerDifficultyLevel
    {
        Easy,
        Normal,
        Medium,
        Hard,
    }

    public enum TowerMode
    {
        SinglePlayer,
        MultiPlayer,
    }
    // Start is called before the first frame update
    void Start()
    {
        _playertarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Target>();
        PlayerPrefs.SetInt("DifficultyMultiplier", 1);
        if (_towerDifficultyLevel == TowerDifficultyLevel.Easy)
        {
            numDronesToSpawn = minSpawnLimit;
        }
        if (_towerDifficultyLevel == TowerDifficultyLevel.Normal)
        {
            numDronesToSpawn = minSpawnLimit * 2;
        }
        if (_towerDifficultyLevel == TowerDifficultyLevel.Medium)
        {
            numDronesToSpawn = minSpawnLimit * 3;
        }
        if (_towerDifficultyLevel == TowerDifficultyLevel.Hard)
        {
            numDronesToSpawn = minSpawnLimit * 4;
        }
        if(_playertarget!=null){
        SpawnDrones();}
        if(_playertarget==null){Start();}
    }

    // Update is called once per frame
    void Update()
    {
        /*Distance = Vector3.Distance(transform.position, _playertarget.transform.position);
        if (Distance <= 50f && Distance >= 35f)
        {
            Debug.Log("Warning!!!");
        }
        if (Distance <= 35f && Distance >= 20f)
        {
            Debug.Log("Attack!!!");
            for (int i = 0; i < spawnedDronePrefabs.Length; i++)
            {
                droneAIStateMachine = spawnedDronePrefabs[i].GetComponent<DroneAIStateMachine>();
                droneAIStateMachine.UnderAttackSignal();
            }
        }

        if (Distance >= 500f)
        {
            Debug.Log("Retrieve!!!");
            for (int i = 0; i < spawnedDronePrefabs.Length; i++)
            {
                droneAIStateMachine = spawnedDronePrefabs[i].GetComponent<DroneAIStateMachine>();
                droneAIStateMachine.RetrieveSignal();
            }
        }*/
    }


    void SpawnDrones()
    {
        for (int i = 0; i < numDronesToSpawn; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            randomDronePrefab = GetRandomDronePrefab();
            newDrone = Instantiate(randomDronePrefab, spawnPosition, Quaternion.identity);
            spawnedDronePrefabs[i] = newDrone;
            newDrone.transform.SetParent(_defenderDronesParent);
            droneAIStateMachine = newDrone.GetComponent<DroneAIStateMachine>();
            droneAIStateMachine._droneTowerHandler = transform.GetComponent<DroneTowerHandler>();

            // Create and initialize a DroneStatsScriptableObject for the spawned drone
            droneStats = ScriptableObject.CreateInstance<HostileDronesScriptableObjects>();

            // Determine faction
            droneStats.droneFaction = HostileDronesScriptableObjects.DroneFaction.EnemyDrone;
            _hostileDroneStatsScriptableObjects[i] = droneStats;
            droneStats.bullet=_bullet;

            // Determine type based on random chance or other conditions
            _hostileDroneStatsScriptableObjects[i].droneType = HostileDronesScriptableObjects.DroneType.Guardian;
            // You can also set additional properties based on the drone type if needed

            droneAIStateMachine.droneStat = _hostileDroneStatsScriptableObjects[i];
            if (spawnPosition.x <= spawnProofRadius + 5)
            {
                Vector3 newPos = new Vector3(spawnPosition.x + 5f, spawnPosition.y, spawnPosition.z);
                spawnedpath = Instantiate(dronePathSpawner, newPos, Quaternion.identity);
                spawnedpath.transform.SetParent(_defenderDronesPathParent);
                randomPathGenerator = spawnedpath.GetComponent<RandomPathGenerator>();
                randomPathGenerator.objectToMove = newDrone;
            }
            else if (spawnPosition.x >= spawnProofRadius + 5.1)
            {
                spawnedpath = Instantiate(dronePathSpawner, spawnPosition, Quaternion.identity);
                spawnedpath.transform.SetParent(_defenderDronesPathParent);
                randomPathGenerator = spawnedpath.GetComponent<RandomPathGenerator>();
                randomPathGenerator.objectToMove = newDrone;
            }
            droneAIStateMachine.randomPathGenerator = randomPathGenerator;
            _hostileDroneStatsScriptableObjects[i]._dronePathSpawner = spawnedpath;
            _hostileDroneStatsScriptableObjects[i]._dronePathSpawnerPrefab = _dronepathSpawnerPrefab;
            droneStats.lootTable = _maimLootTable;
            droneStats.blastParticlesSystem = _BlastParticlesSystem;
            droneAIStateMachine._Player = _playertarget;
            _materials=droneAIStateMachine._bodyMeshRenderer.materials;
            _materials[0]=_mainBodyMaterials[Random.Range(0,_mainBodyMaterials.Length)];
            droneAIStateMachine._bodyMeshRenderer.materials=_materials;


            if (_towerDifficultyLevel == TowerDifficultyLevel.Easy)
            {
                droneStats.baseHealth = Random.Range(100, 500) * PlayerPrefs.GetInt("DifficultyMultiplier");
                droneStats.baseDamage = Random.Range(15, 45) * PlayerPrefs.GetInt("DifficultyMultiplier");
            }
            if (_towerDifficultyLevel == TowerDifficultyLevel.Normal)
            {
                droneStats.baseHealth = Random.Range(500, 1000) * PlayerPrefs.GetInt("DifficultyMultiplier");
                droneStats.baseDamage = Random.Range(40, 80) * PlayerPrefs.GetInt("DifficultyMultiplier");
            }
            if (_towerDifficultyLevel == TowerDifficultyLevel.Medium)
            {
                droneStats.baseHealth = Random.Range(1000, 2500) * PlayerPrefs.GetInt("DifficultyMultiplier");
                droneStats.baseDamage = Random.Range(100, 250) * PlayerPrefs.GetInt("DifficultyMultiplier");
            }
            if (_towerDifficultyLevel == TowerDifficultyLevel.Hard)
            {
                droneStats.baseHealth = Random.Range(2500, 8000) * PlayerPrefs.GetInt("DifficultyMultiplier");
                droneStats.baseDamage = Random.Range(250, 500) * PlayerPrefs.GetInt("DifficultyMultiplier");
            }

            droneStats.currentHealth = droneStats.baseHealth;

            currentSpawnedDrones++;
        }
    }

    public void AlertAllDrones()
    {
        for (int i = 0; i < spawnedDronePrefabs.Length; i++)
        {
            droneAIStateMachine = spawnedDronePrefabs[i].GetComponent<DroneAIStateMachine>();
            droneAIStateMachine.UnderAttackSignal();
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomCircle = Random.insideUnitCircle * _towerRange;
        Vector3 spawnPosition = new Vector3(randomCircle.x, 0f, randomCircle.y) + transform.position;
        spawnPosition.y = Random.Range(transform.position.y, transform.position.y + _towerHeight); // Randomize height
        return spawnPosition;
    }

    GameObject GetRandomDronePrefab()
    {
        return dronePrefabs[Random.Range(0, dronePrefabs.Length)];
    }

    void OnDrawGizmosSelected()
    {
        if (_showRange)
        {
            Gizmos.color = Color.red;
            DrawCylinderGizmo(transform.position, spawnProofRadius, spawnProofHeight, 1);
            Gizmos.color = Color.blue;
            DrawCylinderGizmo(transform.position, _towerRange, _towerHeight, 1);
            Gizmos.color = Color.white;
            DrawCylinderGizmo(transform.position, _towerWarningRange, _towerWarningHeight, 1);
        }
    }

    void DrawCylinderGizmo(Vector3 position, float radius, float height, float width)
    {
        float halfHeight = height * 0.5f;
        Vector3 topCenter = position + Vector3.up * halfHeight;
        Vector3 bottomCenter = position - Vector3.up * halfHeight;

        // Draw top and bottom circles
        DrawCircleGizmo(topCenter, radius, width);
        DrawCircleGizmo(bottomCenter, radius, width);

        // Draw cylinder sides
        Gizmos.DrawLine(topCenter + Vector3.right * radius, bottomCenter + Vector3.right * radius);
        Gizmos.DrawLine(topCenter - Vector3.right * radius, bottomCenter - Vector3.right * radius);
        Gizmos.DrawLine(topCenter + Vector3.forward * radius, bottomCenter + Vector3.forward * radius);
        Gizmos.DrawLine(topCenter - Vector3.forward * radius, bottomCenter - Vector3.forward * radius);
    }

    void DrawCircleGizmo(Vector3 center, float radius, float width)
    {
        Vector3 prevPoint = Vector3.zero;
        for (int i = 0; i <= 360; i += 10)
        {
            float angle = i * Mathf.Deg2Rad;
            Vector3 point = center + new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius);
            if (i > 0)
            {
                Gizmos.DrawLine(prevPoint, point);
            }
            prevPoint = point;
        }
    }
}

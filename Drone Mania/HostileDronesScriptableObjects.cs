using UnityEngine;

[CreateAssetMenu(fileName = "Enemy1", menuName = "MDG/ScriptableObjects/HostileDroneStatsScriptableObject")]
public class HostileDronesScriptableObjects : ScriptableObject
{

    [Header("BaseStats")]//Stores Base Stats
    [SerializeField] public DroneFaction droneFaction;
    [SerializeField] public DroneType droneType;
    [SerializeField] public int baseHealth = 100;
    [SerializeField] public int currentHealth = 100;
    [SerializeField] public float baseSpeed = 15;
    [SerializeField] public float rotateSpeed = 220;
    [SerializeField] public float baseFireRate = 0.5f;
    [SerializeField] public int baseDamage;
    [SerializeField] public GameObject bullet;
    [SerializeField] public LootTable lootTable;
    [SerializeField] public GameObject blastParticlesSystem;

    [Header("PREDICTION")]
    [SerializeField] public float _maxDistancePredict = 5000;
    [SerializeField] public float _minDistancePredict = 5;
    [SerializeField] public float _maxTimePrediction = 1;
    [SerializeField]public Vector3 _standardPrediction, _deviatedPrediction;

    [Header("DEVIATION")]
    [SerializeField] public float _deviationAmount = 1;
    [SerializeField] public float _deviationSpeed = 1;

    [Tooltip("CurrentPathGenerator")]
    [SerializeField] public GameObject _dronePathSpawner;
    [Tooltip("PathGeneratorPrefabToMakeNewPath")]
    [SerializeField] public GameObject _dronePathSpawnerPrefab;

    public enum DroneFaction
    {
        EnemyDrone,
        BossDrone,
    }

    public enum DroneType
    {
        Warrior,//Drone Will Join Drone BaseCamp And Defend It <<Stays In Group>>
        Adventurer,//Drone Which Wonders Around Lonely <<Stay Solo>>
        Guardian,//Drone Which Will Protect Portals <<Stays In Group>>
    }
}

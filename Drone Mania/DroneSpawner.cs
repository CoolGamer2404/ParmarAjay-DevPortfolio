using UnityEditor;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject[] dronePrefabs; // Array of drone prefabs for different types
    public HostileDronesScriptableObjects[] _hostileDroneStatsScriptableObjects;
    public GameObject[] spawnedDronePrefabs;
    public int minSpawnLimit = 1;
    public int maxSpawnLimit = 5;
    public float spawnRadius = 10f;
    public float spawnHeight = 5f; // Height of the spawn area cylinder
    public float spawnWidth = 5f; // Width of the spawn area cylinder
    public float spawnProofRadius = 20f; // Radius of the spawn-proof area around the player
    public float spawnProofHeight = 5f; // Height of the spawn-proof area cylinder
    public float spawnProofWidth = 5f; // Width of the spawn-proof area cylinder
    public Transform playerTransform; // Reference to the player's transform

    public bool visualizeSpawnArea = true; // Toggle to visualize spawn areas

    private int currentSpawnedDrones = 0;

    void Start()
    {
        SpawnDrones();
    }

    void SpawnDrones()
    {
        int numDronesToSpawn = Random.Range(minSpawnLimit, maxSpawnLimit + 1);
        for (int i = 0; i < numDronesToSpawn; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject randomDronePrefab = GetRandomDronePrefab();
            GameObject newDrone = Instantiate(randomDronePrefab, spawnPosition, Quaternion.identity);
            spawnedDronePrefabs[i]=newDrone;

            // Create and initialize a DroneStatsScriptableObject for the spawned drone
            HostileDronesScriptableObjects droneStats = ScriptableObject.CreateInstance<HostileDronesScriptableObjects>();

            // Determine faction
            droneStats.droneFaction = HostileDronesScriptableObjects.DroneFaction.EnemyDrone;
            _hostileDroneStatsScriptableObjects[i] = droneStats;

            // Determine type based on random chance or other conditions
            DetermineDroneType(i);
            // You can also set additional properties based on the drone type if needed

            currentSpawnedDrones++;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomCircle.x, 0f, randomCircle.y) + playerTransform.position;
        spawnPosition.y = Random.Range(playerTransform.position.y, playerTransform.position.y + spawnHeight); // Randomize height
        return spawnPosition;
    }

    GameObject GetRandomDronePrefab()
    {
        return dronePrefabs[Random.Range(0, dronePrefabs.Length)];
    }

    public void DetermineDroneType(int number)
    {
        // Implement logic to determine the drone type
        // This can be based on random chance, player progress, etc.
        // For example:
        float randomValue = Random.value;
        if (randomValue < 0.33f)
        {
            //return DroneStatsScriptableObject.DroneType.Warrior;
            _hostileDroneStatsScriptableObjects[number].droneType = HostileDronesScriptableObjects.DroneType.Warrior;
        }
        else if (randomValue < 0.66f)
        {
            //return DroneStatsScriptableObject.DroneType.Adventurer;
            _hostileDroneStatsScriptableObjects[number].droneType = HostileDronesScriptableObjects.DroneType.Adventurer;
        }
        else
        {
            //return DroneStatsScriptableObject.DroneType.Guardian;
            _hostileDroneStatsScriptableObjects[number].droneType = HostileDronesScriptableObjects.DroneType.Guardian;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (visualizeSpawnArea)
        {
            Gizmos.color = Color.blue;
            DrawCylinderGizmo(playerTransform.position, spawnRadius, spawnHeight, spawnWidth);
            Gizmos.color = Color.red;
            DrawCylinderGizmo(playerTransform.position, spawnProofRadius, spawnProofHeight, spawnProofWidth);
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

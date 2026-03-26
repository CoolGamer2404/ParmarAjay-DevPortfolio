using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2Spawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn; // List of prefabs to spawn
    public List<Transform> spawnPoints; // List of spawn points

    private List<Transform> usedSpawnPoints = new List<Transform>(); // Track used spawn points

    private void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        foreach (GameObject objectToSpawn in objectsToSpawn)
        {
            Transform spawnPoint = GetRandomUnusedSpawnPoint();
            if (spawnPoint != null)
            {
                Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
                usedSpawnPoints.Add(spawnPoint);
            }
        }
    }

    Transform GetRandomUnusedSpawnPoint()
    {
        List<Transform> unusedSpawnPoints = new List<Transform>(spawnPoints);

        foreach (Transform usedSpawnPoint in usedSpawnPoints)
        {
            unusedSpawnPoints.Remove(usedSpawnPoint);
        }

        if (unusedSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, unusedSpawnPoints.Count);
            return unusedSpawnPoints[randomIndex];
        }

        return null;
    }
}

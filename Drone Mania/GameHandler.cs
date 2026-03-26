using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    int equippedDrone;

    [SerializeField]private GameObject[] drones;
    [SerializeField]private GameObject[] spawnPoints;
    
    void Awake()
    {
        equippedDrone=PlayerPrefs.GetInt("EquippedDrone");
        Instantiate(drones[equippedDrone-1],spawnPoints[Random.Range(0,spawnPoints.Length)].transform.position,spawnPoints[Random.Range(0,spawnPoints.Length)].transform.rotation);
    }

    void Update()
    {
        
    }
}

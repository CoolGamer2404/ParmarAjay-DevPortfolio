using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1Handler : MonoBehaviour
{
    [SerializeField] private float health;
    private float maxHealth;
    private float baseHealth;
    [SerializeField] private PortalHealthBarHandler _portalHealthBarHandler;
    private int _multiplier = 1;
    [SerializeField] private Portal1Handler[] portal1Handlers;
    private bool isDestroyed = false;
    [SerializeField] private int difficulty=1;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject spawnPositions;
    [SerializeField] private GameObject[] spawnedDrones;

    [SerializeField] private GameObject drone;
    [SerializeField] private GameObject portalCore;
    [SerializeField] private GameObject coreSpawnPoint;

    void Awake()
    {
        //droneStatsScriptableObject=spawnedDrones[0].GetComponent<HostileDronesScriptableObjects>();
        maxHealth = health;
        baseHealth=health;
        //droneBaseDMG=droneStatsScriptableObject.baseDamage;
        //droneBaseHealth=droneStatsScriptableObject.baseHealth;
        //SpawnDrone(5);
        Instantiate(drone,spawnPositions.transform.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnDrone(int amount){
        for (int i = 0; i < amount; i++)
        {
           Instantiate(drone,spawnPositions.transform.position,Quaternion.identity);
        }
    }

    public void Damage(int dmgAmount)
    {
        Debug.Log("Damage");
        if (health <= dmgAmount)
        {
            if (!isDestroyed)
            {
                health -= dmgAmount;
                DestroyThis();
            }
        }
        else
        {
            health -= dmgAmount;
            _portalHealthBarHandler.enabled = true;
            _portalHealthBarHandler.UpdateHealthBar(maxHealth, health);
        }
    }

    private void DestroyThis()
    {
        isDestroyed = true;
        Instantiate(portalCore,coreSpawnPoint.transform.position,Quaternion.identity);
        foreach (var item in portal1Handlers)
        {
            if (item != null)
            {
                item.IncreseMultiplier();
            }
        }
        transform.GetComponent<Portal1Handler>().enabled=false;
        Destroy(portal);
    }

    /// <summary>
    /// Call this function when portal get destroyed 
    /// </summary>
    private HostileDronesScriptableObjects droneStatsScriptableObject;
    private int droneBaseDMG;
    private int droneBaseHealth;
    public void IncreseMultiplier()
    {
        Debug.Log("Current Max HP Is : " + maxHealth.ToString() + "Current HP Is : " + health.ToString() + "Before Increse");
        _multiplier += 1;
        health = baseHealth * _multiplier;
        maxHealth=baseHealth*_multiplier;
        Debug.Log("updated Multiplier To" + _multiplier.ToString());
        Debug.Log("Current Max HP Is : " + maxHealth.ToString() + "Current HP Is : " + health.ToString() + "After Increse");
        return;
    }

    public void IncreseDifficulty(int difficultylvl){
        /////////increse stats of all spawned drones and drones that are going to spawn
        for (int i = 0; i < spawnedDrones.Length; i++)
        {
            droneStatsScriptableObject=spawnedDrones[i].GetComponent<HostileDronesScriptableObjects>();
            droneStatsScriptableObject.currentHealth=droneBaseHealth*difficultylvl;
            droneStatsScriptableObject.baseHealth=droneBaseHealth*difficultylvl;
            droneStatsScriptableObject.baseDamage=droneBaseDMG*difficultylvl;
        }
    }
}

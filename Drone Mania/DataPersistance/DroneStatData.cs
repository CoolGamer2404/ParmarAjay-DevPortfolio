using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DroneStatData
{
    [Header("DroneCurrentData")]
    [SerializeField]
    public bool equipped = false;

    [SerializeField]
    public bool purchased = false;

    [SerializeField]
    public string DRONE_KEY;

    [SerializeField]
    public string DRONE_ENCRYPT_KEY;

    [Header("BaseStats")] //Stores Base Stats
    [SerializeField]
    public int baseHealth = 100;

    //[SerializeField]private float baseSpeed=5f;
    //[SerializeField]private bool baseThruster=false;
    //[SerializeField]private float baseThrusterSpeed;
    //[SerializeField]private float baseThrusterCoolDown;
    [SerializeField]
    public float baseEnergy;

    [SerializeField]
    public int baseDamage;

    [SerializeField]
    public float baseFireRate;

    //[SerializeField]public float energyRegainRate;
    //[SerializeField]public float baseEnergyCost;
    [SerializeField]
    public int currenthealthUpgradePoints;

    //[SerializeField]public int currentthrusterUpgradePoints;
    //[SerializeField]public int currentthrusterPurchasePoint;
    //[SerializeField]public int currentspeedUpgradePoints;
    [SerializeField]
    public int currentenergyUpgradePoints;

    [SerializeField]
    public int currentFireRateUpgradepoints;

    [SerializeField]
    public int currentDamageUpgradepoints;

    [Header("SkinsData")]
    [SerializeField]
    public bool[] isSkinsPurchased;

    [SerializeField]
    public int EquippedSkinNumber;
}

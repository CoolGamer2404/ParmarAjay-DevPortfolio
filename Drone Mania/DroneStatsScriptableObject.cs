using UnityEngine;

[CreateAssetMenu(fileName ="Player1",menuName ="MDG/ScriptableObjects/PlayerDroneStatsScriptableObject")]
public class DroneStatsScriptableObject : ScriptableObject
{
    [Header("DroneCurrentData")]
    [SerializeField]public bool equipped=false;
    [SerializeField]public bool purchased=false;
    [SerializeField]public int price=1000;
    [SerializeField]public string DRONE_KEY;
    [SerializeField]public string DRONE_ENCRYPT_KEY;

    [Header("BaseStats")]//Stores Base Stats
    [SerializeField]public int baseHealth=100;
    [SerializeField]private float baseSpeed=5f;
    [SerializeField]private bool baseThruster=false;
    [SerializeField]private float baseThrusterSpeed=0f;
    [SerializeField]private float baseThrusterCoolDown=180f;
    [SerializeField]public float baseEnergy=1000;
    [SerializeField]public int baseDamage;
    [SerializeField]public float baseFireRate;
    [SerializeField]public float energyRegainRate=15;
    [SerializeField]public float baseEnergyCost;

    [Header("PerUpgradeStats")]//Stores How MUch It Can Be Upgraded
    [SerializeField]public int addHealth=250;
    [SerializeField]private float addSpeed=10f;
    [SerializeField]private bool purchasableThruster=false;
    [SerializeField]private float addThrusterSpeed=0f;
    [SerializeField]private float addThrusterCoolDown=180f;
    [SerializeField]public float addEnergy=3000;
    [SerializeField]public int addDamage;
    [SerializeField]public float addFireRate;

    [Header("LevelStats")]//Stores Current Lvl Stats
    [SerializeField]public int currentHealth=100;
    [SerializeField]private float currentSpeed=5f;
    [SerializeField]private bool isThruster=false;
    [SerializeField]private float currentThrusterSpeed=0f;
    [SerializeField]private float currentThrusterCoolDown=180f;
    [SerializeField]public float currentEnergy=1000;
    [SerializeField]private int currentDamage;
    [SerializeField]public float currentFireRate;

    [Header("ShopStats")]//Stores How many Times It can be upgraded through shops
    [SerializeField]public int maxhealthUpgradePoints=3;
    [SerializeField]public int maxthrusterUpgradePoints=1;
    [SerializeField]public int maxthrusterPurchasePoint=0;
    [SerializeField]public int maxspeedUpgradePoints=2;
    [SerializeField]public int maxenergyUpgradePoints=4;
    [SerializeField]public int maxFireRateUpgradepoints;
    [SerializeField]public int maxDamageUpgradepoints;

    [SerializeField]public int currenthealthUpgradePoints=3;
    [SerializeField]public int currentthrusterUpgradePoints=1;
    [SerializeField]public int currentthrusterPurchasePoint=0;
    [SerializeField]public int currentspeedUpgradePoints=2;
    [SerializeField]public int currentenergyUpgradePoints=4;
    [SerializeField]public int currentFireRateUpgradepoints;
    [SerializeField]public int currentDamageUpgradepoints;

    [SerializeField]public int[] healthUpgradeCost;
    [SerializeField]public int[] energyUpgradeCost;
    [SerializeField]public int[] damageUpgradeCost;
    [SerializeField]public int[] firerateUpgradeCost;

    [Header("SkinsData")]
    [SerializeField]public int[] skinsPrice;
    [SerializeField]public bool[] isSkinsPurchased;
    [SerializeField]public bool[] isSkinsPurchasable;
    [SerializeField]public int EquippedSkinNumber;
}

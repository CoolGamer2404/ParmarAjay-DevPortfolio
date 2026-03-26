using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneStatDataCallbacks : MonoBehaviour
{
    public DronesStatDataHandler _DronesStatDataHandler;

    [SerializeField]
    private DroneStatsScriptableObject[] _DroneStatsScriptableObject;

    private void Awake()
    {
        StartCoroutine(_Start());
    }

    public void Load(string key, string decryptKey, DroneStatsScriptableObject stats)
    {
        // LOAD SCRIPTABLE OBJECT DATA //
        DroneStatData data = _DronesStatDataHandler.LoadData(key, decryptKey);

        stats.equipped = data.equipped;
        stats.purchased = data.purchased;
        stats.DRONE_KEY = data.DRONE_KEY;
        stats.DRONE_ENCRYPT_KEY = data.DRONE_ENCRYPT_KEY;
        stats.baseHealth = data.baseHealth;
        stats.baseEnergy = data.baseEnergy;
        stats.baseDamage = data.baseDamage;
        stats.baseFireRate = data.baseFireRate;
        stats.currenthealthUpgradePoints = data.currenthealthUpgradePoints;
        stats.currentenergyUpgradePoints = data.currentenergyUpgradePoints;
        stats.currentFireRateUpgradepoints = data.currentFireRateUpgradepoints;
        stats.currentDamageUpgradepoints = data.currentDamageUpgradepoints;
        stats.isSkinsPurchased = data.isSkinsPurchased;
        stats.EquippedSkinNumber = data.EquippedSkinNumber;
    }

    public void Save(DroneStatsScriptableObject stats)
    {
        // SAVE SCRIPTABLE OBJECT DATA //
        DroneStatData data = new DroneStatData();

        data.equipped = stats.equipped;
        data.purchased = stats.purchased;
        data.DRONE_KEY = stats.DRONE_KEY;
        data.DRONE_ENCRYPT_KEY = stats.DRONE_ENCRYPT_KEY;
        data.baseHealth = stats.baseHealth;
        data.baseEnergy = stats.baseEnergy;
        data.baseDamage = stats.baseDamage;
        data.baseFireRate = stats.baseFireRate;
        data.currenthealthUpgradePoints = stats.currenthealthUpgradePoints;
        data.currentenergyUpgradePoints = stats.currentenergyUpgradePoints;
        data.currentFireRateUpgradepoints = stats.currentFireRateUpgradepoints;
        data.currentDamageUpgradepoints = stats.currentDamageUpgradepoints;
        data.isSkinsPurchased = stats.isSkinsPurchased;
        data.EquippedSkinNumber = stats.EquippedSkinNumber;

        _DronesStatDataHandler.SaveData(data);
    }

    private IEnumerator _Start()
    {
        // GET ALL SCRIPTABLE_OBJECTS FROM REFERENCES AND FEED INTO LOAD METHOD //
        foreach (var SO in _DroneStatsScriptableObject)
        {
            if (PlayerPrefs.GetInt("SavedData") != 0)
            {
                Load(SO.DRONE_KEY, SO.DRONE_ENCRYPT_KEY, SO);
            }
            else if (PlayerPrefs.GetInt("SavedData") == 0)
            {
                Save(SO);
            }
            yield return new WaitForSeconds(0.2f);
        }
        PlayerPrefs.SetInt("SavedData", 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DroneStatsHandler : MonoBehaviour
{
    [SerializeField] private ShopHandler shopHandler;
    [SerializeField] private DroneStatsScriptableObject drone;
    [SerializeField] private DroneStatsScriptableObject[] otherDrones;
    [SerializeField] private Image[] healthUpgradePoints;
    [SerializeField] private Image[] speedUpgradePoints;
    [SerializeField] private Image[] energyUpgradePoints;
    [SerializeField] private Image[] firerateUpgradePoints;
    [SerializeField] private Image[] damageUpgradePoints;
    [SerializeField] private GameObject[] upgradeBTNs;

    [SerializeField] private GameObject buyBTN;
    [SerializeField] private GameObject EquipBTN;
    [SerializeField] private GameObject EquippedIMG;
    [SerializeField] private GameObject droneShocase;
    [SerializeField] private float rotationSpeed = 0;
    [SerializeField] private int currentDroneNumber;

    [SerializeField] private GameObject healthUpgradeButton;
    [SerializeField] private TMP_Text healthUpgradeCost;
    [SerializeField] private GameObject damageUpgradeButton;
    [SerializeField] private TMP_Text damageUpgradeCost;
    [SerializeField] private GameObject firerateUpgradeButton;
    [SerializeField] private TMP_Text firerateUpgradeCost;
    [SerializeField] private GameObject energyUpgradeButton;
    [SerializeField] private TMP_Text energyUpgradeCost;

    [SerializeField] private MainMenuHandler mainMenuHandler;
    [SerializeField]private DroneStatDataCallbacks _dronesStatDataCallbacks;

    Quaternion rotation;

    void Start()
    {
        shopHandler.currentSelectedDrone = currentDroneNumber;
        UpdateButtonsData();
        UpgradeHealthPoints();
        //UpgradeSpeedPoints();
        UpgradeDamagePoints();
        UpgradFireRatePoints();
        UpgradeEnergyPoints();
        UpgradeEquipedDrone();
        UpdateButtonsData();
    }

    void OnEnable()
    {
        shopHandler.currentSelectedDrone = currentDroneNumber;
        UpdateButtonsData();
        UpgradeHealthPoints();
        //UpgradeSpeedPoints();
        UpgradeDamagePoints();
        UpgradFireRatePoints();
        UpgradeEnergyPoints();
        UpgradeEquipedDrone();
        UpdateButtonsData();
    }

    void Update()
    {
        droneShocase.transform.Rotate(0, Time.deltaTime * rotationSpeed, 0, Space.Self);
    }


    public void UpgradeHealthPoints()
    {
        if (drone.currenthealthUpgradePoints == 0)
        {
            healthUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 1; i < drone.maxhealthUpgradePoints + 1; i++)
            {
                healthUpgradePoints[i].sprite = shopHandler.availableUpgradePointImage;
            }
            for (int i = drone.maxhealthUpgradePoints + 1; i < 6; i++)
            {
                healthUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
        else if (drone.currenthealthUpgradePoints != 0 && drone.currenthealthUpgradePoints == drone.maxhealthUpgradePoints)
        {
            healthUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 0; i < drone.currenthealthUpgradePoints + 1; i++)
            {
                healthUpgradePoints[i].sprite = shopHandler.usedUpgradePointImage;
            }
            for (int i = drone.maxhealthUpgradePoints + 1; i < 6; i++)
            {
                healthUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
        else if (drone.currenthealthUpgradePoints != 0 && drone.currenthealthUpgradePoints != drone.maxhealthUpgradePoints)
        {
            healthUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 0; i < drone.currenthealthUpgradePoints + 1; i++)
            {
                healthUpgradePoints[i].sprite = shopHandler.usedUpgradePointImage;
            }
            for (int i = drone.currenthealthUpgradePoints + 1; i < drone.maxhealthUpgradePoints; i++)
            {
                healthUpgradePoints[i].sprite = shopHandler.availableUpgradePointImage;
            }
            for (int i = drone.maxhealthUpgradePoints + 1; i < 6; i++)
            {
                healthUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
    }
    public void UpgradeSpeedPoints()
    {
        if (drone.currentspeedUpgradePoints == 0)
        {
            speedUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 1; i < drone.maxspeedUpgradePoints + 1; i++)
            {
                speedUpgradePoints[i].sprite = shopHandler.availableUpgradePointImage;
            }
            for (int i = drone.maxspeedUpgradePoints + 1; i < 6; i++)
            {
                speedUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
        else if (drone.currentspeedUpgradePoints != 0 && drone.currentspeedUpgradePoints == drone.maxspeedUpgradePoints)
        {
            speedUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 0; i < drone.currentspeedUpgradePoints + 1; i++)
            {
                speedUpgradePoints[i].sprite = shopHandler.usedUpgradePointImage;
            }
            for (int i = drone.maxspeedUpgradePoints + 1; i < 6; i++)
            {
                speedUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
        else if (drone.currentspeedUpgradePoints != 0 && drone.currentspeedUpgradePoints != drone.maxspeedUpgradePoints)
        {
            speedUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 0; i < drone.currentspeedUpgradePoints + 1; i++)
            {
                speedUpgradePoints[i].sprite = shopHandler.usedUpgradePointImage;
            }
            for (int i = drone.currentspeedUpgradePoints + 1; i < drone.maxspeedUpgradePoints; i++)
            {
                speedUpgradePoints[i].sprite = shopHandler.availableUpgradePointImage;
            }
            for (int i = drone.maxspeedUpgradePoints + 1; i < 6; i++)
            {
                speedUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
    }
    public void UpgradeDamagePoints()
    {
        if (drone.currentDamageUpgradepoints == 0)
        {
            damageUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 1; i < drone.maxDamageUpgradepoints + 1; i++)
            {
                damageUpgradePoints[i].sprite = shopHandler.availableUpgradePointImage;
            }
            for (int i = drone.maxDamageUpgradepoints + 1; i < 6; i++)
            {
                damageUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
        else if (drone.currentDamageUpgradepoints != 0 && drone.currentDamageUpgradepoints == drone.maxDamageUpgradepoints)
        {
            damageUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 0; i < drone.currentDamageUpgradepoints + 1; i++)
            {
                damageUpgradePoints[i].sprite = shopHandler.usedUpgradePointImage;
            }
            for (int i = drone.maxDamageUpgradepoints + 1; i < 6; i++)
            {
                damageUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
        else if (drone.currentDamageUpgradepoints != 0 && drone.currentDamageUpgradepoints != drone.maxDamageUpgradepoints)
        {
            damageUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 0; i < drone.currentDamageUpgradepoints + 1; i++)
            {
                damageUpgradePoints[i].sprite = shopHandler.usedUpgradePointImage;
            }
            for (int i = drone.currentDamageUpgradepoints + 1; i < drone.maxDamageUpgradepoints; i++)
            {
                damageUpgradePoints[i].sprite = shopHandler.availableUpgradePointImage;
            }
            for (int i = drone.maxDamageUpgradepoints + 1; i < 6; i++)
            {
                damageUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
    }
    public void UpgradFireRatePoints()
    {
        if (drone.currentFireRateUpgradepoints == 0)
        {
            firerateUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 1; i < drone.maxFireRateUpgradepoints + 1; i++)
            {
                firerateUpgradePoints[i].sprite = shopHandler.availableUpgradePointImage;
            }
            for (int i = drone.maxFireRateUpgradepoints + 1; i < 6; i++)
            {
                firerateUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
        else if (drone.currentFireRateUpgradepoints != 0 && drone.currentFireRateUpgradepoints == drone.maxFireRateUpgradepoints)
        {
            firerateUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 0; i < drone.currentFireRateUpgradepoints + 1; i++)
            {
                firerateUpgradePoints[i].sprite = shopHandler.usedUpgradePointImage;
            }
            for (int i = drone.maxFireRateUpgradepoints + 1; i < 6; i++)
            {
                firerateUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
        else if (drone.currentFireRateUpgradepoints != 0 && drone.currentFireRateUpgradepoints != drone.maxFireRateUpgradepoints)
        {
            firerateUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 0; i < drone.currentFireRateUpgradepoints + 1; i++)
            {
                firerateUpgradePoints[i].sprite = shopHandler.usedUpgradePointImage;
            }
            for (int i = drone.currentFireRateUpgradepoints + 1; i < drone.maxFireRateUpgradepoints; i++)
            {
                firerateUpgradePoints[i].sprite = shopHandler.availableUpgradePointImage;
            }
            for (int i = drone.maxFireRateUpgradepoints + 1; i < 6; i++)
            {
                firerateUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
    }
    public void UpgradeEnergyPoints()
    {
        if (drone.currentenergyUpgradePoints == 0)
        {
            energyUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 1; i < drone.maxenergyUpgradePoints + 1; i++)
            {
                energyUpgradePoints[i].sprite = shopHandler.availableUpgradePointImage;
            }
            for (int i = drone.maxenergyUpgradePoints + 1; i < 6; i++)
            {
                energyUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
        else if (drone.currentenergyUpgradePoints != 0 && drone.currentenergyUpgradePoints == drone.maxenergyUpgradePoints)
        {
            energyUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 0; i < drone.currentenergyUpgradePoints + 1; i++)
            {
                energyUpgradePoints[i].sprite = shopHandler.usedUpgradePointImage;
            }
            for (int i = drone.maxenergyUpgradePoints + 1; i < 6; i++)
            {
                energyUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
        else if (drone.currentenergyUpgradePoints != 0 && drone.currentenergyUpgradePoints != drone.maxenergyUpgradePoints)
        {
            energyUpgradePoints[0].sprite = shopHandler.usedUpgradePointImage;
            for (int i = 0; i < drone.currentenergyUpgradePoints + 1; i++)
            {
                energyUpgradePoints[i].sprite = shopHandler.usedUpgradePointImage;
            }
            for (int i = drone.currentenergyUpgradePoints + 1; i < drone.maxenergyUpgradePoints; i++)
            {
                energyUpgradePoints[i].sprite = shopHandler.availableUpgradePointImage;
            }
            for (int i = drone.maxenergyUpgradePoints + 1; i < 6; i++)
            {
                energyUpgradePoints[i].sprite = shopHandler.emptyUpgradePointImage;
            }
        }
    }
    public void UpgradeEquipedDrone()
    {
        if (drone.purchased && drone.equipped)
        {
            buyBTN.SetActive(false);
            EquipBTN.SetActive(false);
            EquippedIMG.SetActive(true);
            for (int i = 0; i < upgradeBTNs.Length; i++)
            {
                upgradeBTNs[i].SetActive(true);
            }
        }
        else if (drone.purchased && !drone.equipped)
        {
            buyBTN.SetActive(false);
            EquipBTN.SetActive(true);
            EquippedIMG.SetActive(false);
            for (int i = 0; i < upgradeBTNs.Length; i++)
            {
                upgradeBTNs[i].SetActive(true);
            }
        }
        else if (!drone.purchased)
        {
            buyBTN.SetActive(true);
            EquipBTN.SetActive(false);
            EquippedIMG.SetActive(false);
            for (int i = 0; i < upgradeBTNs.Length; i++)
            {
                upgradeBTNs[i].SetActive(false);
            }
        }
    }
    public void EquipDrone()
    {
        for (int i = 0; i < otherDrones.Length; i++)
        {
            otherDrones[i].equipped = false;
        }
        drone.equipped = true;
        UpgradeEquipedDrone();
        shopHandler.Equip();
        _dronesStatDataCallbacks.Save(drone);
    }

    private void UpdateButtonsData()
    {
        if (drone.purchased)
        {
            if (drone.currenthealthUpgradePoints != drone.maxhealthUpgradePoints)
            {
                healthUpgradeButton.SetActive(true);
                healthUpgradeCost.text = drone.healthUpgradeCost[drone.currenthealthUpgradePoints + 1].ToString();
            }
            else if (drone.currenthealthUpgradePoints == drone.maxhealthUpgradePoints)
            {
                healthUpgradeButton.SetActive(false);
            }
            if (drone.currentDamageUpgradepoints != drone.maxDamageUpgradepoints)
            {
                damageUpgradeButton.SetActive(true);
                damageUpgradeCost.text = drone.damageUpgradeCost[drone.currentDamageUpgradepoints + 1].ToString();
            }
            else if (drone.currentDamageUpgradepoints == drone.maxDamageUpgradepoints)
            {
                damageUpgradeButton.SetActive(false);
            }
            if (drone.currentenergyUpgradePoints != drone.maxenergyUpgradePoints)
            {
                energyUpgradeButton.SetActive(true);
                energyUpgradeCost.text = drone.energyUpgradeCost[drone.currentenergyUpgradePoints + 1].ToString();
            }
            else if (drone.currentenergyUpgradePoints == drone.maxenergyUpgradePoints)
            {
                energyUpgradeButton.SetActive(false);
            }
            if (drone.currentFireRateUpgradepoints != drone.maxFireRateUpgradepoints)
            {
                firerateUpgradeButton.SetActive(true);
                firerateUpgradeCost.text = drone.healthUpgradeCost[drone.currentFireRateUpgradepoints + 1].ToString();
            }
            else if (drone.currentFireRateUpgradepoints == drone.maxFireRateUpgradepoints)
            {
                firerateUpgradeButton.SetActive(false);
            }
        }
        else if (drone.purchased == false)
        {
            healthUpgradeButton.SetActive(false);
            damageUpgradeButton.SetActive(false);
            firerateUpgradeButton.SetActive(false);
            energyUpgradeButton.SetActive(false);
        }
    }

    private int coins;
    private int scraps;

    public void UpgradeHealth()
    {
        if (PlayerPrefs.GetInt("Scrap") >= drone.healthUpgradeCost[drone.currenthealthUpgradePoints + 1])
        {
            //Debug.Log("You Have Enough");
            scraps = PlayerPrefs.GetInt("Scrap");
            PlayerPrefs.SetInt("Scrap", scraps - drone.healthUpgradeCost[drone.currenthealthUpgradePoints + 1]);
            drone.currenthealthUpgradePoints += 1;
            drone.baseHealth += drone.addHealth;
            UpdateButtonsData();
            UpgradeHealthPoints();
            UpdateButtonsData();
            mainMenuHandler.UpdateData();
            _dronesStatDataCallbacks.Save(drone);
        }
        else if (PlayerPrefs.GetInt("Scrap") < drone.healthUpgradeCost[drone.currenthealthUpgradePoints + 1])
        {
            Debug.Log("You Don't Have Enough");
        }
    }
    public void UpgradeEnergy()
    {
        if (PlayerPrefs.GetInt("Scrap") >= drone.energyUpgradeCost[drone.currentenergyUpgradePoints + 1])
        {
            //Debug.Log("You Have Enough");
            scraps = PlayerPrefs.GetInt("Scrap");
            PlayerPrefs.SetInt("Scrap", scraps - drone.energyUpgradeCost[drone.currentenergyUpgradePoints + 1]);
            drone.currentenergyUpgradePoints += 1;
            drone.baseEnergy += drone.addEnergy;
            UpdateButtonsData();
            UpgradeEnergyPoints();
            UpdateButtonsData();
            mainMenuHandler.UpdateData();
            _dronesStatDataCallbacks.Save(drone);
        }
        else if (PlayerPrefs.GetInt("Scrap") < drone.energyUpgradeCost[drone.currentenergyUpgradePoints + 1])
        {
            Debug.Log("You Don't Have Enough");
        }
    }
    public void UpgradeFireRate()
    {
        if (PlayerPrefs.GetInt("Scrap") >= drone.firerateUpgradeCost[drone.currentFireRateUpgradepoints + 1])
        {
            //Debug.Log("You Have Enough");
            scraps = PlayerPrefs.GetInt("Scrap");
            PlayerPrefs.SetInt("Scrap", scraps - drone.firerateUpgradeCost[drone.currentFireRateUpgradepoints + 1]);
            drone.currentFireRateUpgradepoints += 1;
            drone.baseFireRate += drone.addFireRate;
            UpdateButtonsData();
            UpgradeFireRate();
            UpdateButtonsData();
            mainMenuHandler.UpdateData();
            _dronesStatDataCallbacks.Save(drone);
        }
        else if (PlayerPrefs.GetInt("Scrap") < drone.firerateUpgradeCost[drone.currentFireRateUpgradepoints + 1])
        {
            Debug.Log("You Don't Have Enough");
        }
    }
    public void UpgradeDamage()
    {
        if (PlayerPrefs.GetInt("Scrap") >= drone.damageUpgradeCost[drone.currentDamageUpgradepoints + 1])
        {
            //Debug.Log("You Have Enough");
            scraps = PlayerPrefs.GetInt("Scrap");
            PlayerPrefs.SetInt("Scrap", scraps - drone.damageUpgradeCost[drone.currentDamageUpgradepoints + 1]);
            drone.currentDamageUpgradepoints += 1;
            drone.baseDamage += drone.addDamage;
            UpdateButtonsData();
            UpgradeDamagePoints();
            UpdateButtonsData();
            mainMenuHandler.UpdateData();
            _dronesStatDataCallbacks.Save(drone);
        }
        else if (PlayerPrefs.GetInt("Scrap") < drone.damageUpgradeCost[drone.currentDamageUpgradepoints + 1])
        {
            Debug.Log("You Don't Have Enough");
        }
    }

    public void PurchaseDrone()
    {
        if (PlayerPrefs.GetInt("Coin") >= drone.price && !drone.purchased)
        {
            coins = PlayerPrefs.GetInt("Coin") - drone.price;
            PlayerPrefs.SetInt("Coin", coins);
            drone.purchased = true;
            UpdateButtonsData();
            UpgradeHealthPoints();
            //UpgradeSpeedPoints();
            UpgradeDamagePoints();
            UpgradFireRatePoints();
            UpgradeEnergyPoints();
            UpgradeEquipedDrone();
            UpdateButtonsData();
            mainMenuHandler.UpdateData();
            _dronesStatDataCallbacks.Save(drone);
        }
        else if(PlayerPrefs.GetInt("Coin") < drone.price && !drone.purchased){
            coins = drone.price-PlayerPrefs.GetInt("Coin");
            Debug.Log("You Don't Have Enough Coins You Need :- "+coins.ToString());
        }

        else if(drone.purchased){
            Debug.Log("You already own it. :)");
        }
    }
}

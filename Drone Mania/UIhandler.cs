using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIhandler : MonoBehaviour
{

    public bool autoRegainEnergy = false;

    public float regainRate = 0.1f;

    public Image image;

    [SerializeField] private Image _healthBarFill;
    [SerializeField] private TMPro.TMP_Text _healthAmounttext;
    [SerializeField] private Image _energyBarFill;
    [SerializeField] private TMPro.TMP_Text _energyAmounttext;
    [SerializeField] private TMPro.TMP_Text repairkittext;
    [SerializeField] private TMPro.TMP_Text batterytext;
    [SerializeField] public DroneStatsScriptableObject _droneStats;
    public bool isFirePressed;
    public Transform player;
    [SerializeField] public bool isMultiPlayer = false;

    public Transform crosshair;
    public Image _crossHairImage;

    public Sprite redCrossHairFocus;
    public Sprite blackCrossHairFocus;


    void Awake()
    {
        if (!isMultiPlayer)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            _droneStats = player.GetComponent<DroneHandler>().droneStatsScriptableObject;
        }
    }
    void OnEnable()
    {
        if (!isMultiPlayer)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            _droneStats = player.GetComponent<DroneHandler>().droneStatsScriptableObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _energyBarFill.fillAmount = _droneStats.currentEnergy / _droneStats.baseEnergy;
        _healthBarFill.fillAmount = _droneStats.currentHealth / _droneStats.baseHealth;
        _healthAmounttext.text = _droneStats.currentHealth.ToString() + "/" + _droneStats.baseHealth.ToString();
        if (autoRegainEnergy && _droneStats.currentEnergy <= _droneStats.baseEnergy)
        {
            _droneStats.currentEnergy += Time.deltaTime * regainRate;
            _energyBarFill.fillAmount = _droneStats.currentEnergy / _droneStats.baseEnergy;
            _energyAmounttext.text = Mathf.FloorToInt(_droneStats.currentEnergy).ToString() + "/" + _droneStats.baseEnergy.ToString();
        }
        repairkittext.text = PlayerPrefs.GetInt("RepairKit").ToString();
        batterytext.text = PlayerPrefs.GetInt("Battery").ToString();
    }

    public void ChangeToFirstPerson() { }
    public void ChangeToThirdPerson() { }

    public void UseBattery()
    {
        if (PlayerPrefs.GetInt("Battery") != 0)
        {
            int amount = PlayerPrefs.GetInt("Battery");
            PlayerPrefs.SetInt("Battery", amount -= 1);
            _droneStats.currentEnergy = _droneStats.baseEnergy;
            Debug.Log("Recharged");
            repairkittext.text = PlayerPrefs.GetInt("RepairKit").ToString();
            batterytext.text = PlayerPrefs.GetInt("Battery").ToString();
            return;
        }
    }
    public void UseRepairKit()
    {
        if (PlayerPrefs.GetInt("RepairKit") != 0)
        {
            int amount = PlayerPrefs.GetInt("RepairKit");
            PlayerPrefs.SetInt("RepairKit", amount -= 1);
            _droneStats.currentHealth = _droneStats.baseHealth;
            Debug.Log("Recharged");
            repairkittext.text = PlayerPrefs.GetInt("RepairKit").ToString();
            batterytext.text = PlayerPrefs.GetInt("Battery").ToString();
            return;
        }
    }
}

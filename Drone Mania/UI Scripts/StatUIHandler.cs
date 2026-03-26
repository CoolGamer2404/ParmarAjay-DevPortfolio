using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatUIHandler : MonoBehaviour
{
    [Header("Required Fields")]
    [SerializeField]private TMP_Text healthStatTXT;
    [SerializeField]private TMP_Text damageStatTXT;
    [SerializeField]private TMP_Text fireRateStatTXT;
    [SerializeField]private TMP_Text energyStatTXT;
    [SerializeField]private DroneStatsScriptableObject droneData;

    [Header("BaseStat")]
    [SerializeField]private int health;
    [SerializeField]private float firerate;
    [SerializeField]private float damage;
    [SerializeField]private float energy;
    

    private int newHealth;
    private float newFirerate;
    private float newDamage;
    private float newEnergy;
    public void UpdateStatDetails(){
        newHealth=droneData.baseHealth-health;
        newFirerate=droneData.baseFireRate-firerate;
        newDamage=droneData.baseDamage-damage;
        newEnergy=droneData.baseEnergy-energy;
        healthStatTXT.text =("(+" + newHealth.ToString() + ")").ToString();
        fireRateStatTXT.text=("(+" + newFirerate.ToString() + ")").ToString();
        damageStatTXT.text=("(+" + newDamage.ToString() + ")").ToString();
        energyStatTXT.text=("(+" + newEnergy.ToString() + ")").ToString();
    }
}

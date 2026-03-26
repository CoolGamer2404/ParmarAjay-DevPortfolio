using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;
using TMPro;
using UnityEngine.UI;

public class CharacterDataHandler : MonoBehaviour
{
    [SerializeField]private GameObject hitVFX;

    [Header("Character Stats")]
    public CharacterStat Health;//thia is max health
    public float CurrentHealth;//this is current health
    public CharacterStat Defence;//decrese damage by this amount
    [Tooltip("Base:-3")]
    public CharacterStat Speed;//speed of walking 
    [Tooltip("Base:-6")]
    public CharacterStat SprintSpeed;// sprint speed will be multiplied by 1.5 of base speed
    public CharacterStat CrouchSpeed;// sprint speed will be divided by .5 of base speed
    //public CharacterStat AttackSpeed;//speed of attacks
    public CharacterStat Damage;//damage
    public CharacterStat CritChance;//chance to do crit damage
    public CharacterStat CritDamage;//DMG == damage+crit damage
    public CharacterStat Strength;//breaking power of blocks
    public CharacterStat XPGain;//multiplies expereience gain

    [Header("Inventory Character Stats UI ")]
    [SerializeField]private TMP_Text healthText;
    [SerializeField]private TMP_Text damageText;
    [SerializeField]private TMP_Text speedText;
    [SerializeField]private TMP_Text critchanceText;
    [SerializeField]private TMP_Text critdamageText;
    [SerializeField]private TMP_Text strengthText;
    [SerializeField]private TMP_Text defenceText;

    [SerializeField] private Image _healthBarFill;
    [SerializeField] private TMP_Text healthbarText;
    [SerializeField] private GameObject deathCanvas;

    [Header("Data To Save")]
    public int Mushrooms=0;
    public int Coins=0;
    //[Header("Character Stats")]

    void Start()
    {
        UpdateUI();
        CurrentHealth=Health.Value;
    }

    // Update is called once per frame
    void Update()
    {
        _healthBarFill.fillAmount = CurrentHealth / Health.Value;
        healthbarText.text=(CurrentHealth+"/"+Health.Value).ToString();
    }

    public void TakeDamage(float damage){
        Debug.Log("Take Damage");
        float takenDamage=damage*(1-(Defence.Value/(Defence.Value+100)));
        CurrentHealth-=takenDamage;

        if(CurrentHealth<=takenDamage||CurrentHealth<0){
            Die();
        }
    }

    private void Die()
    {
        //throw new System.NotImplementedException();
        deathCanvas.SetActive(true);
    }

    float baseDamage,finalDamage;
    float critChance,critDamage;
    float randomRoll;
    public float CountDamage(){
        baseDamage=(Damage.Value+Strength.Value)/2;

        critChance=CritChance.Value/100;
        randomRoll=Random.Range(0,1);

        if(randomRoll < critChance){
            critDamage=CritDamage.Value/100;

            finalDamage=baseDamage*(1+critDamage);
            return finalDamage;
        }
        else{
            return baseDamage;
        }
    }
    public void GiveDamage(){}
    public void HitVFX(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 3f);

    }

#region INVENTORY STAT UI UPDATES
//UPDATE INVENTORY STAT UI//
    public void UpdateUI(){
        healthText.text=Health.Value.ToString();
        damageText.text=Damage.Value.ToString();
        speedText.text=Speed.Value.ToString();
        critchanceText.text=CritChance.Value.ToString();
        critdamageText.text=CritDamage.Value.ToString();
        defenceText.text=Defence.Value.ToString();
        strengthText.text=Strength.Value.ToString();
    }

#endregion


#region CHARACTER STATS SAVE & LOAD
//ALWAYS CALL SAVE STATS METHOD AFTER CHANGING DATA SO IT CAN BECOME EASIER TO TRACK ON GAME CRASH OR ON ANY ERRORS//
//ONLY SAVE BASE_CHARACTER_STAT_DATA THAT WE GET DURING NEW START AND ONLY ADD PERMANENT BUFFS LIKE SKILLS LVL UP THIS FOR PERMANENT SAVE INTO SLOT//
//THIS WILL SAVE ALL STATS DATA INTO PLAYERPREFS//
    public void SaveStats(){}
//THIS WILL RETRIEVE ALL DATA SAVED FROM PLAYERPREFS TO THIS MAIN SCRIPT//
    public void LoadStats(){}
#endregion

#region SAVE EQUIPMENT PURCHASE AND INVENTORY AND EQUIP
    public void PurchasedItem(ItemDataScriptableObject item){}


    public void SaveEquipmentsData(){}
    public void LoadEquipmentsData(){}
#endregion

}

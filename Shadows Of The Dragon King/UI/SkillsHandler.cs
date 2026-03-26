using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillsHandler : MonoBehaviour
{
    [Header("Skills XP Text")]
    [SerializeField]private TMP_Text speedStatXPText;
    [SerializeField]private TMP_Text moraleStatXPText;
    [SerializeField]private TMP_Text strengthStatXPText;
    [SerializeField]private TMP_Text agilityStatXPText;
    [SerializeField]private TMP_Text defenceStatXPText;
    [SerializeField]private TMP_Text attackStatXPText;
    [SerializeField]private TMP_Text disciplineStatXPText;

    [Header("Skills LVL Text")]
    [SerializeField]private TMP_Text speedStatLVLText;
    [SerializeField]private TMP_Text moraleStatLVLText;
    [SerializeField]private TMP_Text strengthStatLVLText;
    [SerializeField]private TMP_Text agilityStatLVLText;
    [SerializeField]private TMP_Text defenceStatLVLText;
    [SerializeField]private TMP_Text attackStatLVLText;
    [SerializeField]private TMP_Text disciplineStatLVLText;

    [SerializeField]private CharacterDataHandler characterDataHandler;


    //STORES CURRENT LVL OF EACH SKILL SO CAN BE USED EASILTY//
    int speedLVL,moraleLVL,strengthLVL,agilityLVL,defenceLVL,attackLVL,disciplineLVL;
    //FOR SHOWING CURRENTXP/NEXTLVL XP ::EXAMPLE:-{1/1050}:://
    private int[] LevelExperience = {
        0,1050, 2450, 4550, 7700, 12425, 19513, 30145, 46094, 70018,
        105904, 159732, 240474, 361587, 543257, 815762, 1224520, 1837656, 2757360, 4136916
    };


    // Start is called before the first frame update
    void Start()
    {
        GetCurrentSkillsLvl();
        UpdateSkillsUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUpSkill(SkillCategory skill){
        switch(skill){
            case SkillCategory.Strength:
            characterDataHandler.Strength.BaseValue+=5f;
            break;
            case SkillCategory.Speed:
            characterDataHandler.Speed.BaseValue+=0.2f;
            break;
            case SkillCategory.Agility:
            characterDataHandler.SprintSpeed.BaseValue+=0.25f;
            break;
            case SkillCategory.Defense:
            characterDataHandler.Defence.BaseValue+=2f;
            break;
            case SkillCategory.Morale:
            characterDataHandler.CritChance.BaseValue+=4f;
            break;
            case SkillCategory.Discipline:
            characterDataHandler.CritDamage.BaseValue+=10f;
            break;
            case SkillCategory.Attack:
            characterDataHandler.Damage.BaseValue+=5f;
            break;
        }
    }

    public void UpdateFullSkillsUI(){
        GetCurrentSkillsLvl();
        UpdateSkillsUI();
    }

    private void GetCurrentSkillsLvl(){
        strengthLVL=PlayerData.Instance.GetCurrentLevel(SkillCategory.Strength);
        speedLVL=PlayerData.Instance.GetCurrentLevel(SkillCategory.Speed);
        agilityLVL=PlayerData.Instance.GetCurrentLevel(SkillCategory.Agility);
        attackLVL=PlayerData.Instance.GetCurrentLevel(SkillCategory.Attack);
        defenceLVL=PlayerData.Instance.GetCurrentLevel(SkillCategory.Defense);
        disciplineLVL=PlayerData.Instance.GetCurrentLevel(SkillCategory.Discipline);
        moraleLVL=PlayerData.Instance.GetCurrentLevel(SkillCategory.Morale);
    }

    private void UpdateSkillsUI(){
        strengthStatXPText.text = PlayerData.Instance.GetCurrentExperience(SkillCategory.Strength).ToString()+"/"+LevelExperience[strengthLVL];
        strengthStatLVLText.text=ReturnTwoDigitLVL(strengthLVL);
        speedStatXPText.text = PlayerData.Instance.GetCurrentExperience(SkillCategory.Speed).ToString()+"/"+LevelExperience[speedLVL];
        speedStatLVLText.text=ReturnTwoDigitLVL(speedLVL);
        agilityStatXPText.text = PlayerData.Instance.GetCurrentExperience(SkillCategory.Agility).ToString()+"/"+LevelExperience[agilityLVL];
        agilityStatLVLText.text=ReturnTwoDigitLVL(agilityLVL);
        defenceStatXPText.text = PlayerData.Instance.GetCurrentExperience(SkillCategory.Defense).ToString()+"/"+LevelExperience[defenceLVL];
        defenceStatLVLText.text=ReturnTwoDigitLVL(defenceLVL);
        moraleStatXPText.text = PlayerData.Instance.GetCurrentExperience(SkillCategory.Morale).ToString()+"/"+LevelExperience[moraleLVL];
        moraleStatLVLText.text=ReturnTwoDigitLVL(moraleLVL);
        disciplineStatXPText.text = PlayerData.Instance.GetCurrentExperience(SkillCategory.Discipline).ToString()+"/"+LevelExperience[disciplineLVL];
        disciplineStatLVLText.text=ReturnTwoDigitLVL(disciplineLVL);
        attackStatXPText.text = PlayerData.Instance.GetCurrentExperience(SkillCategory.Attack).ToString()+"/"+LevelExperience[attackLVL];
        attackStatLVLText.text=ReturnTwoDigitLVL(attackLVL);
    }


string empty;
    private string ReturnTwoDigitLVL(int lvl){
        if(lvl<=9)
        return empty="[0"+lvl.ToString()+"]";
        else
        return empty="["+lvl.ToString()+"]";
    }
}


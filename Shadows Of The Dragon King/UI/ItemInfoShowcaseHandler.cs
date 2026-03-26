using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoShowcaseHandler : MonoBehaviour
{
    [SerializeField]private ItemDataScriptableObject item;

    [Header("Item Info Variable")]
    [SerializeField]private Image slotImage;
    [SerializeField]private Sprite emptySlotImage;
    [SerializeField]private bool isEmpty;
    [SerializeField]private Image equipBtn;
    [SerializeField]private Sprite equip,use,replace,unequip;
    [SerializeField]private ButtonType buttonType;
    [SerializeField]private EquipmentSlot headSlot,bodySlot,pantSlot,bootSlot,necklessSlot,glovesSlot,ringSlot,beltSlot;
    [SerializeField]private InventoryManager inventoryManager;
    private EquipmentSlot currentEquipmentSlot;//THIS STORES CURRENT EQUIPMENT TYPE FOR EASY ACCESS DURING UPDATES//
    private ItemSlot currentItemSlot;

    [Header("Stats Variables")]
    [SerializeField]private Color _HealthStatColor;
    [SerializeField]private Color _StrengthStatColor;
    [SerializeField]private Color _DamageStatColor;
    [SerializeField]private Color _AttackSpeedStatColor;
    [SerializeField]private Color _CritChanceStatColor;
    [SerializeField]private Color _CritDamageStatColor;
    [SerializeField]private Color _DefenceStatColor;
    [SerializeField]private Color _ExperienceGainStatColor;

    [SerializeField]private GameObject _StatTextPrefab;
    [SerializeField]private GameObject _ItemInfoTextPrefab;
    [SerializeField]private Transform _StatInfoParent;
    [SerializeField]public CharacterDataHandler characterDataHandler;



    private enum ButtonType{
        equipBtn,
        unequipBtn,
        replaceBtn,
        useBtn,
    }

    void Start()
    {
        inventoryManager=GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
    }


GameObject spawned;
TMP_Text spawnedText;
string statString;
    public void ShowcaseItem(ItemDataScriptableObject item,ItemSlot itemSlot){
        this.item=item;
        currentItemSlot=itemSlot;
        ClearItems();//CLEAR PAST ITEMS BUFFS INSTANCES//
        ShowcaseStatsBuff();//SHOWCASE BUFFS//
        ShowcaseDetails();//UPDATES UI//
        UpdateBtns();//UPDATE BUTTONS//
    }
    public void ShowcaseEquipment(ItemDataScriptableObject item,EquipmentSlot equipmentSlot){
        this.item=item;
        currentItemSlot=null;
        ClearItems();//CLEAR PAST ITEMS BUFFS INSTANCES//
        ShowcaseStatsBuff();//SHOWCASE BUFFS//
        ShowcaseDetails();//UPDATES UI//
        UpdateBtns();//UPDATE BUTTONS//
    }
    public void ClearShowcase(){
        item=null;
        currentItemSlot=null;
        ClearItems();
    }
    private void UpdateBtns(){
        if(item.itemType==ItemDataScriptableObject.ItemType.Equipment){
            switch (item.equipmentType)
            {
                case ItemDataScriptableObject.EquipmentType.Head:
                UpdateEquipmentBtns(headSlot);
                currentEquipmentSlot=headSlot;
                break;
                case ItemDataScriptableObject.EquipmentType.Body:
                UpdateEquipmentBtns(bodySlot);
                currentEquipmentSlot=bodySlot;
                break;
                case ItemDataScriptableObject.EquipmentType.Pant:
                UpdateEquipmentBtns(pantSlot);
                currentEquipmentSlot=pantSlot;
                break;
                case ItemDataScriptableObject.EquipmentType.Boot:
                UpdateEquipmentBtns(bootSlot);
                currentEquipmentSlot=bootSlot;
                break;
                case ItemDataScriptableObject.EquipmentType.Neckless:
                UpdateEquipmentBtns(necklessSlot);
                currentEquipmentSlot=necklessSlot;
                break;
                case ItemDataScriptableObject.EquipmentType.Glove:
                UpdateEquipmentBtns(glovesSlot);
                currentEquipmentSlot=glovesSlot;
                break;
                case ItemDataScriptableObject.EquipmentType.Ring:
                UpdateEquipmentBtns(ringSlot);
                currentEquipmentSlot=ringSlot;
                break;
                case ItemDataScriptableObject.EquipmentType.Belt:
                UpdateEquipmentBtns(beltSlot);
                currentEquipmentSlot=beltSlot;
                break;
            }
        }
        else{
            UpdateConsumablesButton();
        }
    }

    public void DestroyButton(){
        currentItemSlot.ClearSlot();
        ClearShowcase();
    }
    private void UpdateConsumablesButton(){
        buttonType=ButtonType.useBtn;
            equipBtn.sprite=use;
    }
    private void UpdateEquipmentBtns(EquipmentSlot slot){
        if(slot.isSlotFull && item.isEquipped){
            Debug.Log("1");
            buttonType=ButtonType.unequipBtn;
            equipBtn.sprite=unequip;
        }
        else if(!slot.isSlotFull && !item.isEquipped){
            buttonType=ButtonType.equipBtn;
            equipBtn.sprite=equip;
        }
        else if(slot.isSlotFull && !item.isEquipped){
            buttonType=ButtonType.replaceBtn;
            equipBtn.sprite=replace;
        }
    }
    private void ShowcaseDetails(){
        if(isEmpty){
            slotImage.sprite=emptySlotImage;
        }
        else{
            slotImage.sprite=item.icon;
        }
    }

    //THIS IS FOR EQUIP/UNEQUIP/USE/REPLACE BUTTON//
    public void MultiPurposeBUttonPress(){
        switch (buttonType)
        {
            case ButtonType.equipBtn:
            currentEquipmentSlot.Equip(item,currentItemSlot);
            currentItemSlot.isSlotFull=false;
            break;
            case ButtonType.unequipBtn:
            currentEquipmentSlot.UnEquip(inventoryManager.ReturnEmptyItemSlot());
            //Debug.Log("Call This "+currentEquipmentSlot.gameObject.name.ToString());
            break;
            case ButtonType.useBtn:
            Use();
            break;
            case ButtonType.replaceBtn:
            currentEquipmentSlot.Replace(item,currentItemSlot);
            break;
        }
    }

    void Use(){
        if(currentItemSlot.itemQuantity>=2 && characterDataHandler.CurrentHealth<characterDataHandler.Health.Value-item.ItemStatBuff[0].statAmount){
            currentItemSlot.itemQuantity-=1;
            characterDataHandler.CurrentHealth+=item.ItemStatBuff[0].statAmount;
            characterDataHandler.Mushrooms-=1;
        }
        else if(currentItemSlot.itemQuantity<=2 && characterDataHandler.CurrentHealth<characterDataHandler.Health.Value-item.ItemStatBuff[0].statAmount){
            currentItemSlot.itemQuantity-=1;
            characterDataHandler.CurrentHealth+=item.ItemStatBuff[0].statAmount;
            characterDataHandler.Mushrooms-=1;
            currentItemSlot.ClearSlot();
            ClearShowcase();
        }
    }

    private void ShowcaseStatsBuff(){
        for (int i = 0; i < item.ItemStatBuff.Count; i++)
        {
            spawned=Instantiate(_StatTextPrefab);
            spawned.transform.SetParent(_StatInfoParent);
            spawned.transform.localScale=new Vector3(1,1,1);
            spawnedText=spawned.transform.GetComponent<TMP_Text>();
            switch (item.ItemStatBuff[i].statName){
                case ItemDataScriptableObject.Stats.StatName.health:
                    if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.Flat){
                        statString="  +"+item.ItemStatBuff[i].statAmount.ToString()+"  Health";
                        spawnedText.text=statString;
                        spawnedText.color=_HealthStatColor;
                    }

                    else if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.PercentAdd){
                        statString="  +"+(item.ItemStatBuff[i].statAmount*100).ToString()+"%  Health";
                        spawnedText.text=statString;
                        spawnedText.color=_HealthStatColor;
                    }
                break;
                case ItemDataScriptableObject.Stats.StatName.defence:
                    if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.Flat){
                        statString="  +"+item.ItemStatBuff[i].statAmount.ToString()+"  Defence";
                        spawnedText.text=statString;
                        spawnedText.color=_DefenceStatColor;
                    }

                    else if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.PercentAdd){
                        statString="  +"+(item.ItemStatBuff[i].statAmount*100).ToString()+"%  Defence";
                        spawnedText.text=statString;
                        spawnedText.color=_DefenceStatColor;
                    }
                break;
                case ItemDataScriptableObject.Stats.StatName.damage:
                    if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.Flat){
                        statString="  +"+item.ItemStatBuff[i].statAmount.ToString()+"  Damage";
                        spawnedText.text=statString;
                        spawnedText.color=_DamageStatColor;
                    }

                    else if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.PercentAdd){
                        statString="  +"+(item.ItemStatBuff[i].statAmount*100).ToString()+"%  Damage";
                        spawnedText.text=statString;
                        spawnedText.color=_DamageStatColor;
                    }
                break;
                case ItemDataScriptableObject.Stats.StatName.critChance:
                    if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.Flat){
                        statString="  +"+item.ItemStatBuff[i].statAmount.ToString()+"  CritChance";
                        spawnedText.text=statString;
                        spawnedText.color=_CritChanceStatColor;
                    }

                    else if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.PercentAdd){
                        statString="  +"+(item.ItemStatBuff[i].statAmount*100).ToString()+"%  CritChance";
                        spawnedText.text=statString;
                        spawnedText.color=_CritChanceStatColor;
                    }
                break;
                case ItemDataScriptableObject.Stats.StatName.critDamage:
                    if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.Flat){
                        statString="  +"+item.ItemStatBuff[i].statAmount.ToString()+"  CritDamage";
                        spawnedText.text=statString;
                        spawnedText.color=_CritDamageStatColor;
                    }

                    else if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.PercentAdd){
                        statString="  +"+(item.ItemStatBuff[i].statAmount*100).ToString()+"%  CritDamage";
                        spawnedText.text=statString;
                        spawnedText.color=_CritDamageStatColor;
                    }
                break;
                case ItemDataScriptableObject.Stats.StatName.attackSpeed:
                    if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.Flat){
                        statString="  +"+item.ItemStatBuff[i].statAmount.ToString()+"  AttackSpeed";
                        spawnedText.text=statString;
                        spawnedText.color=_AttackSpeedStatColor;
                    }

                    else if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.PercentAdd){
                        statString="  +"+(item.ItemStatBuff[i].statAmount*100).ToString()+"%  AttackSpeed";
                        spawnedText.text=statString;
                        spawnedText.color=_AttackSpeedStatColor;
                    }
                break;
                case ItemDataScriptableObject.Stats.StatName.xpGain:
                    if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.Flat){
                        statString="  +"+item.ItemStatBuff[i].statAmount.ToString()+"  ExperienceGain";
                        spawnedText.text=statString;
                        spawnedText.color=_ExperienceGainStatColor;
                    }

                    else if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.PercentAdd){
                        statString="  +"+(item.ItemStatBuff[i].statAmount*100).ToString()+"%  ExperienceGain";
                        spawnedText.text=statString;
                        spawnedText.color=_ExperienceGainStatColor;
                    }
                break;
                case ItemDataScriptableObject.Stats.StatName.strength:
                    if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.Flat){
                        statString="  +"+item.ItemStatBuff[i].statAmount.ToString()+"  Strength";
                        spawnedText.text=statString;
                        spawnedText.color=_StrengthStatColor;
                    }

                    else if(item.ItemStatBuff[i].statType==Kryz.CharacterStats.StatModType.PercentAdd){
                        statString="  +"+(item.ItemStatBuff[i].statAmount*100).ToString()+"%  Strength";
                        spawnedText.text=statString;
                        spawnedText.color=_StrengthStatColor;
                    }
                break;
            }
        }
    }
    public void ClearItems(){
        foreach(Transform child in _StatInfoParent){
            Destroy(child.gameObject);
        }
    }
}

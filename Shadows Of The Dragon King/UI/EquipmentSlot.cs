using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Kryz.CharacterStats;

public class EquipmentSlot : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]private Image slotImage;
    [SerializeField]private ItemDataScriptableObject item;
    [SerializeField]private ItemInfoShowcaseHandler itemInfoShowcaseHandler;
    [SerializeField]private GameObject slotSelectedShader;
    [SerializeField]private InventoryManager inventoryManager;
    [SerializeField]private GameObject equipmentBG;
    [SerializeField]private Sprite emptySlotImg;
    [SerializeField]private CharacterDataHandler characterDataHandler;
    public bool isSlotFull;
    public enum EquipmentSlotType{
        HeadSlot,
        BodySlot,
        PantSlot,
        BootSlot,
        NecklessSlot,
        GloveSlot,
        RingSlot,
        BeltSlot,
    }

    //FOR EQUIPPING
    public void Equip(ItemDataScriptableObject itemData,ItemSlot currentSlot){
        //Debug.Log("Running Equip From " + currentSlot.gameObject.name.ToString());
        item=itemData;
        item.isEquipped=true;
        slotImage.sprite=item.icon;
        isSlotFull=true;
        equipmentBG.SetActive(false);
        currentSlot.ClearSlot();
        itemInfoShowcaseHandler.ClearShowcase();
        ApplyStatsModifiers();
        //Invoke("Select",0.2f);
        Select();
    }


    //FOR UNEQUIPPING ARTIFACT
    public void UnEquip(ItemSlot emptySlot){
        //Debug.Log("Running UnEquip From " + this.gameObject.name.ToString());
        slotImage.sprite=emptySlotImg;
        isSlotFull=false;
        equipmentBG.SetActive(true);
        item.isEquipped=false;
        RemoveStatsModifier();
        emptySlot.AddItem(item);
        item=null;
        emptySlot.Select();
    }


    //FOR UNEQUIP CURRENT EQUIPMENT AND EQUIP NEW ONE
    public void Replace(ItemDataScriptableObject itemData,ItemSlot replacementSlot){
        if(replacementSlot==null)
            return;
        replacementSlot.ClearSlot();
        //REMOVE OLD ITEM//
        item.isEquipped=false;
        replacementSlot.AddItem(item);
        item=null;
        replacementSlot.Select();
        //EQUIP NEW ITEM//
        slotImage.sprite=itemData.icon;
        itemData.isEquipped=true;
        item=itemData;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyStatsModifiers(){
        for (int i = 0; i < item.ItemStatBuff.Count; i++)
        {
            if(item.ItemStatBuff[i].statName==ItemDataScriptableObject.Stats.StatName.health)
                characterDataHandler.Health.AddModifier(new StatModifier(item.ItemStatBuff[i].statAmount, item.ItemStatBuff[i].statType, this));
            else if(item.ItemStatBuff[i].statName==ItemDataScriptableObject.Stats.StatName.defence)
                characterDataHandler.Defence.AddModifier(new StatModifier(item.ItemStatBuff[i].statAmount, item.ItemStatBuff[i].statType, this));
            else if(item.ItemStatBuff[i].statName==ItemDataScriptableObject.Stats.StatName.damage)
                characterDataHandler.Damage.AddModifier(new StatModifier(item.ItemStatBuff[i].statAmount, item.ItemStatBuff[i].statType, this));
            else if(item.ItemStatBuff[i].statName==ItemDataScriptableObject.Stats.StatName.critChance)
                characterDataHandler.CritChance.AddModifier(new StatModifier(item.ItemStatBuff[i].statAmount, item.ItemStatBuff[i].statType, this));
            else if(item.ItemStatBuff[i].statName==ItemDataScriptableObject.Stats.StatName.critDamage)
                characterDataHandler.CritDamage.AddModifier(new StatModifier(item.ItemStatBuff[i].statAmount, item.ItemStatBuff[i].statType, this));
            //else if(item.ItemStatBuff[i].statName==ItemDataScriptableObject.Stats.StatName.attackSpeed)
            //    characterDataHandler.AttackSpeed.AddModifier(new StatModifier(item.ItemStatBuff[i].statAmount, item.ItemStatBuff[i].statType, this));
            else if(item.ItemStatBuff[i].statName==ItemDataScriptableObject.Stats.StatName.xpGain)
                characterDataHandler.XPGain.AddModifier(new StatModifier(item.ItemStatBuff[i].statAmount, item.ItemStatBuff[i].statType, this));
        }
        characterDataHandler.UpdateUI();
    }
    public void RemoveStatsModifier(){
        characterDataHandler.Health.RemoveAllModifiersFromSource(this);
        characterDataHandler.Defence.RemoveAllModifiersFromSource(this);
        characterDataHandler.Damage.RemoveAllModifiersFromSource(this);
        characterDataHandler.CritChance.RemoveAllModifiersFromSource(this);
        characterDataHandler.CritDamage.RemoveAllModifiersFromSource(this);
        //characterDataHandler.AttackSpeed.RemoveAllModifiersFromSource(this);
        characterDataHandler.XPGain.RemoveAllModifiersFromSource(this);
        characterDataHandler.UpdateUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button==PointerEventData.InputButton.Left){
            Select();
        }
    }
    public void Deselct(){
        slotSelectedShader.SetActive(false);
    }
    public void Select(){
        //Debug.Log("Select " + this.gameObject.name.ToString());
        inventoryManager.DeselectAll();
            itemInfoShowcaseHandler.ShowcaseEquipment(item,this);
            slotSelectedShader.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using Kryz.CharacterStats.Examples;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    [SerializeField]private ItemDataScriptableObject item;
    [SerializeField]private ShopItem[] itemSlots;
    [SerializeField]private Image slotImage;
    [SerializeField]private Sprite emptySlotImage;
    [SerializeField]private TMP_Text cost;
    [SerializeField]private GameObject soldOut,purchaseButton;
    [SerializeField]private CharacterDataHandler characterDataHandler;
    [SerializeField]private TMP_Text coinText;

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

    [SerializeField]private ShopItem firstEquipmentItem,firstWeaponItem;


    [SerializeField]private InventoryManager inventoryManager;
    [SerializeField]private CharacterInputs characterInputs;
    [SerializeField]private GameObject shopUI;
    [SerializeField]private GameObject equipmentShopPanel,weaponShopPanel;



GameObject spawned;
TMP_Text spawnedText;
string statString;
    // Start is called before the first frame update
    void Start()
    {
        firstEquipmentItem.Select();
        equipmentShopPanel.SetActive(true);
        weaponShopPanel.SetActive(false);
        //PlayerPrefs.SetInt("Coins",1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowcaseItem(ItemDataScriptableObject item){
        this.item=item;
        ClearItems();//CLEAR PAST ITEMS BUFFS INSTANCES//
        ShowcaseStatsBuff();//SHOWCASE BUFFS//
        ShowcaseDetails();//UPDATES UI//
        //UpdateBtns();//UPDATE BUTTONS//
    }
    private void ShowcaseDetails(){
        coinText.text=PlayerPrefs.GetInt("Coins").ToString();
        slotImage.sprite=item.icon;
        if(item.isSoldOut){
            soldOut.gameObject.SetActive(true);
            purchaseButton.SetActive(false);
        }
        else if(!item.isSoldOut){
            soldOut.gameObject.SetActive(false);
            purchaseButton.SetActive(true);
            cost.text=item.price.ToString();
        }
    }

    public void DeselectAll(){
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].DeSelect();
        }
    }
    bool purchaseCD;
    int purchaseCDTime=1;

    public void Purchase(){
        if(PlayerPrefs.GetInt("Coins")>=item.price){
            if(!purchaseCD){
                int coins=PlayerPrefs.GetInt("Coins");
                ItemSlot itemSlot=inventoryManager.ReturnEmptyItemSlot();
                    if(itemSlot!=null){
                        coins-=item.price;
                        PlayerPrefs.SetInt("Coins",coins);
                        inventoryManager.AddItem(item);
                        item.isSoldOut=true;
                        characterDataHandler.PurchasedItem(item);
                        ShowcaseDetails();
                    }
                purchaseCD=true;
                Invoke(nameof(ResetCD),purchaseCDTime);
            }
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

    public void EnableEquipmentsUI(){
        firstEquipmentItem.Select();
        equipmentShopPanel.SetActive(true);
        weaponShopPanel.SetActive(false);
    }
    public void EnableWeaponsUI(){
        firstWeaponItem.Select();
        equipmentShopPanel.SetActive(false);
        weaponShopPanel.SetActive(true);
    }

    public void CloseShop(){
        shopUI.SetActive(false);
        characterInputs.EnableMovement();
    }

    public void OpenShop(){
        shopUI.SetActive(true);
        characterInputs.DisableMovement();
    }
    public void ClearItems(){
        foreach(Transform child in _StatInfoParent){
            Destroy(child.gameObject);
        }
    }
    void ResetCD(){
        purchaseCD=false;
    }

}

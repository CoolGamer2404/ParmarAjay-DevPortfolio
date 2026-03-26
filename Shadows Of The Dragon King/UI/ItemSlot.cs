using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]private Image itemImage;
    [SerializeField]private TMP_Text itemAmountText;
    [SerializeField]private ItemDataScriptableObject itemDataScriptableObject;
    [SerializeField]private ItemInfoShowcaseHandler itemInfoShowcaseHandler;
    [SerializeField]private GameObject selectedShader;
    [SerializeField]private GameObject amountTXT;
    [SerializeField]private TMP_Text amount;
    [SerializeField]private Sprite emptySlotImg;
    public int itemQuantity=0;
    InventoryManager inventoryManager;
    public bool isSlotSelected;
    public bool isSlotFull=false;
    public ItemDataScriptableObject item;
    public CharacterDataHandler characterDataHandler;

    void Start()
    {
        inventoryManager=GameObject.Find("CharacterController").GetComponent<InventoryManager>();
        characterDataHandler=GameObject.Find("Character").GetComponent<CharacterDataHandler>();
        if(!isSlotFull){
            itemImage.sprite=emptySlotImg;
        }
    }

    public void AddItem(ItemDataScriptableObject item){
        this.itemDataScriptableObject=item;
        this.itemImage.sprite=item.icon;
        this.item=item;
        isSlotFull=true;
        if(item.isStackable){
            characterDataHandler.Mushrooms+=1;
            amountTXT.SetActive(true);
            itemQuantity+=item.quantity;
            itemInfoShowcaseHandler.characterDataHandler.Mushrooms=itemQuantity;
        }
        UpdateSlotUI();
    }

    public void UpdateSlotUI(){
        if(item.isStackable){
            amountTXT.SetActive(true);
            amount.text=itemQuantity.ToString();
        }
        else if(!item.isStackable){
            amountTXT.SetActive(false);
        }
    }
    public void AddItemAmount(int amount){
        itemQuantity+=amount;
        UpdateSlotUI();
    }

    // CLEAR SLOT FOR FURTHER USAGES //
    public void ClearSlot(){
        item=null;
        itemImage.sprite=emptySlotImg;
        itemDataScriptableObject=null;
        amountTXT.SetActive(false);
        isSlotFull=false;
    }

    private void Showcase(){
        itemInfoShowcaseHandler.ShowcaseItem(itemDataScriptableObject,this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button==PointerEventData.InputButton.Left){
            Select();
        }
    }

    public void Select(){
        inventoryManager.DeselectAll();
        selectedShader.SetActive(true);
        isSlotSelected=true;
        Showcase();
    }
    public void DeSelect(){
        selectedShader.SetActive(false);
        isSlotSelected=false;
    }

}

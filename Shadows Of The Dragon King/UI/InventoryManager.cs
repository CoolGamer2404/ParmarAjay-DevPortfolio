using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]private GameObject inventoryPanel;
    [SerializeField]private ItemSlot[] itemSlots;
    [SerializeField]private EquipmentSlot[] equipmentSlots;
    [SerializeField]private CharacterInputs inputs;
    [SerializeField]private Character character;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    bool invCD;
    int invCDTime=1;
    void Update()
    {
        if(inventory){
            if(!invCD){
                InventoryInput();

                invCD=true;
                Invoke(nameof(ResetCD),invCDTime);
            }
        }
    }

    public int AddItem(ItemDataScriptableObject item){
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].isSlotFull==true && itemSlots[i].item.itemName==item.itemName && item.isStackable){
                itemSlots[i].AddItemAmount(item.quantity);
                return 0;
            }
            else if(itemSlots[i].isSlotFull==false){
                itemSlots[i].AddItem(item);
                return 0;
            }
        }
        return 1;
    }

    public ItemSlot ReturnEmptyItemSlot(){
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].isSlotFull==false){
                return itemSlots[i];
            }
        }
        return null;
    }

    public void DeselectAll(){
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].DeSelect();
        }
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].Deselct();
        }
    }
















    /// <summary>
    /// ////////////////////////////Inventory Input Handle
    /// </summary>

    void InventoryInput(){
        if(inventoryPanel.activeSelf){
            inventoryPanel.SetActive(false);
            inputs.cursorLocked=true;
            inputs.cursorInputForLook=true;
            character.enabled=true;
            Cursor.lockState =  CursorLockMode.Locked;
        }
        else{
            inventoryPanel.SetActive(true);
            inputs.cursorLocked=false;
            inputs.cursorInputForLook=false;
            character.enabled=false;
            Cursor.lockState =  CursorLockMode.None;
        }
    }
    public bool inventory;

    public void OnInventory(InputValue value)
		{
			InventoryInput(value.isPressed);
		}
    public void InventoryInput(bool newInventoryState)
		{
			inventory = newInventoryState;
		}
    void ResetCD(){
        invCD=false;
    }
}

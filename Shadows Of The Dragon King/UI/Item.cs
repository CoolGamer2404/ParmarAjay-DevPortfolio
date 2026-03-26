using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private InventoryManager inventoryManager;
    [SerializeField]private ItemDataScriptableObject item;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager=GameObject.Find("CharacterController").GetComponent<InventoryManager>();
    }

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag=="Player"){
            int leftOverItems=inventoryManager.AddItem(item);
            if(leftOverItems==0)
            Destroy(gameObject);
        }
    }
}

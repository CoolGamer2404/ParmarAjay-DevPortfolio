using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PowerBoxQueastHandler : MonoBehaviour
{
    public float distance;
    public Transform PlayerCamera;
    public float InteractionRange;

    public static bool isPowerOff=false;
    public static bool InteractableWithPowerBox;

    public GameObject Wire1;
    public GameObject Wire2;

    private string Cutter="Cutter";

    // Start is called before the first frame update
    void Start()
    {
        isPowerOff=true;
        Wire1.SetActive(true);
        Wire2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerCamera.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= InteractionRange)
        {
            InteractableWithPowerBox = true;
        }
        if (distanceToPlayer.magnitude >= InteractionRange)
        {
            InteractableWithPowerBox = false;
        }
    
        if(InteractableWithPowerBox==true){
            RayCast();
            Debug.Log("Ray");
        }
    }
    void RayCast(){
        RaycastHit wirehit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out wirehit, distance)){
            if(wirehit.transform.tag=="Wire"){
                Debug.Log("Got Wire");
                if(CrossPlatformInputManager.GetButtonDown("ItemUse") &&Inventory.SlotFull&&InventoryHandler.EquippedItemName == Cutter){
                    Interact();
                }
            }
        }
    }
    void Interact(){
        Wire1.SetActive(false);
        Wire2.SetActive(true);
        MainGateQuestHandler.isElectricityIsOn=false;
        isPowerOff=true;
    }
}

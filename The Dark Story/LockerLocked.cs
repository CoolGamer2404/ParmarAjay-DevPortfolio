using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class LockerLocked : MonoBehaviour
{
    public float distance;
    public Transform PlayerCamera;
    public float InteractionRange;
    public static bool Interactable;
    public static bool InteractableWithLocker;
    public Transform LockerGameObject;
    private static string LockerScriptName="Locker";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerCamera.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= InteractionRange)
        {
            InteractableWithLocker = true;
        }
        if (distanceToPlayer.magnitude >= InteractionRange)
        {
            InteractableWithLocker = false;
        }

        if(InteractableWithLocker==true){
            RayCast();
        }
    }
    void RayCast(){
        RaycastHit lockedlockerhit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out lockedlockerhit, distance)){
            if(lockedlockerhit.transform.tag=="Locker"){
                LockerGameObject=lockedlockerhit.transform;
                Interactable=true;
                if(CrossPlatformInputManager.GetButtonDown("ItemUse") && Inventory.SlotFull&&InventoryHandler.EquippedItemName == "LockerKey"){
                    (lockedlockerhit.transform.GetComponent(LockerScriptName) as MonoBehaviour).enabled=true;
                }
            }
            if(lockedlockerhit.transform.tag!="Locker"){
                Interactable=false;
                LockerGameObject=null;
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MainGateQuestHandler : MonoBehaviour
{
    public static bool isElectricityIsOn;
    private bool isGateOpen;

    private static bool isOpened;
    public bool isOpenedT;
    public Animator da;
    public float distance;
    public Transform PlayerCamera;
    private Animator DoorAnimator;
    public float InteractionRange;
    public static bool InteractableWithDoor;
    public static bool Interactable;
    public Transform DoorGameObject;
    [SerializeField]private string KeyName;
    // Start is called before the first frame update
    void Start()
    {
        isElectricityIsOn=true;
        isGateOpen=false;
        isOpened=false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerCamera.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= InteractionRange)
        {
            InteractableWithDoor = true;
        }
        if (distanceToPlayer.magnitude >= InteractionRange)
        {
            InteractableWithDoor = false;
        }
        if(InteractableWithDoor==true){
            RayCast();
        }

    }
    void RayCast(){
        RaycastHit doorhit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, distance)){
            if(doorhit.transform.tag=="MainGate"){
                DoorGameObject=doorhit.transform;
                DoorAnimator=doorhit.transform.GetComponentInParent<Animator>();
                Interactable=true;
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")){
                    if(isElectricityIsOn==true){
                        if(isGateOpen==false){
                            if(Inventory.SlotFull && InventoryHandler.EquippedItemName == KeyName){
                                Debug.Log("TurnOff Electricity First");
                            }
                        }
                    }
                    if(isElectricityIsOn==false){
                        if(isGateOpen==false){
                            if(Inventory.SlotFull && InventoryHandler.EquippedItemName == KeyName){
                                isGateOpen=true;
                                Interact();
                            }
                        }
                        if(isGateOpen==true){
                            Interact();
                        }
                    }
                }
            }
            else{
                Interactable=false;
                DoorGameObject=null;
            }
        }
    }
    void Interact(){
        DoorAnimator.SetBool("Open", !DoorAnimator.GetBool("Open"));
        return;
    }
}

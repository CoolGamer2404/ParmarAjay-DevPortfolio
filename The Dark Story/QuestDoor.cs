using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class QuestDoor : MonoBehaviour
{
    private static bool isOpened;
    public float distance;
    public Transform PlayerCamera;
    private Animator DoorAnimator;
    public float InteractionRange;
    public static bool InteractableWithDoor;
    public static bool Interactable;
    private float nextInteractionTime=2f;
    public float OpenRotation;
    public float CloseRotation;
    public float CurrentRotation;
    public Transform DoorGameObject;

    private static string DoorName;
    private static string SpecialDoorName="SpecialDoor";
    private static string MainGateName="MainGate";
    private static string MainDoorName="MainDoor";
    private static string MainEmemyDoorName="MainEmemyDoor";

    private static string SpecialKeyName = "SpecialKey";
    private static string MainDoorKeyName = "MainDoorKey";
    private static string MainGateKeyName = "MainGateKey";
    private static string MainEmemyDoorKeyName = "MainEmemyDoorKey";

    private static bool SpecialRoomLocked=true;
    private static bool MainDoorLocked=true;
    private static bool MainGateLocked=true;
    private static bool MainEnemyDoorLocked=true;

    // Start is called before the first frame update
    void Start()
    {
        isOpened=false;
        nextInteractionTime=2f;
        SpecialRoomLocked=true;
        MainDoorLocked=true;
        MainGateLocked=true;
        MainEnemyDoorLocked=true;
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
        if(DoorGameObject!=null){
            CurrentRotation=DoorGameObject.localRotation.y;
            if(DoorGameObject.localRotation.y==OpenRotation){
                isOpened=true;
            }
            if(DoorGameObject.localRotation.y==CloseRotation){
                isOpened=false;
            }
        }
    }
    void RayCast(){
        RaycastHit questdoorhit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out questdoorhit, distance)){
            if(questdoorhit.transform.tag=="QuestDoor"){
                DoorGameObject=questdoorhit.transform;
                DoorName=questdoorhit.transform.name.ToString();
                DoorAnimator=questdoorhit.transform.GetComponentInParent<Animator>();
                Interactable=true;
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")){
                    Interact();
                    //nextInteractionTime-=Time.deltaTime;
                }
            }
            else{
                Interactable=false;
                DoorGameObject=null;
            }
        }
    }
    void Interact(){
        if(isOpened==true && nextInteractionTime==2f){
            //DoorAnimator.SetBool("Close", false);
            DoorAnimator.SetBool("Open", false);
        }
        if(isOpened==false && nextInteractionTime==2f){
            //For SpecialDoor
            if(DoorName==SpecialDoorName && InventoryHandler.EquippedItemName==SpecialKeyName && SpecialRoomLocked==true){
                DoorAnimator.SetBool("Open", true);
                Debug.Log("KeyUsed");
                SpecialRoomLocked=false;
                return;
            }
            if(DoorName==SpecialDoorName && SpecialRoomLocked==false){
                DoorAnimator.SetBool("Open", true);
            }
            //For MainDoor
            if(DoorName==MainDoorName && InventoryHandler.EquippedItemName==MainDoorKeyName && MainDoorLocked==true){
                DoorAnimator.SetBool("Open", true);
                Debug.Log("KeyUsed");
                MainDoorLocked=false;
                return;
            }
            if(DoorName==MainDoorName && MainDoorLocked==false){
                DoorAnimator.SetBool("Open", true);
            }
            //For Main Gate
            if(DoorName==MainGateName && InventoryHandler.EquippedItemName==MainGateKeyName && MainGateLocked==true){
                DoorAnimator.SetBool("Open", true);
                Debug.Log("KeyUsed");
                MainGateLocked=false;
                return;
            }
            if(DoorName==MainGateName && MainGateLocked==false){
                DoorAnimator.SetBool("Open", true);
            }
            //For MainEnemyRoomDoor
            if(DoorName==MainEmemyDoorName && InventoryHandler.EquippedItemName==MainEmemyDoorKeyName && MainEnemyDoorLocked==true){
                DoorAnimator.SetBool("Open", true);
                Debug.Log("KeyUsed");
                MainEnemyDoorLocked=false;
                return;
            }
            if(DoorName==MainEmemyDoorName && MainEnemyDoorLocked==false){
                DoorAnimator.SetBool("Open", true);
            }
        }
    }
    void QuestDoorOpened(){
        nextInteractionTime=2f;
    }
    void QuestDoorClosed(){
        nextInteractionTime=2f;
    }
}

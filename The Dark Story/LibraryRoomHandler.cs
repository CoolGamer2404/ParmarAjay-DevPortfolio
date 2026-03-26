using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class LibraryRoomHandler : MonoBehaviour
{
    public float distance;
    public Transform PlayerCamera;
    public float InteractionRange;
    public static bool InteractableWithLibraryDoor;
    public Transform LibraryDoorGameObject;
    public GameObject DoorGameObject;
    private bool isOpen;
    private string ScriptName="Door";
    // Start is called before the first frame update
    void Start()
    {
        DoorGameObject.SetActive(true);
        (LibraryDoorGameObject.GetComponent(ScriptName) as MonoBehaviour).enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerCamera.transform.position - DoorGameObject.transform.position;
        if (distanceToPlayer.magnitude <= InteractionRange)
        {
            InteractableWithLibraryDoor = true;
        }
        if (distanceToPlayer.magnitude >= InteractionRange)
        {
            InteractableWithLibraryDoor = false;
        }
        if(InteractableWithLibraryDoor==true){
            RayCast();
        }
    }

    void RayCast(){
        RaycastHit librarydoorhit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out librarydoorhit, distance)){
            if(librarydoorhit.transform.tag=="Interactables"){
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")&& Inventory.SlotFull&&InventoryHandler.EquippedItemName == "LibraryRoomKey"){
                    (LibraryDoorGameObject.GetComponent(ScriptName) as MonoBehaviour).enabled=true;
                    DoorGameObject.SetActive(false);
                }
            }
        }
        
    }
}

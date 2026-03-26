using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MainDoorQuestHandler : MonoBehaviour
{
    public  bool maindoorisopen;
    public  bool plankisremoved;

    //for detecting planks
    [SerializeField]private bool plank1;
    [SerializeField]private bool plank2;
    [SerializeField]private bool plank3;
    public GameObject plank1object;
    public GameObject plank2object;
    public GameObject plank3object;
    private string plankScriptName="Plank";

    //for door
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
    public float OpenRotation;
    public float CloseRotation;
    public float CurrentRotation;
    [SerializeField]private string KeyName;

    // Start is called before the first frame update
    void Start()
    {
        isOpened=false;
        plankisremoved=false;
        maindoorisopen=false;
        plank1=false;
        plank2=false;
        plank3=false;
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

        plank1=(plank1object.transform.GetComponent(plankScriptName) as MonoBehaviour).enabled;
        plank2=(plank2object.transform.GetComponent(plankScriptName) as MonoBehaviour).enabled;
        plank3=(plank3object.transform.GetComponent(plankScriptName) as MonoBehaviour).enabled;

        if(plank1==false && plank2==false&& plank3==false){
            plankisremoved=true;
        }

        if(InteractableWithDoor==true){
            RayCast();
        }
        da=DoorAnimator;
        isOpenedT=isOpened;
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
        RaycastHit doorhit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, distance)){
            if(doorhit.transform.tag=="MainDoor"){
                DoorGameObject=doorhit.transform;
                DoorAnimator=doorhit.transform.GetComponentInParent<Animator>();
                Interactable=true;
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")&& Inventory.SlotFull && InventoryHandler.EquippedItemName == KeyName && maindoorisopen==false && plankisremoved==true){
                    maindoorisopen=true;
                    Interact();
                }
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")&& Inventory.SlotFull && InventoryHandler.EquippedItemName == KeyName && maindoorisopen==false && plankisremoved==false){
                    Debug.Log("Remove Plank First");
                }
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")&& maindoorisopen==true && plankisremoved==true){
                    Interact();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DestroyableBox : MonoBehaviour
{
    private static bool interactableWithBox=false;
    public Transform PlayerCamera;
    public float InteractionRange;
    [SerializeField]public static bool Interactable;
    public float distance;
    public static string CrawBar = "Crawbar";
    [SerializeField]private GameObject BoxCell;
    [SerializeField]private GameObject MainBox;
    [SerializeField]private GameObject DestroyableBoxGameObject;

    // Start is called before the first frame update
    void Start()
    {
        interactableWithBox=false;
        DestroyableBoxGameObject=null;
        BoxCell=null;
        MainBox=null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerCamera.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= InteractionRange)
        {
            interactableWithBox = true;
        }
        if (distanceToPlayer.magnitude >= InteractionRange)
        {
            interactableWithBox = false;
        }
        //for interaction
        if(interactableWithBox==true){
            RayCastForBox();
        }
        
    }
    void RayCastForBox(){
        RaycastHit boxhit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out boxhit, distance)){
            if(boxhit.transform.tag=="Box"){
                Interactable=true;
                //LokkingAtObName=boxhit.transform.parent.transform.name;
                DestroyableBoxGameObject=boxhit.transform.parent.transform.gameObject;
                MainBox=boxhit.transform.gameObject;
                    BoxCell=boxhit.transform.parent.transform.Find("BoxCells").gameObject;
                if(DestroyableBoxGameObject!=null){
                    //LokkingAtObName=boxhit.transform.parent.transform.name;
                    DestroyableBoxGameObject=boxhit.transform.parent.transform.gameObject;
                    MainBox=boxhit.transform.gameObject;
                    BoxCell=boxhit.transform.parent.transform.Find("BoxCells").gameObject;
                } 
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")&&Inventory.SlotFull&&InventoryHandler.EquippedItemName == CrawBar){
                    InteractWithBox();
                }
            }
            else{
                Interactable=false;
                DestroyableBoxGameObject=null;
                BoxCell=null;
                MainBox=null;
            }
        }
    }
    void InteractWithBox(){
        MainBox.SetActive(false);
        BoxCell.SetActive(true);
    }
}

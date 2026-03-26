using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Plank : MonoBehaviour
{
    private static bool interactableWithPlank=false;
    public Transform PlayerCamera;
    public float InteractionRange;
    public static bool Interactable;
    private Rigidbody plankRb;
    public float distance;
    public static string CrawBar = "Crawbar";
    private string ScriptName1="Inventory";
    private string ScriptName2="Plank";

    // Start is called before the first frame update
    void Start()
    {
        interactableWithPlank=false;
        if(plankRb!=null){
            plankRb.isKinematic = true;
        }
        (transform.GetComponent(ScriptName1) as MonoBehaviour).enabled=false;
        (transform.GetComponent(ScriptName2) as MonoBehaviour).enabled=true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerCamera.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= InteractionRange)
        {
            interactableWithPlank = true;
        }
        if (distanceToPlayer.magnitude >= InteractionRange)
        {
            interactableWithPlank = false;
        }
        //for interaction
        if(interactableWithPlank==true){
            RayCastForPlank();
        }
    }
    void RayCastForPlank(){
        RaycastHit plankhit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out plankhit, distance)){
            if(plankhit.transform.tag=="Plank"){
                Interactable=true;
                plankRb=plankhit.transform.GetComponent<Rigidbody>();
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")&&Inventory.SlotFull&&InventoryHandler.EquippedItemName == CrawBar){
                    InteractWithPlank();
                    (plankhit.transform.GetComponent(ScriptName1) as MonoBehaviour).enabled=true;
                    (plankhit.transform.GetComponent(ScriptName2) as MonoBehaviour).enabled=false;
                }
            }
            else{
                Interactable=false;
            }
        }
    }
    void InteractWithPlank(){
        plankRb.isKinematic = false;
    }
}

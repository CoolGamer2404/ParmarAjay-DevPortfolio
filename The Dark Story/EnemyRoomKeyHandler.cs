using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class EnemyRoomKeyHandler : MonoBehaviour
{
    public GameObject EnemyDoor;
    public float distance;
    public Transform PlayerCamera;
    public float InteractionRange;
    private static bool InteractableWithEnemyDoor;
    private bool isOpenEnemyDoor=false;
    public string EnemyDoorScriptName="Door";
    public string KeyName="EnemyRoomKey";
    [SerializeField]private GameObject ConnectedDoorGameObject;
    [SerializeField]private GameObject CurrentGameObject;
    // Start is called before the first frame update
    void Start()
    {
        EnemyDoor=null;
        isOpenEnemyDoor=false;
        (ConnectedDoorGameObject.transform.GetComponent(EnemyDoorScriptName) as MonoBehaviour).enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerCamera.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= InteractionRange)
        {
            InteractableWithEnemyDoor = true;
        }
        if (distanceToPlayer.magnitude >= InteractionRange)
        {
            InteractableWithEnemyDoor = false;
        }

        if(InteractableWithEnemyDoor==true){
            RayCast();
        }
    }
    void RayCast(){
        RaycastHit enemydoorhit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out enemydoorhit, distance)){
            if(enemydoorhit.transform.tag=="EnemyDoor"){
                EnemyDoor=enemydoorhit.transform.gameObject;
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")&&Inventory.SlotFull&&InventoryHandler.EquippedItemName == KeyName){
                    (ConnectedDoorGameObject.transform.GetComponent(EnemyDoorScriptName) as MonoBehaviour).enabled=true;
                    CurrentGameObject.SetActive(false);
                }
            }
            if(enemydoorhit.transform.tag!="EnemyDoor"){
                EnemyDoor=null;
            }
        }
    }
}

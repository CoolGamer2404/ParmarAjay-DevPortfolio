using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MountSystemHandler : MonoBehaviour
{
    bool mount;
    private bool isOnMount=false;
    [SerializeField]private float cd=1f;
    [SerializeField]private bool isoncd=false;

    [SerializeField]GameObject characterController,mountGameObject;
    [SerializeField]Transform characterSpawnLocation,mountSpawnLocation;
    [SerializeField]GameObject mainCamera,playerFollowCamera,mountCamera;
    [SerializeField]private Minimap minimap;
    [SerializeField]private MarkerHolder markerHolder;
    [SerializeField]private Character character;
    [SerializeField]private EquipmentSystem equipmentSystem;
    [SerializeField]private FullQuestHandler fullQuestHandler;



    private void OnMount(InputValue value)
		{
			MountInput(value.isPressed);
		}
    private void MountInput(bool newMountState)
		{
			mount = newMountState;
		}

    void Start(){
        minimap.player=characterController.transform;
        markerHolder.playerObject=characterController;
        playerFollowCamera.SetActive(true);
        mainCamera.SetActive(true);
        fullQuestHandler=GameObject.Find("-----------QuestsHandler---------").GetComponent<FullQuestHandler>();
    }

    void Update()
    {
        if(mount && fullQuestHandler.currentQuestIndex>=2){
            if(!isoncd){
                MountEagle();

                isoncd=true;
                Invoke(nameof(ResetCD),cd);
            }
        }
    }

    void MountEagle(){
        if(isOnMount){
            DIsableMount();
            return;
        }
        else if(!isOnMount){
           EnableMount();
            return;
        }
    }
    void ResetCD(){
        isoncd=false;
    }

    void EnableMount(){
        mountGameObject.transform.position=mountSpawnLocation.position;
        mountGameObject.SetActive(true);
        mountCamera.SetActive(true);
        playerFollowCamera.SetActive(false);
        mainCamera.SetActive(false);
        minimap.player=mountGameObject.transform;
        markerHolder.playerObject=mountGameObject;
        character.weaponDrawn=false;
        character.SetStandingState();
        equipmentSystem.SheathWeapon();
        characterController.SetActive(false);

        isOnMount=true;
    }
    void DIsableMount(){
        playerFollowCamera.SetActive(true);
        mainCamera.SetActive(true);
        characterController.transform.position=characterSpawnLocation.position;
        characterController.SetActive(true);
        //character.weaponDrawn=false;
        //character.SetStandingState();
        //equipmentSystem.SheathWeapon();
        mountGameObject.SetActive(false);
        mountCamera.SetActive(false);
        minimap.player=characterController.transform;
        markerHolder.playerObject=characterController;

        isOnMount=false;
    }
}


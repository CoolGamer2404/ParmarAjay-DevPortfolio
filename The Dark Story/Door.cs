using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    private static bool isOpened;
    public bool isOpenedT;
    public Animator da;
    public float distance;
    public Transform PlayerCamera;
    public Animator DoorAnimator;
    public float InteractionRange;
    public static bool InteractableWithDoor;
    public static bool Interactable;
    private float nextInteractionTime=2f;
    public float OpenRotation;
    public float CloseRotation;
    public float CurrentRotation;
    public Transform DoorGameObject;



    // Start is called before the first frame update
    void Start()
    {
        isOpened=false;
        nextInteractionTime=2f;
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
            if(doorhit.transform.tag=="Door"){
                DoorGameObject=doorhit.transform;
                DoorAnimator=doorhit.transform.GetComponentInParent<Animator>();
                Interactable=true;
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")&&nextInteractionTime==2f){
                    Interact();
                    nextInteractionTime-=Time.deltaTime;
                }
            }
            else{
                Interactable=false;
                DoorGameObject=null;
            }
        }
    }
    public void Interact(){
        if(isOpened==true && nextInteractionTime==2f){
            Debug.Log("Open");
            //DoorAnimator.SetBool("Close", false);
            DoorAnimator.SetBool("Open", false);
        }
        if(isOpened==false && nextInteractionTime==2f){
            Debug.Log("Close");
            DoorAnimator.SetBool("Open", true);
        }
    }

    public void AIEnter(){
        if(isOpened==false){
            DoorAnimator.SetBool("Open", true);
            isOpened=true;
            return;
        }
        if(isOpened==true){
            return;
        }
    }
    public void AIExit(){
        if(isOpened==true){
            DoorAnimator.SetBool("Open",false);
            isOpened=false;
            return;
        }
        if(isOpened==false){
            return;
        }
    }
    void DoorOpened(){
        nextInteractionTime=2f;
    }
    void DoorClosed(){
        nextInteractionTime=2f;
    }
}

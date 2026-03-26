using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using UnityEngine.InputSystem;

namespace Interactions
{
    public class RayCaster : MonoBehaviour
    {
        [Header("InputsSystemPc")]
        [SerializeField] private InputActionAsset inputActionAsset;

        [SerializeField] private InputAction interactAction;
        [SerializeField] private InputAction dropAction;
        [SerializeField]private int rayLength=5;
        [SerializeField]private LayerMask layerMaskinteract;
        [SerializeField]private string exclusedLayerName=null;

        private AllInteractionHandler _allInteractionHandler;
        public InteractionInventoryHandler _interactionInventoryHandler;

        //[SerializeField] private GameObject InteractButton;

        [SerializeField]private Image crossHair=null;
        private bool isCrosshairActive=false;
        private bool DoOnce=false;

        [SerializeField]private Transform itemSlot;
        [SerializeField]private Transform Player;

        private string InteractableTag="Interactables";
        private string InteractableTag2="SafeButton";

        public TMP_Text  textField;

        private void Start(){
            //InteractButton.SetActive(false);
            interactAction = inputActionAsset.FindAction("Interact");
            interactAction.Enable();
        }

        private void Update(){
            RaycastHit hit;
            Vector3 forwardposition=transform.TransformDirection(Vector3.forward);

            int mask=1<<LayerMask.NameToLayer(exclusedLayerName)|layerMaskinteract.value;

            if(Physics.Raycast(transform.position,forwardposition,out hit,rayLength,mask)){
                if(hit.collider.CompareTag(InteractableTag)){
                    /*if(!DoOnce){
                        _allInteractionHandler=hit.collider.gameObject.GetComponent<AllInteractionHandler>();
                        _allInteractionHandler.ItemSlot=itemSlot;
                        _allInteractionHandler.player=Player;
                        _allInteractionHandler.lookingAtObject=hit.collider.gameObject;
                        _allInteractionHandler.uiText=textField;
                        CrosshairChange(true);
                    }*/
                    _allInteractionHandler=hit.collider.gameObject.GetComponent<AllInteractionHandler>();
                        _allInteractionHandler.ItemSlot=itemSlot;
                        _allInteractionHandler.player=Player;
                        _allInteractionHandler.lookingAtObject=hit.collider.gameObject;
                        _allInteractionHandler.uiText=textField;
                        CrosshairChange(true);
                    isCrosshairActive=true;        
                    //DoOnce=true;

                    if(interactAction.triggered){
                        _allInteractionHandler.Interact(); 
                        _allInteractionHandler.uiText=textField;
                    }
                    /*if(Input.GetMouseButtonDown(2)){
                        _allInteractionHandler.Interact();
                        _allInteractionHandler.uiText=textField;
                    }*/
                }
                if(hit.collider.CompareTag(InteractableTag2)){
                    _allInteractionHandler=hit.collider.gameObject.GetComponent<AllInteractionHandler>();
                    isCrosshairActive=true;  
                    _allInteractionHandler.lookingAtObject=hit.collider.gameObject;      
                    //DoOnce=true;
                    CrosshairChange(true);
                }
            }
            else{
                if(isCrosshairActive){
                    CrosshairChange(false);
                    //DoOnce=false;
                }
            }
        }
        void CrosshairChange(bool on){
            if(on/* && !DoOnce*/){
                crossHair.color=Color.red;
                //InteractButton.SetActive(true);
            }
            else{
                crossHair.color=Color.white;
                isCrosshairActive=false;
                //InteractButton.SetActive(false);
            }
        }
    }
}


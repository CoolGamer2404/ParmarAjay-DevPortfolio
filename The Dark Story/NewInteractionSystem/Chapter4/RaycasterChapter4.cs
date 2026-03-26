using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using UnityEngine.InputSystem;

public class RaycasterChapter4 : MonoBehaviour
{
    [Header("InputsSystemPc")]
        [SerializeField] private InputActionAsset inputActionAsset;

        [SerializeField] private InputAction interactAction;
        [SerializeField] private InputAction dropAction;
        [SerializeField]private int rayLength=5;
        [SerializeField]private LayerMask layerMaskinteract;
        [SerializeField]private string exclusedLayerName=null;

        private IronCellDoors _ironCellDoors;

        //[SerializeField] private GameObject InteractButton;

        [SerializeField]private Image crossHair=null;
        private bool isCrosshairActive=false;
        private bool DoOnce=false;
        [SerializeField]private Transform Player;

        private string InteractableTag="Interactables";
        private string torchTag="Interactables";

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
                    _ironCellDoors=hit.collider.gameObject.GetComponent<IronCellDoors>();
                        //_allInteractionHandler.lookingAtObject=hit.collider.gameObject;
                        CrosshairChange(true);
                    isCrosshairActive=true;        

                    if(interactAction.triggered){
                        _ironCellDoors.Interact(); 
                    }
                }
                /*if(hit.collider.CompareTag(torchTag)){
                    _allInteractionHandler=hit.collider.gameObject.GetComponent<AllInteractionHandler>();
                    isCrosshairActive=true;  
                    _allInteractionHandler.lookingAtObject=hit.collider.gameObject;      
                    CrosshairChange(true);
                }*/
            }
            else{
                if(isCrosshairActive){
                    CrosshairChange(false);
                }
            }
        }
        void CrosshairChange(bool on){
            if(on){
                crossHair.color=Color.red;
            }
            else{
                crossHair.color=Color.white;
                isCrosshairActive=false;
            }
        }
}

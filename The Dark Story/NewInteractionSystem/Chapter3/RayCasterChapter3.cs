using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Interactions
{
    public class RayCasterChapter3 : MonoBehaviour
    {
        [Header("InputsSystemPc")]
        [SerializeField] private InputActionAsset inputActionAsset;

        [SerializeField] private InputAction interactAction;
        [SerializeField] private InputAction dropAction;


        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskinteract;
        [SerializeField] private string exclusedLayerName = null;

        [SerializeField]private Chapter3InteractionsHandler _chapter3InteractionsHandler;

        [SerializeField] private GameObject InteractButton;

        [SerializeField] private Image crossHair = null;
        private bool isCrosshairActive = false;
        private bool DoOnce = false;

        [SerializeField] private Transform itemSlot;
        [SerializeField] private Transform Player;

        [SerializeField] public static bool isLever1IsOn;
        [SerializeField] public static bool isLever2IsOn;
        [SerializeField] public static bool isLever3IsOn;
        [SerializeField] public static bool isLever4IsOn;

        private string InteractableTag = "Interactables";

        private void Start()
        {
            //InteractButton.SetActive(false);
            interactAction = inputActionAsset.FindAction("Interact");
            interactAction.Enable();
        }

        private void Update()
        {
            RaycastHit hit;
            Vector3 forwardposition = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(exclusedLayerName) | layerMaskinteract.value;

            if (Physics.Raycast(transform.position, forwardposition, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(InteractableTag))
                {
                    
                        _chapter3InteractionsHandler = hit.collider.gameObject.GetComponent<Chapter3InteractionsHandler>();
                        CrosshairChange(true);
                    
                    isCrosshairActive = true;
                    //DoOnce = true;

                    if(interactAction.triggered){
                        _chapter3InteractionsHandler.Interact(); 
                        //_allElementsQueastHandler.uiText=textField;
                    }
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    CrosshairChange(false);
                    //DoOnce = false;
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


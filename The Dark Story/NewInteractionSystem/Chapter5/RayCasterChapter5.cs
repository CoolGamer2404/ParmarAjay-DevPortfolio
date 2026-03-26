using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

namespace Chapter5
{
    public class RayCasterChapter5 : MonoBehaviour
    {
        [Header("InputsSystemPc")]
        [SerializeField] private InputActionAsset inputActionAsset;

        [SerializeField] private InputAction interactAction;


        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskinteract;
        [SerializeField] private string exclusedLayerName = null;

        [SerializeField]private AllInteractionsHandlerChapter5 _allInteractionsHandlerChapter5;


        [SerializeField] private Image crossHair = null;
        private bool isCrosshairActive = false;
        private bool DoOnce = false;

        [SerializeField] private Transform itemSlot;
        [SerializeField] private Transform Player;

        [SerializeField] public static bool isLever1IsOn;
        [SerializeField] public static bool isLever2IsOn;
        [SerializeField] public static bool isLever3IsOn;
        [SerializeField] public static bool isLever4IsOn;

        [SerializeField] private Transform dropLocation;

        private string InteractableTag = "Interactables";

        public TMP_Text  textField;

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
                     _allInteractionsHandlerChapter5 = hit.collider.gameObject.GetComponent<AllInteractionsHandlerChapter5>();
                        CrosshairChange(true);
                        _allInteractionsHandlerChapter5.ItemSlot=itemSlot;
                        _allInteractionsHandlerChapter5.player=Player;
                        _allInteractionsHandlerChapter5.lookingAtObject=hit.collider.gameObject;
                    isCrosshairActive = true;
                    _allInteractionsHandlerChapter5.uiText=textField;
                    _allInteractionsHandlerChapter5.dropLocation=dropLocation;

                    if(interactAction.triggered){
                         _allInteractionsHandlerChapter5 = hit.collider.gameObject.GetComponent<AllInteractionsHandlerChapter5>();
                        _allInteractionsHandlerChapter5.Interact(); 
                        _allInteractionsHandlerChapter5.uiText=textField;
                    }

                    /*if (CrossPlatformInputManager.GetButtonDown("Interact"))
                    {
                        _allInteractionsHandlerChapter5.Interact();
                    }
                    if (Input.GetMouseButtonDown(2))
                    {
                        _allInteractionsHandlerChapter5.Interact();
                    }*/
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    CrosshairChange(false);
                }
            }
        }
        void CrosshairChange(bool on)
        {
            if (on)
            {
                crossHair.color = Color.red;
            }
            else
            {
                crossHair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }
}


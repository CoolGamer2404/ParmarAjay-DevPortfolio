using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;
using TMPro;

namespace Interactions
{
    public class RayCasterForChapter2 : MonoBehaviour
    {
        [Header("InputsSystemPc")]
        [SerializeField] private InputActionAsset inputActionAsset;

        [SerializeField] private InputAction interactAction;
        [SerializeField] private InputAction dropAction;

        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskinteract;
        [SerializeField] private string exclusedLayerName = null;

        private AllElementsQueastHandler _allElementsQueastHandler;

        [SerializeField] private Image crossHair = null;
        private bool isCrosshairActive = false;
        private bool DoOnce = false;

        [SerializeField] private Transform itemSlot;
        [SerializeField] private Transform Player;

        private string InteractableTag = "Interactables";
        public TMP_Text textField;

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
                    _allElementsQueastHandler = hit.collider.gameObject.GetComponent<AllElementsQueastHandler>();
                    _allElementsQueastHandler.ItemSlot = itemSlot;
                    _allElementsQueastHandler.player = Player;
                    _allElementsQueastHandler.uiText = textField;
                    CrosshairChange(true);
                    isCrosshairActive = true;

                    if (interactAction.triggered)
                    {
                        _allElementsQueastHandler.Interact();
                        _allElementsQueastHandler.uiText = textField;
                        //_allElementsQueastHandler.uiText=textField;
                    }
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

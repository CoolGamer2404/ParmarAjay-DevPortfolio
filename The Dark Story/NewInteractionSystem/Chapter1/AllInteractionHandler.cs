using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.AI;

namespace Interactions
{
    public class AllInteractionHandler : MonoBehaviour
    {
        [Header("InputsSystemPc")]
        [SerializeField] private InputActionAsset inputActionAsset;
        [SerializeField] private InputAction dropAction;
        [SerializeField] private string targetInputActionAssetName = "StarterAssets";
        [SerializeField] private InputActionAsset[] allAssets;
        [SerializeField] private StarterAssetsInputs StarterAssetsInputs;
        [SerializeField] private Escape escape;
        [SerializeField] private Keypad keypad;


        [SerializeField] private Transform Equippeditem;
        [SerializeField] private int DropTime = 1;
        [SerializeField] private ObjectType objectType;
        [SerializeField] private PickUpItem pickUpItem;

        [SerializeField] private GameObject SafeUI;


        [SerializeField] private RequiredKeyOrTool requiredKeyOrTool;
        [SerializeField] private string name = null;

        [SerializeField] private InteractablesAnimationHandler _interactablesAnimationHandler;



        [Header("-------------------------RadioReferances-------------------------")]
        [SerializeField] private bool isRadioOn = true;
        [SerializeField] private AudioSource radioAudioSource;

        private enum RequiredKeyOrTool
        {
            Crawbar,
            Cutter,
            MainDoorKey,
            MainGateKey,
            CabinetKeys,
            DamiensRoomKey,
            LibraryRoomKey,
            SpecialRoomKey,
            Plank,
            BasementKey,
            LockerKeys,
            GuestRoom1Key,
            GuestRoom2Key,
        }
        private enum ObjectType
        {
            Door,
            Drawer,
            Cabinet,
            Safe,
            LockedDoor,
            LockedSafe,
            LockedDrawer,
            LockedCabinet,
            SteamPipeHandle,
            Pickup,
            Painting,
            LockedLocker,
            Locker,
            PlacedPlank,
            Plank,
            MainDoor,
            MainGate,
            Wire,
            DestroyableBox,
            BrokenFloor,
            PickedUp,
            WallPlank,
            FlashLight,
            Radio,
            BlockedDoor,
            BlockedDrawer,
        }
        private enum PickUpItem
        {
            Crawbar,
            Cutter,
            MainDoorKey,
            MainGateKey,
            CabinetKeys,
            DamiensRoomKey,
            LibraryRoomKey,
            SpecialRoomKey,
            Plank,
            BasementKey,
            LockerKeys,
            notPickable,
            GuestRoom1Key,
            GuestRoom2Key,
        }
        [Header("OnlyForPickable")]
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private BoxCollider boxCollider;
        public Transform ItemSlot;
        public Vector3 Scale;
        public bool itemEquipped;
        public static bool SlotFull;


        [Header("Drop")]
        [SerializeField] private float dropForwardForce;
        [SerializeField] private float dropUpwardForce;
        [SerializeField] public Transform player;
        [SerializeField] private bool isthisItemEquipped;

        [Header("ForQuestObjects")]
        [SerializeField] public GameObject lookingAtObject;
        [SerializeField] private Rigidbody currentPaintingRigidbody;
        [SerializeField] private Rigidbody currentPlankRigidbody;
        [SerializeField] public static int placedPlanks;
        [SerializeField] private GameObject Wire1;
        [SerializeField] private GameObject Wire2;
        [SerializeField] public static bool isElectricityIsOn;
        [SerializeField] private GameObject Box;
        [SerializeField] private GameObject BoxCell;
        [SerializeField] private MeshRenderer flashLight;
        [SerializeField] private GameObject flashLight1;
        [SerializeField] private GameObject flashLight2;
        [SerializeField] private GameObject flashLight3;
        [SerializeField] private GameObject jumpScareGlassFallGameObject;
        [SerializeField] private bool isJupScareGameObjectIsAlreadyOn=false;
        [SerializeField] private bool isGuestRoom2Door=false;

        [Header("Only_For_Main_Gate")]
        [SerializeField] private PlayVideo playVideo;



        [SerializeField] public TMP_Text uiText;
        [SerializeField] private int uiTime = 3;

        [Header("PlanksQuest")]
        [SerializeField] private GameObject placedPlankOnFloor;
        [SerializeField] private bool hasAIBlocker=false;
        [SerializeField] private NavMeshObstacle navMeshObstacle;



        // Start is called before the first frame update
        void Start()
        {
            placedPlanks = 3;
            SlotFull=false;
            if (objectType == ObjectType.Pickup)
            {
                boxCollider = gameObject.transform.GetComponent<BoxCollider>();
                rigidbody.isKinematic = false;
                isthisItemEquipped = false;
                Equippeditem = null;
            }
            if (objectType == ObjectType.WallPlank)
            {
                boxCollider = gameObject.transform.GetComponent<BoxCollider>();
                rigidbody.isKinematic = false;
                isthisItemEquipped = false;
                Equippeditem = null;
            }
            if (objectType == ObjectType.Wire)
            {
                Wire1.SetActive(true);
                Wire2.SetActive(false);
                isElectricityIsOn = true;
            }
            allAssets = Resources.FindObjectsOfTypeAll<InputActionAsset>();
            foreach (InputActionAsset asset in allAssets)
            {
                if (asset.name == targetInputActionAssetName)
                {
                    inputActionAsset = asset;
                }
            }
            dropAction = inputActionAsset.FindAction("Drop");
            dropAction.Enable();
        }

        // Update is called once per frame
        public void Update()
        {
            if (dropAction.triggered)
            {
                DropObject();
            }
            if (isthisItemEquipped && objectType == ObjectType.Pickup)
            {
                rigidbody.isKinematic = true;
                boxCollider.enabled = false;
                rigidbody.freezeRotation = true;
            }
            if (!isthisItemEquipped && objectType == ObjectType.Pickup)
            {
                rigidbody.isKinematic = false;
                boxCollider.enabled = true;
                rigidbody.freezeRotation = false;
            }
        }

        public void Interact()
        {

            if (objectType == ObjectType.Door)
            {
                _interactablesAnimationHandler.PlayAnimation();
                if(!isJupScareGameObjectIsAlreadyOn && isGuestRoom2Door){
                    jumpScareGlassFallGameObject.SetActive(true);
                }
            }
            if (objectType == ObjectType.Drawer)
            {
                _interactablesAnimationHandler.PlayAnimation();
            }
            if (objectType == ObjectType.Cabinet)
            {
                _interactablesAnimationHandler.PlayAnimation();
            }
            if (objectType == ObjectType.LockedDoor)
            {
                if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                {
                    objectType = ObjectType.Door;
                    _interactablesAnimationHandler.PlayUnlockMusic();
                }
                else
                {
                    StartCoroutine(ShowUI("You Need " + requiredKeyOrTool.ToString()));
                }
            }
            if(objectType==ObjectType.BlockedDoor){
                
                StartCoroutine(ShowUI("This Door Is Blocked! Try Other Door"));
            }
            if(objectType==ObjectType.BlockedDrawer){
                
                StartCoroutine(ShowUI("This Drawer Is Blocked! Try Other Drawer"));
            }
            if (objectType == ObjectType.LockedDrawer)
            {
                if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                {
                    objectType = ObjectType.Drawer;
                }
                else
                {
                    StartCoroutine(ShowUI("You Need " + requiredKeyOrTool.ToString()));
                }
            }
            if (objectType == ObjectType.Safe)
            {
                if (keypad.isUnlocked)
                {
                    _interactablesAnimationHandler.PlayAnimation();
                }
                else if (!keypad.isUnlocked)
                {
                    escape.isSafeMenuActive = true;
                    SafeUI.SetActive(true);
                    StarterAssetsInputs.cursorLocked = false;
                    StarterAssetsInputs.cursorInputForLook = false;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                }

            }
            if (objectType == ObjectType.FlashLight)
            {
                FlashLight.isGotFlashLight = true;
                flashLight.enabled = false;
                flashLight1.SetActive(false);
                flashLight2.SetActive(false);
                flashLight3.SetActive(false);
                StartCoroutine(ShowFlashLightUI("Press 'F' To Toggle On/Off FlashLight"));
            }
            if (objectType == ObjectType.LockedCabinet)
            {
                if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                {
                    objectType = ObjectType.Cabinet;
                }
                else
                {
                    StartCoroutine(ShowUI("You Need " + requiredKeyOrTool.ToString()));
                }
            }
            if (objectType == ObjectType.SteamPipeHandle)
            {
                _interactablesAnimationHandler.PlayAnimation();
            }
            if (objectType == ObjectType.Painting)
            {
                currentPaintingRigidbody = lookingAtObject.GetComponent<Rigidbody>();
                currentPaintingRigidbody.isKinematic = false;
            }
            if (objectType == ObjectType.LockedLocker)
            {
                if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                {
                    objectType = ObjectType.Locker;
                }
                else
                {
                    StartCoroutine(ShowUI("You Need " + requiredKeyOrTool.ToString()));
                }
            }
            if (objectType == ObjectType.MainDoor)
            {
                if (placedPlanks <= 0)
                {
                    if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                    {
                        objectType = ObjectType.Door;
                    }
                    else
                    {
                        StartCoroutine(ShowUI("You Need"+requiredKeyOrTool.ToString()));
                    }
                }
                else
                {
                    StartCoroutine(ShowUI("Remove Planks First!!!"));
                }
            }
            if (objectType == ObjectType.MainGate)
            {
                /*if (isElectricityIsOn == false)
                {
                    if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                    {
                        playVideo.StartVideo();
                    }
                }
                else
                {
                    StartCoroutine(ShowUI("Turn Off Electricity"));
                }*/
                if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                {
                    playVideo.StartVideo();
                }
            }
            if (objectType == ObjectType.Locker)
            {
                _interactablesAnimationHandler.PlayAnimation();
            }
            if (objectType == ObjectType.DestroyableBox)
            {
                if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                {
                    Box.SetActive(false);
                    BoxCell.SetActive(true);
                }
                else
                {
                    StartCoroutine(ShowUI("Find a way to break"));
                }
            }
            if (objectType == ObjectType.PlacedPlank)
            {
                if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                {
                    //objectType = ObjectType.Pickup;
                    placedPlanks -= 1;
                    _interactablesAnimationHandler.PlayMusic();
                    currentPlankRigidbody = lookingAtObject.GetComponent<Rigidbody>();
                    currentPlankRigidbody.isKinematic = false;
                    rigidbody = currentPlankRigidbody;
                    StartCoroutine(StartPlankDestruction());
                    
                }
            }
            if (objectType == ObjectType.Radio)
            {
                if (isRadioOn)
                {
                    radioAudioSource.Stop();
                    isRadioOn = false;
                    return;
                }
                if (!isRadioOn)
                {
                    radioAudioSource.Play();
                    isRadioOn = true;
                    return;
                }
            }
            if (objectType == ObjectType.WallPlank)
            {
                if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                {
                    //objectType = ObjectType.Pickup;
                    transform.tag = "Untagged";
                    //transform.gameObject.layer = "Default";
                    currentPlankRigidbody = lookingAtObject.GetComponent<Rigidbody>();
                    currentPlankRigidbody.isKinematic = false;
                    _interactablesAnimationHandler.PlayMusic();
                    rigidbody = currentPlankRigidbody;
                    if (hasAIBlocker)
                    {
                        navMeshObstacle.carving = false;
                        StartCoroutine(StartPlankDestruction());
                    }

                }
            }
            if(objectType == ObjectType.BrokenFloor)
            {
                if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString())
                {
                    placedPlankOnFloor.SetActive(true);
                    InteractionInventoryHandler.itemEquipped = false;
                    InteractionInventoryHandler.EquippedItemName = null;
                    SlotFull = false;
                    Destroy(InteractionInventoryHandler.EquippedItem);
                    Destroy(gameObject);
                }
            }
            if (objectType == ObjectType.Wire)
            {
                if (InteractionInventoryHandler.EquippedItemName == requiredKeyOrTool.ToString() && isElectricityIsOn)
                {
                    Wire1.SetActive(false);
                    Wire2.SetActive(true);
                    isElectricityIsOn = false;
                }
                else
                {
                    StartCoroutine(ShowUI("You need WireCutter"));
                }
            }
            if (objectType == ObjectType.Pickup)
            {
                if (!SlotFull)
                {
                    StartCoroutine(ShowUI(pickUpItem.ToString()));
                    InteractionInventoryHandler.itemEquipped = true;
                    isthisItemEquipped = true;
                    InteractionInventoryHandler.EquippedItem = transform.gameObject;
                    InteractionInventoryHandler.EquippedItemName = pickUpItem.ToString();
                    SlotFull = true;

                    transform.SetParent(ItemSlot);
                    transform.localPosition = Vector3.zero;
                    transform.localRotation = Quaternion.Euler(Vector3.zero);
                    transform.localScale = Scale;
                    //objectType = ObjectType.PickedUp;
                    StartCoroutine(ShowUI(pickUpItem.ToString()));
                }
            }



            ///InteractionInventoryHandler.isItemEquipped=true;
            ///InteractionInventoryHandler.ItemName=name;
        }
        public void DropObject()
        {
            //AllInteractionHandler allInteractionHandlerNew = null;
            if (pickUpItem != PickUpItem.notPickable)
            {
                InteractionInventoryHandler.itemEquipped = false;
                InteractionInventoryHandler.EquippedItemName = null;
                isthisItemEquipped = false;
                SlotFull = false;
                //allInteractionHandlerNew=InteractionInventoryHandler.EquippedItem.GetComponent<AllInteractionHandler>();
                //allInteractionHandlerNew.objectType = ObjectType.Pickup;

                InteractionInventoryHandler.EquippedItem.transform.SetParent(null);
                /*rigidbody.velocity = player.GetComponent<Rigidbody>().velocity;

                rigidbody.AddForce(ItemSlot.forward * dropForwardForce, ForceMode.Impulse);
                rigidbody.AddForce(ItemSlot.up * dropUpwardForce, ForceMode.Impulse);

                float random = Random.Range(-1f, 1f);
                rigidbody.AddTorque(new Vector3(random, random, random) * 10);*/


                InteractionInventoryHandler.EquippedItemName = null;
            }
        }

        //EquipItem
        //Open/Close

        private IEnumerator ShowUI(string txt)
        {
            uiText.text = txt;
            yield return new WaitForSeconds(uiTime);
            uiText.text = null;
        }
        private IEnumerator ShowFlashLightUI(string txt)
        {
            uiText.text = txt;
            yield return new WaitForSeconds(uiTime);
            uiText.text = null;
            gameObject.SetActive(false);
        }
        private IEnumerator StartPlankDestruction()
        {
            yield return new WaitForSeconds(15);
            Destroy(gameObject);
        }
    }
}


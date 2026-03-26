using System.Collections;
using UnityEngine;
using Interactions;
using UnityEngine.InputSystem;
using TMPro;

namespace Chapter5
{
    public class AllInteractionsHandlerChapter5 : MonoBehaviour
    {
        [Header("InputsSystemPc")]
        [SerializeField] private InputActionAsset inputActionAsset;

        [SerializeField] private InputAction dropAction;
        [SerializeField] private string targetInputActionAssetName = "StarterAssets";
        [SerializeField] private InputActionAsset[] allAssets;

        [Header("OnlyForPickable")]
        [SerializeField] private Rigidbody rigidbody;
        public Transform ItemSlot;
        public Vector3 Scale;
        public bool itemEquipped;
        public static bool SlotFull;
        [SerializeField] private Transform Equippeditem;
        [SerializeField] private AllInteractionsHandlerChapter5 _allInteractionsHandlerChapter5;
        private BoxCollider boxCollider;
        public TMP_Text uiText;
        [SerializeField] private int uiTime = 3;

        [Header("Drop")]
        [SerializeField] private float dropForwardForce;
        [SerializeField] private float dropUpwardForce;
        [SerializeField] public Transform dropLocation;
        [SerializeField] public Transform player;
        [SerializeField] private bool isthisItemEquipped;

        [Header("AccessMachine")]
        [SerializeField] private Animator doorAnimator;
        [SerializeField] private bool isDoorOpen;
        [SerializeField] public GameObject lookingAtObject;
        [SerializeField] public AllInteractionsHandlerChapter5 AccessMachineInteractionsHandler;


        [Header("ForCabinets")]
        [SerializeField] private InteractablesAnimationHandler _interactablesAnimationHandler;

        [SerializeField] private ObjectType objectType;
        [SerializeField] private PickupName pickupName;
        [SerializeField] private AccessMachineColor accessMachineColor;
        [SerializeField] private bool isInteractable = true;
        [SerializeField] private int WaitTime = 3;

        [Header("ForTablte&Charger")]
        [SerializeField] private Transform tabletParent;
        [SerializeField] private ChargingScreen chargingScreen;
        [SerializeField] private Vector3 tabletPosition;
        [SerializeField] private Vector3 tabletScale;
        [SerializeField] private Quaternion tabletRotation;
        [SerializeField] private Transform tabletStandParent;
        [SerializeField] private Vector3 tabletOnStandPosition;
        [SerializeField] private Vector3 tabletOnStandScale;
        [SerializeField] private Quaternion tabletOnStandRotation;
        [SerializeField] private AllInteractionsHandlerChapter5 tabletInteractionHandler;
        [SerializeField] private AllInteractionsHandlerChapter5 brokenTabletInteractionHandler;

        [Header("For Documents")]
        [SerializeField] private GameObject documentUI;


        [Header("-------------------------Lights--------------------------")]
        [SerializeField] LightsActivator lightsActivator;
        [SerializeField] private AudioSource switchAudioSource;
        [SerializeField] private AudioClip switchAudioClip;
        private enum ObjectType
        {
            RedButton,
            BlueButton,
            GreenButton,
            Pickup,
            AccessMachine,
            SciFiCabinet,
            Inventory,
            Charger,
            NotPickable,
            TabletStand,
            Document,
        }
        private enum PickupName
        {
            BlueCard,
            GreenCard,
            OrangeCard,
            PinkCard,
            PurpleCard,
            RedCard,
            Tablet,
            BrokenTablet,
            ChargedTablet,
        }
        private enum AccessMachineColor
        {
            Blue,
            Green,
            Orange,
            Pink,
            Purple,
            Red,
        }
        // Start is called before the first frame update
        void Start()
        {
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
            if (objectType == ObjectType.Pickup)
            {
                rigidbody.isKinematic = false;
                isthisItemEquipped = false;
                Equippeditem = null;
            }
            if (objectType == ObjectType.AccessMachine)
            {
                isDoorOpen = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            /*if(Input.GetMouseButtonDown(2)){
                lightmapActivator.ActivateNighttimeLightmaps();
            }if(Input.GetMouseButtonDown(2)){
                lightmapActivator.ActivateNighttimeLightmaps();
            }*/
            if (dropAction.triggered)
            {
                if ((Equippeditem != null))
                {
                    _allInteractionsHandlerChapter5 = Equippeditem.GetComponent<AllInteractionsHandlerChapter5>();
                    _allInteractionsHandlerChapter5.DropObject();
                }
            }
            if (isthisItemEquipped && objectType == ObjectType.Pickup)
            {
                if (boxCollider != null && rigidbody != null)
                {
                    boxCollider.enabled = false;
                    rigidbody.isKinematic = true;
                }

            }
            if (!isthisItemEquipped && objectType == ObjectType.Pickup)
            {
                if (boxCollider != null && objectType != null)
                {
                    boxCollider.enabled = true;
                    rigidbody.isKinematic = false;
                }
            }
            if (objectType == ObjectType.Charger && tabletParent.childCount != 1)
            {
                chargingScreen.isBrokenTabletPlaced = false;
                chargingScreen.isTabletPlaced = false;
            }
            if (objectType == ObjectType.Charger && tabletParent.childCount == 1)
            {
                if (tabletParent.GetChild(0).name == "BrokenTablet")
                {
                    chargingScreen.isBrokenTabletPlaced = true;
                }
                if (tabletParent.GetChild(0).name == "Tablet")
                {
                    chargingScreen.isTabletPlaced = true;
                }
            }
        }

        public void Interact()
        {
            if (objectType == ObjectType.RedButton && isInteractable && lightsActivator.isRedOn==false)
            {
                UnityEngine.Debug.Log("RedPowerIsRecovered");
                TaskTextHandler.lightsActivated += 1;
                lightsActivator.isRedOn = true;
                switchAudioSource.PlayOneShot(switchAudioClip);
                StartCoroutine(ShowUI("Recovered Red"));

                StartCoroutine(WaitBeforeClick());
            }
            if (objectType == ObjectType.BlueButton && isInteractable && lightsActivator.isBlueOn==false)
            {
                UnityEngine.Debug.Log("BluePowerIsRecovered");
                TaskTextHandler.lightsActivated += 1;
                lightsActivator.isBlueOn = true;
                switchAudioSource.PlayOneShot(switchAudioClip);
                StartCoroutine(ShowUI("Recovered Blue"));
                StartCoroutine(WaitBeforeClick());
            }
            if (objectType == ObjectType.GreenButton && isInteractable && lightsActivator.isGreenOn==false)
            {
                UnityEngine.Debug.Log("GreenPowerIsRecovered");
                TaskTextHandler.lightsActivated += 1;
                lightsActivator.isGreenOn = true;
                switchAudioSource.PlayOneShot(switchAudioClip);
                StartCoroutine(ShowUI("Recovered Green"));
                StartCoroutine(WaitBeforeClick());
            }
            if (objectType == ObjectType.Document)
            {
                documentUI.SetActive(true);
            }
            if (objectType == ObjectType.Charger && isInteractable && InteractionInventoryHandler.EquippedItemName == "BrokenTablet")
            {
                brokenTabletInteractionHandler.placeTablet(tabletParent, tabletPosition, tabletScale, tabletRotation);
                chargingScreen.isBrokenTabletPlaced = true;
            }
            if (objectType == ObjectType.Charger && isInteractable && InteractionInventoryHandler.EquippedItemName == "Tablet")
            {
                tabletInteractionHandler.placeTablet(tabletParent, tabletPosition, tabletScale, tabletRotation);
                chargingScreen.isTabletPlaced = true;
            }
            if (objectType == ObjectType.TabletStand && isInteractable && InteractionInventoryHandler.EquippedItemName == "Tablet")
            {
                if (tabletStandParent.childCount == 0)
                {
                    tabletInteractionHandler.placeTabletOnStand(tabletStandParent, tabletOnStandPosition, tabletOnStandScale, tabletOnStandRotation);
                }
            }
            if (objectType == ObjectType.TabletStand && isInteractable && InteractionInventoryHandler.EquippedItemName == "BrokenTablet")
            {
                if (tabletStandParent.childCount == 0)
                {
                    brokenTabletInteractionHandler.placeTabletOnStand(tabletStandParent, tabletOnStandPosition, tabletOnStandScale, tabletOnStandRotation);
                }
            }
            if (objectType == ObjectType.Inventory)
            {
                StartCoroutine(ShowUI("Charged Tablet"));
                //UnityEngine.Debug.Log("You PickedUp Charged tablet");
            }
            if (pickupName == PickupName.ChargedTablet)
            {
                Destroy(transform.gameObject);
                TabletHandler.tabletGot = true;
                StartCoroutine(ShowUI("Charged Tablet"));
            }
            if (objectType == ObjectType.Pickup)
            {
                if (!SlotFull)
                {
                    InteractionInventoryHandler.itemEquipped = true;
                    InteractionInventoryHandler.EquippedItem = transform.gameObject;
                    AccessMachineInteractionsHandler = lookingAtObject.GetComponent<AllInteractionsHandlerChapter5>();
                    AccessMachineInteractionsHandler.isthisItemEquipped = true;
                    Equippeditem = transform;
                    InteractionInventoryHandler.EquippedItemName = pickupName.ToString();
                    SlotFull = true;

                    transform.SetParent(ItemSlot);
                    transform.localPosition = Vector3.zero;
                    transform.localRotation = Quaternion.Euler(Vector3.zero);
                    transform.localScale = Scale;
                    StartCoroutine(ShowUI(pickupName.ToString()));
                }
            }
            if (objectType == ObjectType.AccessMachine)
            {
                AccessMachineInteractionsHandler = lookingAtObject.GetComponent<AllInteractionsHandlerChapter5>();
                if (accessMachineColor == AccessMachineColor.Blue && !AccessMachineInteractionsHandler.isDoorOpen && InteractionInventoryHandler.EquippedItemName == "BlueCard" && isInteractable)
                {
                    UnityEngine.Debug.Log("its Unlocked");
                    doorAnimator.Play("isOpen", 0, 0.0f);
                    AccessMachineInteractionsHandler.isDoorOpen = true;
                    StartCoroutine(ShowUI("Access Granted."));
                    StartCoroutine(WaitBeforeClick());
                }
                if (accessMachineColor == AccessMachineColor.Green && !AccessMachineInteractionsHandler.isDoorOpen && InteractionInventoryHandler.EquippedItemName == "GreenCard" && isInteractable)
                {
                    UnityEngine.Debug.Log("its Unlocked");
                    doorAnimator.Play("isOpen", 0, 0.0f);
                    AccessMachineInteractionsHandler.isDoorOpen = true;
                    StartCoroutine(ShowUI("Access Granted."));
                    StartCoroutine(WaitBeforeClick());
                }
                if (accessMachineColor == AccessMachineColor.Red && !AccessMachineInteractionsHandler.isDoorOpen && InteractionInventoryHandler.EquippedItemName == "RedCard" && isInteractable)
                {
                    UnityEngine.Debug.Log("its Unlocked");
                    doorAnimator.Play("isOpen", 0, 0.0f);
                    AccessMachineInteractionsHandler.isDoorOpen = true;
                    StartCoroutine(ShowUI("Access Granted."));
                    StartCoroutine(WaitBeforeClick());
                }
                if (accessMachineColor == AccessMachineColor.Pink && !AccessMachineInteractionsHandler.isDoorOpen && InteractionInventoryHandler.EquippedItemName == "PinkCard" && isInteractable)
                {
                    UnityEngine.Debug.Log("its Unlocked");
                    doorAnimator.Play("isOpen", 0, 0.0f);
                    AccessMachineInteractionsHandler.isDoorOpen = true;
                    StartCoroutine(ShowUI("Access Granted."));
                    StartCoroutine(WaitBeforeClick());
                }
                if (accessMachineColor == AccessMachineColor.Purple && !AccessMachineInteractionsHandler.isDoorOpen && InteractionInventoryHandler.EquippedItemName == "PurpleCard" && isInteractable)
                {
                    UnityEngine.Debug.Log("its Unlocked");
                    doorAnimator.Play("isOpen", 0, 0.0f);
                    AccessMachineInteractionsHandler.isDoorOpen = true;
                    StartCoroutine(ShowUI("Access Granted."));
                    StartCoroutine(WaitBeforeClick());
                }
                if (accessMachineColor == AccessMachineColor.Orange && !AccessMachineInteractionsHandler.isDoorOpen && InteractionInventoryHandler.EquippedItemName == "OrangeCard" && isInteractable)
                {
                    UnityEngine.Debug.Log("its Unlocked");
                    doorAnimator.Play("isOpen", 0, 0.0f);
                    AccessMachineInteractionsHandler.isDoorOpen = true;
                    StartCoroutine(ShowUI("Access Granted."));
                    StartCoroutine(WaitBeforeClick());
                }
                else if (!AccessMachineInteractionsHandler.isDoorOpen && isInteractable)
                {
                    StartCoroutine(ShowUI("You Need Key Card Of Same Color"));
                    //UnityEngine.Debug.Log("You Need Defined Card For Defined Access Machine");
                    StartCoroutine(WaitBeforeClick());
                }
                else if (AccessMachineInteractionsHandler.isDoorOpen && isInteractable)
                {
                    StartCoroutine(ShowUI("Error 404 : Door Is Already Open"));
                    //UnityEngine.Debug.Log("Its Open -_-");
                    StartCoroutine(WaitBeforeClick());
                }
            }
            if (objectType == ObjectType.SciFiCabinet)
            {
                _interactablesAnimationHandler.PlayAnimation();
            }
        }

        private IEnumerator WaitBeforeClick()
        {
            isInteractable = false;
            yield return new WaitForSeconds(WaitTime);
            isInteractable = true;
        }
        public void DropObject()
        {
            InteractionInventoryHandler.itemEquipped = false;
            InteractionInventoryHandler.EquippedItemName = null;
            InteractionInventoryHandler.EquippedItem = null;
            isthisItemEquipped = false;
            SlotFull = false;

            if(pickupName==PickupName.Tablet){
                transform.localScale = new Vector3(1,1,1);
            }
            if(pickupName==PickupName.BrokenTablet){
                transform.localScale = new Vector3(1,1,1);
            }

            Equippeditem.SetParent(null);


            Equippeditem.position=dropLocation.position;

            if(pickupName==PickupName.Tablet){
                transform.localScale = new Vector3(1,1,1);
            }
            if(pickupName==PickupName.BrokenTablet){
                transform.localScale = new Vector3(1,1,1);
            }
            
            //rigidbody.velocity = player.GetComponent<Rigidbody>().velocity;

            //rigidbody.AddForce(ItemSlot.forward * dropForwardForce, ForceMode.Impulse);
            //rigidbody.AddForce(ItemSlot.up * dropUpwardForce, ForceMode.Impulse);

            //float random = UnityEngine.Random.Range(-1f, 1f);
            //rigidbody.AddTorque(new Vector3(random, random, random) *2);


            Equippeditem.position=dropLocation.position;
            InteractionInventoryHandler.EquippedItemName = null;
            Equippeditem = null;
        }

        public void placeTablet(Transform parent, Vector3 tabPos, Vector3 tabScale, Quaternion tabRot)
        {
            InteractionInventoryHandler.itemEquipped = false;
            InteractionInventoryHandler.EquippedItemName = null;
            InteractionInventoryHandler.EquippedItem = null;
            isthisItemEquipped = false;
            SlotFull = false;

            Equippeditem.SetParent(parent);
            transform.localPosition = tabPos;
            transform.localScale = tabScale;
            transform.rotation = tabRot;

            InteractionInventoryHandler.EquippedItemName = null;
            Equippeditem = null;
        }

        public void placeTabletOnStand(Transform parent, Vector3 tabPos, Vector3 tabScale, Quaternion tabRot)
        {
            InteractionInventoryHandler.itemEquipped = false;
            InteractionInventoryHandler.EquippedItemName = null;
            InteractionInventoryHandler.EquippedItem = null;
            isthisItemEquipped = false;
            SlotFull = false;

            Equippeditem.SetParent(parent);
            transform.localPosition = tabPos;
            transform.localScale = tabScale;
            transform.rotation = tabRot;

            InteractionInventoryHandler.EquippedItemName = null;
            Equippeditem = null;
        }

        public void ChangePickUpNameToChargedTablet()
        {
            pickupName = PickupName.ChargedTablet;
        }
        public void ChangeToNotPickup()
        {
            objectType = ObjectType.NotPickable;
        }
        public void ChangeToPickup()
        {
            objectType = ObjectType.Pickup;
        }

        private IEnumerator ShowUI(string txt)
        {
            uiText.text = txt;
            yield return new WaitForSeconds(uiTime);
            uiText.text = null;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;
using UnityHFSM;
using TMPro;
using UnityEngine.UIElements;

namespace Interactions
{
    public class AllElementsQueastHandler : MonoBehaviour
    {
        [Header("InputsSystemPc")]
        [SerializeField] private InputActionAsset inputActionAsset;
        [SerializeField] private InputAction dropAction;
        [SerializeField] private string targetInputActionAssetName = "StarterAssets";
        [SerializeField] private InputActionAsset[] allAssets;

        [Header("OnlyForPickable")]
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private BoxCollider boxCollider;
        public Transform ItemSlot;
        public Vector3 Scale;
        public bool itemEquipped;
        public static bool SlotFull;
        [SerializeField] private PickUpItem pickUpItem;

        [Header("Drop")]
        [SerializeField] private float dropForwardForce;
        [SerializeField] private float dropUpwardForce;
        [SerializeField] public Transform player;
        [SerializeField] private bool isthisItemEquipped;

        [Header("ForFindingObjectType")]
        [SerializeField] private ObjectType objectType;
        [SerializeField] private ElementMachineType elementMachineType;

        [Header("References")]
        [SerializeField] private InteractablesAnimationHandler _interactablesAnimationHandler;
        [SerializeField] private Transform Equippeditem;
        [SerializeField] private ElementsHandler EarthelementsHandler;
        [SerializeField] private ElementsHandler WaterelementsHandler;
        [SerializeField] private ElementsHandler FireelementsHandler;
        [SerializeField] private ElementsHandler WindelementsHandler;
        [SerializeField] private ElementsHandler SpaceelementsHandler;
        [SerializeField] private GameObject ItemInChildrenOfItemSlot;
        [SerializeField] public TMP_Text uiText;
        [SerializeField] private int uiTime = 3;


        [Header("Water Elements References")]
        [SerializeField] private GameObject FilledWater;
        [SerializeField] private AllElementsQueastHandler BucketQuestHandler;
        [SerializeField] private bool isBucketInteractable;
        [SerializeField] private bool isBucketPlaced;
        [SerializeField] private int WaitForBucketTime = 5;
        [SerializeField] public static bool isBucket;
        [SerializeField] private AllElementsQueastHandler HandpumpelementsHandler;
        [SerializeField] private Vector3 BucketPosition;
        [SerializeField] private Vector3 BucketScale;
        [SerializeField] private Quaternion BucketRotation;

        [Header("Steam")]
        [SerializeField] private PipeSteamController pipeSteamController;


        [Header("Element Machine Main")]
        [SerializeField] private bool earth,fire,space,water,wind;
        [SerializeField] private GameObject earthJar,fireJar,spaceJar,waterJar,windJar;
        [SerializeField] private PlayVideo playVideo;
        [SerializeField] private PlayVideo playVideo2;
        [SerializeField] private GameObject basementkeygameObject;


        private enum ObjectType
        {
            ElementMachineMain,
            Pickup,
            InteractableButtonOrLever,
            SteamPipeLever,
            HandPump,
            LockedObjects,
            PlacedObjects,///This Objects Are Not Removable Once Placed
            ElementMachine,
            EarthJar,
            WaterJar,
            FireJar,
            SpaceJar,
            WindJar,
            PlacedTorch1,
            PlacedTorch2,
        }
        private enum PickUpItem
        {
            EarthElementJar,
            River,
            Landscape,
            Heart,
            Tree,

            SpaceElementJar,
            Mercury,
            Earth,
            Mars,
            Venus,

            WindElementJar,
            Cog1,
            Cog2,

            WaterElementJar,
            EmptyWaterBucket,
            FullWaterBucket,

            FireElementJar,
            Torch1,
            Torch2,
            Matchbox,

            BasementKey,
        }
        private enum ElementMachineType
        {
            Earth,
            Fire,
            Water,
            Wind,
            Space,
        }
        void Start()
        {
            ItemInChildrenOfItemSlot = null;
            if (objectType == ObjectType.Pickup)
            {
                //rigidbody.isKinematic = false;
                isthisItemEquipped = false;
                boxCollider=gameObject.transform.GetComponent<BoxCollider>();
            }
            if(objectType==ObjectType.ElementMachineMain){
                wind=false;
                water=false;
                space=false;
                fire=false;
                earth=false;
                windJar.SetActive(false);
                waterJar.SetActive(false);
                spaceJar.SetActive(false);
                fireJar.SetActive(false);
                earthJar.SetActive(false);
                basementkeygameObject.SetActive(false);
            }

            allAssets = Resources.FindObjectsOfTypeAll<InputActionAsset>();
            foreach (InputActionAsset asset in allAssets){
                if (asset.name == targetInputActionAssetName){
                    inputActionAsset=asset;
                }
            }
            dropAction = inputActionAsset.FindAction("Drop");
            dropAction.Enable();
        }

        public void Update()
        {
            if (dropAction.triggered)
            {
                DropObject();
            }
            if (isthisItemEquipped &&objectType==ObjectType.Pickup)
            {
                boxCollider = gameObject.transform.GetComponent<BoxCollider>();
                rigidbody.isKinematic = false;
                boxCollider.enabled=false;
                rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            }
            if (!isthisItemEquipped &&objectType==ObjectType.Pickup)
            {
                rigidbody.isKinematic = false;
                boxCollider.enabled=true;
                rigidbody.constraints = RigidbodyConstraints.None;
            }
            if (ElementsHandler.isSpaceQuestCompleted)
            {
                //Debug.Log("isSpaceQuestCompleted");
                if (objectType == ObjectType.SpaceJar)
                {
                    Debug.Log("converted To Pickup from space");
                    objectType = ObjectType.Pickup;
                }
            }
            if (ElementsHandler.isEarthQuestCompleted)
            {
                //Debug.Log("isEarthQuestCompleted");
                if (objectType == ObjectType.EarthJar)
                {
                    Debug.Log("converted To Pickup from earth");
                    objectType = ObjectType.Pickup;
                }
            }
            if (ElementsHandler.isFireQuestCompleted)
            {
                //Debug.Log("isFireQuestCompleted");
                if (objectType == ObjectType.FireJar)
                {
                    Debug.Log("converted To Pickup from fire");
                    objectType = ObjectType.Pickup;
                }
            }
            /*if (ElementsHandler.isWindQuestCompleted)
            {
                if (objectType == ObjectType.WindJar)
                {
                    Debug.Log("converted To Pickup from wind");
                    objectType = ObjectType.Pickup;
                }
            }*/
            if (ElementsHandler.isWaterQuestCompleted)
            {
                //Debug.Log("isWaterQuestCompleted");
                if (objectType == ObjectType.WaterJar)
                {
                    Debug.Log("converted To Pickup from water");
                    objectType = ObjectType.Pickup;
                }
            }

            if(objectType==ObjectType.ElementMachineMain){
                if(fire==true && space==true && water==true && earth==true && wind==true){
                    playVideo.StartVideo();
                    basementkeygameObject.SetActive(true);
                }
            }
        }

        public void Interact()
        {
            if (objectType == ObjectType.Pickup)
            {
                if (!SlotFull)
                {
                    StartCoroutine(ShowUI(pickUpItem.ToString()));
                    if (pickUpItem==PickUpItem.BasementKey){
                        playVideo2.StartVideo();
                    }
                    InteractionInventoryHandler.itemEquipped = true;
                    isthisItemEquipped = true;
                    Equippeditem = transform;
                    InteractionInventoryHandler.EquippedItem = transform.gameObject;
                    InteractionInventoryHandler.EquippedItemName = pickUpItem.ToString();
                    SlotFull = true;

                    transform.SetParent(ItemSlot);
                    transform.localPosition = Vector3.zero;
                    transform.localRotation = Quaternion.Euler(Vector3.zero);
                    transform.localScale = Scale;
                    StartCoroutine(ShowUI(pickUpItem.ToString()));
                }
            }
            if(pickUpItem==PickUpItem.EarthElementJar && objectType != ObjectType.Pickup)
            {
                StartCoroutine(ShowUI("You Need To Place All Objects Related To Earth!!!"));
            }
            if (pickUpItem == PickUpItem.WaterElementJar && objectType != ObjectType.Pickup)
            {
                StartCoroutine(ShowUI("I Need Water To Give You Water..."));
            }
            if (pickUpItem == PickUpItem.SpaceElementJar && objectType != ObjectType.Pickup)
            {
                StartCoroutine(ShowUI("Some Planets Are Missing???"));
            }
            if (pickUpItem == PickUpItem.FireElementJar && objectType != ObjectType.Pickup)
            {
                StartCoroutine(ShowUI("There Should Be Fire."));
            }
            if (objectType==ObjectType.SteamPipeLever){
                pipeSteamController.Interact();
            }
            if (objectType == ObjectType.ElementMachineMain)
            {
                if(InteractionInventoryHandler.EquippedItemName=="EarthElementJar"){
                    earth=true;
                    earthJar.SetActive(true);
                    DestroyObject();
                }
                if(InteractionInventoryHandler.EquippedItemName=="FireElementJar"){
                    fire=true;
                    fireJar.SetActive(true);
                    DestroyObject();
                }
                if(InteractionInventoryHandler.EquippedItemName=="WaterElementJar"){
                    water=true;
                    waterJar.SetActive(true);
                    DestroyObject();
                }
                if(InteractionInventoryHandler.EquippedItemName=="WindElementJar"){
                    wind=true;
                    windJar.SetActive(true);
                    DestroyObject();
                }
                if(InteractionInventoryHandler.EquippedItemName=="SpaceElementJar"){
                    space=true;
                    spaceJar.SetActive(true);
                    DestroyObject();
                }
                else
                {
                    StartCoroutine(ShowUI("You Need All Five Elements Jars!"));
                }
            }
            if (objectType == ObjectType.InteractableButtonOrLever)
            {
                WindelementsHandler.StartCogs();
            }
            if (objectType == ObjectType.ElementMachine)
            {
                if (elementMachineType == ElementMachineType.Earth && SlotFull)
                {
                    EarthelementsHandler.Place();
                }
                if (elementMachineType == ElementMachineType.Fire && SlotFull)
                {
                    FireelementsHandler.Place();
                }
                if (elementMachineType == ElementMachineType.Space && SlotFull)
                {
                    SpaceelementsHandler.Place();
                }
                if(elementMachineType==ElementMachineType.Water && SlotFull){
                    WaterelementsHandler.FillJars();
                }
            }
            if (objectType == ObjectType.PlacedTorch1)
            {
                FireelementsHandler.LightUpTorch1();
            }
            if (objectType == ObjectType.PlacedTorch2)
            {
                FireelementsHandler.LightUpTorch2();
            }
            if(objectType==ObjectType.HandPump){
                if(InteractionInventoryHandler.EquippedItemName=="EmptyWaterBucket"){
                    HandpumpelementsHandler.PlaceBucket();
                }
                if(BucketQuestHandler.isBucketPlaced && InteractionInventoryHandler.EquippedItemName!="EmptyWaterBucket"){
                    BucketQuestHandler.FillBucket();
                }
            }
        }

        public void DropObject()
        {
            InteractionInventoryHandler.itemEquipped = false;
            InteractionInventoryHandler.EquippedItemName = null;
            isthisItemEquipped = false;
            SlotFull = false;

            Equippeditem.SetParent(null);
            rigidbody.velocity = player.GetComponent<Rigidbody>().velocity;

            rigidbody.AddForce(ItemSlot.forward * dropForwardForce, ForceMode.Impulse);
            rigidbody.AddForce(ItemSlot.up * dropUpwardForce, ForceMode.Impulse);

            float random = Random.Range(-1f, 1f);
            rigidbody.AddTorque(new Vector3(random, random, random) * 10);


            InteractionInventoryHandler.EquippedItemName = null;
        }
        public void DestroyObject()
        {
            ItemInChildrenOfItemSlot = ItemSlot.GetChild(0).gameObject;
            InteractionInventoryHandler.itemEquipped = false;
            InteractionInventoryHandler.EquippedItemName = null;
            isthisItemEquipped = false;
            SlotFull = false;

            Destroy(ItemInChildrenOfItemSlot);
            InteractionInventoryHandler.EquippedItemName = null;
        }

        public void PlaceBucket(){
            ItemInChildrenOfItemSlot = ItemSlot.GetChild(0).gameObject;
            InteractionInventoryHandler.EquippedItemName=null;
            InteractionInventoryHandler.itemEquipped=false;
            BucketQuestHandler.isthisItemEquipped=false;
            SlotFull=false;
            ItemInChildrenOfItemSlot.transform.SetParent(null);
            ItemInChildrenOfItemSlot.transform.position=BucketPosition;
            ItemInChildrenOfItemSlot.transform.rotation=BucketRotation;
            ItemInChildrenOfItemSlot.transform.localScale=BucketScale;
            BucketQuestHandler.isBucketPlaced=true;
            BucketQuestHandler.StartCoroutine(Wait());
        }

        public void ChangeBucketStats()
        {
            ItemInChildrenOfItemSlot = ItemSlot.GetChild(0).gameObject;
            BucketQuestHandler=ItemInChildrenOfItemSlot.GetComponent<AllElementsQueastHandler>();
            if (BucketQuestHandler.pickUpItem == PickUpItem.FullWaterBucket && isBucketInteractable)
            {
                InteractionInventoryHandler.EquippedItemName = "EmptyWaterBucket";
                BucketQuestHandler.FilledWater.SetActive(false);
                BucketQuestHandler.pickUpItem=PickUpItem.EmptyWaterBucket;
                Debug.Log("1");
                StartCoroutine(Wait());
                return;
            }
            if (BucketQuestHandler.pickUpItem == PickUpItem.EmptyWaterBucket && isBucketInteractable)
            {
                InteractionInventoryHandler.EquippedItemName = "FullWaterBucket";
                BucketQuestHandler.FilledWater.SetActive(true);
                BucketQuestHandler.pickUpItem=PickUpItem.FullWaterBucket;
                Debug.Log("2");
                StartCoroutine(Wait());
                return;
            }
        }
        public void FillBucket(){
            if(BucketQuestHandler.pickUpItem==PickUpItem.EmptyWaterBucket){
                BucketQuestHandler.FilledWater.SetActive(true);
                BucketQuestHandler.pickUpItem=PickUpItem.FullWaterBucket;
                StartCoroutine(Wait());
            }
        }
        private IEnumerator Wait()
        {
            isBucketInteractable = false;
            BucketQuestHandler.isBucketPlaced=false;
            yield return new WaitForSeconds(WaitForBucketTime);
            isBucketInteractable = true;
            BucketQuestHandler.isBucketPlaced=true;
        }
        private IEnumerator ShowUI(string txt)
        {
            uiText.text = txt;
            yield return new WaitForSeconds(uiTime);
            uiText.text = null;
        }
    }
}

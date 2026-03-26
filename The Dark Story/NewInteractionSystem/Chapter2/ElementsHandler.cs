using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityHFSM;

namespace Interactions
{
    public class ElementsHandler : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ElementQuest elementQuest;
        [SerializeField] private GameObject River;
        [SerializeField] private GameObject Heart;
        [SerializeField] private GameObject Landscape;
        [SerializeField] private GameObject Tree;
        [SerializeField] private GameObject Jar1Water;
        [SerializeField] private GameObject Jar2Water;
        [SerializeField] private GameObject Jar3Water;
        [SerializeField] private GameObject Jar4Water;
        [SerializeField] private GameObject Jar5Water;
        [SerializeField] private GameObject Jar6Water;
        [SerializeField] private GameObject Torch1;
        [SerializeField] private GameObject Torch2;
        [SerializeField] private GameObject Torch1Lights;
        [SerializeField] private GameObject Torch2Lights;
        [SerializeField] private GameObject Torch1ParticlesSystem;
        [SerializeField] private GameObject Torch2ParticlesSystem;
        [SerializeField] private GameObject Cog1;
        [SerializeField] private GameObject Cog2;
        [SerializeField] private GameObject Venus;
        [SerializeField] private GameObject Mars;
        [SerializeField] private GameObject Mercury;
        [SerializeField] private GameObject Earth;
        [SerializeField] private AllElementsQueastHandler allElementsQueastHandler;
        [SerializeField] private int WaitTime=1;
        [SerializeField] private bool interactable;
        [SerializeField] public TMP_Text uiText;
        [SerializeField] private int uiTime = 3;


        [Header("EarthElementQuest")]
        [SerializeField] public static bool isEarthQuestCompleted = false;
        [SerializeField] public static bool isLandscapePlaced = false;
        [SerializeField] public static bool isRiverPlaced = false;
        [SerializeField] public static bool isHeartPlaced = false;
        [SerializeField] public static bool isTreePlaced = false;

        [Header("WaterElementQuest")]
        [SerializeField] public static bool isWaterQuestCompleted = false;
        [SerializeField] public static bool isJar1IsFull = false;
        [SerializeField] public static bool isJar2IsFull = false;
        [SerializeField] public static bool isJar3IsFull = false;
        [SerializeField] public static bool isJar4IsFull = false;
        [SerializeField] public static bool isJar5IsFull = false;
        [SerializeField] public static bool isJar6IsFull = false;
        [SerializeField] public static int FullJars=0;

        [Header("FireElementQuest")]
        [SerializeField] public static bool isFireQuestCompleted = false;
        [SerializeField] public static bool isTorch1Placed = false;
        [SerializeField] public static bool isTorch2Placed = false;
        [SerializeField] public static bool isToch1Lit = false;
        [SerializeField] public static bool isToch2Lit = false;

        [Header("WindElementQuest")]
        [SerializeField] public static bool isWindQuestCompleted = false;
        [SerializeField] public static bool isCog1Placed = false;
        [SerializeField] public static bool isCog2Placed = false;
        [SerializeField] public static bool isCogsAreWorking = false;

        [Header("SpaceElementQuest")]
        [SerializeField] public static bool isSpaceQuestCompleted = false;
        [SerializeField] public static bool isMercuryPlaced = false;
        [SerializeField] public static bool isEarthPlaced = false;
        [SerializeField] public static bool isMarsPlaced = false;
        [SerializeField] public static bool isVenusPlaced = false;

        private enum ElementQuest
        {
            EarthQuest,
            FireQuest,
            WaterQuest,
            WindQuest,
            SpaceQuest,
        }
        void Start()
        {
            isWindQuestCompleted = false;

            isCog1Placed = false;

            isCog2Placed = false;
            isCogsAreWorking=false;

            isSpaceQuestCompleted = false;
            isMercuryPlaced = false;

            isEarthPlaced = false;

            isMarsPlaced = false;

            isVenusPlaced = false;

            isWaterQuestCompleted = false;
            isJar1IsFull = false;

            isJar2IsFull = false;
            isJar3IsFull = false;
            isJar4IsFull = false;
            isJar5IsFull = false;
            isJar6IsFull = false;
            FullJars=0;
            interactable=true;
            WaitTime=1;


            isFireQuestCompleted = false;

            isTorch1Placed = false;

            isTorch2Placed = false;

            isToch1Lit = false;
            isToch2Lit = false;
            isEarthQuestCompleted = false;
            isLandscapePlaced = false;

            isRiverPlaced = false;

            isHeartPlaced = false;

            isTreePlaced = false;

        }

        // Update is called once per frame
        public void Update()
        {
            if(isHeartPlaced && isRiverPlaced && isLandscapePlaced && isTreePlaced){
                isEarthQuestCompleted=true;
            }
            if(isTorch1Placed && isTorch2Placed && isToch1Lit && isToch2Lit){
                isFireQuestCompleted=true;
            }
            if(isCog1Placed && isCog2Placed && isCogsAreWorking){
                isWindQuestCompleted=true;
            }
            if(isJar1IsFull && isJar2IsFull && isJar3IsFull && isJar4IsFull && isJar5IsFull && isJar6IsFull){
                isWaterQuestCompleted=true;
            }
            if(isMarsPlaced && isMercuryPlaced && isEarthPlaced && isVenusPlaced){
                isSpaceQuestCompleted=true;
            }
        }

        public void Place()
        {
            if (elementQuest == ElementQuest.EarthQuest)
            {
                if (InteractionInventoryHandler.EquippedItemName == "Heart")
                {
                    isHeartPlaced = true;
                    Heart.SetActive(true);
                    allElementsQueastHandler.DestroyObject();
                }
                if (InteractionInventoryHandler.EquippedItemName == "River")
                {
                    isRiverPlaced = true;
                    River.SetActive(true);
                    allElementsQueastHandler.DestroyObject();
                }
                if (InteractionInventoryHandler.EquippedItemName == "Landscape")
                {
                    isLandscapePlaced = true;
                    Landscape.SetActive(true);
                    allElementsQueastHandler.DestroyObject();
                }
                if (InteractionInventoryHandler.EquippedItemName == "Tree")
                {
                    isTreePlaced = true;
                    Tree.SetActive(true);
                    allElementsQueastHandler.DestroyObject();
                }
                else if(InteractionInventoryHandler.EquippedItemName != null && InteractionInventoryHandler.EquippedItemName != "Tree" && InteractionInventoryHandler.EquippedItemName != "Landscape" && InteractionInventoryHandler.EquippedItemName != "River" && InteractionInventoryHandler.EquippedItemName != "Heart")
                {
                    StartCoroutine(ShowUI("You cant use it here!"));
                }
            }
            if(elementQuest==ElementQuest.FireQuest){
                if(InteractionInventoryHandler.EquippedItemName == "Torch1"){
                    Torch1.SetActive(true);
                    isTorch1Placed=true;
                    allElementsQueastHandler.DestroyObject();
                }
                if(InteractionInventoryHandler.EquippedItemName == "Torch2"){
                    Torch2.SetActive(true);
                    isTorch2Placed=true;
                    allElementsQueastHandler.DestroyObject();
                }
                if (InteractionInventoryHandler.EquippedItemName == "Matchbox")
                {
                    StartCoroutine(ShowUI("Use It On Torches To Light them Up."));
                }
                else if(InteractionInventoryHandler.EquippedItemName != "Matchbox" && InteractionInventoryHandler.EquippedItemName != "Torch2"&& InteractionInventoryHandler.EquippedItemName != "Torch1"&& InteractionInventoryHandler.EquippedItemName != null)
                {
                    StartCoroutine(ShowUI("You cant use it here!"));
                }
            }
            if(elementQuest==ElementQuest.SpaceQuest){
                if(InteractionInventoryHandler.EquippedItemName=="Mars"){
                    Mars.SetActive(true);
                    isMarsPlaced=true;
                    allElementsQueastHandler.DestroyObject();
                }
                if(InteractionInventoryHandler.EquippedItemName=="Earth"){
                    Earth.SetActive(true);
                    isEarthPlaced=true;
                    allElementsQueastHandler.DestroyObject();
                }
                if(InteractionInventoryHandler.EquippedItemName=="Venus"){
                    Venus.SetActive(true);
                    isVenusPlaced=true;
                    allElementsQueastHandler.DestroyObject();
                }
                if(InteractionInventoryHandler.EquippedItemName=="Mercury"){
                    Mercury.SetActive(true);
                    isMercuryPlaced=true;
                    allElementsQueastHandler.DestroyObject();
                }
                else if(InteractionInventoryHandler.EquippedItemName != "Mars"&& InteractionInventoryHandler.EquippedItemName != "Earth"&& InteractionInventoryHandler.EquippedItemName != "Venus"&& InteractionInventoryHandler.EquippedItemName != "Mercury"&& InteractionInventoryHandler.EquippedItemName != null)
                {
                    StartCoroutine(ShowUI("You cant use it here!"));
                }
            }
            if(elementQuest==ElementQuest.WindQuest){
                if(InteractionInventoryHandler.EquippedItemName=="Cog1"){
                    Cog1.SetActive(true);
                    isCog1Placed=true;
                    allElementsQueastHandler.DestroyObject();
                }
                if(InteractionInventoryHandler.EquippedItemName=="Cog2"){
                    Cog2.SetActive(true);
                    isCog2Placed=true;
                    allElementsQueastHandler.DestroyObject();
                }
                else
                {
                    StartCoroutine(ShowUI("You cant use it here!"));
                }
            }
        }

        public void StartCogs(){
            if(isCog1Placed && isCog2Placed){
                //
                isCogsAreWorking=true;
            }
            else{
                Debug.Log("It's Not Working");
            }
        }

        public void FillJars(){
            if(InteractionInventoryHandler.EquippedItemName=="FullWaterBucket" && interactable){
                if(FullJars==0){
                    isJar1IsFull=true;
                    Jar1Water.SetActive(true);
                    allElementsQueastHandler.ChangeBucketStats();
                    FullJars=1;
                    StartCoroutine(WaitForSecond());
                    return;
                }
                if(FullJars==1){
                    isJar2IsFull=true;
                    Jar2Water.SetActive(true);
                    allElementsQueastHandler.ChangeBucketStats();
                    FullJars=2;
                    StartCoroutine(WaitForSecond());
                    return;
                }
                if(FullJars==2){
                    isJar3IsFull=true;
                    Jar3Water.SetActive(true);
                    allElementsQueastHandler.ChangeBucketStats();
                    FullJars=3;
                    StartCoroutine(WaitForSecond());
                    return;
                }
                if(FullJars==3){
                    isJar4IsFull=true;
                    Jar4Water.SetActive(true);
                    allElementsQueastHandler.ChangeBucketStats();
                    FullJars=4;
                    StartCoroutine(WaitForSecond());
                    return;
                }
                if(FullJars==4){
                    isJar5IsFull=true;
                    Jar5Water.SetActive(true);
                    allElementsQueastHandler.ChangeBucketStats();
                    FullJars=5;
                    StartCoroutine(WaitForSecond());
                    return;
                }
                if(FullJars==5){
                    isJar6IsFull=true;
                    Jar6Water.SetActive(true);
                    allElementsQueastHandler.ChangeBucketStats();
                    FullJars=6;
                    StartCoroutine(WaitForSecond());
                    return;
                }
            }
            else if (InteractionInventoryHandler.EquippedItemName == "EmptyWaterBucket" && interactable)
            {
                StartCoroutine(ShowUI("Bucket Is Empty!!!"));
            }
            else
            {
                StartCoroutine(ShowUI("You cant use it here!"));
            }
        }

        public void LightUpTorch1(){
            if(InteractionInventoryHandler.EquippedItemName=="Matchbox"){
                Torch1Lights.SetActive(true);
                Torch1ParticlesSystem.SetActive(true);
                isToch1Lit=true;
            }
        }
        public void LightUpTorch2(){
            if(InteractionInventoryHandler.EquippedItemName=="Matchbox"){
                Torch2Lights.SetActive(true);
                Torch2ParticlesSystem.SetActive(true);
                isToch2Lit=true;
            }
        }

        private IEnumerator WaitForSecond(){
            interactable=false;
            yield return new WaitForSeconds(WaitTime);
            interactable=true;
        }
        private IEnumerator ShowUI(string txt)
        {
            uiText.text = txt;
            yield return new WaitForSeconds(uiTime);
            uiText.text = null;
        }
    }
}

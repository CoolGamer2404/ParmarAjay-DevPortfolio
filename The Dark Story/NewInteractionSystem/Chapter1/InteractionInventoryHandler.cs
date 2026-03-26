using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions
{
    public class InteractionInventoryHandler : MonoBehaviour
    {

        public static string EquippedItemName;
        [SerializeField]public string name;
        [SerializeField]public bool isItem;

        public static bool itemEquipped;

        public Vector3 ItemPosition;
        public Vector3 ItemScale;
        public Quaternion ItemRotation;

        public static GameObject EquippedItem;

        public static bool isItemEquipped;
        public static string ItemName;

        [Header("Objects Rotation")]
        [SerializeField]private Vector3 CrawbarPosition;
        [SerializeField]private Vector3 CrawbarScale;
        [SerializeField]private Vector3 CrawbarRotation;
        [SerializeField]private Vector3 CutterPosition;
        [SerializeField]private Vector3 CutterScale;
        [SerializeField]private Vector3 CutterRotation;
        [SerializeField]private Vector3 PlankPosition;
        [SerializeField]private Vector3 PlankScale;
        [SerializeField]private Vector3 PlankRotation;
        [SerializeField]private Vector3 MainDoorKeyPosition;
        [SerializeField]private Vector3 MainDoorKeyScale;
        [SerializeField]private Vector3 MainDoorKeyRotation;
        [SerializeField]private Vector3 MainGateKeyPosition;
        [SerializeField]private Vector3 MainGateKeyScale;
        [SerializeField]private Vector3 MainGateKeyRotation;
        [SerializeField]private Vector3 LockerPosition;
        [SerializeField]private Vector3 LockerScale;
        [SerializeField]private Vector3 LockerRotation;
        [SerializeField]private Vector3 CabinetPosition;
        [SerializeField]private Vector3 CabinetScale;
        [SerializeField]private Vector3 CabinetRotation;
        [SerializeField]private Vector3 DamiensRoomKeyPosition;
        [SerializeField]private Vector3 DamiensRoomKeyScale;
        [SerializeField]private Vector3 DamiensRoomKeyRotation;
        [SerializeField] private Vector3 GuestRoom1KeyPosition;
        [SerializeField] private Vector3 GuestRoom1KeyScale;
        [SerializeField] private Vector3 GuestRoom1KeyRotation;
        [SerializeField] private Vector3 GuestRoom2KeyPosition;
        [SerializeField] private Vector3 GuestRoom2KeyScale;
        [SerializeField] private Vector3 GuestRoom2KeyRotation;
        [SerializeField]private Vector3 LibraryRoomKeyPosition;
        [SerializeField]private Vector3 LibraryRoomKeyScale;
        [SerializeField]private Vector3 LibraryRoomKeyRotation;
        [SerializeField]private Vector3 SpecialRoomKeyPosition;
        [SerializeField]private Vector3 SpecialRoomKeyScale;
        [SerializeField]private Vector3 SpecialRoomKeyRotation;
        [SerializeField]private Vector3 BasementKeyPosition;
        [SerializeField]private Vector3 BasementKeyScale;
        [SerializeField]private Vector3 BasementKeyRotation;

        [SerializeField]private Vector3 HeartPosition;
        [SerializeField]private Vector3 HeartScale;
        [SerializeField]private Vector3 HeartRotation;
        [SerializeField]private Vector3 LandscapePosition;
        [SerializeField]private Vector3 LandscapeScale;
        [SerializeField]private Vector3 LandscapeRotation;
        [SerializeField]private Vector3 RiverPosition;
        [SerializeField]private Vector3 RiverScale;
        [SerializeField]private Vector3 RiverRotation;
        [SerializeField]private Vector3 TreePosition;
        [SerializeField]private Vector3 TreeScale;
        [SerializeField]private Vector3 TreeRotation;
        [SerializeField]private Vector3 EmptyWaterBucketPosition;
        [SerializeField]private Vector3 EmptyWaterBucketScale;
        [SerializeField]private Vector3 EmptyWaterBucketRotation;
        [SerializeField]private Vector3 FullWaterBucketPosition;
        [SerializeField]private Vector3 FullWaterBucketScale;
        [SerializeField]private Vector3 FullWaterBucketRotation;
        [SerializeField]private Vector3 MarsPosition;
        [SerializeField]private Vector3 MarsScale;
        [SerializeField]private Vector3 MarsRotation;
        [SerializeField]private Vector3 VenusPosition;
        [SerializeField]private Vector3 VenusScale;
        [SerializeField]private Vector3 VenusRotation;
        [SerializeField]private Vector3 MercuryPosition;
        [SerializeField]private Vector3 MercuryScale;
        [SerializeField]private Vector3 MercuryRotation;
        [SerializeField]private Vector3 EarthPosition;
        [SerializeField]private Vector3 EarthScale;
        [SerializeField]private Vector3 EarthRotation;
        [SerializeField]private Vector3 Torch2Scale;
        [SerializeField]private Vector3 Torch1Position;
        [SerializeField]private Vector3 Torch1Rotation;
        [SerializeField]private Vector3 Torch1Scale;
        [SerializeField]private Vector3 Torch2Position;
        [SerializeField]private Vector3 Torch2Rotation;
        [SerializeField]private Vector3 MatchboxPosition;
        [SerializeField]private Vector3 MatchboxScale;
        [SerializeField]private Vector3 MatchboxRotation;
        [SerializeField]private Vector3 EarthElementJarPosition;
        [SerializeField]private Vector3 EarthElementJarScale;
        [SerializeField]private Vector3 EarthElementJarRotation;
        [SerializeField]private Vector3 SpaceElementJarPosition;
        [SerializeField]private Vector3 SpaceElementJarScale;
        [SerializeField]private Vector3 SpaceElementJarRotation;
        [SerializeField]private Vector3 FireElementJarPosition;
        [SerializeField]private Vector3 FireElementJarScale;
        [SerializeField]private Vector3 FireElementJarRotation;
        [SerializeField]private Vector3 WaterElementJarPosition;
        [SerializeField]private Vector3 WaterElementJarScale;
        [SerializeField]private Vector3 WaterElementJarRotation;
        [SerializeField]private Vector3 WindElementJarPosition;
        [SerializeField]private Vector3 WindElementJarScale;
        [SerializeField]private Vector3 WindElementJarRotation;




        [SerializeField]private Vector3 tabletScale;
        [SerializeField]private Vector3 tabletPosition;
        [SerializeField]private Vector3 tabletRotation;
        [SerializeField]private Vector3 brokenTabletScale;
        [SerializeField]private Vector3 brokenTabletPosition;
        [SerializeField]private Vector3 brokenTabletRotation;

        [SerializeField]private Vector3 redCardScale;
        [SerializeField]private Vector3 redCardPosition;
        [SerializeField]private Vector3 redCardRotation;
        [SerializeField]private Vector3 blueCardScale;
        [SerializeField]private Vector3 blueCardPosition;
        [SerializeField]private Vector3 blueCardRotation;
        [SerializeField]private Vector3 greenCardScale;
        [SerializeField]private Vector3 greenCardPosition;
        [SerializeField]private Vector3 greenCardRotation;
        [SerializeField]private Vector3 orangeCardScale;
        [SerializeField]private Vector3 orangeCardPosition;
        [SerializeField]private Vector3 orangeCardRotation;
        [SerializeField]private Vector3 purpleCardScale;
        [SerializeField]private Vector3 purpleCardPosition;
        [SerializeField]private Vector3 purpleCardRotation;
        [SerializeField]private Vector3 pinkCardScale;
        [SerializeField]private Vector3 pinkCardPosition;
        [SerializeField]private Vector3 pinkCardRotation;
        public GameObject gameObject;


        public void Start(){
            itemEquipped=false;
            isItemEquipped=false;
            EquippedItemName=null;
        }

        public void Update(){
            name=EquippedItemName;
            isItem=itemEquipped;
            gameObject=EquippedItem;
            if(EquippedItemName!=null){
                itemEquipped=true;
            }
            if(itemEquipped && EquippedItemName=="Crawbar"){
                EquippedItem.transform.localScale=CrawbarScale;
                EquippedItem.transform.localPosition=CrawbarPosition;
                EquippedItem.transform.eulerAngles=CrawbarRotation;
            }
            if(itemEquipped && EquippedItemName=="Cutter"){
                EquippedItem.transform.localScale=CutterScale;
                EquippedItem.transform.localPosition=CutterPosition;
                EquippedItem.transform.eulerAngles=CutterRotation;
            }
            if(itemEquipped && EquippedItemName=="Plank"){
                EquippedItem.transform.localScale=PlankScale;
                EquippedItem.transform.localPosition=PlankPosition;
                EquippedItem.transform.eulerAngles=PlankRotation;
            }
            if(itemEquipped && EquippedItemName=="MainDoorKey"){
                EquippedItem.transform.localScale=MainDoorKeyScale;
                EquippedItem.transform.localPosition=MainDoorKeyPosition;
                EquippedItem.transform.eulerAngles=MainDoorKeyRotation;
            }
            if(itemEquipped && EquippedItemName=="MainGateKey"){
                EquippedItem.transform.localScale=MainGateKeyScale;
                EquippedItem.transform.localPosition=MainGateKeyPosition;
                EquippedItem.transform.eulerAngles=MainGateKeyRotation;
            }
            if(itemEquipped && EquippedItemName=="CabinetKeys"){
                EquippedItem.transform.localScale=CabinetScale;
                EquippedItem.transform.localPosition=CabinetPosition;
                EquippedItem.transform.eulerAngles=CabinetRotation;
            }
            if(itemEquipped && EquippedItemName=="LockerKeys"){
                EquippedItem.transform.localScale=LockerScale;
                EquippedItem.transform.localPosition=LockerPosition;
                EquippedItem.transform.eulerAngles=LockerRotation;
            }
            if(itemEquipped && EquippedItemName=="DamiensRoomKey"){
                EquippedItem.transform.localScale= DamiensRoomKeyScale;
                EquippedItem.transform.localPosition= DamiensRoomKeyPosition;
                EquippedItem.transform.eulerAngles= DamiensRoomKeyRotation;
            }
            if (itemEquipped && EquippedItemName == "GuestRoom1Key")
            {
                EquippedItem.transform.localScale = GuestRoom1KeyScale;
                EquippedItem.transform.localPosition = GuestRoom1KeyPosition;
                EquippedItem.transform.eulerAngles = GuestRoom1KeyRotation;
            }
            if (itemEquipped && EquippedItemName == "GuestRoom2Key")
            {
                EquippedItem.transform.localScale = GuestRoom2KeyScale;
                EquippedItem.transform.localPosition = GuestRoom2KeyPosition;
                EquippedItem.transform.eulerAngles = GuestRoom2KeyRotation;
            }
            if (itemEquipped && EquippedItemName=="LibraryRoomKey"){
                EquippedItem.transform.localScale=LibraryRoomKeyScale;
                EquippedItem.transform.localPosition=LibraryRoomKeyPosition;
                EquippedItem.transform.eulerAngles=LibraryRoomKeyRotation;
            }
            if(itemEquipped && EquippedItemName=="SpecialRoomKey"){
                EquippedItem.transform.localScale=SpecialRoomKeyScale;
                EquippedItem.transform.localPosition=SpecialRoomKeyPosition;
                EquippedItem.transform.eulerAngles=SpecialRoomKeyRotation;
            }
            if(itemEquipped && EquippedItemName=="BasementKey"){
                EquippedItem.transform.localScale=BasementKeyScale;
                EquippedItem.transform.localPosition=BasementKeyPosition;
                EquippedItem.transform.eulerAngles=BasementKeyRotation;
            }

            //All Quest Items Of Chapter2
            if(itemEquipped && EquippedItemName=="Heart"){
                EquippedItem.transform.localScale=HeartScale;
                EquippedItem.transform.localPosition=HeartPosition;
                EquippedItem.transform.eulerAngles=HeartRotation;
            }
            if(itemEquipped && EquippedItemName=="Landscape"){
                EquippedItem.transform.localScale=LandscapeScale;
                EquippedItem.transform.localPosition=LandscapePosition;
                EquippedItem.transform.eulerAngles=LandscapeRotation;
            }
            if(itemEquipped && EquippedItemName=="River"){
                EquippedItem.transform.localScale=RiverScale;
                EquippedItem.transform.localPosition=RiverPosition;
                EquippedItem.transform.eulerAngles=RiverRotation;
            }
            if(itemEquipped && EquippedItemName=="Tree"){
                EquippedItem.transform.localScale=TreeScale;
                EquippedItem.transform.localPosition=TreePosition;
                EquippedItem.transform.eulerAngles=TreeRotation;
            }
            /*if(itemEquipped && EquippedItemName=="Cog1"){
            }
            if(itemEquipped && EquippedItemName=="Cog2"){
            }*/
            if(itemEquipped && EquippedItemName=="EmptyWaterBucket"){
                EquippedItem.transform.localScale=EmptyWaterBucketScale;
                EquippedItem.transform.localPosition=EmptyWaterBucketPosition;
                EquippedItem.transform.eulerAngles=EmptyWaterBucketRotation;
            }
            if(itemEquipped && EquippedItemName=="FullWaterBucket"){
                EquippedItem.transform.localScale=FullWaterBucketScale;
                EquippedItem.transform.localPosition=FullWaterBucketPosition;
                EquippedItem.transform.eulerAngles=FullWaterBucketRotation;
            }
            if(itemEquipped && EquippedItemName=="Mars"){
                EquippedItem.transform.localScale=MarsScale;
                EquippedItem.transform.localPosition=MarsPosition;
                EquippedItem.transform.eulerAngles=MarsRotation;
            }
            if(itemEquipped && EquippedItemName=="Venus"){
                EquippedItem.transform.localScale=VenusScale;
                EquippedItem.transform.localPosition=VenusPosition;
                EquippedItem.transform.eulerAngles=VenusRotation;
            }
            if(itemEquipped && EquippedItemName=="Mercury"){
                EquippedItem.transform.localScale=MercuryScale;
                EquippedItem.transform.localPosition=MercuryPosition;
                EquippedItem.transform.eulerAngles=MercuryRotation;
            }
            if(itemEquipped && EquippedItemName=="Earth"){
                EquippedItem.transform.localScale=EarthScale;
                EquippedItem.transform.localPosition=EarthPosition;
                EquippedItem.transform.eulerAngles=EarthRotation;
            }
            if(itemEquipped && EquippedItemName=="Torch1"){
                EquippedItem.transform.localScale=Torch1Scale;
                EquippedItem.transform.localPosition=Torch1Position;
                EquippedItem.transform.eulerAngles=Torch1Rotation;
            }
            if(itemEquipped && EquippedItemName=="Torch2"){
                EquippedItem.transform.localScale=Torch2Scale;
                EquippedItem.transform.localPosition=Torch2Position;
                EquippedItem.transform.eulerAngles=Torch2Rotation;
            }
            if(itemEquipped && EquippedItemName=="Matchbox"){
                EquippedItem.transform.localScale=MatchboxScale;
                EquippedItem.transform.localPosition=MatchboxPosition;
                EquippedItem.transform.eulerAngles=MatchboxRotation;
            }
            if(itemEquipped && EquippedItemName=="EarthElementJar"){
                EquippedItem.transform.localScale=EarthElementJarScale;
                EquippedItem.transform.localPosition=EarthElementJarPosition;
                EquippedItem.transform.eulerAngles=EarthElementJarRotation;
            }
            if(itemEquipped && EquippedItemName=="FireElementJar"){
                EquippedItem.transform.localScale=FireElementJarScale;
                EquippedItem.transform.localPosition=FireElementJarPosition;
                EquippedItem.transform.eulerAngles=FireElementJarRotation;
            }
            if(itemEquipped && EquippedItemName=="WindElementJar"){
                EquippedItem.transform.localScale=WindElementJarScale;
                EquippedItem.transform.localPosition=WindElementJarPosition;
                EquippedItem.transform.eulerAngles=WindElementJarRotation;
            }
            if(itemEquipped && EquippedItemName=="SpaceElementJar"){
                EquippedItem.transform.localScale=SpaceElementJarScale;
                EquippedItem.transform.localPosition=SpaceElementJarPosition;
                EquippedItem.transform.eulerAngles=SpaceElementJarRotation;
            }
            if(itemEquipped && EquippedItemName=="WaterElementJar"){
                EquippedItem.transform.localScale=WaterElementJarScale;
                EquippedItem.transform.localPosition=WaterElementJarPosition;
                EquippedItem.transform.eulerAngles=WaterElementJarRotation;
            }
            

        /*    //For Chapter 5
            if(itemEquipped && EquippedItemName=="RedCard"){
                EquippedItem.transform.localScale=redCardScale;
                EquippedItem.transform.localPosition=redCardPosition;
                EquippedItem.transform.eulerAngles=redCardRotation;
            }
            if(itemEquipped && EquippedItemName=="BlueCard"){
                EquippedItem.transform.localScale=blueCardScale;
                EquippedItem.transform.localPosition=blueCardPosition;
                EquippedItem.transform.eulerAngles=blueCardRotation;
            }
            if(itemEquipped && EquippedItemName=="GreenCard"){
                EquippedItem.transform.localScale=greenCardScale;
                EquippedItem.transform.localPosition=greenCardPosition;
                EquippedItem.transform.eulerAngles=greenCardRotation;
            }
            if(itemEquipped && EquippedItemName=="OrangeCard"){
                EquippedItem.transform.localScale=orangeCardScale;
                EquippedItem.transform.localPosition=orangeCardPosition;
                EquippedItem.transform.eulerAngles=orangeCardRotation;
            }
            if(itemEquipped && EquippedItemName=="PinkCard"){
                EquippedItem.transform.localScale=pinkCardScale;
                EquippedItem.transform.localPosition=pinkCardPosition;
                EquippedItem.transform.eulerAngles=pinkCardRotation;
            }
            if(itemEquipped && EquippedItemName=="PurpleCard"){
                EquippedItem.transform.localScale=purpleCardScale;
                EquippedItem.transform.localPosition=purpleCardPosition;
                EquippedItem.transform.eulerAngles=purpleCardRotation;
            }

            if(itemEquipped&&EquippedItemName=="Tablet"){
                EquippedItem.transform.localScale=tabletScale;
                EquippedItem.transform.localPosition=tabletPosition;
                EquippedItem.transform.eulerAngles=tabletRotation;
            }
            if(itemEquipped&&EquippedItemName=="BrokenTablet"){
                EquippedItem.transform.localScale=brokenTabletScale;
                EquippedItem.transform.localPosition=brokenTabletPosition;
                EquippedItem.transform.eulerAngles=brokenTabletRotation;
            }*/
        }

        /*public void ChangeInteractButtonIcon(string name){
            if(name=="Key"){
                EquippedItemName="Key";
                InteractButton.sprite=keyIcon;
                isItemEquipped=false;
            }
            if(name=="Cutter"){
                EquippedItemName="Cutter";
                InteractButton.sprite=cutterIcon;
                isItemEquipped=false;
            }
            if(name=="Crawbar"){
                EquippedItemName="Crawbar";
                InteractButton.sprite=crawbarIcon;
                isItemEquipped=false;
            }
            else{
                EquippedItemName=null;
                isItemEquipped=false;
            }
        }*/
    }
}


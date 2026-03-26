using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WorkShopSkin : MonoBehaviour
{
    [SerializeField] private DroneSkinWebDataScriptableObject droneSkinWebData;
    [SerializeField] private DroneStatsScriptableObject droneData;
    [SerializeField] private int DroneNumber;
    [SerializeField] private int SkinNumber;
    [SerializeField] private WorkShopSkin[] otherSkins;
    [SerializeField] private GameObject SkinBoarder;
    [SerializeField] private DroneSkinHandler droneSkinHandler;

    [Header("SkinPurchaseButton")]
    [SerializeField] private GameObject DroneSkinPurchaseButton;

    [Header("SkinEquipButton")]
    [SerializeField] private GameObject DroneSkinEquipButton;

    [Header("SkinEquippedButton")]
    [SerializeField] private GameObject DroneSkinEquippedButton;

    [Header("SkinEquipButton")]
    [SerializeField] private GameObject DroneSkinDownloadButton;
    [Header("OtherReferences")]
    [SerializeField] private DownloadedResourcesScriptableObject downloadData;
    [SerializeField] private DownloadedResourcesScriptableObject baseresourcesScriptableObject;

    string name;

    // Start is called before the first frame update
    void Start()
    {
        name=string.Format("Drone{0}Skin{1}Download",droneSkinWebData.droneNum,droneSkinWebData.skinNum);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCaseSkin()
    {
        DisableOtherSkins();////Disable other drone skins buttons and boarder
        EnableMySkin();//Enables Buttons And Boarders Of Current Skin
    }
    public void DownloadSkin()
    {
        StartCoroutine(DownloadAssetBundleFromServer(droneSkinWebData.downloadLink));
    }

    public void PurchaseSkin()
    {
        if (droneData.skinsPrice[SkinNumber] >= PlayerPrefs.GetInt("Coins"))
        {
            Debug.Log("Purchased");
        }
        else if (droneData.skinsPrice[SkinNumber] < PlayerPrefs.GetInt("Coins"))
        {
            Debug.Log("Not Enough Coins");
        }
    }

    private void DisableOtherSkins()
    {
        for (int i = 0; i < otherSkins.Length; i++)
        {
            otherSkins[i].DisableMySkin();
        }
    }

    public void DisableMySkin()
    {
        //Only call this method when other drone is selected while you waqnna disable this skin
        DroneSkinPurchaseButton.SetActive(false);
        DroneSkinEquipButton.SetActive(false);
        DroneSkinEquippedButton.SetActive(false);
        DroneSkinDownloadButton.SetActive(false);
        SkinBoarder.SetActive(false);
        return;
    }

    public void EquipSkin()
    {
        if (DroneNumber == 1)
        {
            PlayerPrefs.SetInt("Drone1CurrentSkin", SkinNumber);
            droneData.EquippedSkinNumber=SkinNumber;
            PlayerPrefs.SetInt("EquippedDrone",DroneNumber);
            UpdateSkin();
            return;
        }
        else if (DroneNumber == 2)
        {
            PlayerPrefs.SetInt("Drone2CurrentSkin", SkinNumber);
            droneData.EquippedSkinNumber=SkinNumber;
            PlayerPrefs.SetInt("EquippedDrone",DroneNumber);
            UpdateSkin();
            return;
        }
        else if (DroneNumber == 3)
        {
            PlayerPrefs.SetInt("Drone3CurrentSkin", SkinNumber);
            droneData.EquippedSkinNumber=SkinNumber;
            PlayerPrefs.SetInt("EquippedDrone",DroneNumber);
            UpdateSkin();
            return;
        }
        else if (DroneNumber == 4)
        {
            PlayerPrefs.SetInt("Drone4CurrentSkin", SkinNumber);
            droneData.EquippedSkinNumber=SkinNumber;
            PlayerPrefs.SetInt("EquippedDrone",DroneNumber);
            UpdateSkin();
            return;
        }
        else if (DroneNumber == 5)
        {
            PlayerPrefs.SetInt("Drone5CurrentSkin", SkinNumber);
            droneData.EquippedSkinNumber=SkinNumber;
            PlayerPrefs.SetInt("EquippedDrone",DroneNumber);
            UpdateSkin();
            return;
        }
    }

    private void EnableMySkin()
    {
        //Enables Buttons And Boarders Of Current Skin
        SkinBoarder.SetActive(true);
        if (PlayerPrefs.GetInt(name)==1 || SkinNumber==0)/////////this will run if skin is downloaded
        {
            DroneSkinDownloadButton.SetActive(false);
            droneSkinHandler.ShowDemoSkin(SkinNumber);
            if (droneData.isSkinsPurchased[SkinNumber])/////////this will run if skin is purchased
            {
                DroneSkinPurchaseButton.SetActive(false);
                if (DroneNumber == 1)////if current drone number is 1
                {
                    if (PlayerPrefs.GetInt("Drone1CurrentSkin") == SkinNumber)///if skin number of player prefs is same as this
                    {
                        DroneSkinEquippedButton.SetActive(true);
                        DroneSkinEquipButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(SkinNumber);
                    }
                    else if (PlayerPrefs.GetInt("Drone1CurrentSkin") != SkinNumber)///if skin number of player prefs is not same as this
                    {
                        DroneSkinEquipButton.SetActive(true);
                        DroneSkinEquippedButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(SkinNumber);
                    }
                }
                else if (DroneNumber == 2)
                {
                    if (PlayerPrefs.GetInt("Drone2CurrentSkin") == SkinNumber)
                    {
                        DroneSkinEquippedButton.SetActive(true);
                        DroneSkinEquipButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(SkinNumber);
                    }
                    else if (PlayerPrefs.GetInt("Drone2CurrentSkin") != SkinNumber)
                    {
                        DroneSkinEquipButton.SetActive(true);
                        DroneSkinEquippedButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(SkinNumber);
                    }
                }
                else if (DroneNumber == 3)
                {
                    if (PlayerPrefs.GetInt("Drone3CurrentSkin") == SkinNumber)
                    {
                        DroneSkinEquippedButton.SetActive(true);
                        DroneSkinEquipButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(SkinNumber);
                    }
                    else if (PlayerPrefs.GetInt("Drone3CurrentSkin") != SkinNumber)
                    {
                        DroneSkinEquipButton.SetActive(true);
                        DroneSkinEquippedButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(SkinNumber);
                    }
                }
                else if (DroneNumber == 4)
                {
                    if (PlayerPrefs.GetInt("Drone4CurrentSkin") == SkinNumber)
                    {
                        DroneSkinEquippedButton.SetActive(true);
                        DroneSkinEquipButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(SkinNumber);
                    }
                    else if (PlayerPrefs.GetInt("Drone4CurrentSkin") != SkinNumber)
                    {
                        DroneSkinEquipButton.SetActive(true);
                        DroneSkinEquippedButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(SkinNumber);
                    }
                }
                else if (DroneNumber == 5)
                {
                    if (PlayerPrefs.GetInt("Drone5CurrentSkin") == SkinNumber)
                    {
                        DroneSkinEquippedButton.SetActive(true);
                        DroneSkinEquipButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(SkinNumber);
                    }
                    else if (PlayerPrefs.GetInt("Drone5CurrentSkin") != SkinNumber)
                    {
                        DroneSkinEquipButton.SetActive(true);
                        DroneSkinEquippedButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(SkinNumber);
                    }
                }
            }
            else if (droneData.isSkinsPurchased[SkinNumber] == false && droneData.isSkinsPurchasable[SkinNumber])
            {
                DroneSkinPurchaseButton.SetActive(true);
                droneSkinHandler.ShowDemoSkin(SkinNumber);
            }
            else if (droneData.isSkinsPurchased[SkinNumber] == false && droneData.isSkinsPurchasable[SkinNumber] == false)
            {
                DroneSkinPurchaseButton.SetActive(false);
                droneSkinHandler.ShowDemoSkin(SkinNumber);
            }
        }
        else if (PlayerPrefs.GetInt(name)!=1 && SkinNumber!=0)/////////this will run if skin is not downloaded
        {
            DroneSkinDownloadButton.SetActive(true);
            if (droneData.isSkinsPurchased[SkinNumber])/////////this will run if skin is purchased
            {
                DroneSkinPurchaseButton.SetActive(false);
                if (DroneNumber == 1)
                {
                    if (PlayerPrefs.GetInt("Drone1CurrentSkin") == SkinNumber)
                    {
                        DroneSkinEquippedButton.SetActive(true);
                        //DroneSkinEquipButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(0);
                    }
                    else if (PlayerPrefs.GetInt("Drone1CurrentSkin") != SkinNumber)
                    {
                        //DroneSkinEquipButton.SetActive(true);
                        DroneSkinEquippedButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(0);
                    }
                }
                else if (DroneNumber == 2)
                {
                    if (PlayerPrefs.GetInt("Drone2CurrentSkin") == SkinNumber)
                    {
                        DroneSkinEquippedButton.SetActive(true);
                        //DroneSkinEquipButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(0);
                    }
                    else if (PlayerPrefs.GetInt("Drone2CurrentSkin") != SkinNumber)
                    {
                        //DroneSkinEquipButton.SetActive(true);
                        DroneSkinEquippedButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(0);
                    }
                }
                else if (DroneNumber == 3)
                {
                    if (PlayerPrefs.GetInt("Drone3CurrentSkin") == SkinNumber)
                    {
                        DroneSkinEquippedButton.SetActive(true);
                        //DroneSkinEquipButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(0);
                    }
                    else if (PlayerPrefs.GetInt("Drone3CurrentSkin") != SkinNumber)
                    {
                        //DroneSkinEquipButton.SetActive(true);
                        DroneSkinEquippedButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(0);
                    }
                }
                else if (DroneNumber == 4)
                {
                    if (PlayerPrefs.GetInt("Drone4CurrentSkin") == SkinNumber)
                    {
                        DroneSkinEquippedButton.SetActive(true);
                        //DroneSkinEquipButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(0);
                    }
                    else if (PlayerPrefs.GetInt("Drone4CurrentSkin") != SkinNumber)
                    {
                        //DroneSkinEquipButton.SetActive(true);
                        DroneSkinEquippedButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(0);
                    }
                }
                else if (DroneNumber == 5)
                {
                    if (PlayerPrefs.GetInt("Drone5CurrentSkin") == SkinNumber)
                    {
                        DroneSkinEquippedButton.SetActive(true);
                        //DroneSkinEquipButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(0);
                    }
                    else if (PlayerPrefs.GetInt("Drone5CurrentSkin") != SkinNumber)
                    {
                        //DroneSkinEquipButton.SetActive(true);
                        DroneSkinEquippedButton.SetActive(false);
                        droneSkinHandler.ShowDemoSkin(0);
                    }
                }
            }
            else if (droneData.isSkinsPurchased[SkinNumber] == false)/////////this will run if skin is not purchased
            {
                DroneSkinPurchaseButton.SetActive(true);
                droneSkinHandler.ShowDemoSkin(0);
            }
        }
    }

    private void UpdateSkin(){
        ShowCaseSkin();
        droneSkinHandler.UpdateSkin();
    }


    private IEnumerator DownloadAssetBundleFromServer(string url)
    {
        SkinsScriptableGameObject skin = null;
        using (UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogWarning("Error on get request at:" + url + "" + www.error);
            }
            else
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                skin = bundle.LoadAsset(bundle.GetAllAssetNames()[0]) as SkinsScriptableGameObject;
                bundle.Unload(false);
                yield return new WaitForEndOfFrame();
                if(DroneNumber==1){
                    baseresourcesScriptableObject.drone1Skins[SkinNumber] = skin;
                }
                else if(DroneNumber==2){
                    baseresourcesScriptableObject.drone2Skins[SkinNumber] = skin;
                }
                else if(DroneNumber==3){
                    baseresourcesScriptableObject.drone3Skins[SkinNumber] = skin;
                }
                else if(DroneNumber==4){
                    baseresourcesScriptableObject.drone4Skins[SkinNumber] = skin;
                }
                else if(DroneNumber==5){
                    baseresourcesScriptableObject.drone5Skins[SkinNumber] = skin;
                }
                //droneSkinWebData.isDownloaded=true;
                PlayerPrefs.SetInt(name,1);
            }
            www.Dispose();
            UpdateSkin();
        }
    }
}

using System;
using System.Collections;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SkinsWebRequestHandler : MonoBehaviour
{
    [SerializeField]
    private DroneSkinWebDataScriptableObject droneSkinWebData;

    [SerializeField]
    private int DroneNumber;

    [SerializeField]
    private int SkinNumber;

    [SerializeField]
    private DownloadedResourcesScriptableObject baseresourcesScriptableObject;

    [Header("SkinsProgressBar")]
    [SerializeField]
    private Image DroneProgessBar;

    [Header("SkinsDownloadButtons")]
    [SerializeField]
    private GameObject DroneDownloadButton;

    [Header("SkinsDownloadedButtons")]
    [SerializeField]
    private GameObject DroneDownloadedImage;

    [Header("SkinsDownloadSizeText")]
    [SerializeField]
    private TMP_Text DroneDownloadSizeText;

    [Header("ForDebugging")]
    [SerializeField]
    private PhotonDebugging photonDebugging;

    private string name;

    void Start()
    {
        name=string.Format("Drone{0}Skin{1}Download",droneSkinWebData.droneNum,droneSkinWebData.skinNum);
    }

    // Update is called once per frame
    void Update() { }

    public void UpdateData()
    {
        if (PlayerPrefs.GetInt(name)==1)
        {
            DroneProgessBar.fillAmount = 1;
            DroneDownloadButton.SetActive(false);
            DroneDownloadedImage.SetActive(true);
            DroneDownloadSizeText.text = null;
        }
        else if (PlayerPrefs.GetInt(name)!=1)
        {
            DroneProgessBar.fillAmount = 0;
            DroneDownloadButton.SetActive(true);
            DroneDownloadedImage.SetActive(false);
            StartCoroutine(
                GetContentSize(
                    droneSkinWebData.link,
                    (size) =>
                    {
                        DroneDownloadSizeText.text = size.ToString();
                        droneSkinWebData.resourceSize = size.ToString();
                    }
                )
            );
        }
    }

    private IEnumerator GetContentSize(string url, Action<long> resut)
    {
        UnityWebRequest uwr = UnityWebRequest.Head(url);
        yield return uwr.SendWebRequest();
        string size = uwr.GetResponseHeader("Content-Length");

        if (uwr.isNetworkError || uwr.isHttpError)
        {
            Debug.Log("Error While Getting Length: " + uwr.error);
            if (resut != null)
                resut(-1);
        }
        else
        {
            if (resut != null)
                resut(Convert.ToInt64(size));
        }
        uwr.Dispose();
    }

    public void DownloadResource()
    {
        StartCoroutine(DownloadAssetBundleFromServer(droneSkinWebData.downloadLink));
    }

    private IEnumerator DownloadAssetBundleFromServer(string url)
    {
        Uri uri = new Uri(url);

        //WebClient client = new WebClient();

        SkinsScriptableGameObject skin = null;
        string fileName = string.Format("Drone{0}Skin{1}", DroneNumber, SkinNumber);

        //client.DownloadFileAsync(uri, Application.persistentDataPath + fileName);
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        using (WebClient client = new WebClient())
        {
            client.DownloadFileAsync(uri, filePath);

            while (client.IsBusy)
                yield return null;

            // Download completed successfully
            Debug.Log($"Asset bundle downloaded to: {filePath}");
            if (photonDebugging != null)
            {
                photonDebugging.SendCustomLog($"Asset bundle downloaded to: {filePath}");
            }

            AssetBundle bundle = AssetBundle.LoadFromFile(filePath);
            if (bundle != null)
            {
                skin = bundle.LoadAsset(bundle.GetAllAssetNames()[0]) as SkinsScriptableGameObject;

                switch (DroneNumber)
                {
                    case 1:
                        baseresourcesScriptableObject.drone1Skins[SkinNumber] = skin;
                        break;
                    case 2:
                        baseresourcesScriptableObject.drone2Skins[SkinNumber] = skin;
                        break;
                    case 3:
                        baseresourcesScriptableObject.drone3Skins[SkinNumber] = skin;
                        break;
                    case 4:
                        baseresourcesScriptableObject.drone4Skins[SkinNumber] = skin;
                        break;
                    case 5:
                        baseresourcesScriptableObject.drone5Skins[SkinNumber] = skin;
                        break;
                }

                //droneSkinWebData.isDownloaded = true;
                PlayerPrefs.SetInt(name,1);
                UpdateData();
                bundle.Unload(false);
            }
            else
            {
                Debug.LogError("Failed to load asset bundle.");
                if (photonDebugging != null)
                {
                    photonDebugging.SendCustomLog("Failed to load asset bundle.");
                }
            }
        }

        /*while (client.IsBusy)
            yield return null;

        AssetBundle bundle = AssetBundle.LoadFromFile(Application.persistentDataPath + fileName);
        skin = bundle.LoadAsset(bundle.GetAllAssetNames()[0]) as SkinsScriptableGameObject;
        
        if (DroneNumber == 1)
        {
            baseresourcesScriptableObject.drone1Skins[SkinNumber] = skin;
        }
        else if (DroneNumber == 2)
        {
            baseresourcesScriptableObject.drone2Skins[SkinNumber] = skin;
        }
        else if (DroneNumber == 3)
        {
            baseresourcesScriptableObject.drone3Skins[SkinNumber] = skin;
        }
        else if (DroneNumber == 4)
        {
            baseresourcesScriptableObject.drone4Skins[SkinNumber] = skin;
        }
        else if (DroneNumber == 5)
        {
            baseresourcesScriptableObject.drone5Skins[SkinNumber] = skin;
        }
        droneSkinWebData.isDownloaded = true;
        UpdateData();*/

        /*using (UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogWarning("Error on get request at:" + url + "" + www.error);
            }
            else
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                DroneProgessBar.fillAmount = www.downloadProgress;
                string fileName = string.Format("Drone{0}Skin{1}", DroneNumber, SkinNumber);
                string savePath = Path.Combine(Application.persistentDataPath, fileName);
                UnityEngine.Object[] obj = bundle.LoadAllAssets();
                Byte[] bytes = SerializeAssets(obj);
                File.WriteAllBytes(savePath, bytes);
                skin = AssetBundle.LoadFromFile(savePath).LoadAsset(AssetBundle.LoadFromFile(savePath).GetAllAssetNames()[0]) as SkinsScriptableGameObject;
                //skin = bundle.LoadAsset(bundle.GetAllAssetNames()[0]) as SkinsScriptableGameObject;
                bundle.Unload(true);
                yield return new WaitForEndOfFrame();
                if (DroneNumber == 1)
                {
                    baseresourcesScriptableObject.drone1Skins[SkinNumber] = skin;
                }
                else if (DroneNumber == 2)
                {
                    baseresourcesScriptableObject.drone2Skins[SkinNumber] = skin;
                }
                else if (DroneNumber == 3)
                {
                    baseresourcesScriptableObject.drone3Skins[SkinNumber] = skin;
                }
                else if (DroneNumber == 4)
                {
                    baseresourcesScriptableObject.drone4Skins[SkinNumber] = skin;
                }
                else if (DroneNumber == 5)
                {
                    baseresourcesScriptableObject.drone5Skins[SkinNumber] = skin;
                }
                droneSkinWebData.isDownloaded = true;
            }
            www.Dispose();
        }*/
    }

    /*private byte[] SerializeAssets(UnityEngine.Object[] assets)
    {
        MemoryStream stream = new MemoryStream();
        BinaryFormatter formatter = new BinaryFormatter();
        foreach (UnityEngine.Object asset in assets)
        {
            formatter.Serialize(stream, asset);
        }
        return stream.ToArray();
    }*/
}

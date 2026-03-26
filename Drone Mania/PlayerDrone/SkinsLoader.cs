using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SkinsLoader : MonoBehaviour
{
    [SerializeField]
    private DroneSkinWebDataScriptableObject[] WebData;
    private string fileName,
        filePath;

    [SerializeField]
    private DownloadedResourcesScriptableObject baseresourcesScriptableObject;

    [Header("ForDebugging")]
    [SerializeField]
    private PhotonDebugging photonDebugging;

    string name;

    void Start()
    {
        // LOAD ALL DOWNLOADED SKINS //
        foreach (var webData in WebData)
        {
            name=string.Format("Drone{0}Skin{1}Download",webData.droneNum,webData.skinNum);
            if (PlayerPrefs.GetInt(name)==1)
            {
                fileName = string.Format("Drone{0}Skin{1}", webData.droneNum, webData.skinNum);
                filePath = Path.Combine(Application.persistentDataPath, fileName);
                AssetBundle bundle = AssetBundle.LoadFromFile(filePath);
                if (bundle != null)
                {
                    if (photonDebugging != null)
                    {
                        photonDebugging.SendCustomLog($"Asset bundle found : {webData.droneNum}_,_{webData.skinNum}");
                    }

                    SkinsScriptableGameObject skin =
                        bundle.LoadAsset(bundle.GetAllAssetNames()[0]) as SkinsScriptableGameObject;

                    switch (webData.droneNum)
                    {
                        case 1:
                            baseresourcesScriptableObject.drone1Skins[webData.skinNum] = skin;
                            break;
                        case 2:
                            baseresourcesScriptableObject.drone2Skins[webData.skinNum] = skin;
                            break;
                        case 3:
                            baseresourcesScriptableObject.drone3Skins[webData.skinNum] = skin;
                            break;
                        case 4:
                            baseresourcesScriptableObject.drone4Skins[webData.skinNum] = skin;
                            break;
                        case 5:
                            baseresourcesScriptableObject.drone5Skins[webData.skinNum] = skin;
                            break;
                    }
                    bundle.Unload(false);
                }
                if (bundle == null)
                {
                    if (photonDebugging != null)
                    {
                        photonDebugging.SendCustomLog($"Asset bundle not found: {webData.droneNum}_,_{webData.skinNum}");
                    }
                }
            }
            if (PlayerPrefs.GetInt(name)!=1)
            {
                if (photonDebugging != null)
                {
                    photonDebugging.SendCustomLog($"Asset bundle not downloaded: {webData.droneNum}_,_{webData.skinNum}");
                }
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ResourcesDownloadManager : MonoBehaviour
{
    [Header("OtherReferences")]
    [SerializeField] private DownloadedResourcesScriptableObject downloadData;

    [Header("SkinsURL")]
    [SerializeField] private String[] DroneSkinsLinks;

    [Header("SkinsProgressBar")]
    [SerializeField] private Image[] DronesProgessBars;

    [Header("SkinsDownloadButtons")]
    [SerializeField] private GameObject[] DroneDownloadButtons;

    [Header("SkinsDownloadedButtons")]
    [SerializeField] private GameObject[] DroneDownloadedImages;

    [Header("SkinsDownloadSizeText")]
    [SerializeField] private TMP_Text[] DroneDownloadSizeTexts;

    public Renderer testCube;
    public Material mat1, mat2;
    public Material[] mats;

    public Image bar;

    [SerializeField] private DownloadedResourcesScriptableObject baseresourcesScriptableObject;

    // Start is called before the first frame update
    void Start()
    {
        if (baseresourcesScriptableObject.drone1Skins[3] == null)
        {
            Debug.Log("its Null");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSkin1()
    {
        PlayerPrefs.SetInt("Drone1CurrentSkin", 1);
        return;
    }
    public void ChangeSkin2()
    {
        PlayerPrefs.SetInt("Drone1CurrentSkin", 2);
        return;
    }
    public void ChangeSkin3()
    {
        PlayerPrefs.SetInt("Drone1CurrentSkin", 3);
        return;
    }

    public void Change2Skin1()
    {
        PlayerPrefs.SetInt("Drone2CurrentSkin", 1);
        return;
    }
    public void Change2Skin2()
    {
        PlayerPrefs.SetInt("Drone2CurrentSkin", 2);
        return;
    }
    public void Change2Skin3()
    {
        PlayerPrefs.SetInt("Drone2CurrentSkin", 3);
        return;
    }

    public void Change3Skin1()
    {
        PlayerPrefs.SetInt("Drone3CurrentSkin", 1);
        return;
    }
    public void Change3Skin2()
    {
        PlayerPrefs.SetInt("Drone3CurrentSkin", 2);
        return;
    }
    public void Change3Skin3()
    {
        PlayerPrefs.SetInt("Drone3CurrentSkin", 3);
        return;
    }

    public void Change4Skin1()
    {
        PlayerPrefs.SetInt("Drone4CurrentSkin", 1);
        return;
    }
    public void Change4Skin2()
    {
        PlayerPrefs.SetInt("Drone4CurrentSkin", 2);
        return;
    }
    public void Change4Skin3()
    {
        PlayerPrefs.SetInt("Drone4CurrentSkin", 3);
        return;
    }

    public void Change5Skin1()
    {
        PlayerPrefs.SetInt("Drone5CurrentSkin", 1);
        return;
    }
    public void Change5Skin2()
    {
        PlayerPrefs.SetInt("Drone5CurrentSkin", 2);
        return;
    }
    public void Change5Skin3()
    {
        PlayerPrefs.SetInt("Drone5CurrentSkin", 3);
        return;
    }

    public void SetMat1()
    {
        testCube.material = mat1;
    }
    public void SetMat2()
    {
        testCube.materials = mats;
    }

    public void DownloadSkin1()
    {
        //StartCoroutine(DownloadAssetBundleFromServer(Drone1Skins[2]));
    }

    /*public void enableDownloadManager()
    {
        for (int i = 0; i < Drone1ProgessBar.Length; i++)
        {
            Drone1ProgessBar[i].fillAmount = downloadData.drone1SkinsDownloadProgress[i + 1];
            Drone2ProgessBar[i].fillAmount = downloadData.drone2SkinsDownloadProgress[i + 1];
            Drone3ProgessBar[i].fillAmount = downloadData.drone3SkinsDownloadProgress[i + 1];
            Drone4ProgessBar[i].fillAmount = downloadData.drone4SkinsDownloadProgress[i + 1];
            Drone5ProgessBar[i].fillAmount = downloadData.drone5SkinsDownloadProgress[i + 1];
        }

        for (int i = 0; i < Drone1ProgessBar.Length; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < Drone1ProgessBar.Length; j++)
                {
                    if (downloadData.drone1SkinsDownloadProgress[j] != 1)
                    {
                        Drone1DownloadButton[j].SetActive(true);
                        Drone1DownloadImage[j].SetActive(false);
                        StartCoroutine(GetContentSize(Drone1Skins[j],
                        (size) =>
                        {
                            Drone1DownloadSizeText[j].text = size.ToString();
                        }));
                    }
                    else if(downloadData.drone1SkinsDownloadProgress[j]==1){
                        Drone1DownloadButton[j].SetActive(false);
                        Drone1DownloadImage[j].SetActive(true);
                    }
                }
            }
            else if (i == 1)
            {
                for (int j = 0; j < Drone1ProgessBar.Length; j++)
                {
                    if (downloadData.drone2SkinsDownloadProgress[j] != 1)
                    {
                        Drone2DownloadButton[j].SetActive(true);
                        Drone2DownloadImage[j].SetActive(false);
                        StartCoroutine(GetContentSize(Drone2Skins[j],
                        (size) =>
                        {
                            Drone2DownloadSizeText[j].text = size.ToString();
                        }));
                    }
                    else if(downloadData.drone1SkinsDownloadProgress[j]==1){
                        Drone2DownloadButton[j].SetActive(false);
                        Drone2DownloadImage[j].SetActive(true);
                    }
                }
            }
            else if (i == 2)
            {
                for (int j = 0; j < Drone1ProgessBar.Length; j++)
                {
                    if (downloadData.drone3SkinsDownloadProgress[j] != 1)
                    {
                        Drone3DownloadButton[j].SetActive(true);
                        Drone3DownloadImage[j].SetActive(false);
                        StartCoroutine(GetContentSize(Drone3Skins[j],
                        (size) =>
                        {
                            Drone3DownloadSizeText[j].text = size.ToString();
                        }));
                    }
                    else if(downloadData.drone1SkinsDownloadProgress[j]==1){
                        Drone3DownloadButton[j].SetActive(false);
                        Drone3DownloadImage[j].SetActive(true);
                    }
                }
            }
            else if (i == 3)
            {
                for (int j = 0; j < Drone1ProgessBar.Length; j++)
                {
                    if (downloadData.drone4SkinsDownloadProgress[j] != 1)
                    {
                        Drone4DownloadButton[j].SetActive(true);
                        Drone4DownloadImage[j].SetActive(false);
                        StartCoroutine(GetContentSize(Drone4Skins[j],
                        (size) =>
                        {
                            Drone4DownloadSizeText[j].text = size.ToString();
                        }));
                    }
                    else if(downloadData.drone1SkinsDownloadProgress[j]==1){
                        Drone4DownloadButton[j].SetActive(false);
                        Drone4DownloadImage[j].SetActive(true);
                    }
                }
            }
            else if (i == 4)
            {
                for (int j = 0; j < Drone1ProgessBar.Length; j++)
                {
                    if (downloadData.drone5SkinsDownloadProgress[j] != 1)
                    {
                        Drone5DownloadButton[j].SetActive(true);
                        Drone5DownloadImage[j].SetActive(false);
                        StartCoroutine(GetContentSize(Drone5Skins[j],
                        (size) =>
                        {
                            Drone5DownloadSizeText[j].text = size.ToString();
                        }));
                    }
                    else if(downloadData.drone1SkinsDownloadProgress[j]==1){
                        Drone5DownloadButton[j].SetActive(false);
                        Drone5DownloadImage[j].SetActive(true);
                    }
                }
            }
        }
    }*/

    [SerializeField] private string contentSize;
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
                contentSize = www.GetResponseHeader("Content-Length");
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                bar.fillAmount = www.downloadProgress;
                skin = bundle.LoadAsset(bundle.GetAllAssetNames()[0]) as SkinsScriptableGameObject;
                bundle.Unload(false);
                yield return new WaitForEndOfFrame();
                baseresourcesScriptableObject.drone1Skins[3] = skin;
            }
            www.Dispose();
        }
    }







    public void enableDownloadManagaer()
    {
        ////Task 1 get all resources size
        ////Task 2 Update bars
        ////Task 3 Update btns
        for (int i = 0; i < DroneSkinsLinks.Length; i++)
        {
            if (baseresourcesScriptableObject.dronesSkinsDownloadProgress[i] != 1)
            {
                DroneDownloadButtons[i].SetActive(true);
                DroneDownloadedImages[i].SetActive(false);
                StartCoroutine(GetContentSize(DroneSkinsLinks[i],
                (size) =>
                {
                    DroneDownloadSizeTexts[i].text = size.ToString();
                }));
            }
            else if (baseresourcesScriptableObject.dronesSkinsDownloadProgress[i] == 1)
            {
                DroneDownloadButtons[i].SetActive(false);
                DroneDownloadedImages[i].SetActive(true);
            }
            StopAllCoroutines();
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
    }

}

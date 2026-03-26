using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSkinHandler : MonoBehaviour
{

    [SerializeField] private int DroneNumber;
    [SerializeField] private DownloadedResourcesScriptableObject downloadedResourcesScriptableObject;

    [Serializable]
    public class DroneDataClass
    {
        public MeshRenderer meshRenderer;
    }

    public List<DroneDataClass> droneData;

    void Awake()
    {
        for (int i = 0; i < droneData.Count; i++)
        {
            if(DroneNumber==1){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone1Skins[PlayerPrefs.GetInt("Drone1CurrentSkin")].skin[i].materials;
            }
            else if(DroneNumber==2){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone2Skins[PlayerPrefs.GetInt("Drone2CurrentSkin")].skin[i].materials;
            }
            else if(DroneNumber==3){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone3Skins[PlayerPrefs.GetInt("Drone3CurrentSkin")].skin[i].materials;
            }
            else if(DroneNumber==4){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone4Skins[PlayerPrefs.GetInt("Drone4CurrentSkin")].skin[i].materials;
            }
            else if(DroneNumber==5){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone5Skins[PlayerPrefs.GetInt("Drone5CurrentSkin")].skin[i].materials;
            }
        }
    }

    public void UpdateSkin()
    {
        for (int i = 0; i < droneData.Count; i++)
        {
            if(DroneNumber==1){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone1Skins[PlayerPrefs.GetInt("Drone1CurrentSkin")].skin[i].materials;
            }
            else if(DroneNumber==2){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone2Skins[PlayerPrefs.GetInt("Drone2CurrentSkin")].skin[i].materials;
            }
            else if(DroneNumber==3){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone3Skins[PlayerPrefs.GetInt("Drone3CurrentSkin")].skin[i].materials;
            }
            else if(DroneNumber==4){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone4Skins[PlayerPrefs.GetInt("Drone4CurrentSkin")].skin[i].materials;
            }
            else if(DroneNumber==5){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone5Skins[PlayerPrefs.GetInt("Drone5CurrentSkin")].skin[i].materials;
            }
        }
    }

    public void ShowDemoSkin(int skinNum){
        for (int i = 0; i < droneData.Count; i++){
            if(DroneNumber==1){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone1Skins[skinNum].skin[i].materials;
            }
            else if(DroneNumber==2){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone2Skins[skinNum].skin[i].materials;
            }
            else if(DroneNumber==3){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone3Skins[skinNum].skin[i].materials;
            }
            else if(DroneNumber==4){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone4Skins[skinNum].skin[i].materials;
            }
            else if(DroneNumber==5){
                droneData[i].meshRenderer.materials=downloadedResourcesScriptableObject.drone5Skins[skinNum].skin[i].materials;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScrrenDroneHandler : MonoBehaviour
{
    [SerializeField]private GameObject[] drones_GameObject;
    [SerializeField]private DroneSkinHandler[] droneSkinHandlers;
    [SerializeField]private float rotationSpeed = 0;
    private GameObject currentDrone;
    void Start()
    {
        for (int i = 0; i < drones_GameObject.Length; i++)
        {
            if(PlayerPrefs.GetInt("EquippedDrone")==i+1){
                drones_GameObject[i].SetActive(true);
                droneSkinHandlers[i].UpdateSkin();
                currentDrone=drones_GameObject[i];
            }
            else if(PlayerPrefs.GetInt("EquippedDrone")!=i+1){
                drones_GameObject[i].SetActive(false);
            }
        }
    }

    public void UpdateDrones(){
        for (int i = 0; i < drones_GameObject.Length; i++)
        {
            if(PlayerPrefs.GetInt("EquippedDrone")==i+1){
                drones_GameObject[i].SetActive(true);
                droneSkinHandlers[i].UpdateSkin();
                currentDrone=drones_GameObject[i];
            }
            else if(PlayerPrefs.GetInt("EquippedDrone")!=i+1){
                drones_GameObject[i].SetActive(false);
            }
        }
    }
    void Update()
    {
        if(currentDrone==null)
        return;
        currentDrone.transform.Rotate(0, Time.deltaTime * rotationSpeed, 0, Space.Self);
    }

    public void HideDrones(){
        for (int i = 0; i < drones_GameObject.Length; i++)
        {
            drones_GameObject[i].SetActive(false);
        }
    }
    public void ShowDrones(){
        for (int i = 0; i < drones_GameObject.Length; i++)
        {
            if(PlayerPrefs.GetInt("EquippedDrone")==i+1){
                drones_GameObject[i].SetActive(true);
            }
            else if(PlayerPrefs.GetInt("EquippedDrone")!=i+1){
                drones_GameObject[i].SetActive(false);
            }
        }
    }
}

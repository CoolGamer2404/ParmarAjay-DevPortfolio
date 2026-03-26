using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageMarkersHandler : MonoBehaviour
{
    [SerializeField]private int villageTriggerIndex;
    [SerializeField]private ObjectivePosition[] allMarkers;
    [SerializeField]private GameObject[] triggers;
    [SerializeField]private ObjectivePosition villageMarker;
    [SerializeField]private FullQuestHandler fullQuestHandler;

    private void EnterVillage(){
        if(fullQuestHandler.currentQuestIndex>=2){
            villageMarker.RemoveMarker();
        }
        //Debug.Log("Entered Village");
        fullQuestHandler.currentVillage=villageTriggerIndex;
        //villageMarker.RemoveMarker();
        if(fullQuestHandler.currentQuestIndex<=1)
        return;
        for (int i = 0; i < allMarkers.Length; i++)
        {
            allMarkers[i].AddMarker();
            triggers[i].SetActive(true);
        }
    }
    private void ExitVillage(){
        //Debug.Log("Exit Village");
        fullQuestHandler.currentVillage=0;
        villageMarker.AddMarker();
        if(fullQuestHandler.currentQuestIndex<=1)
        return;
        for (int i = 0; i < allMarkers.Length; i++)
        {
            allMarkers[i].RemoveMarker();
            triggers[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider){
        if(collider.tag=="Player"){
            EnterVillage();
            fullQuestHandler.EnteredVillage(villageTriggerIndex);
        }
    }
    private void OnTriggerExit(Collider collider){
        if(collider.tag=="Player"){
            ExitVillage();
        }
    }
}

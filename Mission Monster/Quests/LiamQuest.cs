using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LiamQuest : MonoBehaviour
{
    [SerializeField]private GameObject _Liam;
    [SerializeField]private GameObject _Trigger1,_Trigger2,_FoodTrigger;
    [SerializeField]private GameObject _LiamArrow;
    [SerializeField]private MainQuestHandler mainQuestHandler;
    [SerializeField]private TMP_Text questText2;
    [SerializeField]private GameObject food;
    [SerializeField]private ObjectivePosition _FoodMarker;
    [SerializeField]private ObjectivePosition _LiamMarker;

    public void EnableQuest(){
        _Liam.SetActive(true);
        _Trigger1.SetActive(true);
        //_LiamArrow.SetActive(true);
        //questText2.text="Talk To Liam";
    }

    public void StartQuest(){
        _Trigger1.SetActive(false);
        _FoodTrigger.SetActive(true);
        food.SetActive(true);
        //_BoxIndicator.SetActive(true);
        questText2.text="Get Food";
    }
    public void NextQuest(){
        _Trigger2.SetActive(true);
        _FoodTrigger.SetActive(false);
        _FoodMarker.RemoveMarker();
        _LiamMarker.AddMarker();
        _LiamArrow.SetActive(true);
        //_BoxIndicator.SetActive(false);
        questText2.text="Give Food To Liam";
    }
    public void EndQuest(){
        _Liam.SetActive(false);
        _Trigger2.SetActive(false);
        mainQuestHandler._totalNPCTalked-=1;
        mainQuestHandler.UpdateNPCTalked();
        questText2.text=null;
    }
}

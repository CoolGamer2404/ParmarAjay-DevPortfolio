using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LucasQuest : MonoBehaviour
{
    [SerializeField]private GameObject _Lucas;
    [SerializeField]private GameObject _Trigger1,_Trigger2,_MedkitTrigger;
    [SerializeField]private GameObject _LucasArrow;
    [SerializeField]private MainQuestHandler mainQuestHandler;
    [SerializeField]private TMP_Text questText2;
    [SerializeField]private GameObject _medKit;
    [SerializeField]private ObjectivePosition _MedkitMarker;
    [SerializeField]private ObjectivePosition _LucasMarker;

    public void EnableQuest(){
        _Lucas.SetActive(true);
        _Trigger1.SetActive(true);
        //_LucasArrow.SetActive(true);
        //questText2.text="Talk To Lucas";
    }

    public void StartQuest(){
        _Trigger1.SetActive(false);
        _MedkitTrigger.SetActive(true);
        _medKit.SetActive(true);
        //_BoxIndicator.SetActive(true);
        questText2.text="Get Medkit";
    }
    public void NextQuest(){
        _Trigger2.SetActive(true);
        _MedkitTrigger.SetActive(false);
        _LucasArrow.SetActive(true);
        _LucasMarker.AddMarker();
        _MedkitMarker.RemoveMarker();
        //_BoxIndicator.SetActive(false);
        questText2.text="Give Medkit To Lucas";
    }
    public void EndQuest(){
        _Lucas.SetActive(false);
        _Trigger2.SetActive(false);
        mainQuestHandler._totalNPCTalked-=1;
        mainQuestHandler.UpdateNPCTalked();
        questText2.text=null;
    }
}

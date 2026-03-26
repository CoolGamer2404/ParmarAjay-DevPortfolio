using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EthanQuest : MonoBehaviour
{
    [SerializeField]private GameObject _Ethan;
    [SerializeField]private GameObject _Trigger1,_Trigger2,_BoxTrigger;
    [SerializeField]private GameObject _EthanArrow,_BoxIndicator;
    [SerializeField]private Transform _EthanPosition2;
    [SerializeField]private MainQuestHandler mainQuestHandler;
    [SerializeField]private TMP_Text questText2;

    public void EnableQuest(){
        _Ethan.SetActive(true);
        _Trigger1.SetActive(true);
        //_EthanArrow.SetActive(true);
        //questText2.text="Talk To Ethan";
    }

    public void StartQuest(){
        _Trigger1.SetActive(false);
        _BoxTrigger.SetActive(true);
        _BoxIndicator.SetActive(true);
        questText2.text="Move Box to Designated Location";
    }
    public void NextQuest(){
        _Ethan.transform.position=_EthanPosition2.position;
        _Ethan.transform.rotation=_EthanPosition2.rotation;
        _Trigger2.SetActive(true);
        _BoxTrigger.SetActive(false);
        _BoxIndicator.SetActive(false);
        _EthanArrow.SetActive(true);
        questText2.text="Talk To Ethan";
    }
    public void EndQuest(){
        _Ethan.SetActive(false);
        _Trigger2.SetActive(false);
        mainQuestHandler._totalNPCTalked-=1;
        mainQuestHandler.UpdateNPCTalked();
        questText2.text=null;
        _EthanArrow.SetActive(false);
    }
}

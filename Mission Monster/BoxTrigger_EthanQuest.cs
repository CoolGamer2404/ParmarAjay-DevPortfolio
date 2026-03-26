using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger_EthanQuest : MonoBehaviour
{
    [SerializeField]private EthanQuest ethanQuest;
    [SerializeField]private GameObject Trigger;
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="QuestBox"){
            ethanQuest.NextQuest();
            Trigger.SetActive(false);
        }
    }
}

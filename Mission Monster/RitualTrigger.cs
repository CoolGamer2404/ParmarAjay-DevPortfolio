using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualTrigger : MonoBehaviour
{
    [SerializeField]private MainQuestHandler mainQuestHandler;
    [SerializeField]private GameObject Trigger;
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="Player"){
            mainQuestHandler.StartRitual();
            Trigger.SetActive(false);
        }
    }
}

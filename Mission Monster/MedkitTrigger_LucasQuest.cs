using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitTrigger_LucasQuest : MonoBehaviour
{
    [SerializeField]private LucasQuest lucasQuest;
    [SerializeField]private GameObject Trigger;
    [SerializeField]private GameObject Medkit;
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="Player"){
            lucasQuest.NextQuest();
            Trigger.SetActive(false);
            Medkit.SetActive(false);
        }
    }
}

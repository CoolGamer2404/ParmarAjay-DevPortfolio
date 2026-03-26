using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField]private FullQuestHandler fullQuestHandler;
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            fullQuestHandler.UpdateQuestPhase();
            this.gameObject.SetActive(false);
        }
    }
}

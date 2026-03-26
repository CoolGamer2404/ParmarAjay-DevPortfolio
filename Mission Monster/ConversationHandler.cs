using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using StarterAssets;
using UnityEditor;

public class ConversationHandler : MonoBehaviour
{
    [SerializeField]private NPCConversation conversation;
    [SerializeField]private StarterAssetsInputs starterAssetsInputs;
    [SerializeField]private FirstPersonController firstPersonController;
    [SerializeField]private GameObject interactInfoPanel;
    [SerializeField]private GameObject _npcCamera;

    void Start(){
        this.gameObject.GetComponent<MeshRenderer>().enabled=false;
    }
    
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            interactInfoPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            interactInfoPanel.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other){
        if(other.CompareTag("Player")){
            if(starterAssetsInputs.interact){
                interactInfoPanel.SetActive(false);
                ConversationManager.Instance.StartConversation(conversation);
                ConverationStart();
            }
        }
    }

    public void ConverationStart(){
        if(_npcCamera!=null)
        _npcCamera.SetActive(true);
        starterAssetsInputs.cursorLocked=false;
        starterAssetsInputs.cursorInputForLook=false;
        firstPersonController.enabled=false;
        Cursor.lockState =  CursorLockMode.None;
    }
    public void ConversationEnd(){
        if(_npcCamera!=null)
        _npcCamera.SetActive(false);
        firstPersonController.enabled=true;
        starterAssetsInputs.cursorLocked=true;
        starterAssetsInputs.cursorInputForLook=true;
        Cursor.lockState =  CursorLockMode.Locked;
    }
}

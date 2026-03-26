using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using StarterAssets;
using UnityEditor;

public class ConversationHandler : MonoBehaviour
{
    [SerializeField]private NPCConversation conversation;
    [SerializeField]private CharacterInputs characterInputs;
    //[SerializeField]private FirstPersonController firstPersonController;
    [SerializeField]private Character character;
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
            if(characterInputs.interact){
                interactInfoPanel.SetActive(false);
                ConversationManager.Instance.StartConversation(conversation);
                ConverationStart();
            }
        }
    }

    public void ConverationStart(){
        if(_npcCamera!=null)
        _npcCamera.SetActive(true);
        characterInputs.cursorLocked=false;
        characterInputs.cursorInputForLook=false;
        //firstPersonController.enabled=false;
        character.enabled=false;
        Cursor.lockState =  CursorLockMode.None;
    }
    public void ConversationEnd(){
        if(_npcCamera!=null)
        _npcCamera.SetActive(false);
        //firstPersonController.enabled=true;
        character.enabled=true;
        characterInputs.cursorLocked=true;
        characterInputs.cursorInputForLook=true;
        Cursor.lockState =  CursorLockMode.Locked;
    }
}

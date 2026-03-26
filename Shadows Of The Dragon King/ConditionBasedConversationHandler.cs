using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class ConditionBasedConversationHandler : MonoBehaviour
{
    [SerializeField]private NPCConversation conversationTrue,conversationFalse;
    [SerializeField]private CharacterInputs characterInputs;
    [SerializeField]private Character character;
    [SerializeField]private GameObject interactInfoPanel;
    [SerializeField]private GameObject _npcCamera;

    [SerializeField]private int conditionAmount;
    [SerializeField]private ConditionType conditionType;
    CharacterDataHandler data;

    private enum ConditionType{
        None,
        Mushrooms,
        Coins,
    }

    void Start(){
        this.gameObject.GetComponent<MeshRenderer>().enabled=false;
        data=GameObject.Find("Character").GetComponent<CharacterDataHandler>();
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
                switch (conditionType)
                {
                    case ConditionType.Mushrooms:
                        if(data.Mushrooms>=conditionAmount){
                            data.Mushrooms-=conditionAmount;
                            interactInfoPanel.SetActive(false);
                            ConversationManager.Instance.StartConversation(conversationTrue);
                            ConverationStart();
                        }
                        else if(data.Mushrooms<conditionAmount){
                            interactInfoPanel.SetActive(false);
                            ConversationManager.Instance.StartConversation(conversationFalse);
                            ConverationStart();
                        }
                    break;
                    case ConditionType.Coins:
                        if(PlayerPrefs.GetInt("Coins")>=conditionAmount){
                            int coins=PlayerPrefs.GetInt("Coins")-conditionAmount;
                            PlayerPrefs.SetInt("Coins",coins);
                            interactInfoPanel.SetActive(false);
                            ConversationManager.Instance.StartConversation(conversationTrue);
                            ConverationStart();
                        }
                        else if(PlayerPrefs.GetInt("Coins")<conditionAmount){
                            interactInfoPanel.SetActive(false);
                            ConversationManager.Instance.StartConversation(conversationFalse);
                            ConverationStart();
                        }
                    break;
                }
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

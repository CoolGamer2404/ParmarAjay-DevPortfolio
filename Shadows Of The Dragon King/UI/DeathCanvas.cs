using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCanvas : MonoBehaviour
{
    [SerializeField]CharacterController characterController;
    [SerializeField]Transform village1Location,village2Location,village3Location;
    [SerializeField]FullQuestHandler fullQuestHandler;
    [SerializeField]GameObject character;

    void Start(){
        characterController.enabled=false;
    }
    public void ExitGame(){
        SceneManager.LoadScene(0);
    }
    public void Retry(){
        if(fullQuestHandler.currentQuestIndex==1 || fullQuestHandler.currentQuestIndex==0){
            character.transform.position=village1Location.position;
        }
        else if(fullQuestHandler.currentQuestIndex==2){
            character.transform.position=village2Location.position;
        }
        else if(fullQuestHandler.currentQuestIndex==3){
            character.transform.position=village3Location.position;
        }
        characterController.enabled=true;
        this.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
//using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]private Animator PlayAnimator;
    [SerializeField]private GameObject AgreementPopUp;
    [SerializeField]private UnityEngine.UI.Image image;
    [SerializeField]private int random;


    [SerializeField]private InputField textField;
    [SerializeField]private string password="harshandajay@";
    [SerializeField]private GameObject adminPasswordPanel;
    [SerializeField]private GameObject adminPanel;
    [SerializeField]private GameObject updatePanel;

    [SerializeField]private int HasGameStartedValue=0;
    [SerializeField]private GameObject mainMenuUI;

    //public TMP_Text tMP_Text;

    public void Start(){
        Time.timeScale=1f;
        //tMP_Text.text=PlayerPrefs.GetInt("Coins").ToString();
         if(!PlayerPrefs.HasKey("GameStarted")){
            AgreementPopUp.SetActive(true);
        }
        if(!PlayerPrefs.HasKey("Sensitivity")){
            SetSensitivity();
        }
        HasGameStartedValue=PlayerPrefs.GetInt("IsGameStarted");

        if(HasGameStartedValue!=0){
            updatePanel.SetActive(false);
            mainMenuUI.SetActive(true);
        }
        if(HasGameStartedValue==0){
            updatePanel.SetActive(true);
            mainMenuUI.SetActive(false);
        }

        adminPanel.SetActive(false);
        adminPasswordPanel.SetActive(false);

        random=UnityEngine.Random.Range(0,2);
        if(random==0 || random==1){
            image.enabled=false;
        }
        if(random==2){
            image.enabled=true;
        }
    }

    private void Update(){
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.F10)){
            adminPasswordPanel.SetActive(true);
        }
    }
    public void Play(){
        PlayAnimator.Play("Play",0,0.0f);
    }
    public void BackFromPlay(){
        PlayAnimator.Play("Back",0,0.0f);
    }

    public void QuitGame()
    {
        // Quit the application (works in standalone builds)
        Application.Quit();
        Debug.Log("QuitGame");
    }
    public void Agree(){
        PlayerPrefs.SetInt("GameStarted",1);
        AgreementPopUp.SetActive(false);
    }
    public void SetSensitivity(){
        PlayerPrefs.SetFloat("Sensitivity",1f);
        return;
    }

    public void EnterPassword(){
        if(textField.text.ToString()==password){
            adminPanel.SetActive(true);
            adminPasswordPanel.SetActive(false);
        }
    }

    public void SetGameStarted(){
        PlayerPrefs.SetInt("IsGameStarted",1);
    }
    public void ClearGameStarted(){
        PlayerPrefs.SetInt("IsGameStarted",0);
    }

    /*public void UpdateUi(){
        tMP_Text.text=PlayerPrefs.GetInt("Coins").ToString();
        return;
    }*/
}

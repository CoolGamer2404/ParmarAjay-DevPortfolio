using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField]private GameObject gameCamera;
    [SerializeField]private MainQuestHandler mainQuestHandler;
    [SerializeField]private StarterAssetsInputs starterAssetsInputs;
    [SerializeField]private FirstPersonController firstPersonController;
    [SerializeField]private GameObject MiniMap;
    [SerializeField]private GameObject MainMenuUI;
    [SerializeField]private AudioSource audioSourceMain;
    [SerializeField]private AudioClip audioClipMain;
    // Start is called before the first frame update
    void Start()
    {
        gameCamera.SetActive(true);
        starterAssetsInputs.cursorLocked=false;
        starterAssetsInputs.cursorInputForLook=false;
        firstPersonController.enabled=false;
        Cursor.lockState =  CursorLockMode.None;
        MiniMap.SetActive(false);
        MainMenuUI.SetActive(true);
        audioSourceMain.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(){
        gameCamera.SetActive(false);
        MiniMap.SetActive(true);
        mainQuestHandler.StartGame();
        starterAssetsInputs.cursorLocked=true;
        starterAssetsInputs.cursorInputForLook=true;
        firstPersonController.enabled=true;
        Cursor.lockState =  CursorLockMode.Locked;
        MainMenuUI.SetActive(false);
        audioSourceMain.Stop();
    }

    public void Restart(){
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
    }
}

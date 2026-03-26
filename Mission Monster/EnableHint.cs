using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnableHint : MonoBehaviour
{
    [SerializeField]private GameObject visionHint;
    [SerializeField]private StarterAssetsInputs starterAssetsInputs;
    [SerializeField]private FirstPersonController firstPersonController;
    public void ShowVisionHint(){
        visionHint.SetActive(true);
        starterAssetsInputs.cursorLocked=false;
        starterAssetsInputs.cursorInputForLook=false;
        firstPersonController.enabled=false;
        Cursor.lockState =  CursorLockMode.None;
    }
    public void CloseVisionHint(){
        visionHint.SetActive(false);
        firstPersonController.enabled=true;
        starterAssetsInputs.cursorLocked=true;
        starterAssetsInputs.cursorInputForLook=true;
        Cursor.lockState =  CursorLockMode.Locked;
    }
}

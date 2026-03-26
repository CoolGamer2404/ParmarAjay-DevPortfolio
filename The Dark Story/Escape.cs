using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Escape : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private InputAction escapeAction;
    [SerializeField] public bool isSafeMenuActive=false;

    [SerializeField] private GameObject uiMenu;
    public StarterAssetsInputs starterAssetsInputs;

    public static bool isdeathmenuActive = false;
    public bool isdmenuActive = false;

    private bool isMenuActive = false; // Track whether the menu is active

    void Start()
    {
        escapeAction = inputActionAsset.FindAction("Escape");
        escapeAction.Enable();
        UpdateCursorVisibility();
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        isdmenuActive=isdeathmenuActive;
        if (escapeAction.triggered && !isSafeMenuActive)
        {
            isMenuActive = !isMenuActive;
            if(Time.timeScale==0f){
                Time.timeScale=1f;
                //Debug.Log("TimeScaleIs="+Time.timeScale.ToString());
            }
            else{
                Time.timeScale=0f;
                //Debug.Log("TimeScaleIs="+Time.timeScale.ToString());
            }
            starterAssetsInputs.cursorLocked = !starterAssetsInputs.cursorLocked;
            starterAssetsInputs.ChangeCursorstate();

            uiMenu.SetActive(isMenuActive);
            UpdateCursorVisibility();
            Debug.Log("escapeAction.triggered");
        }
    }

    public void EscapeKeyDown()
    {
        if (isdeathmenuActive==false)
        {
            isMenuActive = !isMenuActive;
            if(Time.timeScale==0f){
                Time.timeScale=1f;
                //Debug.Log("TimeScaleIs="+Time.timeScale.ToString());
            }
            else{
                Time.timeScale=0f;
                //Debug.Log("TimeScaleIs="+Time.timeScale.ToString());
            }

            starterAssetsInputs.cursorLocked = !starterAssetsInputs.cursorLocked;
            starterAssetsInputs.ChangeCursorstate();

            uiMenu.SetActive(isMenuActive);
            UpdateCursorVisibility();
            Debug.Log("EscapeKeyDown");
        }
    }
    public void SetDeathMenuActive()
    {
        isdeathmenuActive = !isdeathmenuActive;
        starterAssetsInputs.cursorLocked = !starterAssetsInputs.cursorLocked;
        starterAssetsInputs.ChangeCursorstate();
        UpdateCursorVisibility();
        Debug.Log("Camefrom++++SetDeathMenuActive");
        return;
    }

    private void UpdateCursorVisibility()
    {
        // Show the cursor if it's not locked, hide it if it's locked.
        Cursor.visible = !starterAssetsInputs.cursorLocked;
        Debug.Log("CursorIsVisible"+starterAssetsInputs.cursorLocked.ToString());
    }
}

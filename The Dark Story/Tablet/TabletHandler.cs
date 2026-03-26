using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class TabletHandler : MonoBehaviour
{
    [Header("-------------------InputsSystemPc-------------------")]
    [SerializeField] private InputActionAsset inputActionAsset;

    [SerializeField] private InputAction tabletOpenAction;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;

    [Header("--------------------------TabletInfo--------------------------")]
    [SerializeField] private bool isTabletOn = false;
    [SerializeField] private int waitTime = 1;
    [SerializeField] public static bool tabletGot = false;
    [SerializeField] private ForceFieldCollider forceFieldCollider;
    [SerializeField] private GameObject forceField;

    [Header("---------------------------TabletUI---------------------------")]
    [SerializeField] public GameObject mainUI;
    [SerializeField] public GameObject mainBorder;
    [SerializeField] public GameObject lockUI;
    public GameObject appUI;
    //[SerializeField]private GameObject chargingUI;
    [SerializeField] public GameObject forceFieldUI;
    [SerializeField] public Animator tabletAnimator;
    [SerializeField] public Escape escape;

    [SerializeField] public TMP_Text errorText;
    [SerializeField] private int uiTime=3;

    [Header("--------------------------TabletSounds--------------------------")]
    [SerializeField] private AudioSource tabletAudioSource;
    [SerializeField] private AudioClip tabletOpenAudioClip;
    [SerializeField] private AudioClip tabletCloseAudioClip;
    [SerializeField] private AudioClip tabletErrorAudioClip;

    public void Start()
    {
        tabletOpenAction = inputActionAsset.FindAction("Tablet");
        tabletOpenAction.Enable();
    }

    // Update is called once per frame
    public void Update()
    {
        if (tabletGot)
        {
            if (tabletOpenAction.triggered)
            {
                if (!isTabletOn)
                {
                    StartCoroutine(OpenTablet());
                    return;
                }
                if(isTabletOn){
                    StartCoroutine(CloseTablet());
                    return;
                }
            }
        }
    }

    public void Unlock()
    {
        tabletAnimator.Play("Unlock");
    }

    public void Unlocked(){
        lockUI.SetActive(false);
        mainUI.SetActive(true);
        mainBorder.SetActive(true);
        appUI.SetActive(true);
    }

    public void PlayforceFieldDesign(){
        tabletAnimator.Play("ForceFieldDesign");
    }

    public void BackFromForcefieldApp(){
        tabletAnimator.Play("Unlocked");
    }

    public IEnumerator OpenTablet()
    {
        tabletAnimator.Play("StaticLock");
        tabletAudioSource.PlayOneShot(tabletOpenAudioClip);
        lockUI.SetActive(true);
        mainBorder.SetActive(false);
        //chargingUI.SetActive(false);
        forceFieldUI.SetActive(false);
        starterAssetsInputs.cursorLocked = false;
        starterAssetsInputs.cursorInputForLook = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        yield return new WaitForSeconds(waitTime);
        isTabletOn = true;
    }
    public IEnumerator CloseTablet()
    {
        tabletAnimator.Play("StaticEmpty");
        tabletAudioSource.PlayOneShot(tabletCloseAudioClip);
        lockUI.SetActive(false);
        mainBorder.SetActive(false);
        //chargingUI.SetActive(false);
        forceFieldUI.SetActive(false);
        appUI.SetActive(false);
        starterAssetsInputs.cursorLocked = true;
        starterAssetsInputs.cursorInputForLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;        
        yield return new WaitForSeconds(waitTime);
        isTabletOn = false;
    }

    public void turnOffForceField(){
        if(forceFieldCollider.isPlayerInCollider && TaskTextHandler.documentsCollected==5){
            forceField.SetActive(false);
        }
        else if(forceFieldCollider.isPlayerInCollider==false){
            tabletAudioSource.PlayOneShot(tabletErrorAudioClip);
            StartCoroutine(ShowUIText("Error! ForceField Is Out Of Range!"));
            //Debug.Log("You Need To Go In Range");
        }
        else if(forceFieldCollider.isPlayerInCollider && TaskTextHandler.documentsCollected != 5)
        {
            tabletAudioSource.PlayOneShot(tabletErrorAudioClip);
            StartCoroutine(ShowUIText("You Can't Escape Before Collecting All 5 Documents!"));
            //Debug.Log("I need to collect all 5 documents before leaving");
        }
    }

    private IEnumerator ShowUIText(string txt)
        {
            errorText.text = txt;
            yield return new WaitForSeconds(uiTime);
            errorText.text = null;
        }
}
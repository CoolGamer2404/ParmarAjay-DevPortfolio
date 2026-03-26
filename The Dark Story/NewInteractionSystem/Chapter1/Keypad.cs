using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text passwordInput;
    [SerializeField] private StarterAssetsInputs StarterAssetsInputs;
    [SerializeField] private GameObject SafeUI;
    [SerializeField] private Escape escape;

    [SerializeField] public bool isUnlocked = false;
    [SerializeField] private int WaitTime = 2;

    [SerializeField] private int SafeNo;


    public void Input(int number)
    {
        passwordInput.text += number;
    }
    public void Cancel()
    {
        if (passwordInput.text.Length > 0)
        {
            passwordInput.text = passwordInput.text.Substring(0, passwordInput.text.Length - 1);
        }
    }
    public void Enter()
    {
        if (SafeNo == 1)
        {
            if (passwordInput.text == Safe.GenratedPassWord.ToString())
            {
                isUnlocked = true;
                passwordInput.text = "UNLOCKED";
                escape.isSafeMenuActive = false;
                passwordInput.text = null;
                SafeUI.SetActive(false);
                StarterAssetsInputs.cursorLocked = true;
                StarterAssetsInputs.cursorInputForLook = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (passwordInput.text != Safe.GenratedPassWord.ToString())
            {
                StartCoroutine(WaitForSomeTime());
                Debug.Log("Locked");
            }
        }
        if (SafeNo == 2)
        {
            if (passwordInput.text == Safe2Handler.GenratedPassWord.ToString())
            {
                isUnlocked = true;
                passwordInput.text = "UNLOCKED";
                escape.isSafeMenuActive = false;
                passwordInput.text = null;
                SafeUI.SetActive(false);
                StarterAssetsInputs.cursorLocked = true;
                StarterAssetsInputs.cursorInputForLook = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (passwordInput.text != Safe2Handler.GenratedPassWord.ToString())
            {
                StartCoroutine(WaitForSomeTime());
                Debug.Log("Locked");
            }
        }
    }
    public void Close()
    {
        escape.isSafeMenuActive = false;
        passwordInput.text = null;
        SafeUI.SetActive(false);
        StarterAssetsInputs.cursorLocked = true;
        StarterAssetsInputs.cursorInputForLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private IEnumerator WaitForSomeTime()
    {
        passwordInput.text = "INVALID";
        yield return new WaitForSeconds(WaitTime);
        passwordInput.text = null;
    }
}

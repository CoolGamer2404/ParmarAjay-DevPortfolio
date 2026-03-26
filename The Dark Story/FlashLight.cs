using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    [Header("---------------------------------InputsSystemPc---------------------------------")]
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private InputAction flashLghtAction;

    [Header("---------------------------------FlashLightReferences---------------------------------")]
    [SerializeField] private GameObject flashLight;
    [SerializeField] private bool isChapter1 = false;
    public static bool isGotFlashLight = false;
    public static bool flashLightOn = false;


    private void Start()
    {
        flashLghtAction = inputActionAsset.FindAction("FlashLight");
        flashLghtAction.Enable();
        flashLight.SetActive(false);
    }

    private void Update()
    {
        if (isChapter1 == false)
        {
            if (flashLghtAction.triggered)
            {
                if (flashLightOn)
                {
                    flashLightOn = false;
                    flashLight.SetActive(false);
                    return;
                }
                if (!flashLightOn)
                {
                    flashLightOn = true;
                    flashLight.SetActive(true);
                    return;
                }
            }
        }
        if (isChapter1)
        {
            if (isGotFlashLight)
            {
                if (flashLghtAction.triggered)
                {
                    if (flashLightOn)
                    {
                        flashLightOn = false;
                        flashLight.SetActive(false);
                        return;
                    }
                    if (!flashLightOn)
                    {
                        flashLightOn = true;
                        flashLight.SetActive(true);
                        return;
                    }
                }
            }
        }
    }
}

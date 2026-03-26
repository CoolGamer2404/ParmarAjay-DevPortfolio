using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class FlashLightHandler : MonoBehaviour
{
    public Image FlashLightButtonImage;

    public Sprite FlashLightOff;
    public Sprite FlashLightOn;

    public static bool isFlashLightOn;

    public GameObject FlashLightgameObject;

    // Start is called before the first frame update
    void Start()
    {
        isFlashLightOn=false;
        FlashLightButtonImage.sprite=FlashLightOn;
        FlashLightgameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isFlashLightOn==true){
            FlashLightButtonImage.sprite=FlashLightOn;
            FlashLightgameObject.SetActive(true);
        }
        if(isFlashLightOn==false){
            FlashLightButtonImage.sprite=FlashLightOff;
            FlashLightgameObject.SetActive(false);
        }
        if(CrossPlatformInputManager.GetButtonDown("FlashLight")){
            if(isFlashLightOn==false){
                isFlashLightOn=true;
                return;
            }
            if(isFlashLightOn==true){
                isFlashLightOn=false;
                return;
            }
        }
    }
}

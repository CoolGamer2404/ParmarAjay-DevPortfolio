using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class LoopRoomsHandler : MonoBehaviour
{
    [SerializeField] public int currentRoomNo;
    [SerializeField] private float[] RoomsOxygen;

    [SerializeField] private GameObject Oxygen;

    //[SerializeField] private Slider slider;

    [SerializeField] private Image image;
    [SerializeField] private GameObject deathUI;
    [SerializeField] private Escape escape;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;

    void Start()
    {
        for (int i = 0; i < RoomsOxygen.Length; i++)
        {
            RoomsOxygen[i] = 15f;
        }
    }
    void Update()
    {
        if (currentRoomNo == 0 || currentRoomNo == 19)
        {
            Oxygen.SetActive(false);
        }
        if (currentRoomNo != 0 && currentRoomNo != 19)
        {
            Oxygen.SetActive(true);
            RoomsOxygen[currentRoomNo] -= Time.deltaTime;
            //slider.value = RoomsOxygen[currentRoomNo];
            image.fillAmount = RoomsOxygen[currentRoomNo] / 15f;
            if (RoomsOxygen[currentRoomNo] <= 0f)
            {
                //Debug.Log("You Are Dead!!!!!!!!");
                deathUI.SetActive(true);
                escape.isdmenuActive = true;
                starterAssetsInputs.cursorLocked = false;
                starterAssetsInputs.cursorInputForLook = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                /*for (int i = 0; i < RoomsOxygen.Length; i++)
                {
                    Debug.Log("Oxygen Of Room No"+i+"is"+RoomsOxygen[i]);
                }*/
            }
        }
    }

    public void ResetAllData(){
        for (int i = 0; i < RoomsOxygen.Length; i++)
        {
            RoomsOxygen[i] = 15f;
        }
        currentRoomNo=0;
    }

}

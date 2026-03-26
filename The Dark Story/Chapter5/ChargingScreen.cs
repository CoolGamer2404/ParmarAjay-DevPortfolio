using System.Collections;
using System.Collections.Generic;
using Chapter5;
using UnityEngine;
using UnityEngine.UI;

public class ChargingScreen : MonoBehaviour
{
    [Header("---------------------ChargingUI---------------------")]
    [SerializeField] public static float currentCharging = 0f;
    [SerializeField] private GameObject Charge0;
    [SerializeField] private GameObject Charge20;
    [SerializeField] private GameObject Charge40;
    [SerializeField] private GameObject Charge60;
    [SerializeField] private GameObject Charge80;
    [SerializeField] private GameObject Charge100;
    [SerializeField] private GameObject mainChargingUI;
    [SerializeField] private Sprite redChargingPoint;
    [SerializeField] private Sprite orangeChargingPoint;
    [SerializeField] private Sprite greenChargingPoint;

    [SerializeField] public bool isBrokenTabletPlaced=true;
    [SerializeField] public bool isTabletPlaced=false;
    [SerializeField] public Animator animator;
    [SerializeField] private Transform parentTablet;

    [SerializeField] private AllInteractionsHandlerChapter5 tabletInteractionHandler;


    void Update()
    {
        if(isBrokenTabletPlaced){
            mainChargingUI.SetActive(true);
            animator.Play("Error");
        }
        if (isTabletPlaced)
        {
            tabletInteractionHandler.ChangeToNotPickup();
            mainChargingUI.SetActive(true);
            animator.Play("Charge");
            if (currentCharging == 0f)
            {
                //----------------------Set Active Charging Points----------------------
                Charge0.gameObject.SetActive(true);
                Charge20.gameObject.SetActive(false);
                Charge40.gameObject.SetActive(false);
                Charge60.gameObject.SetActive(false);
                Charge80.gameObject.SetActive(false);
                Charge100.gameObject.SetActive(false);
                //----------------------Set Color According Charge----------------------
                Charge0.GetComponent<Image>().sprite = redChargingPoint;
            }
            else if (currentCharging == 20f)
            {
                //----------------------Set Active Charging Points----------------------
                Charge0.gameObject.SetActive(true);
                Charge20.gameObject.SetActive(true);
                Charge40.gameObject.SetActive(false);
                Charge60.gameObject.SetActive(false);
                Charge80.gameObject.SetActive(false);
                Charge100.gameObject.SetActive(false);
                //----------------------Set Color According Charge----------------------
                Charge0.GetComponent<Image>().sprite = orangeChargingPoint;
                Charge20.GetComponent<Image>().sprite = orangeChargingPoint;
            }
            else if (currentCharging == 40f)
            {
                //----------------------Set Active Charging Points----------------------
                Charge0.gameObject.SetActive(true);
                Charge20.gameObject.SetActive(true);
                Charge40.gameObject.SetActive(true);
                Charge60.gameObject.SetActive(false);
                Charge80.gameObject.SetActive(false);
                Charge100.gameObject.SetActive(false);
                //----------------------Set Color According Charge----------------------
                Charge0.GetComponent<Image>().sprite = greenChargingPoint;
                Charge20.GetComponent<Image>().sprite = greenChargingPoint;
                Charge40.GetComponent<Image>().sprite = greenChargingPoint;
            }
            else if (currentCharging == 60f)
            {
                //----------------------Set Active Charging Points----------------------
                Charge0.gameObject.SetActive(true);
                Charge20.gameObject.SetActive(true);
                Charge40.gameObject.SetActive(true);
                Charge60.gameObject.SetActive(true);
                Charge80.gameObject.SetActive(false);
                Charge100.gameObject.SetActive(false);
                //----------------------Set Color According Charge----------------------
                Charge0.GetComponent<Image>().sprite = greenChargingPoint;
                Charge20.GetComponent<Image>().sprite = greenChargingPoint;
                Charge40.GetComponent<Image>().sprite = greenChargingPoint;
                Charge60.GetComponent<Image>().sprite = greenChargingPoint;
            }
            else if (currentCharging == 80f)
            {
                //----------------------Set Active Charging Points----------------------
                Charge0.gameObject.SetActive(true);
                Charge20.gameObject.SetActive(true);
                Charge40.gameObject.SetActive(true);
                Charge60.gameObject.SetActive(true);
                Charge80.gameObject.SetActive(true);
                Charge100.gameObject.SetActive(false);
                //----------------------Set Color According Charge----------------------
                Charge0.GetComponent<Image>().sprite = greenChargingPoint;
                Charge20.GetComponent<Image>().sprite = greenChargingPoint;
                Charge40.GetComponent<Image>().sprite = greenChargingPoint;
                Charge60.GetComponent<Image>().sprite = greenChargingPoint;
                Charge80.GetComponent<Image>().sprite = greenChargingPoint;
            }
            else if (currentCharging == 100f)
            {
                //----------------------Set Active Charging Points----------------------
                Charge0.gameObject.SetActive(true);
                Charge20.gameObject.SetActive(true);
                Charge40.gameObject.SetActive(true);
                Charge60.gameObject.SetActive(true);
                Charge80.gameObject.SetActive(true);
                Charge100.gameObject.SetActive(true);
                //----------------------Set Color According Charge----------------------
                Charge0.GetComponent<Image>().sprite = greenChargingPoint;
                Charge20.GetComponent<Image>().sprite = greenChargingPoint;
                Charge40.GetComponent<Image>().sprite = greenChargingPoint;
                Charge60.GetComponent<Image>().sprite = greenChargingPoint;
                Charge80.GetComponent<Image>().sprite = greenChargingPoint;
                Charge100.GetComponent<Image>().sprite = greenChargingPoint;

                //---------------------
                //tabletInteractionHandler.ChangeToPickup();
                tabletInteractionHandler.ChangePickUpNameToChargedTablet();
            }
        }
        if(parentTablet.childCount!=1){
            animator.Play("StaticEmpty");
            mainChargingUI.SetActive(false);
            isTabletPlaced=false;
            isBrokenTabletPlaced=false;
        }

    }

    public void Charge()
    {
        currentCharging += 20f;
        return;
    }
}

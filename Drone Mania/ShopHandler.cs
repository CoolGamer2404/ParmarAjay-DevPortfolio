using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    public Sprite emptyUpgradePointImage;
    public Sprite availableUpgradePointImage;
    public Sprite usedUpgradePointImage;

    [SerializeField]
    public int currentSelectedDrone = 0;

    [SerializeField]
    private int totalDronesAvailable;

    [SerializeField]
    private GameObject[] dronesStats;

    [SerializeField]
    private Image[] droneSelectionCircles;

    [SerializeField]
    private Sprite selectedDroneCircle;

    [SerializeField]
    private Sprite deSelectedDroneCircle;

    [SerializeField]
    private GameObject nextBTN;

    [SerializeField]
    private GameObject previousBTN;

    [SerializeField]
    private Vector2 smallCircleSize;

    [SerializeField]
    private Vector2 bigCircleSize;

    [SerializeField]
    private GameObject[] drones;

    void Start()
    {
        UpdateSelection();
        UpdateDroneShowCase();
        if (PlayerPrefs.GetInt("EquippedDrone") == null || PlayerPrefs.GetInt("EquippedDrone") == 0)
        {
            PlayerPrefs.SetInt("EquippedDrone", 1);
        }
    }

    // Update is called once per frame
    void Update() { }

    public void NextDrone()
    {
        if (currentSelectedDrone == totalDronesAvailable)
        {
            return;
        }
        if (currentSelectedDrone != totalDronesAvailable)
        {
            currentSelectedDrone += 1;
            UpdateSelection();
            UpdateDroneShowCase();
            return;
        }
    }

    public void PreviousDrone()
    {
        if (currentSelectedDrone == 0)
        {
            return;
        }
        if (currentSelectedDrone != 0)
        {
            currentSelectedDrone -= 1;
            UpdateSelection();
            UpdateDroneShowCase();
            return;
        }
    }

    public void UpdateSelection()
    {
        if (currentSelectedDrone == 0)
        {
            dronesStats[0].SetActive(true);
            previousBTN.SetActive(false);
            nextBTN.SetActive(true);
            droneSelectionCircles[0].sprite = selectedDroneCircle;
            droneSelectionCircles[0].GetComponent<RectTransform>().sizeDelta = bigCircleSize;
            for (int i = 1; i < totalDronesAvailable; i++)
            {
                dronesStats[i].SetActive(false);
                droneSelectionCircles[i].sprite = deSelectedDroneCircle;
                droneSelectionCircles[i].GetComponent<RectTransform>().sizeDelta = smallCircleSize;
            }
        }
        else if (currentSelectedDrone != 0 && currentSelectedDrone != totalDronesAvailable)
        {
            for (int i = 0; i < totalDronesAvailable + 1; i++)
            {
                dronesStats[i].SetActive(false);
                droneSelectionCircles[i].sprite = deSelectedDroneCircle;
                droneSelectionCircles[i].GetComponent<RectTransform>().sizeDelta = smallCircleSize;
            }
            dronesStats[currentSelectedDrone].SetActive(true);
            droneSelectionCircles[currentSelectedDrone].sprite = selectedDroneCircle;
            droneSelectionCircles[currentSelectedDrone].GetComponent<RectTransform>().sizeDelta =
                bigCircleSize;
            previousBTN.SetActive(true);
            nextBTN.SetActive(true);
        }
        else if (currentSelectedDrone == totalDronesAvailable)
        {
            dronesStats[totalDronesAvailable].SetActive(true);
            previousBTN.SetActive(true);
            nextBTN.SetActive(false);
            droneSelectionCircles[totalDronesAvailable].sprite = selectedDroneCircle;
            droneSelectionCircles[currentSelectedDrone].GetComponent<RectTransform>().sizeDelta =
                bigCircleSize;
            for (int i = 0; i < totalDronesAvailable; i++)
            {
                dronesStats[i].SetActive(false);
                droneSelectionCircles[i].sprite = deSelectedDroneCircle;
                droneSelectionCircles[i].GetComponent<RectTransform>().sizeDelta = smallCircleSize;
            }
        }
    }

    public void Buy(int number)
    {
        UpdateSelection();
    }

    public void Equip()
    {
        UpdateSelection();
        PlayerPrefs.SetInt("EquippedDrone", currentSelectedDrone + 1);
        return;
    }

    void UpdateDroneShowCase()
    {
        for (int i = 0; i < drones.Length; i++)
        {
            if (i == currentSelectedDrone)
            {
                drones[i].SetActive(true);
            }
            else if (i != currentSelectedDrone)
            {
                drones[i].SetActive(false);
            }
        }
    }
}

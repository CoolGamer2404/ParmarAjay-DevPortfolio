using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private bool isMainMenuSettings = false;
    private DroneController playerDroneController;

    // Start is called before the first frame update
    void Start()
    {
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        if (PlayerPrefs.GetFloat("Sensitivity") == 0)
        {
            PlayerPrefs.SetFloat("Sensitivity", 180f);
            sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");
        }
        else if (PlayerPrefs.GetFloat("Sensitivity") != 0) { sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity"); }

        if (!isMainMenuSettings)
        {
            playerDroneController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<DroneController>();
            playerDroneController.maxYawSpeed = PlayerPrefs.GetFloat("Sensitivity");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSensitivityChanged(float value)
    {
        // Update the sensitivity based on the slider's value
        PlayerPrefs.SetFloat("Sensitivity", value);
        if (playerDroneController == null)
        {
            playerDroneController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<DroneController>();
            playerDroneController.maxYawSpeed = PlayerPrefs.GetFloat("Sensitivity");
        }
        else if (playerDroneController != null) { playerDroneController.maxYawSpeed = PlayerPrefs.GetFloat("Sensitivity"); }
    }
}

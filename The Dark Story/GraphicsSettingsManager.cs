using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingsManager : MonoBehaviour
{
    public Dropdown graphicsDropdown;

    private void Start()
    {
        // Initialize the Dropdown options and set the default preset
        /*List<string> presetNames = new List<string>();

        // Populate the dropdown options from the preset names
        foreach (Dropdown.OptionData option in graphicsDropdown.options)
        {
            presetNames.Add(option.text);
        }*/

        // Set the default graphics preset
        int defaultPresetIndex = PlayerPrefs.GetInt("Graphics"); // Set the index for your default preset
        SetGraphicsPreset(PlayerPrefs.GetInt("Graphics"));
        graphicsDropdown.value = PlayerPrefs.GetInt("Graphics");

        // Listen for changes to the dropdown
        graphicsDropdown.onValueChanged.AddListener(OnGraphicsPresetChanged);
    }

    private void OnGraphicsPresetChanged(int presetIndex)
    {
        // Handle graphics preset changes
        SetGraphicsPreset(presetIndex);
        PlayerPrefs.SetInt("Graphics", presetIndex);
    }

    private void SetGraphicsPreset(int presetIndex)
    {
        // Implement your code to apply graphics settings based on the selected preset
        string selectedPreset = graphicsDropdown.options[presetIndex].text;

        switch (selectedPreset)
        {
            case "Very Low":
                // Set very low-quality graphics settings
                QualitySettings.SetQualityLevel(0);
                graphicsDropdown.value = 0;
                PlayerPrefs.SetInt("Graphics", 0);
                break;

            case "Low":
                // Set low-quality graphics settings
                QualitySettings.SetQualityLevel(1);
                graphicsDropdown.value = 1;
                PlayerPrefs.SetInt("Graphics", 1);
                break;

            case "Medium":
                // Set medium-quality graphics settings
                QualitySettings.SetQualityLevel(2);
                    graphicsDropdown.value = 2;
                PlayerPrefs.SetInt("Graphics", 2);
                break;

            case "High":
                // Set high-quality graphics settings
                QualitySettings.SetQualityLevel(3);
                graphicsDropdown.value = 3;
                PlayerPrefs.SetInt("Graphics", 3);
                break;

            case "Very High":
                // Set very high-quality graphics settings
                QualitySettings.SetQualityLevel(4);
                graphicsDropdown.value = 4;
                PlayerPrefs.SetInt("Graphics", 4);
                break;

            case "Ultra":
                // Set ultra-quality graphics settings
                QualitySettings.SetQualityLevel(5);
                graphicsDropdown.value = 5;
                PlayerPrefs.SetInt("Graphics", 5);
                break;

            default:
                break;
        }
    }
}

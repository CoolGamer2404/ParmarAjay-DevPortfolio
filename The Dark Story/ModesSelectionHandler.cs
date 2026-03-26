using UnityEngine;
using UnityEngine.UI;
using System;

public class ModesSelectionHandler : MonoBehaviour
{
    public Dropdown dropdown;
    public GamesModshandler gamesModshandler;

    // Start is called before the first frame update
    void Start()
    {
        // Set the dropdown options based on the enum values
        //dropdown.AddOptions(new List<string>(Enum.GetNames(typeof(GamesModshandler._SelectedMod))));

        // Set the initial value of the dropdown based on the current selected mode
        dropdown.value = (int)gamesModshandler._selectedMod;
        dropdown.RefreshShownValue();

        // Add a listener to the dropdown to handle mode changes
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    // Callback when the dropdown value changes
    void OnDropdownValueChanged(int index)
    {
        // Update the selected mode in the GamesModshandler script
        //gamesModshandler._selectedMod=gamesModshandler.;
    }
}

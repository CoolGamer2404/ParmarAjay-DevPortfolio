using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesModshandler : MonoBehaviour
{
    public enum _SelectedMod
    {
        Tutorial,//This will be not available
        Easy,
        Normal,//This will be not available
        Medium,
        Hard,
        Extreme//This will be not available 
    }

    public _SelectedMod _selectedMod=_SelectedMod.Medium;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    ///////*
    //Summory//
    //Get slected mod info
    //turn of or on scripts thta are realted tp that mod
    //make specific doors and drawers locked in relatipn of that mod
    //Adjust spped of enmey anhd player acoording to mod
    //End script to optimize
    //////*/
}

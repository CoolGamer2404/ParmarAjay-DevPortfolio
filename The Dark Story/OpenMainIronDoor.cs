using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMainIronDoor : MonoBehaviour
{
    [SerializeField]private IronCellDoors ironCellDoors;
    [SerializeField]private GameObject cutScenePlayer;
    
    public void open(){
        ironCellDoors.Open();
        cutScenePlayer.SetActive(true);
    }
}

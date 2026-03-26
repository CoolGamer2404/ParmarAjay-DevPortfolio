using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DroneSkinWebData", menuName = "MDG/ScriptableObjects/DroneSkinWebData")]
public class DroneSkinWebDataScriptableObject : ScriptableObject
{
    [Header("WebData")]
    public String link;
    public String resourceSize;
    public int droneNum;
    public int skinNum;

    [Header("DownloadData")]
    public String downloadLink;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item1",menuName ="MDG/ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public GameObject itemDrop;
}

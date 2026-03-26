using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DroneData", menuName = "MDG/ScriptableObjects/DroneData")]
public class DroneDataScriptableObject : ScriptableObject
{
    [Serializable]
    public class DroneDataClass{
        public MeshRenderer meshRenderer;
        public int MaterialInMashNumber;
        public int MaterialIndex;
    }

    public List<DroneDataClass>droneData;
}

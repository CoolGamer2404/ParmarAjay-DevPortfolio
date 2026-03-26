using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin1", menuName = "MDG/ScriptableObjects/Skin")]
public class SkinsScriptableGameObject : ScriptableObject
{
    public bool isThisSkinActive=false;
    public SkinsScriptableGameObject[] curentDroneOtherSkins;
    public int DroneNumber=0;
    public int skinNumber;
    
    [Serializable]
    public class SkinData
    {
        #region CommentedOutCode
        //public Material material;
        /*public Texture2D baseMap;
        public Texture2D metallicMap;
        public Texture2D normalMap;
        public Texture2D heightMap;
        public bool isEmission;
        [ColorUsage(true,true)]
        public Color emissionColor;*/
        #endregion

        public string NameOfMEshRenderer;
        public Material[] materials;
    }

    public List<SkinData> skin;

    public void SetThisSkin(){
        #region CommentedOutCode
        /*foreach (var skinData in skin)
        {
            if (skinData.material != null)
            {
                if (skinData.baseMap != null)
                {
                    skinData.material.SetTexture("_BaseMap", skinData.baseMap);
                }

                if (skinData.metallicMap != null)
                {
                    skinData.material.SetTexture("_MetallicGlossMap", skinData.metallicMap);
                }

                if (skinData.normalMap != null)
                {
                    skinData.material.SetTexture("_BumpMap", skinData.normalMap);
                }

                if (skinData.heightMap != null)
                {
                    skinData.material.SetTexture("_ParallaxMap", skinData.heightMap);
                }
                if(skinData.isEmission){
                    skinData.material.SetVector("_EmissionColor",skinData.emissionColor);
                }
            }
            else
            {
                Debug.LogWarning("Material is null for one of the skins");
            }
        }*/
        #endregion
        
        
        PlayerPrefs.SetInt("Drone"+DroneNumber.ToString()+"CurrentSkin",skinNumber);
        for (int i = 0; i < curentDroneOtherSkins.Length; i++)
        {
            curentDroneOtherSkins[i].isThisSkinActive=false;
        }
        isThisSkinActive = true;
    }
}

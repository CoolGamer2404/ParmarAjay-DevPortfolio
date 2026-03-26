using System.Collections;
using UnityEngine;

namespace Chapter5
{
    public class LightmapActivator : MonoBehaviour
    {
        public Texture2D[] daytimeLightmaps;
        public Texture2D[] nighttimeLightmaps;

        // Function to activate daytime lightmaps
        public void ActivateDaytimeLightmaps()
        {
            StartCoroutine(SetDay());
        }

        // Function to activate nighttime lightmaps
        public void ActivateNighttimeLightmaps()
        {
            LightmapData[] lightmaps = new LightmapData[nighttimeLightmaps.Length];

            for (int i = 0; i < nighttimeLightmaps.Length; i++)
            {
                lightmaps[i] = new LightmapData();
                lightmaps[i].lightmapColor = nighttimeLightmaps[i];
            }

            LightmapSettings.lightmaps = lightmaps;
        }

        public IEnumerator SetDay(){
            LightmapData[] lightmaps = new LightmapData[daytimeLightmaps.Length];

            for (int i = 0; i < daytimeLightmaps.Length; i++)
            {
                lightmaps[i] = new LightmapData();
                lightmaps[i].lightmapColor = daytimeLightmaps[i];
            }
            
            LightmapSettings.lightmaps = lightmaps;
            return null;
        }
    }
}

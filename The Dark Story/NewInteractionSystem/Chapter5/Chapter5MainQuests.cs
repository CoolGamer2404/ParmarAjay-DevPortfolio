using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter5
{
    public class Chapter5MainQuests : MonoBehaviour
    {
        public static bool isRedLightOn=false;
        public static bool isGreenLightOn=false;
        public static bool isBlueLightOn=false;

        public static bool isLightsOn=false;
        public static bool isLightQuestFinished;
        // Start is called before the first frame update
        void Start()
        {
            isBlueLightOn=false;
            isGreenLightOn=false;
            isRedLightOn=false;
            isLightQuestFinished=false;
        }

        // Update is called once per frame
        void Update()
        {
            if(isLightQuestFinished==false){
                LightQueast();
            }
        }
        void LightQueast(){
            if(isRedLightOn && isBlueLightOn && isGreenLightOn){
                isLightsOn=true;
                SwapLightmapUv();
            }
        }
        void SwapLightmapUv(){
            isLightQuestFinished=true;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Rendering;

public class VisionController : MonoBehaviour
{
    [SerializeField]private MonstersSkinsHandler[] monstersSkinsHandlers;
    [SerializeField]private StarterAssetsInputs starterAssetsInputs;
    [SerializeField]private Volume _MonsterVisionVolume;
    public bool isVisionControllable=false;
    [SerializeField]private float cd=1f;
    [SerializeField]private bool isoncd=false;

    private VisionMode visionMode=VisionMode.NormalMode;

    public enum VisionMode{
        NormalMode,
        MonsterMode,
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnableVIsion(){
        isVisionControllable=true;
        return;
    }

    // Update is called once per frame
    void Update()
    {
        if(starterAssetsInputs.vision && isVisionControllable){
            if(!isoncd){
                ChangeVision();
                ChangeVolume();

                isoncd=true;
                Invoke(nameof(ResetCD),cd);
            }
        }
    }

    void ChangeVolume(){
        switch (visionMode)
        {
            case VisionMode.NormalMode:
            visionMode=VisionMode.MonsterMode;
            _MonsterVisionVolume.weight=1;
            break;
            case VisionMode.MonsterMode:
            visionMode=VisionMode.NormalMode;
            _MonsterVisionVolume.weight=0;
            break;
        }
    }

    void ChangeVision(){
        for (int i = 0; i < monstersSkinsHandlers.Length; i++)
        {
            monstersSkinsHandlers[i].ChangeMode();
        }
    }
    void ResetCD(){
        isoncd=false;
    }
}

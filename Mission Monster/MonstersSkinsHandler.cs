using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersSkinsHandler : MonoBehaviour
{
    [SerializeField]private Material[] _monsterMats,_humanMats;
    [SerializeField]private GameObject _body,_ear;
    public VisionMode visionMode=VisionMode.NormalMode;

    public enum VisionMode{
        NormalMode,
        MonsterMode,
    }
    void Start()
    {
        ChangeMats();
    }
    void ChangeMats(){
        if(visionMode==VisionMode.NormalMode){
            _body.GetComponent<SkinnedMeshRenderer>().materials=_humanMats;
            _ear.GetComponent<SkinnedMeshRenderer>().material=_humanMats[0];
        }
        else if(visionMode==VisionMode.MonsterMode){
            _body.GetComponent<SkinnedMeshRenderer>().materials=_monsterMats;
            _ear.GetComponent<SkinnedMeshRenderer>().material=_monsterMats[0];
        }
    }

    public void ChangeMode(){
        switch (visionMode)
        {
            case VisionMode.NormalMode:
            visionMode=VisionMode.MonsterMode;
            ChangeMats();
            break;
            case VisionMode.MonsterMode:
            visionMode=VisionMode.NormalMode;
            ChangeMats();
            break;
        }
    }
}

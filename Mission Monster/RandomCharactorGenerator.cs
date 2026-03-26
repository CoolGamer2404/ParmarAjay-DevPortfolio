using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCharactorGenerator : MonoBehaviour
{
    [Header("Body")]
    [SerializeField]private GameObject _Body;
    [SerializeField]private GameObject _ear;
    [SerializeField]private NPCType _type;
    [SerializeField]private bool _isGenrateRandomType=false;
    [SerializeField]private bool _isFemale=false;

    [Header("Clothes & Accesory")]
    [SerializeField]private GameObject[] _hairs;
    [SerializeField]private GameObject[] _shirts;
    [SerializeField]private GameObject pant;
    [SerializeField]private GameObject[] _boots;

    [Header("Materials")]
    [SerializeField]private Material[] _humanSkinMaterials;
    [SerializeField]private Material[] _monsterSkinMaterials;
    [SerializeField]private Material[] _hairMaterials;
    [SerializeField]private Material[] _shirtMaterials;
    [SerializeField]private Material[] _pantMaterials;
    [SerializeField]private Material[] _bootMaterials;
    [SerializeField]private Material[] _humanFaceMaterials;
    [SerializeField]private Material[] _monsterFaceMaterials;


    GameObject hair;
    GameObject shirt;
    GameObject boot;

    private enum NPCType{
        Human,
        Monster,
    }

    void Start()
    {
        if(_isGenrateRandomType)
        GenrateRandomType();
        if(!_isGenrateRandomType)
        GenerateRandomFace();
    }

    int rand;

    public void GenrateRandomType(){
        rand=Random.Range(0,2);
        switch(rand){
            case 0:_type=NPCType.Human;
            break;
            case 1:_type=NPCType.Monster;
            break;
        }
        GenerateRandomFace();
    }
    public void GenerateRandomFace(){
        switch(_type){
            case NPCType.Human:mats[1]=getRandomMaterial(_humanFaceMaterials);
            break;
            case NPCType.Monster:mats[1]=getRandomMaterial(_monsterFaceMaterials);
            break;
        }
        GetRandomClothes();
    }

    int shirtNumber;

    public void GetRandomClothes(){
        for (int i = 0; i < _hairs.Length; i++)
        {
            _hairs[i].SetActive(false);
        }
        for (int i = 0; i < _shirts.Length; i++)
        {
            _shirts[i].SetActive(false);
        }
        for (int i = 0; i < _boots.Length; i++)
        {
            _boots[i].SetActive(false);
        }
        hair=_hairs[Random.Range(0,_hairs.Length)];
        shirtNumber=Random.Range(0,_shirts.Length);
        shirt=_shirts[shirtNumber];
        boot=_boots[Random.Range(0,_boots.Length)];

        hair.SetActive(true);
        shirt.SetActive(true);
        boot.SetActive(true);
        if(_isFemale && shirtNumber==0){
            pant.SetActive(false);
        }
        else if(!_isFemale || shirtNumber!=0){
            pant.SetActive(true);
        }

        if(hair!=null && shirt !=null && boot!=null)
            SetRandomMaterials();
    }
    [SerializeField]private Material[] mats;
    public void SetRandomMaterials(){
        if(_type==NPCType.Human){
        mats[0]=getRandomMaterial(_humanSkinMaterials);}
        else if(_type==NPCType.Monster){
        mats[0]=getRandomMaterial(_monsterSkinMaterials);}
        hair.GetComponent<SkinnedMeshRenderer>().material=getRandomMaterial(_hairMaterials);
        shirt.GetComponent<SkinnedMeshRenderer>().material=getRandomMaterial(_shirtMaterials);
        pant.GetComponent<SkinnedMeshRenderer>().material=getRandomMaterial(_pantMaterials);
        boot.GetComponent<SkinnedMeshRenderer>().material=getRandomMaterial(_bootMaterials);
        _Body.GetComponent<SkinnedMeshRenderer>().materials=mats;
        _ear.GetComponent<SkinnedMeshRenderer>().material=mats[0];
    }
    
    Material mat;
    Material getRandomMaterial(Material[] materials){
        mat=materials[Random.Range(0,materials.Length)];
        return mat;
    }
}

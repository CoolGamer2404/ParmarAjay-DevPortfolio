using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneStageHandler : MonoBehaviour
{

    public bool Stg1;
    public bool Stg2;
    public bool Stg3;

    public float tm=100f;

    // Update is called once per frame
    void Update()
    {
        Stg1=Input.GetKey("Jump");
        Stg2=Input.GetKey("Stage2");
        tm-=Time.deltaTime;
        UPD();
        UPD2();
    }
    void UPD(){
        if(Stg1==true){
            Debug.Log("test1");
        }
        return;
    }
    void UPD2(){
        if(tm<=0f){
            return;
        }
    }
}

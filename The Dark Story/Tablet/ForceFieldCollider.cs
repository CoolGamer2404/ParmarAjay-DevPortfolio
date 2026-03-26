using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldCollider : MonoBehaviour
{
    public bool isPlayerInCollider;

    public void Start(){
        isPlayerInCollider=false;
    }
    public void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            isPlayerInCollider=true;
        }
    }
    public void OnTriggerExit(Collider other){
        if(other.tag=="Player"){
            isPlayerInCollider=false;
        }
    }
}

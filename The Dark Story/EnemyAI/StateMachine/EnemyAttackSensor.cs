using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Interactions;

public class EnemyAttackSensor : MonoBehaviour
{
    public bool gotPlayer=false;
    private void OnTriggerEnter(Collider other){
        gotPlayer=true;
    }
}

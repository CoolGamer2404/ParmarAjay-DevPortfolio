using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetLacation1;
    public Transform targetLacation2;

    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
    }

    public void Target1(){
        agent.destination=targetLacation1.position;
    }

    public void Target2(){
        agent.destination=targetLacation2.position;
    }
}

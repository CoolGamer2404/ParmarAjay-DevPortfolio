using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[ExecuteInEditMode]
public class SkeletonLocationDubugging : MonoBehaviour
{
    public NavMeshAgent agent;
    void Update()
    {
        Debug.Log(agent.transform.position);
    }
}

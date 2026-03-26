using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{

    [SerializeField]private NavMeshAgent agent;
    [SerializeField]private Animator animator;
    [SerializeField]private GameObject PATH;
    [SerializeField]private float minDistance=1;
    [SerializeField]private Transform[] PathPoints;
    [SerializeField]private bool isRandomSpeed=false;
    [SerializeField]private float min=1.5f,max=2.5f;

    public int index=0;
    void Start()
    {
        if(isRandomSpeed){
            agent.speed=Random.Range(min,max);
        }
        PathPoints=new Transform[PATH.transform.childCount];
        for (int i = 0; i < PathPoints.Length; i++)
        {
            PathPoints[i]=PATH.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Roam();
    }

    void Roam(){
        if(Vector3.Distance(transform.position,PathPoints[index].position)<minDistance){
            if(index >=0 && index<PathPoints.Length-1){
                index+=1;
            }
            else{
                index=0;
            }
        }

        agent.SetDestination(PathPoints[index].position);
        if(animator!=null)
        animator.SetFloat("vertical",!agent.isStopped ? 1 :0);
    }
}

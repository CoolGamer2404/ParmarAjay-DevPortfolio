using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterHandler : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private NavMeshAgent agent;
    public float minDist=1.2f;
    public Transform target;
    public MainQuestHandler mainQuestHandler;

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainQuestHandler.DestroyMonsters)
        Destroy(this.gameObject);
        float dist=Vector3.Distance(transform.position,target.position);
        Debug.Log(dist.ToString());
        if(dist<=minDist){
            //agent.isStopped=true;
            agent.speed=0;
            animator.SetBool("Attack",true);
            animator.SetBool("Walk",false);
        }
        else{
            //agent.isStopped=false;
            animator.SetBool("Attack",false);
            animator.SetBool("Walk",true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour
{
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;

    [SerializeField] private Transform PlayerTransform;

    [SerializeField] private NavMeshAgent spider;
    [SerializeField] private Vector3 distanceOfCurrentTarget;
    [SerializeField] private Transform CurrentTarget;

    [SerializeField] private bool canChange;
    [SerializeField] private int waitTimeForChangingTarget=5;
    [SerializeField] private int standingTime=15;

    [SerializeField] private Animator animator;



    [SerializeField]private float PlayerDistance;
    [SerializeField]private float PlayerAngle;
    [SerializeField]private float MinimumDistance;
    [SerializeField]private float MinimumPlayerAngle;
    [SerializeField]private bool isInPlayerRange;
    [SerializeField]private bool isInPlayerSight;
    [SerializeField]private Vector3 PlayerDirection;
    void Start()
    {
        spider.SetDestination(target1.position);
        CurrentTarget = target1;
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        distanceOfCurrentTarget = CurrentTarget.position - transform.position;
        animator.SetFloat("Speed", spider.velocity.magnitude);
        PlayerDistance=Vector3.Distance(PlayerTransform.position,transform.position);
        PlayerDirection=PlayerTransform.position-spider.transform.position;
        PlayerAngle=Vector3.Angle(spider.transform.forward,PlayerDirection);

        if(PlayerAngle<=MinimumPlayerAngle/2f){
            isInPlayerSight=true;
        }
        if(PlayerDistance<=MinimumDistance){
            isInPlayerRange=true;
        }
        if(PlayerDistance>=MinimumDistance){
            isInPlayerRange=false;
        }
        if(PlayerAngle>=76f){
            isInPlayerSight=false;
        }
        if(isInPlayerRange==true && isInPlayerSight==true){
            FollowPlayer();
        }
        if (distanceOfCurrentTarget.magnitude <= 1f && CurrentTarget!=PlayerTransform)
        {
            animator.SetFloat("Attack", 0f);
            StartCoroutine(Stop());      
        }
        if (distanceOfCurrentTarget.magnitude <= 1f && CurrentTarget==PlayerTransform)
        {
            animator.SetFloat("Attack", 0.3f);
        }
        if (spider.destination == PlayerTransform.position && isInPlayerRange && isInPlayerSight)
        {
            distanceOfCurrentTarget = PlayerTransform.position - transform.position;
        }
        if(spider.destination == PlayerTransform.position && !isInPlayerRange){
            StartCoroutine(Stop());
        }
    }

    private IEnumerator Wait(){
        canChange=false;
        yield return new WaitForSeconds(waitTimeForChangingTarget);
        canChange=true;
    }
    private IEnumerator Stop(){
        yield return new WaitForSeconds(standingTime);
        canChange=true;
        Change();
    }

    private void Change(){
        if (CurrentTarget == target1 && canChange)
        {
            spider.SetDestination(target2.position);
            CurrentTarget = target2;
            canChange=false;
            StopAllCoroutines();
        }
        if (CurrentTarget == target2 && canChange)
        {
            spider.SetDestination(target1.position);
            CurrentTarget = target1;
            canChange=false;
            StopAllCoroutines();
        }
        if(CurrentTarget==PlayerTransform && canChange){
            spider.SetDestination(target1.position);
            CurrentTarget = target1;
            canChange=false;
            StopAllCoroutines();
        }
    }
    private void FollowPlayer(){
        spider.destination=PlayerTransform.position;
        spider.speed=2f;
        CurrentTarget=PlayerTransform;
    }
}

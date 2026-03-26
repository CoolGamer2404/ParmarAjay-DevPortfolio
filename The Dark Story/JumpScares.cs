using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class JumpScares : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]public static bool OnJumpScare=false;
    private float waitTime=5f;

    // Start is called before the first frame update
    void Start()
    {
        OnJumpScare=false;
        animator.enabled=false;
        waitTime=5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(OnJumpScare==true){
            waitTime-=Time.deltaTime;
        }
        if(waitTime<=1f){
            animator.enabled=true;
        }
    }
}

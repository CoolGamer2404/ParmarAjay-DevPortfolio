using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AnimationHandler : MonoBehaviour
{
    public bool isTalking,isIdle;
    public Animator animator;

    void Start()
    {
        if(isTalking){
            animator.SetBool("Talking",true);
            animator.SetBool("Idle",false);
        }
        else if(isIdle){
            animator.SetBool("Idle",true);
            animator.SetBool("Talking",false);
        }
    }

    public void SetIdle(){
        isIdle=true;
        isTalking=false;
        if(isTalking){
            animator.SetBool("Talking",true);
            animator.SetBool("Idle",false);
        }
        else if(isIdle){
            animator.SetBool("Idle",true);
            animator.SetBool("Talking",false);
        }
    }
    public void SetTalking(){
        isIdle=false;
        isTalking=true;
        if(isTalking){
            animator.SetBool("Talking",true);
            animator.SetBool("Idle",false);
        }
        else if(isIdle){
            animator.SetBool("Idle",true);
            animator.SetBool("Talking",false);
        }
    }
}

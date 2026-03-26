using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneZombie : MonoBehaviour
{
    public Animator animator;
    public GameObject Enemy1;
    public GameObject Enemy2;
    void SetActive(){
        Enemy1.SetActive(false);
        Enemy2.SetActive(true);
    }
    void SetOne(){
        animator.SetFloat("Blend",1f);
    }
    void SetTwo(){
        animator.SetFloat("Blend",2f);
    }
    void SetThree(){
        animator.SetFloat("Blend",3f);
    }
    void SetFour(){
        animator.SetFloat("Blend",4f);
    }
    void SetFive(){
        animator.SetFloat("Blend",5f);
    }
}

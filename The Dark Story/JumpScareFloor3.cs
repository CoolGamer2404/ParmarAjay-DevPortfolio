using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareFloor3 : MonoBehaviour
{
    public static bool SkeletonAnim=false;
    [SerializeField]private Animator skeletonAnim;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnim.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider player){
        Debug.Log("True");
        JumpScares.OnJumpScare=true;
    }

    void SetActiveSkeletonAnim(){
        skeletonAnim.enabled=true;
    }
    void DeActiveSkeletonAnim(){
        skeletonAnim.enabled=false;
    }
}

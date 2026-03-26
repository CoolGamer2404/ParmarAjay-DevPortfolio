using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletStandHandler : MonoBehaviour
{
    [SerializeField]private Transform tabletStandParent;
    [SerializeField] public Animator tabletStandAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tabletStandParent.childCount==0){
            tabletStandAnimator.Play("isClose");
        }
        if(tabletStandParent.childCount==1){
            tabletStandAnimator.Play("isOpen");
        }
    }
}

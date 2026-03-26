using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    [SerializeField]private float DestructionTime;
    private static bool isStartedDestructing=false;
    [SerializeField]private bool isStartedDestructingcheck;
    // Start is called before the first frame update
    void Start()
    {
        isStartedDestructing=true;
    }

    // Update is called once per frame
    void Update()
    {
        isStartedDestructingcheck=isStartedDestructing;
        if(isStartedDestructing==true){
            DestructionTime-=Time.deltaTime;
        }
        if(DestructionTime<=0f){
            Destroy(gameObject.transform.parent.transform.gameObject);
        }
    }
}

using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Obstacle : MonoBehaviour
{
    public GameObject t2;
    public float speed; 
    public float lifetime;
    
    // Start is called before the first frame update
    void Start()
    {
        t2=this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*speed* Time.deltaTime);
        lifetime-=Time.deltaTime;
        if(lifetime<=0){
        Destroy(gameObject);
        GameManager.score+=1;
    }

}
    /*private void OnBecamelnvisible()
    {
        GameManager.score+=1; 
        Destroy(gameObject);
    }*/

}
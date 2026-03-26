using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Transform _LookRot;
    public Ritual_zombieSpawner ritual_ZombieSpawner;

    // Start is called before the first frame update
    Vector3 direction;
    public GameObject self;
    void Start()
    {
        
        direction=_LookRot.forward;
        transform.rotation=Quaternion.LookRotation(direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0f)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        Destroy(this.gameObject,40f);
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Monster"){
            Debug.Log("Got Hit");
            GameObject g=collision.gameObject;
            Destroy(g);
            ritual_ZombieSpawner.TotalCurrentZombies-=1;
            Destroy(self);
        }
        if(collision.gameObject.tag!="Monster"){
            Destroy(self);
        }
        else{
            Debug.Log("Colision");
        }
    }
}

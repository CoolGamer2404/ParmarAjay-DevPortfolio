using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrone_Projectile_Move : MonoBehaviour
{
    public float speed;
    public Transform _LookRot;

    // Start is called before the first frame update
    Vector3 direction;
    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        direction=_LookRot.TransformDirection(Vector3.forward);
        transform.rotation=Quaternion.LookRotation(direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0f)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        Destroy(this.gameObject,5f);
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            Destroy(self);
        }
        if(collision.gameObject.tag!="Player"){
            Destroy(self);
        }
    }
}

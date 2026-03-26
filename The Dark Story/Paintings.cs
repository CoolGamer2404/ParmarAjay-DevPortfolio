using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Paintings : MonoBehaviour
{
    public GameObject Painting;
    public float distance;
    public Transform PlayerCamera;
    public float InteractionRange;
    private static bool InteractableWithPainting;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Painting=null;
        rb=null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerCamera.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= InteractionRange)
        {
            InteractableWithPainting = true;
        }
        if (distanceToPlayer.magnitude >= InteractionRange)
        {
            InteractableWithPainting = false;
        }
        if(InteractableWithPainting==true){
            RayCastForPainting();
        }
    }
    void RayCastForPainting(){
        RaycastHit paintinghit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out paintinghit, distance)){
            if(paintinghit.transform.tag=="Painting"){
                Painting=paintinghit.transform.gameObject;
                rb=Painting.GetComponent<Rigidbody>();
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")){
                    rb.isKinematic=false;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float jumpForce;
    bool canJump;
    public Animator animator;
    public int number=0;
    public static int charnum=0;

    //for health 
    public int health;
    


    private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
           
        }

    // Start is called before the first frame update
    void Start()
    {
         /*if(GameManager.IsEquipped[number]==true)
            (
                charnum = number;
                health=GameData.staticHealth;
            )*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) &&  canJump)
        {
            //Jump
            animator.SetBool("isJumping",true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
            animator.SetBool("isJumping",false);
        }
    }
   private void OnCollisionExit(Collision collision)
    {
         if(collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
       if(other.gameObject.tag == "Obstacle") 
       {
            //SceneManager.LoadScene(0);
            GameManager.Health-=1;
       }
    }

}

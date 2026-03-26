using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;

public class ThirdPersonController : MonoBehaviour
{
    public FixedJoystick fixedJoystick;
    protected ThirdPersonUserControl thirdPerson;

    public bool isCrouching = false;
    CapsuleCollider capsuleCollider;
    public bool CrouchButtonPressed = false;
    public float crouchButtonPressedTimer;
    public bool startCountDown;
    public GameObject Check;


    // Start is called before the first frame update
    void Start()
    {
        thirdPerson = GetComponent<ThirdPersonUserControl>();
        //crouchButtonPressedTimer = 1f;
        startCountDown = false;
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        thirdPerson.hInput = fixedJoystick.Horizontal;
        thirdPerson.vInput=fixedJoystick.Vertical;
        Crouch();
        if (CrouchButtonPressed == false && CrossPlatformInputManager.GetButtonDown("crouch"))
        {
            CrouchButtonPressed = true;
            Debug.Log("crouchPressed");
            startCountDown = true;
        }
        if (startCountDown == true)
        {
            crouchButtonPressedTimer -= Time.deltaTime;
        }
        if (CrouchButtonPressed == true && CrossPlatformInputManager.GetButtonDown("crouch")&&crouchButtonPressedTimer<=0)
        {
            CrouchButtonPressed = false;
            Debug.Log("crouchNotPressed");
            crouchButtonPressedTimer = 1f;
            startCountDown=false;
        }
    }

    public void Crouch()
    {
        if (!isCrouching && CrouchButtonPressed == true)
        {
            capsuleCollider.height = 0.8f;
            capsuleCollider.center = new Vector3(0f, 1.2f, 0f);
            isCrouching = true;
            Debug.Log("isCrouching");
        }

        Debug.DrawRay(Check.transform.position, Vector3.up * 1f, Color.cyan);

        if (isCrouching && CrouchButtonPressed == false)
        {
            var cantstandup = Physics.Raycast(Check.transform.position, Vector3.up, 2f);
            if (cantstandup)
            {
                Debug.Log("Something is in the way or on head");
            }
            if (!cantstandup)
            {
                Debug.Log("Everything is just perfect");
            }

            if (!cantstandup)
            {
                capsuleCollider.height = 1.6f;
                capsuleCollider.center = new Vector3(capsuleCollider.center.x, 0.8f, capsuleCollider.center.z);
                isCrouching = false;
                Debug.Log("isnotCrouching");
            }
        }
    }
}

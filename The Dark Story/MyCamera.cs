using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class MyCamera : MonoBehaviour
{
    public class Event : UnityEvent<Vector2> { }
    public Event joystickOutputEvent;

    public float Xaxis;
    public float Yaxis;

    public float RotationSensitivity = 8f;
    public Transform target;

    public float RotationMin;
    public float RotationMax;
    public bool enableMobileInput = false;
    //public Joystick joystick;
    public FixedTouchField touchPanel;
    //public Transform charTransform;

    void Start()
    {
        if (enableMobileInput)
            RotationSensitivity = 0.2f;
    }

    void LateUpdate()
    {
        if (enableMobileInput)
        {
            Yaxis += touchPanel.TouchDist.x * RotationSensitivity;
            Xaxis -= touchPanel.TouchDist.y * RotationSensitivity;
        }
        else
        {
            Yaxis += Input.GetAxis("Mouse X") * RotationSensitivity;
            Xaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
        }

        Xaxis = Mathf.Clamp(Xaxis,RotationMin,RotationMax);
        Vector2 targetRotation = new Vector2(Xaxis,Yaxis);
        //Vector3 charRotation = new Vector3(0f,Yaxis);
        transform.eulerAngles = targetRotation;
        OutputPointerEventValue(targetRotation);
        //charTransform.eulerAngles= charRotation;

        transform.position = target.position - transform.forward * 0f;
    }

    private void OutputPointerEventValue(Vector2 pointerPosition)
    {
        joystickOutputEvent.Invoke(pointerPosition);
    }
}

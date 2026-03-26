using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private const string HORIZONTAL="Horizontal";
    private const string VERTICAL="Vertical";

    [SerializeField]private WheelCollider FrontLeftWheelCollider;
    [SerializeField]private WheelCollider RearLeftWheelCollider;
    [SerializeField]private WheelCollider FrontRightWheelCollider;
    [SerializeField]private WheelCollider RearRightWheelCollider;

    [SerializeField]private Transform FrontLeftWheelTransform;
    [SerializeField]private Transform RearLeftWheelTransform;
    [SerializeField]private Transform FrontRightWheelTransform;
    [SerializeField]private Transform RearRightWheelTransform;

    [SerializeField]private float motorForce;
    [SerializeField]private float breakForce;
    [SerializeField]private float maxSteeringAngle;

    [SerializeField]private float horizontalinput;
    [SerializeField]private float verticalinput;
    [SerializeField]private bool isBreaking;
    [SerializeField]private float currentsteerAngle;
    private float currentbreakForce;

    private void FixedUpdate(){
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput(){
        horizontalinput=Input.GetAxis(HORIZONTAL);
        verticalinput=Input.GetAxis(VERTICAL);

        isBreaking=Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor(){
        FrontLeftWheelCollider.motorTorque = verticalinput * motorForce;
        FrontRightWheelCollider.motorTorque = verticalinput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }
    private void ApplyBreaking(){
        FrontLeftWheelCollider.brakeTorque=currentbreakForce;
        FrontRightWheelCollider.brakeTorque=currentbreakForce;
        RearLeftWheelCollider.brakeTorque=currentbreakForce;
        RearRightWheelCollider.brakeTorque=currentbreakForce;
    }

    private void HandleSteering(){
        currentsteerAngle=maxSteeringAngle*horizontalinput;
        FrontLeftWheelCollider.steerAngle=currentsteerAngle;
        FrontRightWheelCollider.steerAngle=currentsteerAngle;
    }

    private void UpdateWheels(){
        UpdateSingleWheel(FrontLeftWheelCollider,FrontLeftWheelTransform);
        UpdateSingleWheel(FrontRightWheelCollider,FrontRightWheelTransform);
        UpdateSingleWheel(RearLeftWheelCollider,RearLeftWheelTransform);
        UpdateSingleWheel(RearRightWheelCollider,RearRightWheelTransform);
    }
    
    private void UpdateSingleWheel(WheelCollider wheelCollider,Transform wheelTransform){
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos,out rot);
        wheelTransform.position=pos;
        wheelTransform.rotation=rot;
    }
}

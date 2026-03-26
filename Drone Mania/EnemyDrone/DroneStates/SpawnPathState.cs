using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPathState : DroneAIBaseState
{
    public SpawnPathState(DroneAIStateMachine currentContextDroneAI,DroneAIStateFactory StateFactoryDroneAI):base (currentContextDroneAI,StateFactoryDroneAI){}
    public override void EnterState(){
        Debug.Log("I Am Spawned");
        Debug.Log("First Find Drone Base For Me");
        Debug.Log("i Would Like To Wander Solo");
        Debug.Log("Hey! Generate Path");
        Debug.Log("Assign Me Path For Moving");
    }
    public override void UpdateState(){}
    public override void ExitState(){}
    public override void CheckSwitchState(){}
}

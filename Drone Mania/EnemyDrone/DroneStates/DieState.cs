using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : DroneAIBaseState
{
    public DieState(DroneAIStateMachine currentContextDroneAI,DroneAIStateFactory StateFactoryDroneAI):base (currentContextDroneAI,StateFactoryDroneAI){}
    public override void EnterState(){
        //Debug.Log("I Am Dead!!!!!!!!!!!!!!");
    }
    public override void UpdateState(){}
    public override void ExitState(){}
    public override void CheckSwitchState(){}
}

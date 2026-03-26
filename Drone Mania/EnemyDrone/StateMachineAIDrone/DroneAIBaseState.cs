public abstract class DroneAIBaseState 
{
    protected DroneAIStateMachine _ctxDroneAI;
    protected DroneAIStateFactory _factoryDroneAI;
    public DroneAIBaseState(DroneAIStateMachine currentContextDroneAI,DroneAIStateFactory StateFactoryDroneAI){
        _ctxDroneAI=currentContextDroneAI;
        _factoryDroneAI=StateFactoryDroneAI;  
    }
    public abstract void EnterState();//Start Method
    public abstract void UpdateState();//Update Method
    public abstract void ExitState();//Exit Method
    public abstract void CheckSwitchState();//For Changing State

    protected void SwitchState(DroneAIBaseState newState){/////For Switching State
        ExitState();

        newState.EnterState();

        _ctxDroneAI.CurrentState=newState;
    }
}

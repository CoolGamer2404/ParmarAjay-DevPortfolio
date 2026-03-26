using UnityEngine;

public abstract class BossDrone1_BaseState
{
    protected BossDrone1_StateMachine _ctxBossDroneAI;
    protected BossDrone1_StateFactory _factoryBossDroneAI;
    public BossDrone1_BaseState(BossDrone1_StateMachine currentContextBsssDroneAI,BossDrone1_StateFactory StateFactoryBossDroneAI){
        _ctxBossDroneAI=currentContextBsssDroneAI;
        _factoryBossDroneAI=StateFactoryBossDroneAI;  
    }
    public abstract void EnterState();//Start Method
    public abstract void UpdateState();//Update Method
    public abstract void ExitState();//Exit Method
    public abstract void CheckSwitchState();//For Changing State
    public abstract void HandleCollision(Collider collider);//For Changing State

    protected void SwitchState(BossDrone1_BaseState newState){/////For Switching State
        ExitState();

        newState.EnterState();

        _ctxBossDroneAI.CurrentState=newState;
    }
}

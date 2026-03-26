public abstract class EnemyBaseState
{
    protected EnemyStateMachine _ctx;
    protected EnemyStateFactory _factory;
    public EnemyBaseState(EnemyStateMachine currentContext,EnemyStateFactory enemyStateFactory){
        _ctx=currentContext;
        _factory=enemyStateFactory;    
    }
    public abstract void EnterState();//Start Method
    public abstract void UpdateState();//Update Method
    public abstract void ExitState();//Exit Method
    public abstract void CheckSwitchState();//For Changing State

    protected void SwitchState(EnemyBaseState newState){/////For Switching State
        ExitState();

        newState.EnterState();

        _ctx.CurrentState=newState;
    }
}

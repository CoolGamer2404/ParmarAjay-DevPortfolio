public class EnemyStateFactory
{
    EnemyStateMachine _context;

    public EnemyStateFactory(EnemyStateMachine currentContext)
    {
        _context = currentContext;
    }

    public EnemyBaseState Idle(){
        return new IdleState(_context,this);
    }
    public EnemyBaseState Wandering(){
        return new WanderingState(_context,this);
    }
    public EnemyBaseState Following(){
        return new FollowingState(_context,this);
    }
    public EnemyBaseState Attack(){
        return new AttackState(_context,this);
    }
    public EnemyBaseState Forgot(){
        return new ForgotState(_context,this);
    }
    public EnemyBaseState CheckLastPosition(){
        return new CheckLastPositionState(_context,this);
    }
}

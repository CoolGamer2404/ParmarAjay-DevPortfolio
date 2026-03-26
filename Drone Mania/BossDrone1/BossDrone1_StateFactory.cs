public class BossDrone1_StateFactory
{
    BossDrone1_StateMachine _context;

    public BossDrone1_StateFactory(BossDrone1_StateMachine currentContext)
    {
        _context = currentContext;
    }

    public BossDrone1_BaseState Idle(){
        return new BossDrone1_State_Idle(_context,this);
    }
    public BossDrone1_BaseState Stun(){
        return new BossDrone1_State_Stun(_context,this);
    }
    public BossDrone1_BaseState ChangeLocation(){
        return new BossDrone1_State_ChangeLocation(_context,this);
    }

    public BossDrone1_BaseState SpawnDrones()
    {
        return new BossDrone1_Attack_SpawnDrones(_context, this);
    }

    public BossDrone1_BaseState Dash()
    {
        return new BossDrone1_Attack_Dash(_context, this);
    }

    public BossDrone1_BaseState ShootProjectiles()
    {
        return new BossDrone1_Attack_ShootProjectiles(_context, this);
    }

    public BossDrone1_BaseState ShootMissiles()
    {
        return new BossDrone1_Attack_ShootMissiles(_context, this);
    }

    public BossDrone1_BaseState ShootAsteroid()
    {
        return new BossDrone1_Attack_ShootAsteroid(_context, this);
    }

    public BossDrone1_BaseState WildFire()
    {
        return new BossDrone1_Attack_WildFire(_context, this);
    }
}


public class DroneAIStateFactory
{
    DroneAIStateMachine _context;

    public DroneAIStateFactory(DroneAIStateMachine currentContext)
    {
        _context = currentContext;
    }

    public DroneAIBaseState Wandering(){
        return new WanderingState(_context,this);
    }
    public DroneAIBaseState Chasing(){
        return new ChaseState(_context,this);
    }
    public DroneAIBaseState Dying(){
        return new DieState(_context,this);
    }
    public DroneAIBaseState Retriving(){
        return new RetriveState(_context,this);
    }
    public DroneAIBaseState SpawingPath(){
        return new SpawnPathState(_context,this);
    }
}

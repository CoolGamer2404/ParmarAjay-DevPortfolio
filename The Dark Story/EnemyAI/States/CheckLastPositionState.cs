using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLastPositionState : EnemyBaseState
{
    public CheckLastPositionState(EnemyStateMachine currentContext, EnemyStateFactory enemyStateFactory) : base(currentContext, enemyStateFactory) { }
    public override void EnterState()
    {
        _ctx.LastPlayerTransform=_ctx.PlayerTransform.position;
        //Debug.Log("I Am In");
        _ctx.Agent.SetDestination(_ctx.LastPlayerTransform);
    }//Start Method
    public override void UpdateState()
    {
        _ctx.Animator.Play("Walk");
        //CheckSwitchState();
        if (_ctx.Agent.remainingDistance <= _ctx.Agent.stoppingDistance)
        {
            SwitchState(_factory.Idle());
            _ctx.IsIdleTimeStarted=true;
            _ctx.IdleTime = 5f;
        }
        if (_ctx.EnemySensor.Objects.Count > 0)
        {
            //Debug.Log("FoundPlayer");
            SwitchState(_factory.Following());
        }
    }//Update Method
    public override void ExitState() { }//Exit Method
    public override void CheckSwitchState() { }//For Changing State
}
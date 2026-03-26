using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingState : EnemyBaseState
{
    public WanderingState(EnemyStateMachine currentContext, EnemyStateFactory enemyStateFactory) : base(currentContext, enemyStateFactory) { }
    public override void EnterState()
    {
        //Debug.Log("hello");
        _ctx.NewWanderingLocation = _ctx.WanderingLocations[Random.Range(0, _ctx.WanderingLocations.Length)];
        _ctx.Agent.SetDestination(_ctx.NewWanderingLocation.position);
        if (_ctx.IsCustomSpeed == true)
        {
            _ctx.Agent.speed = _ctx.NewMoveSpeed;
        }
        else if (_ctx.IsCustomSpeed == false)
        {
            _ctx.Agent.speed = 1.5f;
        }
    }//Start Method
    public override void UpdateState()
    {
        _ctx.NewWanderingLocationTime -= Time.deltaTime;
        //Debug.Log(_ctx.Agent.remainingDistance.ToString());
        if (_ctx.Agent.remainingDistance > _ctx.Agent.stoppingDistance)
        {
            _ctx.Animator.Play("Walk");
            if (_ctx.EnemySensor.Objects.Count > 0)
            {
                //Debug.Log("FoundPlayer");
                SwitchState(_factory.Following());
            }
        }
        else if (_ctx.NewWanderingLocationTime < 0f && _ctx.Agent.remainingDistance <= _ctx.Agent.stoppingDistance)
        {
            //Debug.Log("It Starts From Here !!!!!!!"+"Remaining Distance Is:"+_ctx.Agent.remainingDistance.ToString()+"Stopping Distance Is:"+_ctx.Agent.stoppingDistance.ToString());
            SwitchState(_factory.Idle());
            _ctx.IsIdleTimeStarted = true;
            _ctx.IdleTime = 5f;
        }

        //CheckSwitchState();
    }//Update Method
    public override void ExitState() { }//Exit Method
    public override void CheckSwitchState() { }//For Changing State
}

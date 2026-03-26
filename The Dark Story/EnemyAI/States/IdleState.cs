using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyBaseState
{
    private bool countdownStarted = false;

    public IdleState(EnemyStateMachine currentContext, EnemyStateFactory enemyStateFactory) : base(currentContext, enemyStateFactory)
    {
        _ctx = currentContext;
        _factory = enemyStateFactory;
    }

    public override void EnterState()
    {
        //Debug.Log(_ctx.Agent.transform.position.ToString());
        _ctx.IdleTime = 5f;
        _ctx.NewWanderingLocationTime = 7f;
        //Debug.Log("Hello");
        Debug.Log("IdleState");
        _ctx.RespawnPlayer.PlayerRespawned = false;
        _ctx.NewWanderingLocation=null;
    }

    public override void UpdateState()
    {
        if (_ctx.IdleTime > 0f && _ctx.IsIdleTimeStarted)
        {
            _ctx.IdleTime -= Time.deltaTime;
            _ctx.Animator.Play("Idle");
            if (_ctx.EnemySensor.Objects.Count > 0)
            {
                _ctx.IsIdleTimeStarted = false;
                //Debug.Log("Hello3");
                //Debug.Log("FoundPlayer");
                SwitchState(_factory.Following());
            }
        }
        else if (_ctx.IdleTime <= 0f)
        {
            _ctx.IsIdleTimeStarted = false;
            SwitchState(_factory.Wandering());
            // Check if the state is still "Idle" before transitioning
            if (_ctx.CurrentState is IdleState)
            {
                //Debug.Log("Hello2");
                countdownStarted = false; // Reset the countdown flag
                _ctx.NewWanderingLocationTime = 4f;
                SwitchState(_factory.Wandering());
            }
        }
    }

    public override void ExitState() { }
    public override void CheckSwitchState() { }
}

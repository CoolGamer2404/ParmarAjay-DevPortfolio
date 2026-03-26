using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingState : EnemyBaseState
{
    public FollowingState(EnemyStateMachine currentContext,EnemyStateFactory enemyStateFactory):base (currentContext,enemyStateFactory){}
    public override void EnterState(){
        //Debug.Log("I Am In");
        _ctx.Agent.SetDestination(_ctx.PlayerTransform.position);
        _ctx.Animator.Play("Run");
        if (_ctx.IsCustomSpeed == true)
        {
            _ctx.Agent.speed = _ctx.NewRunSpeed;
        }
        else if (_ctx.IsCustomSpeed == false)
        {
            _ctx.Agent.speed = 3f;
        }
  
    }//Start Method
    public override void UpdateState(){
        if(_ctx.EnemySensor.Objects.Count>0){
            //Debug.Log("Still Following");
            _ctx.Agent.SetDestination(_ctx.PlayerTransform.position);
            if(_ctx.PlayerDistance<=_ctx.AttackDistance){
                SwitchState(_factory.Attack());
            }
        }
        if(_ctx.EnemySensor.Objects.Count==0){
            //Debug.Log("Should I Check Last Player Position????");
            if (_ctx.IsCustomSpeed == true)
            {
                _ctx.Agent.speed = _ctx.NewRunSpeed;
            }
            else if (_ctx.IsCustomSpeed == false)
            {
                _ctx.Agent.speed = 1.5f;
            }
            SwitchState(_factory.CheckLastPosition());
        }
        //CheckSwitchState();
    }//Update Method
    public override void ExitState(){}//Exit Method
    public override void CheckSwitchState(){}//For Changing State
}
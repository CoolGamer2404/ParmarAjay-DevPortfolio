using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyBaseState
{
    public AttackState(EnemyStateMachine currentContext,EnemyStateFactory enemyStateFactory):base (currentContext,enemyStateFactory){}
    public override void EnterState(){
        //Attack Functions Here
        //Debug.Log("Hello From Attack State");
        _ctx.Agent.SetDestination(_ctx.PlayerTransform.position);
        _ctx.Agent.stoppingDistance=.6f;
        _ctx.PlayerFollowCamera.transform.gameObject.SetActive(true);
        _ctx.LowHealthCameraGameObject.SetActive(true);
        _ctx.JumpScareEnemyCamera.PlayOneShot(_ctx.jumpScareEnemyCameraClip);
        _ctx._playedOnce = false;
    }//Start Method
    public override void UpdateState(){
        _ctx.Animator.Play("Attack");
        _ctx.FirstPersonController.MoveSpeed=0f;
        CheckSwitchState();
    }//Update Method
    public override void ExitState(){}//Exit Method
    public override void CheckSwitchState(){
        if(_ctx.EnemyAttackSensor1.gotPlayer==true||_ctx.EnemyAttackSensor2.gotPlayer==true){
            _ctx.DeathUI.SetActive(true);
            Escape.isdeathmenuActive=true;
            _ctx.RespawnPlayer.PlayerRespawned=false;
            _ctx.EnemyAttackSensor1.gotPlayer=false;
            _ctx.EnemyAttackSensor2.gotPlayer=false;
            _ctx.StarterAssetsInputs.cursorLocked = false;
            _ctx.StarterAssetsInputs.cursorInputForLook = false;
            Cursor.lockState=CursorLockMode.Confined;
            Cursor.visible=true;
            _ctx.LowHealthPostProcessingGameObject.SetActive(true);
        }
        if(_ctx.RespawnPlayer.PlayerRespawned){
            _ctx.Agent.Warp(_ctx.AgentRespawnPosition);
            _ctx.PlayerFollowCamera.transform.gameObject.SetActive(false);
            _ctx.LowHealthCameraGameObject.SetActive(false);
            _ctx.FirstPersonController.MoveSpeed=3f;
            _ctx.StarterAssetsInputs.cursorLocked = true;
            _ctx.StarterAssetsInputs.cursorInputForLook = true;
            Cursor.visible=false;
            Cursor.lockState=CursorLockMode.Locked;
            SwitchState(_factory.Idle());
            _ctx.IsIdleTimeStarted = true;
            _ctx.IdleTime = 5f;
            _ctx.LowHealthPostProcessingGameObject.SetActive(false);
        }
    }//For Changing State
}

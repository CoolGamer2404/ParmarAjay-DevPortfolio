using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrone1_Attack_Dash : BossDrone1_BaseState
{
    public BossDrone1_Attack_Dash(BossDrone1_StateMachine _ctxBossAI/*currentContextBossDroneAI*/, BossDrone1_StateFactory StateFactoryBossDroneAI) : base(_ctxBossAI, StateFactoryBossDroneAI)
    {
        
    }
    public override void EnterState()
    {
        //Sets Up BOss Height
        Vector3 pos=new Vector3(
            _ctxBossDroneAI.BossDrone.transform.position.x,
            _ctxBossDroneAI.FlyingHeight,
            _ctxBossDroneAI.BossDrone.transform.position.z);
        _ctxBossDroneAI.BossDrone.transform.position=pos;


        _ctxBossDroneAI.RandomDashAmount=UnityEngine.Random.Range(0,4);
        CheckForAvailableDash();
    }
    public override void UpdateState()
    {
        if(_ctxBossDroneAI.IsDashing && Vector3.Distance(_ctxBossDroneAI.InitialDashPosition,_ctxBossDroneAI.BossDrone.transform.position)<_ctxBossDroneAI.DashDistance){
           //_ctxBossDroneAI.BossRB.velocity=_ctxBossDroneAI.BossDrone.transform.forward*_ctxBossDroneAI.DashSpeed;
            _ctxBossDroneAI.BossDrone.transform.position+=_ctxBossDroneAI.BossDrone.transform.forward*_ctxBossDroneAI.DashSpeed*Time.deltaTime;
        }
        if(_ctxBossDroneAI.IsDashing && Vector3.Distance(_ctxBossDroneAI.InitialDashPosition,_ctxBossDroneAI.BossDrone.transform.position)>=_ctxBossDroneAI.DashDistance){
            Debug.LogFormat($"Reached Distance Limit{Vector3.Distance(_ctxBossDroneAI.InitialDashPosition,_ctxBossDroneAI.BossDrone.transform.position).ToString()}");
            StopDash();
        }
    }
    public override void ExitState() {
        Debug.Log("ExitedDash");
    }
    public override void CheckSwitchState() { }

    public override void HandleCollision(Collider collider){
        Debug.Log("Entered Collision");
        if(collider.gameObject.tag==_ctxBossDroneAI.BoundryTag){
            StopDash();
        }
    }

    public void StartDash(){
        //Vector3 direction=_ctxBossDroneAI.Player.transform.position-_ctxBossDroneAI.BossDrone.transform.position;
        //Quaternion lookRot=Quaternion.LookRotation(direction);
        //_ctxBossDroneAI.BossDrone.transform.rotation=Quaternion.RotateTowards(_ctxBossDroneAI.BossDrone.transform.rotation,lookRot,_ctxBossDroneAI.RotationSpeed*Time.deltaTime);
        _ctxBossDroneAI.BossDrone.transform.LookAt(_ctxBossDroneAI.Player.transform.parent,Vector3.up);
        _ctxBossDroneAI.InitialDashPosition=_ctxBossDroneAI.BossDrone.transform.position;

        _ctxBossDroneAI.IsDashing=true;
    }
    public void StopDash(){
        _ctxBossDroneAI.IsDashing=false;
        _ctxBossDroneAI.BossRB.velocity=Vector3.zero;
        _ctxBossDroneAI.RandomDashAmount-=1;
        CheckForAvailableDash();
    }

    public void CheckForAvailableDash(){
        if(_ctxBossDroneAI.RandomDashAmount>0){
            StartDash();
        }
        if(_ctxBossDroneAI.RandomDashAmount<=0){
            ExitState();
        }
    }

}

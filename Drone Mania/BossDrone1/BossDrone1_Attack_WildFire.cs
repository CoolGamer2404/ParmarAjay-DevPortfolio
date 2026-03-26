using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrone1_Attack_WildFire : BossDrone1_BaseState
{
    public BossDrone1_Attack_WildFire(BossDrone1_StateMachine currentContextBossDroneAI, BossDrone1_StateFactory StateFactoryBossDroneAI) : base(currentContextBossDroneAI, StateFactoryBossDroneAI)
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
    }
    public override void UpdateState()
    {
        
    }
    public override void ExitState() {
        
    }
    public override void CheckSwitchState() { }
    public override void HandleCollision(Collider collider){}
}

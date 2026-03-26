using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrone1_State_Stun : BossDrone1_BaseState
{
    public BossDrone1_State_Stun(BossDrone1_StateMachine currentContextBossDroneAI, BossDrone1_StateFactory StateFactoryBossDroneAI) : base(currentContextBossDroneAI, StateFactoryBossDroneAI)
    {
        
    }
    public override void EnterState()
    {
        _ctxBossDroneAI.IsBossVulnarable=true;
    }
    public override void UpdateState()
    {
        
    }
    public override void ExitState() {
        _ctxBossDroneAI.IsBossVulnarable=false;
    }
    public override void CheckSwitchState() { }
    public override void HandleCollision(Collider collider){}
}

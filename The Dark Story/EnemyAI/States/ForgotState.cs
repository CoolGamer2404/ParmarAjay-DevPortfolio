using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgotState : EnemyBaseState
{
    public ForgotState(EnemyStateMachine currentContext,EnemyStateFactory enemyStateFactory):base (currentContext,enemyStateFactory){}
    public override void EnterState(){}//Start Method
    public override void UpdateState(){
        CheckSwitchState();
    }//Update Method
    public override void ExitState(){}//Exit Method
    public override void CheckSwitchState(){}//For Changing State

}

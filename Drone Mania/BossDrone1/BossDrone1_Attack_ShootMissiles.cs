using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrone1_Attack_ShootMissiles : BossDrone1_BaseState
{
    public BossDrone1_Attack_ShootMissiles(BossDrone1_StateMachine currentContextBossDroneAI, BossDrone1_StateFactory StateFactoryBossDroneAI) : base(currentContextBossDroneAI, StateFactoryBossDroneAI)
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

        
        Debug.Log("Entered Spawn State");
        _ctxBossDroneAI.MissilesAmount=Random.Range(8,15);
        _ctxBossDroneAI.ArenaBaseBounds=_ctxBossDroneAI.ArenaBaseMesh.mesh.bounds;

        GenerateRandomPoints();
    }
    public override void UpdateState()
    {
        
    }
    public override void ExitState() {
        
    }
    public override void CheckSwitchState() { }
    public override void HandleCollision(Collider collider){}


    private void GenerateRandomPoints()
    {
        Debug.Log("Generate Random Point1");
        int pointsCount = _ctxBossDroneAI.MissilesAmount;

        // Generate points far from player
        for (int i = 0; i < pointsCount; i++)
        {
            Vector3 point = GeneratePoints();
            _ctxBossDroneAI.InstantiateMissileTargetIndicator(point);
        }
    }

    private Vector3 GeneratePoints()
    {
        Debug.Log("Generate Random Point 2");
        Vector3 center=_ctxBossDroneAI.ArenaBaseMesh.transform.TransformPoint(_ctxBossDroneAI.ArenaBaseBounds.center);
        Vector3 randomPoint = center + new Vector3(
            Random.Range(-_ctxBossDroneAI.ArenaBaseBounds.extents.x, _ctxBossDroneAI.ArenaBaseBounds.extents.x),
            0,
            Random.Range(-_ctxBossDroneAI.ArenaBaseBounds.extents.z, _ctxBossDroneAI.ArenaBaseBounds.extents.z)
        );

        return randomPoint;
    }
}

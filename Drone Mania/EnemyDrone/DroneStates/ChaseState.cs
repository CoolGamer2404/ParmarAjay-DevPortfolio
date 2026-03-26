using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : DroneAIBaseState
{
    public ChaseState(DroneAIStateMachine currentContextDroneAI, DroneAIStateFactory StateFactoryDroneAI) : base(currentContextDroneAI, StateFactoryDroneAI)
    {
    }
    public override void EnterState()
    {

    }
    public override void UpdateState()
    {
        _ctxDroneAI.RB.velocity = _ctxDroneAI.transform.forward * _ctxDroneAI.droneStat.baseSpeed;

            var leadTimePercentage = Mathf.InverseLerp(_ctxDroneAI.droneStat._minDistancePredict, _ctxDroneAI.droneStat._maxDistancePredict, Vector3.Distance(_ctxDroneAI.transform.position, _ctxDroneAI._Player.transform.position));

            PredictMovement(leadTimePercentage);

            AddDeviation(leadTimePercentage);

            RotateDrone();
        /*if (_ctxDroneAI.PlayerDistance > _ctxDroneAI.MinPlayerDistance && _ctxDroneAI.PlayerDistance<_ctxDroneAI.MaxPlayerDistance)
        {
            _ctxDroneAI.RB.velocity = _ctxDroneAI.transform.forward * _ctxDroneAI.droneStat.baseSpeed;

            var leadTimePercentage = Mathf.InverseLerp(_ctxDroneAI.droneStat._minDistancePredict, _ctxDroneAI.droneStat._maxDistancePredict, Vector3.Distance(_ctxDroneAI.transform.position, _ctxDroneAI._Player.transform.position));

            PredictMovement(leadTimePercentage);

            AddDeviation(leadTimePercentage);

            RotateDrone();
        }
        if(_ctxDroneAI.PlayerDistance>_ctxDroneAI.MaxPlayerDistance){
            ExitState();
        }*/
    }
    public override void ExitState() {
        _factoryDroneAI.SpawingPath();
    }
    public override void CheckSwitchState() { }


    /////For Homing Movement///////
    public void PredictMovement(float leadTimePercentage)
    {

        var predictionTime = Mathf.Lerp(0, _ctxDroneAI.droneStat._maxTimePrediction, leadTimePercentage);

        _ctxDroneAI.droneStat._standardPrediction = _ctxDroneAI._Player.Rb.position + _ctxDroneAI._Player.Rb.velocity * predictionTime;
    }

    public void AddDeviation(float leadTimePercentage)
    {

        var deviation = new Vector3(Mathf.Cos(Time.time * _ctxDroneAI.droneStat._deviationSpeed), 0, 0);

        var predictionOffset = _ctxDroneAI.transform.TransformDirection(deviation) * _ctxDroneAI.droneStat._deviationAmount * leadTimePercentage;

        _ctxDroneAI.droneStat._deviatedPrediction = _ctxDroneAI.droneStat._standardPrediction + predictionOffset;
    }

    public void RotateDrone()
    {

        var heading = _ctxDroneAI.droneStat._deviatedPrediction - _ctxDroneAI.transform.position;

        var rotation = Quaternion.LookRotation(heading);
        _ctxDroneAI.RB.MoveRotation(Quaternion.RotateTowards(_ctxDroneAI.transform.rotation, rotation, _ctxDroneAI.droneStat.rotateSpeed * Time.deltaTime));
    }
}

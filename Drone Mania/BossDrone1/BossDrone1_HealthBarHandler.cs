using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDrone1_HealthBarHandler : MonoBehaviour
{
    public Image healthBarGreen,
        healthBarYellow,
        healthBarOrange,
        healthBarRed;
    public BossDrone1_StateMachine _bossDrone1;
    [SerializeField]private float _Amount = 1;
    [SerializeField]private int _CurrentPhaseHealthLoss;
    [SerializeField]private int _CurrentPhaseHealth;
    [SerializeField]private int PhaseHealth;
    [SerializeField]private float _reduceSpeed=2;

    void Start() {

    }

    // Update is called once per frame
    public void UpdateHealthBar()
    {
        switch (_bossDrone1._currentPhase)
        {
            case 1:
                Phase1();
                break;
            case 2:
                Phase2();
                break;
            case 3:
                Phase3();
                break;
            case 4:
                Phase4();
                break;
        }
    }

    void Phase1() {
        //_basePhaseHealthMax=_bossDrone1._bossDroneStat.baseHealth-PhaseHealth*3;
        _CurrentPhaseHealthLoss=_bossDrone1._bossDroneStat.baseHealth-_bossDrone1._bossDroneStat.currentHealth;
        _CurrentPhaseHealth=_bossDrone1.PhaseHealth-_CurrentPhaseHealthLoss;
        _Amount =  _CurrentPhaseHealth / _bossDrone1.PhaseHealth;
        healthBarGreen.fillAmount = (float)_CurrentPhaseHealth/_bossDrone1.PhaseHealth;
    }

    void Phase2() {
        //_basePhaseHealthMax=_bossDrone1._bossDroneStat.baseHealth-PhaseHealth*3;
        _CurrentPhaseHealthLoss=_bossDrone1._bossDroneStat.baseHealth-_bossDrone1._bossDroneStat.currentHealth-_bossDrone1.PhaseHealth;
        _CurrentPhaseHealth=_bossDrone1.PhaseHealth-_CurrentPhaseHealthLoss;
        _Amount =  _CurrentPhaseHealth / _bossDrone1.PhaseHealth;
        healthBarYellow.fillAmount = (float)_CurrentPhaseHealth/_bossDrone1.PhaseHealth;
    }

    void Phase3() {
        //_basePhaseHealthMax=_bossDrone1._bossDroneStat.baseHealth-PhaseHealth*3;
        _CurrentPhaseHealthLoss=_bossDrone1._bossDroneStat.baseHealth-_bossDrone1._bossDroneStat.currentHealth-_bossDrone1.PhaseHealth*2;
        _CurrentPhaseHealth=_bossDrone1.PhaseHealth-_CurrentPhaseHealthLoss;
        _Amount =  _CurrentPhaseHealth / _bossDrone1.PhaseHealth;
        healthBarOrange.fillAmount = (float)_CurrentPhaseHealth/_bossDrone1.PhaseHealth;
    }

    void Phase4() {
        //_basePhaseHealthMax=_bossDrone1._bossDroneStat.baseHealth-PhaseHealth*3;
        _CurrentPhaseHealthLoss=_bossDrone1._bossDroneStat.baseHealth-_bossDrone1._bossDroneStat.currentHealth-_bossDrone1.PhaseHealth*3;
        _CurrentPhaseHealth=_bossDrone1.PhaseHealth-_CurrentPhaseHealthLoss;
        _Amount =  _CurrentPhaseHealth / _bossDrone1.PhaseHealth;
        healthBarRed.fillAmount = (float)_CurrentPhaseHealth/_bossDrone1.PhaseHealth;
    }
}

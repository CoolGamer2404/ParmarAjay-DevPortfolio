using System.Collections;
using System.Collections.Generic;
using System.Threading;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Ritual_zombieSpawner : MonoBehaviour
{
    [SerializeField]private GameObject _ZombiePrefab;
    [SerializeField]private Transform[] _SpawnPositions;
    [SerializeField]private Transform AttackPos;
    [SerializeField]public int _FragmentsCOunt=0;
    [SerializeField]private TMP_Text fragsText;
    [SerializeField]private TMP_Text timerText;
    [SerializeField]public float _Timer=210f;
    [SerializeField]private StarterAssetsInputs starterAssetsInputs;
    [SerializeField]private FirstPersonController firstPersonController;
    public int TotalCurrentZombies=0;
    public bool isRitualOn=false;
    public bool isTimerRunning=false;
    [SerializeField]private float _SpawnDelay;
    public bool isCD;
    private float CDTime=25f;
    private float fragmentsTime=30f;
    public float timer;
    [SerializeField]private MainQuestHandler mainQuestHandler;

    // Update is called once per frame
    void Update()
    {
        if(isRitualOn && isTimerRunning){
            _Timer-=Time.deltaTime;
            timerText.text=FormatTime(_Timer);
            if(!isCD){
                SpawnEnemy();

                isCD=true;
                Invoke(nameof(ResetCD),CDTime);
            }
            timer+=Time.deltaTime;
            if(timer>=fragmentsTime){
                _FragmentsCOunt+=1;
                fragsText.text=_FragmentsCOunt.ToString();
                timer=0;
            }
            if(_Timer<=0){
                mainQuestHandler.EndRitual();
                isTimerRunning=false;
                isRitualOn=false;
            }
        }  
    }
    void ResetCD(){
        isCD=false;
    }
    string FormatTime(float time){
        int Min=(int)time/60;
        int Sec=(int)time%60;
        return string.Format("{0:00}:{1:00}",Min,Sec);
    }
    public void StartRitual(){
        isRitualOn=true;
        isTimerRunning=true;
        starterAssetsInputs.cursorLocked=true;
        starterAssetsInputs.cursorInputForLook=true;
        firstPersonController.enabled=true;
        Cursor.lockState =  CursorLockMode.Locked;
    }
    public void SpawnEnemy(){
        for (int i = 0; i < 4-TotalCurrentZombies; i++)
        {
            Transform rand=_SpawnPositions[Random.Range(0,_SpawnPositions.Length)];
        GameObject enemy=Instantiate(_ZombiePrefab,rand.position,Quaternion.identity);
        enemy.GetComponent<NavMeshAgent>().Warp(rand.position);
        enemy.GetComponent<NavMeshAgent>().SetDestination(AttackPos.position);
        enemy.GetComponent<MonsterHandler>().target=AttackPos;
        enemy.GetComponent<MonsterHandler>().mainQuestHandler=mainQuestHandler;
        TotalCurrentZombies+=1;
        }
    }
}

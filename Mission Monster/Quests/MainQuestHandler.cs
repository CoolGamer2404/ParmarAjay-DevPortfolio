using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class MainQuestHandler : MonoBehaviour
{
    public bool DestroyMonsters=false;
    [SerializeField]private TMP_Text mainQuestText;
    [SerializeField]private GameObject _BLWShaderObj;
    [SerializeField]private GameObject _Boarder;
    [SerializeField]private StarterAssetsInputs starterAssetsInputs;
    [SerializeField]private FirstPersonController firstPersonController;
    [SerializeField]private Volume nightVolume;
    [SerializeField]private Player_Stats player_Stats;
    [SerializeField]private ObjectivePosition _Mark_Marker_4,Ritual_Marker;
    [SerializeField]private Ritual_zombieSpawner ritual_ZombieSpawner;
    public int _totalNPCTalked=0;

    [Header("NPC")]
    [SerializeField]private GameObject _Mark;
    [SerializeField]private GameObject _JackTheAdventurer;
    [SerializeField]private GameObject[] _AllMonsters;
    [SerializeField]private CharacterController characterController;
    [SerializeField]private GameObject _Player;
    [SerializeField]private Transform _PlayerPos2,_PlayerPos3;
    [SerializeField]private GameObject _PlayerPlaceHolder;
    [SerializeField]private GameObject _MiniMap,_RitualPanel,_ConversationPanel;

    [Header("NPC Locations")]
    [SerializeField]private Transform _JackLocation2;
    [SerializeField]private Transform _MarkLocation2;
    [SerializeField]private Transform _MarkLocation3,_MarkLocation4,_MarkLocation5;
    [SerializeField]private Transform[] _AllMonstersLocations1;
    [SerializeField]private Transform[] _AllMonstersLocations2;

    [Header("NPC Triggers")]
    [SerializeField]private GameObject _JackTrigger_1;
    [SerializeField]private GameObject _JackTrigger_2;
    [SerializeField]private GameObject _MarkTrigger_1,_MarkTrigger_2,_MarkTrigger_3,_MarkTrigger_4,_MarkTrigger_5,_MarkTrigger_6;
    [SerializeField]private GameObject _DrCalebTrigger_1;
    [SerializeField]private GameObject _RitualTrigger,_RitualTrigger2;
    [SerializeField]private GameObject[] _Monsters,_Triggers;
    [SerializeField]private EthanQuest _ethanQuestHandler;
    [SerializeField]private LiamQuest _liamQuestHandler;
    [SerializeField]private LucasQuest _lucasQuestHandler;
    //[SerializeField]private NoahQuest _noahQuestHandler;

    [Header("Indicator Arrows")]
    [SerializeField]private GameObject _MarkArrow;
    [SerializeField]private GameObject _DrCalebArrow;
    [SerializeField]private GameObject _JackTheAdventurerArrow;

    private int _currentQuestIndex=0;

    void Start()
    {
        
    }

    public void StartGame(){
        Quest1();
        DeactivateStuff();
    }

    void DeactivateStuff(){
        _DrCalebArrow.SetActive(false);
        _JackTheAdventurerArrow.SetActive(false);
        _MarkTrigger_2.SetActive(false);
        _MarkTrigger_3.SetActive(false);
        _MarkTrigger_4.SetActive(false);
        _DrCalebTrigger_1.SetActive(false);
        _JackTrigger_1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest1(){
        _MarkTrigger_1.SetActive(true);
        _MarkArrow.SetActive(true);
        mainQuestText.text="Talk to Mark";
        _currentQuestIndex=1;
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest2(){
        _MarkArrow.SetActive(false);
        _MarkTrigger_1.SetActive(false);
        _DrCalebTrigger_1.SetActive(true);
        _DrCalebArrow.SetActive(true);
        mainQuestText.text="Talk to Dr.Caleb";
        _currentQuestIndex=2;
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest3(){
        _DrCalebTrigger_1.SetActive(false);
        _Mark.transform.position=_MarkLocation2.position;
        _Mark.transform.rotation=_MarkLocation2.rotation;
        _MarkArrow.SetActive(true);
        _MarkTrigger_2.SetActive(true);
        _DrCalebArrow.SetActive(false);
        mainQuestText.text="Meet Mark";
        _currentQuestIndex=3;
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest4(){
        _Mark.transform.position=_MarkLocation3.position;
        _Mark.transform.rotation=_MarkLocation3.rotation;
        _MarkArrow.SetActive(true);
        _MarkTrigger_2.SetActive(false);
        _MarkTrigger_3.SetActive(true);
        mainQuestText.text="Go to Adventurer's camp and talk to Mark";
        _currentQuestIndex=4;
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest5(){
        _MarkTrigger_3.SetActive(false);
        _JackTrigger_1.SetActive(true);
        _MarkArrow.SetActive(false);
        _JackTheAdventurerArrow.SetActive(true);
        mainQuestText.text="Talk to Adventurer";
        _currentQuestIndex=5;
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest6(){
        _MarkArrow.SetActive(true);
        _MarkTrigger_4.SetActive(true);
        _JackTrigger_1.SetActive(false);
        _JackTheAdventurerArrow.SetActive(false);
        mainQuestText.text="Talk to Mark";
        _currentQuestIndex=6;
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest7(){
        EnableMonstersNPC();
        _MarkArrow.SetActive(false);
        _MarkTrigger_4.SetActive(false);
        mainQuestText.text=$"Find All {_totalNPCTalked} Friends Of Mark By Using Your Vision.You cant see monster in normal mode so use vision and find monsters at marked locations.";
        _currentQuestIndex=7;
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest8(){
        for (int i = 0; i < _AllMonsters.Length; i++)
        {
            _AllMonsters[i].transform.position=_AllMonstersLocations1[i].position;
            _AllMonsters[i].transform.rotation=_AllMonstersLocations1[i].rotation;
            _AllMonsters[i].SetActive(true);
        }
        _Mark.transform.position=_MarkLocation4.position;
        _Mark.transform.rotation=_MarkLocation4.rotation;
        _MarkArrow.SetActive(true);
        _MarkTrigger_5.SetActive(true);
        _Mark_Marker_4.AddMarker();
        mainQuestText.text="Meet Mark For Ritual";
        _currentQuestIndex=8;
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest9(){
        _MarkArrow.SetActive(false);
        _MarkTrigger_5.SetActive(false);
        _RitualTrigger.SetActive(true);
        mainQuestText.text="Start Ritual";
        _currentQuestIndex=9;
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest10(){
        _Mark.transform.position=_MarkLocation4.position;
        _Mark.transform.rotation=_MarkLocation4.rotation;
        _MarkArrow.SetActive(true);
        _MarkTrigger_6.SetActive(true);
        _RitualTrigger.SetActive(false);
        mainQuestText.text="Talk to Mark";
        _currentQuestIndex=10;
        nightVolume.weight+=1;
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Quest11(){
        _Mark.transform.position=_MarkLocation5.position;
        _MarkArrow.SetActive(false);
        _MarkTrigger_5.SetActive(false);
        //_JackTheAdventurer.transform.position=_JackLocation2.position;
        //_JackTheAdventurer.transform.rotation=_JackLocation2.rotation;
        for (int i = 0; i < _AllMonsters.Length; i++)
        {
            _AllMonsters[i].transform.position=_AllMonstersLocations2[i].position;
            _AllMonsters[i].transform.rotation=_AllMonstersLocations2[i].rotation;
        }
        mainQuestText.text="Meet Jack TheAdventurer";
        //_currentQuestIndex=11;
    }

//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void QuestComplete(){
        switch (_currentQuestIndex)
        {
            case 0:
            Quest2();
            break;
            case 1:
            Quest2();
            break;
            case 2:
            Quest3();
            break;
            case 3:
            Quest4();
            break;
            case 4:
            Quest5();
            break;
            case 5:
            Quest6();
            break;
            case 6:
            Quest7();
            break;
            case 7:
            Quest8();
            break;
            case 8:
            Quest9();
            break;
            case 9:
            Quest10();
            break;
            case 10:
            Quest11();
            break;
        }
    }
    public void UpdateNPCTalked(){
        if(_totalNPCTalked!=0){
        mainQuestText.text=$"Find All {_totalNPCTalked} Friends Of Mark By Using Your Vision";
        return;}
        else if(_totalNPCTalked==0){
            QuestComplete();
        }
    }
    public void Decrese1NPCTalked(){
        _totalNPCTalked-=1;
        UpdateNPCTalked();
    }

    public void EnableMonstersNPC(){
        for (int i = 0; i < _Monsters.Length; i++)
        {
            _Monsters[i].SetActive(true);
            _Triggers[i].SetActive(true);
        }
        _ethanQuestHandler.EnableQuest();
        _lucasQuestHandler.EnableQuest();
        _liamQuestHandler.EnableQuest();
    }

    public void ChangePlayerLocationAtDoctors(){
        characterController.enabled=false;
        _Player.transform.position=_PlayerPos2.position;
        characterController.enabled=true;
    }

    public void StartRitual(){
        DestroyMonsters=false;
        player_Stats.Health=7;
        mainQuestText.text="Play as a Mark.Protect Alex until he get all fragments.";
        _PlayerPlaceHolder.SetActive(true);
        _Mark.SetActive(false);
        characterController.enabled=false;
        _Player.transform.position=_PlayerPos3.position;
        characterController.enabled=true;
        _BLWShaderObj.SetActive(true);
        _Boarder.SetActive(true);
        _MiniMap.SetActive(false);
        _RitualPanel.SetActive(true);
        _ConversationPanel.SetActive(false);
        starterAssetsInputs.cursorLocked=false;
        starterAssetsInputs.cursorInputForLook=false;
        firstPersonController.enabled=false;
        Cursor.lockState =  CursorLockMode.None;
    }

    public void RestartRitual(){
        DestroyMonsters=true;
        player_Stats.Health=7;
         _PlayerPlaceHolder.SetActive(false);
        _Mark.SetActive(true);
        _BLWShaderObj.SetActive(false);
        _Boarder.SetActive(false);
        _MiniMap.SetActive(true);
        _RitualPanel.SetActive(false);
        _ConversationPanel.SetActive(true);
        starterAssetsInputs.cursorLocked=true;
        starterAssetsInputs.cursorInputForLook=true;
        firstPersonController.enabled=true;
        Cursor.lockState =  CursorLockMode.Locked;
        ritual_ZombieSpawner.isTimerRunning=false;
        ritual_ZombieSpawner.isRitualOn=false;
        ritual_ZombieSpawner._Timer=210f;
        ritual_ZombieSpawner.isCD=false;
        ritual_ZombieSpawner.timer=0;
        ritual_ZombieSpawner._FragmentsCOunt=0;
        _RitualTrigger2.SetActive(true);
        player_Stats.UpdateHealth();
        Quest8();
    }

    public void EndRitual(){
        _PlayerPlaceHolder.SetActive(false);
        _Mark.SetActive(true);
        characterController.enabled=false;
        _Player.transform.position=_PlayerPlaceHolder.transform.position;
        characterController.enabled=true;
        _BLWShaderObj.SetActive(false);
        _Boarder.SetActive(false);
        _MiniMap.SetActive(true);
        _RitualPanel.SetActive(false);
        _ConversationPanel.SetActive(true);
        starterAssetsInputs.cursorLocked=true;
        starterAssetsInputs.cursorInputForLook=true;
        firstPersonController.enabled=true;
        Cursor.lockState =  CursorLockMode.Locked;
        QuestComplete();
        _Mark_Marker_4.AddMarker();
        Ritual_Marker.RemoveMarker();
    }
}

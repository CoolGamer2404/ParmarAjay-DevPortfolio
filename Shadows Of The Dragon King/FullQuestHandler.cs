using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Kryz.CharacterStats.Examples;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FullQuestHandler : MonoBehaviour
{
    [Header("BASE QUEST DATA")]
    [Tooltip("This Will Store Current Active Quest Number")]
    public int currentQuestIndex=0;
    [Tooltip("Stores Bool Value If Quest Gets Failed Than For Restarting That Quest Again")]
    public bool isCurrentQuestFailed=false;
    [Tooltip("This Will Store Number Of VIllage If Player Is In Any Village")]
    public int currentVillage=0;
    [Tooltip("This Will Store Current Village Number For Respawn On Death")]
    public int currentQuestVillage=0;
    [Tooltip("This WIll Store Index Of Current Active Quest Phase")]
    public int questPhase=0;

    [Header("QUEST VARIABLES")]
    [SerializeField]private ObjectivePosition village1Marker;
    [SerializeField]private ObjectivePosition village2Marker;
    [SerializeField]private ObjectivePosition village3Marker;
    //[SerializeField]private ObjectivePosition settlement1Marker,settlement2Marker,settlement3Marker;
    [SerializeField]private ObjectivePosition blacksmith1QuestMarker,adventurer1Marker,adventurer2Marker1,adventurer2Marker2,adventurer3Marker;
    [SerializeField]private ObjectivePosition npc1Marker,npc2Marker,npc3Marker,npc4Marker;
    [SerializeField]private ObjectivePosition blacksmith1NPCMarker/*slayer1NPCMarker*/;
    [SerializeField]private ObjectivePosition mushroomLocationMarker,Q1P9EMarker;
    [SerializeField]private ObjectivePosition Dragon1Marker,Dragon2Marker,Dragon3Marker,Dragon4Marker;
    [SerializeField]private TMP_Text mainQuestText,questSideText;

    [SerializeField]private GameObject npc1Trigger,npc2Trigger,blacksmith1T1,blacksmith1NPCTrigger,slayer1NPCTrigger,npc3Trigger,npc3Trigger2,npc4Trigger;
    [SerializeField]private GameObject adventure1T1,adventure1T2,adventure1T3,adventure1T4,adventure1T5,adventure1T6;
    [SerializeField]private GameObject adventure2T1,adventure2T2,adventure2T3,adventure3T1;
    [SerializeField]private Transform Adventure2,Adventure2Position2;
    [SerializeField]private GameObject[] village3NPCS;

    [SerializeField]private QuestRewardsScriptableObject q1Rewards,q2Rewards,q3Rewards;
    [SerializeField]private GameObject t1,t2;//External Player Triggers

    [Header("QUEST ENEMY REFERENCES")]
    [SerializeField]private GameObject[] Q1P9Enemies,Q2P8Enemies,Q3P1Enemies;
    [SerializeField]private Transform[] Q1P9SpawnLocations,Q2P8SpawnLocations,Q3P1SpawnLocations;
    [SerializeField]private GameObject Dragon1,Dragon2,Dragon3,Dragon4;

    [Header("Hint Panels")]
    [SerializeField]private GameObject shopHint/*,slayerHint*/,mountHint/*,settlementHint*/,villageAttackBlackScreen,startScreen,endScreen;

    [Header("Misc References")]
    [SerializeField]private CharacterInputs characterInputs;
    [SerializeField]private CharacterDataHandler characterDataHandler;
    


    
    //THIS WILL START QUEST FIRST TIME // CALL IT AFTER INITIAL ANIMATION //
    public void StartMainQuest(){}
    public void EndCurrentQuest(){}
    public void FailCurrentActiveQuest(){}
    public void RestartFailedQuest(){}
    int spawned;
    void Start(){
        //StartQuests();
        startScreen.SetActive(true);
        characterInputs.DisableMovement();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void KilledQuestEnemy(){
        spawnedEnemies-=1;
        Debug.Log("Killed 1 Out of " + spawnedEnemies);
        if(spawnedEnemies<=0){
            Debug.Log("Done");
            UpdateQuestPhase();
        }
    }

    public void ExitGame(){
        SceneManager.LoadScene(0);
    }



    public void StartQuests(){
        Debug.Log("Start Quests");
        switch (currentQuestIndex)
        {
            case 0:
            Quest1();
            break;
            case 1:
            Quest1();
            break;
            case 2:
            Quest2();
            break;
            case 3:
            Quest3();
            break;
        }
    }

    public void EnteredVillage(int villageNumber){
        if(villageNumber==1 && currentQuestIndex<=1 && questPhase==0){
            UpdateQuestPhase();
            return;
        }
        else if(villageNumber==2 && currentQuestIndex==2 && questPhase==0){
            UpdateQuestPhase();
            return;
        }
        else if(villageNumber==3 && currentQuestIndex==3 && questPhase==0){
            UpdateQuestPhase();
            return;
        }
    }
    public void CloseVillageAttackBlackScreen(){
        villageAttackBlackScreen.SetActive(false);
        characterInputs.EnableMovement();
        UpdateQuestPhase();
    }





#region MAIN QUESTS

//THis Will Update Phase Of Current Active Quest Phase
    public void UpdateQuestPhase(){
        questPhase+=1;
        StartQuests();
        return;
    }

    private void CompleteCurrentQuest(){
        questPhase=0;
        StartQuests();
    }

//This Will Show Hint panel and Make Player Cursor Active 
    public void ShowHint(){}

/// <summary>///////////////////////////////////////////////////////////////////////////
/// // QUEST 1 //QUEST 1 //QUEST 1 //QUEST 1 //QUEST 1 //QUEST 1 //QUEST 1 //QUEST 1 ///
/// </summary>//////////////////////////////////////////////////////////////////////////
///                             VILLAGE CRONICLES-PART1                              ///
/// </summary>//////////////////////////////////////////////////////////////////////////
    private void Quest1(){
        switch (questPhase)
        {
            case 0:
                currentQuestIndex=1;
                characterInputs.EnableMovement();
                village1Marker.AddMarker();
                mainQuestText.text="Visit Near By Village.";
                break;
            case 1:
                //village1Marker.RemoveMarker();
                GiveRewards(q1Rewards,0);
                npc1Marker.AddMarker();
                mainQuestText.text="Ask Villagers About Dragons.";
                npc1Trigger.SetActive(true);
                break;
            case 2:
                GiveRewards(q1Rewards,1);
                npc1Marker.RemoveMarker();
                npc2Marker.AddMarker();
                mainQuestText.text="Ask Villagers About Dragons.";
                npc1Trigger.SetActive(false);
                npc2Trigger.SetActive(true);
                break;
            case 3:
                npc2Marker.RemoveMarker();
                GiveRewards(q1Rewards,2);
                blacksmith1QuestMarker.AddMarker();
                mainQuestText.text="Ask Villagers About Dragons.";
                npc2Trigger.SetActive(false);
                blacksmith1T1.SetActive(true);
                break;
            case 4:
                blacksmith1QuestMarker.RemoveMarker();
                GiveRewards(q1Rewards,3);
                blacksmith1T1.SetActive(false);
                shopHint.SetActive(true);
                characterInputs.DisableMovement();
                mainQuestText.text=null;
                break;
            case 5:
                shopHint.SetActive(false);
                GiveRewards(q1Rewards,4);
                //slayerHint.SetActive(false);
                blacksmith1NPCMarker.AddMarker();
                //slayer1NPCMarker.AddMarker();
                characterInputs.EnableMovement();
                adventurer1Marker.AddMarker();
                blacksmith1NPCTrigger.SetActive(true);
                slayer1NPCTrigger.SetActive(true);
                adventure1T1.SetActive(true);
                mainQuestText.text="Continue Asking Villagers About Dragons.";
                break;
            case 6:
                adventure1T1.SetActive(false);
                GiveRewards(q1Rewards,5);
                adventure1T2.SetActive(true);
                mainQuestText.text="Meet Adventurer Once You Are Ready To Help Him";
            break;
            case 7:
                adventure1T2.SetActive(false);
                GiveRewards(q1Rewards,6);
                adventure1T3.SetActive(true);
                mushroomLocationMarker.AddMarker();
                mainQuestText.text="Give 5 Mushrooms To Adventurer.";
            break;
            case 8:
                mushroomLocationMarker.RemoveMarker();
                GiveRewards(q1Rewards,7);
                adventure1T3.SetActive(false);
                adventure1T4.SetActive(true);
                mainQuestText.text="Continue Helping Adventurer.";
            break;
            case 9:
                adventure1T4.SetActive(false);
                GiveRewards(q1Rewards,8);
                adventurer1Marker.RemoveMarker();
                StartCoroutine(SpawnEnemies(3,Q1P9SpawnLocations,Q1P9Enemies));
                Q1P9EMarker.AddMarker();
                mainQuestText.text="Kill Some Enemies To Prove You Can Fight Dragon.";
            break;
            case 10:
                Q1P9EMarker.RemoveMarker();
                GiveRewards(q1Rewards,9);
                adventurer1Marker.AddMarker();
                adventure1T5.SetActive(true);
                mainQuestText.text="Talk To Adventurer.";
            break;
            case 11:
                adventurer1Marker.RemoveMarker();
                GiveRewards(q1Rewards,10);
                Dragon1Marker.AddMarker();
                Dragon1.SetActive(true);
                mainQuestText.text="Go To Marked Location And Kill Dragon.";
            break;
            case 12:
                Dragon1Marker.RemoveMarker();
                GiveRewards(q1Rewards,11);
                Dragon1.SetActive(false);
                adventurer1Marker.AddMarker();
                adventure1T6.SetActive(true);
                mainQuestText.text="It Was Diferent Dragon.Try Asking Adventurer About It.";
            break;
            case 13:
                adventurer1Marker.RemoveMarker();
                GiveRewards(q1Rewards,12);
                adventure1T6.SetActive(false);
                characterInputs.DisableMovement();
                mountHint.SetActive(true);
            break;
            case 14:
                mountHint.SetActive(false);
                mainQuestText.text="GO To Next Village.";
                GiveRewards(q1Rewards,13);
                characterInputs.EnableMovement();
                currentQuestIndex+=1;
                CompleteCurrentQuest();
            break;
        }
    }

/// <summary>///////////////////////////////////////////////////////////////////////////
/// // QUEST 2 //QUEST 2 //QUEST 2 //QUEST 2 //QUEST 2 //QUEST 2 //QUEST 2 //QUEST 2 ///
/// </summary>//////////////////////////////////////////////////////////////////////////
///                             VILLAGE CRONICLES-PART2                              ///
/// </summary>//////////////////////////////////////////////////////////////////////////
    private void Quest2(){
        switch (questPhase)
        {
            case 0:
                village2Marker.AddMarker();
                GiveRewards(q1Rewards,14);
                mainQuestText.text="Go TO Next Village.Dont Forget You Can Fly.";
                break;
            case 1:
                npc3Marker.AddMarker();
                GiveRewards(q2Rewards,0);
                npc3Trigger.SetActive(true);
                mainQuestText.text="Talk To Locals";
                break;
            case 2:
                npc3Marker.RemoveMarker();
                GiveRewards(q2Rewards,1);
                npc3Trigger.SetActive(false);
                UpdateQuestPhase();
                //characterInputs.DisableMovement();
                //settlementHint.SetActive(true);
                break;
            case 3:
                //characterInputs.EnableMovement();
                GiveRewards(q2Rewards,2);
                //settlementHint.SetActive(false);
                //settlement1Marker.AddMarker();
                //settlement2Marker.AddMarker();
                //settlement3Marker.AddMarker();
                adventurer2Marker1.AddMarker();
                adventure2T1.SetActive(true);
                adventurer2Marker1.AddMarker();
                mainQuestText.text="Go And Meet Local Adventurer";
                break;
            case 4:
                adventure2T1.SetActive(false);
                GiveRewards(q2Rewards,3);
                adventure2T2.SetActive(true);
                mainQuestText.text="Give 1000 Coins To Adventurer.You Can Earn Coins By Doing Quests Or Slayers.";
                break;
            case 5:
                adventure2T2.SetActive(false);
                GiveRewards(q2Rewards,4);
                Dragon2Marker.AddMarker();
                Dragon2.SetActive(true);
                adventurer2Marker1.RemoveMarker();
                mainQuestText.text="Time To Kill Dragon.Go TO Marked Position.";
                break;
            case 6:
                Dragon2.SetActive(false);
                GiveRewards(q2Rewards,5);
                Dragon2Marker.RemoveMarker();
                adventurer2Marker1.AddMarker();
                mainQuestText.text="As Expected! Dfferent Dragon Again. Lets Go Meet Adventurer.";
                Adventure2.gameObject.SetActive(false);
                t1.SetActive(true);
                break;
            case 7:
                t1.SetActive(false);
                adventurer2Marker1.RemoveMarker();
                GiveRewards(q2Rewards,6);
                npc3Marker.AddMarker();
                npc3Trigger2.SetActive(true);
                mainQuestText.text="Adventurer Is Missing.Ask Ethan About It.";
                break;
            case 8:
                npc3Marker.RemoveMarker();
                GiveRewards(q2Rewards,7);
                npc3Trigger2.SetActive(false);
                adventurer2Marker2.AddMarker();
                Adventure2.gameObject.SetActive(true);
                Adventure2.position=Adventure2Position2.position;
                StartCoroutine(SpawnEnemies(5,Q2P8SpawnLocations,Q2P8Enemies));
                mainQuestText.text="Find Adventurer.";
                t2.SetActive(true);
                break;
            case 9:
                t2.SetActive(false);
                mainQuestText.text="Kill All Enemies And Save Adventurer.";
                GiveRewards(q2Rewards,8);
                break;
            case 10:
                adventure2T3.SetActive(true);
                GiveRewards(q2Rewards,9);
                mainQuestText.text="Talk To Adventurer.";
                break;
            case 11:
                adventure2T3.SetActive(false);
                GiveRewards(q2Rewards,10);
                adventurer2Marker2.RemoveMarker();
                Dragon3Marker.AddMarker();
                Dragon3.SetActive(true);
                mainQuestText.text="Lets See If This Dragon Is Correct.Go And Kill Dragon.";
                break;
            case 12:
                Dragon3.SetActive(false);
                GiveRewards(q2Rewards,11);
                Dragon3Marker.RemoveMarker();
                currentQuestIndex+=1;
                CompleteCurrentQuest();
                break;
        }
    }
/// <summary>///////////////////////////////////////////////////////////////////////////
/// // QUEST 3 //QUEST 3 //QUEST 3 //QUEST 3 //QUEST 3 //QUEST 3 //QUEST 3 //QUEST 3 ///
/// </summary>//////////////////////////////////////////////////////////////////////////
///                             VILLAGE CRONICLES-PART3                              ///
/// </summary>//////////////////////////////////////////////////////////////////////////
    private void Quest3(){
        switch(questPhase){
            case 0:
                mainQuestText.text="Not Again! Lets Go TO Last Nearby Village.";
                GiveRewards(q2Rewards,12);
                village3Marker.AddMarker();
                StartCoroutine(SpawnEnemies(15,Q3P1SpawnLocations,Q3P1Enemies));
                StartCoroutine(ShowAndHide(false,village3NPCS));
                break;
            case 1:
                mainQuestText.text="Save Village From Monsters";
                GiveRewards(q3Rewards,0);
                village3Marker.RemoveMarker();
                break;
            case 2:
                characterInputs.DisableMovement();
                GiveRewards(q3Rewards,1);
                villageAttackBlackScreen.SetActive(true);
                StartCoroutine(ShowAndHide(true,village3NPCS));
                break;
            case 3:
                adventurer3Marker.AddMarker();
                GiveRewards(q3Rewards,2);
                adventure3T1.SetActive(true);
                mainQuestText.text="Talk TO Adventure About This Attack.";
                break;
            case 4:
                adventure3T1.SetActive(false);
                GiveRewards(q3Rewards,3);
                adventurer3Marker.RemoveMarker();
                Dragon4.SetActive(true);
                Dragon4Marker.AddMarker();
                mainQuestText.text="Time To KIll Dragon King.Prepare Everything That You Need Before Going For Final FIght.";
                break;
            case 5:
                Dragon4Marker.RemoveMarker();
                GiveRewards(q3Rewards,4);
                Dragon4.SetActive(false);
                endScreen.SetActive(true);
                characterInputs.DisableMovement();
                break;
        }
    }
    public void UnlockSlayer(){}

/// <summary>
/// Visit Village - P1<Talk To NPC 1> - P2<Talk To NPC 2> - P3<Talk To Merchant> - P4<Talk To Adventurer>
///                   // QUEST 2 //QUEST 2 //QUEST 2 //QUEST 2 //QUEST 2 //QUEST 2 //QUEST 2 // 
/// </summary>

#endregion

int spawnedEnemies;
    private IEnumerator SpawnEnemies(int amount,Transform[] locations,GameObject[] enemies){
        for (int i = 0; i < amount; i++)
        {
            Transform randomLoc=locations[Random.Range(0,locations.Length)];
            GameObject randomEnemy=enemies[Random.Range(0,enemies.Length)];
            GameObject enemy=Instantiate(randomEnemy,randomLoc.position,Quaternion.identity);
            enemy.GetComponent<NavMeshAgent>().Warp(randomLoc.position);
            enemy.GetComponent<Enemy>().isQuestEnemy=true;
            spawnedEnemies+=1;
            Debug.Log("Spawned "+spawnedEnemies);
        }
        yield return new WaitForSeconds(0.005f);
        StopCoroutine(SpawnEnemies(0,null,null));
    }
    private IEnumerator ShowAndHide(bool value,GameObject[] objects){
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(value);
        }
        yield return new WaitForSeconds(0.005f);
        StopCoroutine(ShowAndHide(true,null));
    }


    public void GiveRewards(QuestRewardsScriptableObject rewardSO,int phaseIndex){
        int coins=PlayerPrefs.GetInt("Coins");
        coins+=rewardSO.QuestRewards[phaseIndex].coins;
        PlayerPrefs.SetInt("Coins",coins);
        switch (rewardSO.QuestRewards[phaseIndex].rewardXpType)
        {
            case QuestRewardsScriptableObject.QuestReward.RewardXpType.strengthXP:
            PlayerData.Instance.AddExperience(SkillCategory.Strength,rewardSO.QuestRewards[phaseIndex].RewardAmount);
            break;
            case QuestRewardsScriptableObject.QuestReward.RewardXpType.attackXP:
            PlayerData.Instance.AddExperience(SkillCategory.Attack,rewardSO.QuestRewards[phaseIndex].RewardAmount);
            break;
            case QuestRewardsScriptableObject.QuestReward.RewardXpType.agilityXP:
            PlayerData.Instance.AddExperience(SkillCategory.Agility,rewardSO.QuestRewards[phaseIndex].RewardAmount);
            break;
            case QuestRewardsScriptableObject.QuestReward.RewardXpType.defenceXp:
            PlayerData.Instance.AddExperience(SkillCategory.Defense,rewardSO.QuestRewards[phaseIndex].RewardAmount);
            break;
            case QuestRewardsScriptableObject.QuestReward.RewardXpType.disciplineXP:
            PlayerData.Instance.AddExperience(SkillCategory.Discipline,rewardSO.QuestRewards[phaseIndex].RewardAmount);
            break;
            case QuestRewardsScriptableObject.QuestReward.RewardXpType.moraleXP:
            PlayerData.Instance.AddExperience(SkillCategory.Morale,rewardSO.QuestRewards[phaseIndex].RewardAmount);
            break;
            case QuestRewardsScriptableObject.QuestReward.RewardXpType.speedXP:
            PlayerData.Instance.AddExperience(SkillCategory.Speed,rewardSO.QuestRewards[phaseIndex].RewardAmount);
            break;
        }
    }
}

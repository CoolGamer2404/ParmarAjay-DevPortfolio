using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
public class DroneHandler : MonoBehaviour
{
    public InputActionAsset _mainInputActionAssets;
    public DroneStatsScriptableObject droneStatsScriptableObject;

    public UIhandler uIhandler;
    public GameObject camera;
    public Vector3 cameraPosition;
    public Quaternion cameraRotation;
    public GameObject player;
    public TrainingLobbyPlayerSpawner playerSpawner;
    public TrainingLobbyHandler trainingLobbyHandler;

    [SerializeField]
    private SkinsSetupHandler skinsSetup;

    [SerializeField]
    private PhotonView myPV;

    [SerializeField]
    private int __DroneNumber;

    [SerializeField]
    private int joinNumber = 0;

    [SerializeField]
    private int teamNumber = 1;

    [SerializeField]
    private GameObject beacon_Beam_Prefab;

    public GameLoader gameLoader;

    private List<string> processUIDs = new List<string>();
    private ExitGames.Client.Photon.Hashtable customProps = new ExitGames.Client.Photon.Hashtable();

    void Awake()
    {
        myPV = this.GetComponent<PhotonView>();
        droneStatsScriptableObject.currentHealth = droneStatsScriptableObject.baseHealth;
        droneStatsScriptableObject.currentEnergy = droneStatsScriptableObject.baseEnergy;
    }

    void Start()
    {
        if (myPV.IsMine)
            switch (__DroneNumber)
            {
                case 1:
                    skinsSetup.SetSkin(__DroneNumber, PlayerPrefs.GetInt("Drone1CurrentSkin"));
                    SyncSkin(__DroneNumber, PlayerPrefs.GetInt("Drone1CurrentSkin"));
                    gameLoader.isSkinsLoaded = true;
                    break;
                case 2:
                    skinsSetup.SetSkin(__DroneNumber, PlayerPrefs.GetInt("Drone2CurrentSkin"));
                    SyncSkin(__DroneNumber, PlayerPrefs.GetInt("Drone2CurrentSkin"));
                    gameLoader.isSkinsLoaded = true;
                    break;
                case 3:
                    skinsSetup.SetSkin(__DroneNumber, PlayerPrefs.GetInt("Drone3CurrentSkin"));
                    SyncSkin(__DroneNumber, PlayerPrefs.GetInt("Drone3CurrentSkin"));
                    gameLoader.isSkinsLoaded = true;
                    break;
                case 4:
                    skinsSetup.SetSkin(__DroneNumber, PlayerPrefs.GetInt("Drone4CurrentSkin"));
                    SyncSkin(__DroneNumber, PlayerPrefs.GetInt("Drone4CurrentSkin"));
                    gameLoader.isSkinsLoaded = true;
                    break;
                case 5:
                    skinsSetup.SetSkin(__DroneNumber, PlayerPrefs.GetInt("Drone5CurrentSkin"));
                    SyncSkin(__DroneNumber, PlayerPrefs.GetInt("Drone5CurrentSkin"));
                    gameLoader.isSkinsLoaded = true;
                    break;
            }

        #region OLD CODE
        /*if (__DroneNumber == 1)
        {
            skinsSetup.SetSkin(__DroneNumber, PlayerPrefs.GetInt("Drone1CurrentSkin"));
            SyncSkin(__DroneNumber, PlayerPrefs.GetInt("Drone1CurrentSkin"));
        }
        else if (__DroneNumber == 2)
        {
            skinsSetup.SetSkin(__DroneNumber, PlayerPrefs.GetInt("Drone2CurrentSkin"));
            SyncSkin(__DroneNumber, PlayerPrefs.GetInt("Drone2CurrentSkin"));
        }
        else if (__DroneNumber == 3)
        {
            skinsSetup.SetSkin(__DroneNumber, PlayerPrefs.GetInt("Drone3CurrentSkin"));
            SyncSkin(__DroneNumber, PlayerPrefs.GetInt("Drone3CurrentSkin"));
        }
        else if (__DroneNumber == 4)
        {
            skinsSetup.SetSkin(__DroneNumber, PlayerPrefs.GetInt("Drone4CurrentSkin"));
            SyncSkin(__DroneNumber, PlayerPrefs.GetInt("Drone4CurrentSkin"));
        }
        else if (__DroneNumber == 5)
        {
            skinsSetup.SetSkin(__DroneNumber, PlayerPrefs.GetInt("Drone5CurrentSkin"));
            SyncSkin(__DroneNumber, PlayerPrefs.GetInt("Drone5CurrentSkin"));
        }*/
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (
            droneStatsScriptableObject.currentEnergy
            <= droneStatsScriptableObject.baseEnergy - droneStatsScriptableObject.energyRegainRate
        )
        {
            droneStatsScriptableObject.currentEnergy +=
                Time.deltaTime * droneStatsScriptableObject.energyRegainRate;
        }
    }

    void OnFireHold(InputValue input)
    {
        if (player.GetComponent<PhotonView>().IsMine)
        {
            uIhandler.isFirePressed = Convert.ToBoolean(input.Get<float>());
        }
    }

    void OnUseRepairKit(InputValue input)
    {
        if (player.GetComponent<PhotonView>().IsMine)
        {
            uIhandler.UseRepairKit();
        }
    }

    void OnUseBattery(InputValue input)
    {
        if (player.GetComponent<PhotonView>().IsMine)
        {
            uIhandler.UseBattery();
        }
    }

    public void TakeDamage(int dmg)
    {
        droneStatsScriptableObject.currentHealth -= dmg;
        return;
    }

    /// <summary>
    /// Multiplayer Damage Handler
    /// </summary>

    public void ApplyDamage(int dmg)
    {
        player.GetComponent<PhotonView>().RPC("RPC_TakeDamage", RpcTarget.All, dmg);
    }

    [PunRPC]
    void RPC_TakeDamage(int damage)
    {
        if (!player.GetComponent<PhotonView>().IsMine)
            return;

        droneStatsScriptableObject.currentHealth -= damage;

        if (droneStatsScriptableObject.currentHealth <= 0)
        {
            //Die & Respawn
            camera.transform.SetParent(null);
            PhotonNetwork.Destroy(this.gameObject);
            playerSpawner.Respawn();
        }
        Debug.Log("Took Damage : " + damage.ToString());
    }

    public void SyncSkin(int _droneNumber, int _skinNumber)
    {
        Debug.Log(
            "This is from sync skin first Log:="
                + _droneNumber.ToString()
                + "_:_"
                + _skinNumber.ToString()
        );
        //string dNum = JsonUtility.ToJson(_droneNumber);
        //string sNum = JsonUtility.ToJson(_skinNumber);
        myPV.RPC("RPC_SyncSkin", RpcTarget.OthersBuffered, _droneNumber, _skinNumber);
        //Debug.Log("This is from sync skin second Log:="+dNum+"_:_"+sNum);
    }

    [PunRPC]
    void RPC_SyncSkin(int droneNum, int skinNum)
    {
        Debug.Log(
            "This is from RPC_SyncSkin first Log:="
                + droneNum.ToString()
                + "_:_"
                + skinNum.ToString()
                + "____MY ID IS:-"
                + myPV.ViewID.ToString()
        );
        //int myDroneNum = JsonUtility.FromJson<int>(droneNum);
        //int mySkinNum = JsonUtility.FromJson<int>(skinNum);
        skinsSetup.SetSkin(droneNum, skinNum);
        //Debug.Log("This is from RPC_SyncSkin second Log:="+myDroneNum.ToString()+"_:_"+mySkinNum.ToString());
    }

    [PunRPC]
    void RPC_StartMode(string mode)
    {
        Debug.Log(mode.ToString());
        PhotonNetwork.LoadLevel(mode);
        /*switch (mode)
        {
            case "Survival":
                PhotonNetwork.LoadLevel("");
                break;
            case "BattleRoyale":
                PhotonNetwork.LoadLevel("");
                break;
            case "1V1":
                PhotonNetwork.LoadLevel("1V1");
                break;
        }*/
    }

    [PunRPC]
    void RPC_StartGame()
    {
        gameLoader.startGameModeHandler.StartGame();
    }

    [PunRPC]
    void RPC_SetJoinData(int joinNum, int teamNum, string uid)
    {
        ExitGames.Client.Photon.Hashtable properties = PhotonNetwork.LocalPlayer.CustomProperties;
        if (uid == PlayerPrefs.GetString("PlayerUID"))
        {
            Debug.Log(
                "Got Request From :"
                    + properties["PlayerUID"].ToString()
                    + "...For Seting Team number To:-"
                    + teamNum.ToString()
                    + "  &  Join Number To ;-"
                    + joinNum.ToString()
            );
            properties["PlayerTeamNumber"] = teamNum;
            properties["PlayerJoinNumber"] = joinNum;
            PhotonNetwork.LocalPlayer.SetCustomProperties(properties);
            myPV.RPC("RPC_PlayerJoined", RpcTarget.MasterClient);
            Debug.Log("Calling RPC_PLAYERJOINED");
            if (myPV.IsMine)
                gameLoader.isDroneDataLoaded = true;
        }
    }

    //private Queue<string> requestQueue = new Queue<string>();
    //private bool isProcessing = false;
    [PunRPC]
    void RPC_ShowCasePlayerJoin(string uid)
    {
        if (myPV.IsMine)
        {
            trainingLobbyHandler.playerShowcaseHandler.ShowCaseJoin(uid);
            Debug.LogFormat($"Got Request In Drone Handler For Showcasing Player Join :- {uid}");
        }
    }

    private Semaphore metaDataSemaphore = new Semaphore(1, 1);

    [PunRPC]
    void RPC_MetaDataRequest(string uid)
    {
        metaDataSemaphore.WaitOne();
        /*if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            requestQueue.Enqueue(uid);
            ProcessQueue();
        }*/
        try
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                Debug.LogFormat(
                    $"Before Checking StateMent processUIDs Count is {processUIDs.Count}"
                );
                Debug.LogFormat(
                    $"Before Checking StateMent player Count is {int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["CurrentTotalPlayers"].ToString())}"
                );
                if (
                    processUIDs.Count
                    == int.Parse(
                        PhotonNetwork.CurrentRoom.CustomProperties["PlayersLimit"].ToString()
                    )
                )
                {
                    Debug.LogFormat($"Reached Maximum Player Limit Of {processUIDs.Count}");
                    StartCoroutine(ProcessQueue());
                }
                else if (
                    processUIDs.Count
                    != int.Parse(
                        PhotonNetwork.CurrentRoom.CustomProperties["PlayersLimit"].ToString()
                    )
                )
                {
                    processUIDs.Add(uid);
                    myPV.RPC("RPC_ShowCasePlayerJoin", RpcTarget.AllBuffered, uid);
                    customProps["CurrentTotalPlayers"] = processUIDs.Count;
                    PhotonNetwork.CurrentRoom.SetCustomProperties(customProps);

                    //Added UID To Process UID
                    Debug.LogFormat(
                        $"After Adding UID To processUIDs Count is {processUIDs.Count}"
                    );
                    //Now Check If UID.Count Is Equal To Minimum Player Amount Once More
                    if (
                        processUIDs.Count
                        == int.Parse(
                            PhotonNetwork.CurrentRoom.CustomProperties["PlayersLimit"].ToString()
                        )
                    )
                    {
                        Debug.LogFormat($"Reached Maximum Player Limit Of {processUIDs.Count}");
                        StartCoroutine(ProcessQueue());
                    }
                }
                /*joinNumber += 1;
                if (teamNumber == 1)
                {
                    myPV.RPC("RPC_SetJoinData", RpcTarget.AllBuffered, joinNumber, teamNumber, uid);
                    Debug.LogFormat($"RPC_SetJoinData : {joinNumber} : {teamNumber} : {uid};");
                    teamNumber += 1;
                    return;
    
                    // this will get current team number than send it back and then +1 into it
                    // Exe. current is 1
                    // send it back
                    // add +1
                    // now it is 2
                }
                if (teamNumber == 2)
                {
                    myPV.RPC("RPC_SetJoinData", RpcTarget.AllBuffered, joinNumber, teamNumber, uid);
                    Debug.LogFormat($"RPC_SetJoinData : {joinNumber} : {teamNumber} : {uid};");
                    teamNumber -= 1;
                    return;
    
                    // this will get current team number than send it back and then -1 into it
                    // Exe. current is 2
                    // send it back
                    // add -1
                    // now it is 1
                }*/
            }
        }
        finally
        {
            metaDataSemaphore.Release();
        }
    }

    private bool isQuickStarted = false;

    [PunRPC]
    void RPC_QuickStartGame()
    {
        Debug.Log("Quick Started Game!!!");
        StartCoroutine(ProcessQueue());
        isQuickStarted = true;
    }

    private IEnumerator ProcessQueue()
    {
        for (int i = 0; i < processUIDs.Count; i++)
        {
            joinNumber += 1;
            if (teamNumber == 1)
            {
                myPV.RPC(
                    "RPC_SetJoinData",
                    RpcTarget.AllBuffered,
                    joinNumber,
                    teamNumber,
                    processUIDs[i]
                );
                Debug.LogFormat(
                    $"RPC_SetJoinData : {joinNumber} : {teamNumber} : {processUIDs[i]};"
                );
                teamNumber += 1;

                // this will get current team number than send it back and then +1 into it
                // Exe. current is 1
                // send it back
                // add +1
                // now it is 2
            }
            else if (teamNumber == 2)
            {
                myPV.RPC(
                    "RPC_SetJoinData",
                    RpcTarget.AllBuffered,
                    joinNumber,
                    teamNumber,
                    processUIDs[i]
                );
                Debug.LogFormat(
                    $"RPC_SetJoinData : {joinNumber} : {teamNumber} : {processUIDs[i]};"
                );
                teamNumber -= 1;

                // this will get current team number than send it back and then -1 into it
                // Exe. current is 2
                // send it back
                // add -1
                // now it is 1
            }
        }
        yield return new WaitForSeconds(3);
        if (isQuickStarted)
        {
            myPV.RPC(
                "RPC_StartMode",
                RpcTarget.AllBuffered,
                PhotonNetwork.CurrentRoom.CustomProperties["GameMode"]
            );
        }
        StopAllCoroutines();
    }

    #region  PROCESSQUEUE
    /*
    void ProcessQueue()
    {
        if (isProcessing || requestQueue.Count == 0)
            return;

        isProcessing = true;
        string uid = requestQueue.Dequeue();

        // Increment the join number for each new player
        joinNumber += 1;

        // Send the join data to all clients
        myPV.RPC("RPC_SetJoinData", RpcTarget.AllBuffered, joinNumber, teamNumber, uid);
        Debug.LogFormat($"RPC_SetJoinData : {joinNumber} : {teamNumber} : {uid};");

        // Alternate the team number between 1 and 2
        if (teamNumber == 1)
        {
            teamNumber += 1;
        }
        else if (teamNumber == 2)
        {
            teamNumber -= 1;
        }

        isProcessing = false;

        // Process the next request in the queue
        ProcessQueue();
    }*/
    #endregion

    public List<string> playersReadyId;

    public int playersJoinedAmount=0;

    private Semaphore playerReadySemaphore = new Semaphore(1, 1);

    [PunRPC]
    void RPC_PlayerIsReady(string id)
    {
        playerReadySemaphore.WaitOne();
        try
        {
            playersReadyId.Add(id);
            for (int i = 0; i < playersReadyId.Count; i++)
            {
                string newString = playersReadyId[i].ToString();
                Debug.LogFormat($"Players ready ID {i} == {newString}");
            }
        }
        finally
        {
            playerReadySemaphore.Release();
        }
    }

    private Semaphore playerJoinedSemaphore = new Semaphore(1, 1);

    [PunRPC]
    void RPC_PlayerJoined()
    {
        Debug.Log("Runnind RPC_PLAYERJOINED");
        playerJoinedSemaphore.WaitOne();
        try
        {
            playersJoinedAmount+=1;
            //playersJoinedId.Add(uid);
        }
        finally
        {
            playerJoinedSemaphore.Release();
        }
    }

    [PunRPC]
    void RPC_StartGame_GameScene()
    {
        trainingLobbyHandler.StartGame();
    }

    [PunRPC]
    void RPC_SpawnBeacon(){
        if(!myPV.IsMine)
        return;
        PhotonNetwork.Instantiate(beacon_Beam_Prefab.name,transform.position,Quaternion.identity);
    }
}

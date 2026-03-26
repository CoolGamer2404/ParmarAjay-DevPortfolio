using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKeyHandler : MonoBehaviour
{
    public GameObject EnemyKeyGameObject;
    public Transform[] EnemyKeySpawnPosition;
    public int EnemyKeySpawnNumbers;
    public GameObject EnemyKeyParent;
    public int SpawnNumber;

    //For Assigninning
    public GameObject SpawnenedEnemyKey;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Slot;
    public GameObject PickupButton;
    public GameObject DropButton;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNumber=UnityEngine.Random.Range(0,EnemyKeySpawnNumbers);
        SpawnenedEnemyKey=Instantiate(EnemyKeyGameObject, EnemyKeySpawnPosition[SpawnNumber].position, EnemyKeySpawnPosition[SpawnNumber].rotation);
        EnemyKeyParent=EnemyKeySpawnPosition[SpawnNumber].gameObject;
        SpawnenedEnemyKey.transform.SetParent(EnemyKeyParent.transform);
        SpawnenedEnemyKey.GetComponent<Inventory>().player=Player.transform;
        SpawnenedEnemyKey.GetComponent<Inventory>().PickUpButton = PickupButton;
        SpawnenedEnemyKey.GetComponent<Inventory>().DropButton = DropButton;
        SpawnenedEnemyKey.GetComponent<Inventory>().ItemSlot=Slot.transform;
    }
}

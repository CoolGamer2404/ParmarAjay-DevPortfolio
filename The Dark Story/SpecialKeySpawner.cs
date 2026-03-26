using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialKeySpawner : MonoBehaviour
{
    public GameObject SpecialKeyGameObject;
    public Transform[] SpecialKeySpawnPosition;
    public int SpecialKeySpawnNumbers;
    public GameObject SpecialKeyParent;
    public int SpawnNumber;

    //For Assigninning
    public GameObject SpawnenedSpecialKey;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Slot;
    public GameObject PickupButton;
    public GameObject DropButton;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNumber=UnityEngine.Random.Range(0,SpecialKeySpawnNumbers);
        SpawnenedSpecialKey=Instantiate(SpecialKeyGameObject, SpecialKeySpawnPosition[SpawnNumber].position, SpecialKeySpawnPosition[SpawnNumber].rotation);
        SpecialKeyParent=SpecialKeySpawnPosition[SpawnNumber].gameObject;
        SpawnenedSpecialKey.transform.SetParent(SpecialKeyParent.transform);
        SpawnenedSpecialKey.GetComponent<Inventory>().player=Player.transform;
        SpawnenedSpecialKey.GetComponent<Inventory>().PickUpButton = PickupButton;
        SpawnenedSpecialKey.GetComponent<Inventory>().DropButton = DropButton;
        SpawnenedSpecialKey.GetComponent<Inventory>().ItemSlot=Slot.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

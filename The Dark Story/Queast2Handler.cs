using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queast2Handler : MonoBehaviour
{
    public GameObject LockerKeyPrefab;
    public Transform[] LockerKeySpawnLocations;
    public int LockerKeySpawnLocationsnumber;
    public GameObject player;
    public Transform itemSlot;
    public GameObject pickupButton;
    public GameObject dropButton;
    public GameObject SpawnedKey;
    public int NumberOfSpawnTransform;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfSpawnTransform = UnityEngine.Random.Range(0, LockerKeySpawnLocationsnumber);
        SpawnedKey = Instantiate(LockerKeyPrefab,LockerKeySpawnLocations[NumberOfSpawnTransform].position,LockerKeySpawnLocations[NumberOfSpawnTransform].rotation);
        SpawnedKey.GetComponent<Inventory>().ItemSlot = itemSlot;
        SpawnedKey.GetComponent<Inventory>().player = player.transform;
        SpawnedKey.GetComponent<Inventory>().PickUpButton = pickupButton;
        SpawnedKey.GetComponent<Inventory>().DropButton = dropButton;
        SpawnedKey.transform.parent = LockerKeySpawnLocations[NumberOfSpawnTransform].transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

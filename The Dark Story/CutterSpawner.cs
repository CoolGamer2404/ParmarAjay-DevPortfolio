using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterSpawner : MonoBehaviour
{
    public GameObject CutterGameObject;
    public Transform[] CutterSpawnPosition;
    public int CutterSpawnNumbers;
    public GameObject CutterParent;
    public int SpawnNumber;
    
    //For Assigninning
    public GameObject SpawnenedCutter;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Slot;
    public GameObject PickupButton;
    public GameObject DropButton;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNumber=UnityEngine.Random.Range(0,CutterSpawnNumbers);
        SpawnenedCutter=Instantiate(CutterGameObject, CutterSpawnPosition[SpawnNumber].position, CutterSpawnPosition[SpawnNumber].rotation);
        CutterParent=CutterSpawnPosition[SpawnNumber].gameObject;
        SpawnenedCutter.transform.SetParent(CutterParent.transform);
        SpawnenedCutter.GetComponent<Inventory>().player=Player.transform;
        SpawnenedCutter.GetComponent<Inventory>().PickUpButton = PickupButton;
        SpawnenedCutter.GetComponent<Inventory>().DropButton = DropButton;
        SpawnenedCutter.GetComponent<Inventory>().ItemSlot=Slot.transform;
    }
}

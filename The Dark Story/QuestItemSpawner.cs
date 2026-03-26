using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemSpawner : MonoBehaviour
{
    //spawn Crawbar For Quest1
    public GameObject CrawBarGameObject;
    public Transform[] CrawBarSpawnPosition;
    public int CrawbarSpawnNumbers;
    public GameObject CrawBarParent;

    //For Assigninning
    public GameObject SpawnenedCrawbar;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Slot;
    public GameObject PickupButton;
    public GameObject DropButton;

    // Start is called before the first frame update
    void Start()
    {
        SpawnenedCrawbar=Instantiate(CrawBarGameObject, CrawBarSpawnPosition[UnityEngine.Random.Range(0, CrawbarSpawnNumbers)].position, CrawBarSpawnPosition[UnityEngine.Random.Range(0, CrawbarSpawnNumbers)].rotation);
        SpawnenedCrawbar.transform.SetParent(CrawBarParent.transform);
        SpawnenedCrawbar.GetComponent<Inventory>().player=Player.transform;
        SpawnenedCrawbar.GetComponent<Inventory>().PickUpButton = PickupButton;
        SpawnenedCrawbar.GetComponent<Inventory>().DropButton = DropButton;
        SpawnenedCrawbar.GetComponent<Inventory>().ItemSlot=Slot.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

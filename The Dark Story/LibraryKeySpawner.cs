using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryKeySpawner : MonoBehaviour
{
    public GameObject LibraryKeyGameObject;
    public Transform[] LibraryKeySpawnPosition;
    public int LibraryKeySpawnNumbers;
    public GameObject LibraryKeyParent;
    public int SpawnNumber;

    //For Assigninning
    public GameObject SpawnenedLibraryKey;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Slot;
    public GameObject PickupButton;
    public GameObject DropButton;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNumber=UnityEngine.Random.Range(0,LibraryKeySpawnNumbers);
        SpawnenedLibraryKey=Instantiate(LibraryKeyGameObject, LibraryKeySpawnPosition[SpawnNumber].position, LibraryKeySpawnPosition[SpawnNumber].rotation);
        LibraryKeyParent=LibraryKeySpawnPosition[SpawnNumber].gameObject;
        SpawnenedLibraryKey.transform.SetParent(LibraryKeyParent.transform);
        SpawnenedLibraryKey.GetComponent<Inventory>().player=Player.transform;
        SpawnenedLibraryKey.GetComponent<Inventory>().PickUpButton = PickupButton;
        SpawnenedLibraryKey.GetComponent<Inventory>().DropButton = DropButton;
        SpawnenedLibraryKey.GetComponent<Inventory>().ItemSlot=Slot.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

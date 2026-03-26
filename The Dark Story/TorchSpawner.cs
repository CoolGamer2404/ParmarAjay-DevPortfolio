using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSpawner : MonoBehaviour
{
    public GameObject TorchGameObject;
    public Transform[] TorchSpawnPosition;
    public int TorchSpawnNumbers;
    public GameObject TorchParent;
    public int SpawnNumber;
    public Transform RotationTransform;
    
    //For Assigninning
    public GameObject SpawnenedTorch;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Slot;
    public GameObject PickupButton;
    public GameObject TorchIcon1;
    public GameObject TorchIcon2;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNumber=UnityEngine.Random.Range(0,TorchSpawnNumbers);
        SpawnenedTorch=Instantiate(TorchGameObject, TorchSpawnPosition[SpawnNumber].position, TorchSpawnPosition[SpawnNumber].rotation);
        TorchParent=TorchSpawnPosition[SpawnNumber].gameObject;
        SpawnenedTorch.transform.SetParent(TorchParent.transform);
        /*SpawnenedTorch.GetComponent<FlashLight>().player=Player.transform;
        SpawnenedTorch.GetComponent<FlashLight>().PickUpButton = PickupButton;
        SpawnenedTorch.GetComponent<FlashLight>().FlashLightSlot=Slot.transform;
        SpawnenedTorch.GetComponent<FlashLight>().TorchIcon1=TorchIcon1;
        SpawnenedTorch.GetComponent<FlashLight>().TorchIcon2=TorchIcon2;*/
    }
}

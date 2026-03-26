using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool isCoreSlotFull=false;
    public GameObject coreIcon;

    // Start is called before the first frame update
    void Start()
    {
        coreIcon.SetActive(false);
        isCoreSlotFull=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupCore(){
        if(!isCoreSlotFull){
            coreIcon.SetActive(true);
            isCoreSlotFull=true;
            return;
        }
        else if(isCoreSlotFull){
            Debug.Log("Core Slot Is Full");
            return;
        }
    }
    public void UseCore(){
        if(!isCoreSlotFull){
            Debug.Log("No Core");
            return;
        }
        else if(isCoreSlotFull){
            Debug.Log("Core Slot Is Full");
            return;
        }
    }
}

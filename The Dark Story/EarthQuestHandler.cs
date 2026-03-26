using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class EarthQuestHandler : MonoBehaviour
{
    [SerializeField] public static bool isLandscape;
    [SerializeField] public static bool isTree;
    [SerializeField] public static bool isRiver;
    [SerializeField] public static bool isLife;
    [SerializeField] private bool isCompleted;

    [SerializeField] private GameObject Life;
    [SerializeField] private GameObject Landscape;
    [SerializeField] private GameObject River;
    [SerializeField] private GameObject Tree;
    [SerializeField] private GameObject EarthElementJar;

    public Transform PlayerCamera;
    public float distance;
    public float InteractionRange;
    public static bool InteractableWithMachine;
    // Start is called before the first frame update
    void Start()
    {
        Tree.SetActive(false);
        Life.SetActive(false);
        Landscape.SetActive(false);
        River.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerCamera.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= InteractionRange)
        {
            InteractableWithMachine = true;
        }
        if (distanceToPlayer.magnitude >= InteractionRange)
        {
            InteractableWithMachine = false;
        }

        if (InteractableWithMachine == true)
        {
            Raycast();
        }

        if (isLandscape==true && isLife == true && isTree == true && isRiver == true)
        {
            isCompleted = true;
        }
    }
    void Raycast()
    {
        RaycastHit machinehit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out machinehit, distance))
        {
            if (machinehit.transform.tag == "ElementMachine")
            {
                if (CrossPlatformInputManager.GetButtonDown("ItemUse"))
                {
                    Interact();
                }
            }
            else
            {
                return;
            }
        }
    }
    void Interact()
    {
        if(isCompleted == true)
        {
            EarthElementJar.SetActive(false);
            return;
        }
        if (InventoryHandler.EquippedItemName == "Life")
        {
            isLife= true;
            Life.SetActive(true);
            return;
        }
        if (InventoryHandler.EquippedItemName == "Landscape")
        {
            isLife = true;
            Landscape.SetActive(true);
            return;
        }
        if (InventoryHandler.EquippedItemName == "Tree")
        {
            isLife = true;
            Tree.SetActive(true);
            return;
        }
        if (InventoryHandler.EquippedItemName == "River")
        {
            isRiver = true;
            River.SetActive(true);
            return;
        }
    }
}

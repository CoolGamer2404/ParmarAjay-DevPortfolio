using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronCellDoors : MonoBehaviour
{
    private enum ObjectType
    {
        IronDoorhandle,
        MainDoorHandle,
        MainTorch,
    }

    //----------------------------------------MainIronCellHandle----------------------------------------//
    [SerializeField] private ObjectType objectType;
    [SerializeField] private GameObject door;
    [SerializeField] private Vector3 doorOpenPosition;
    // [SerializeField]private Vector3 doorClosePosition;
    [SerializeField] private Animator animator;

    public bool isOpen = false;

    //--------------------------------------MainIronDoorHandle---------------------------------------//

    [ColorUsage(true, true)]
    [SerializeField] private Color greenColor;
    [SerializeField]private Renderer rend;
    //-------------------------------------------MainTorch-------------------------------------------//
    [SerializeField] private GameObject mainTorch;
    [SerializeField] private GameObject handTorch;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        if (objectType == ObjectType.MainTorch)
        {
            handTorch.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            door.transform.localPosition = doorOpenPosition;
        }
        /* else if(!isOpen){
             door.transform.position=doorClosePosition;
         }*/
    }
    public void Interact()
    {
        if (objectType == ObjectType.IronDoorhandle)
        {
            animator.Play("Open");
        }
        else if (objectType == ObjectType.MainDoorHandle)
        {
            animator.Play("Open");
        }
        else if (objectType == ObjectType.MainTorch)
        {
            mainTorch.SetActive(false);
            handTorch.SetActive(true);
            return;
        }

    }

    public void Open()
    {
        isOpen = true;
        if(objectType==ObjectType.MainDoorHandle){
            Material material=rend.material;
            material.SetColor("_EmissionColor", greenColor);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    public float distance;
    public Transform PlayerCamera;
    public float InteractionRange;
    public GameObject Button;
    public static bool InteractableWithSafeLock;
    public static int GenratedPassWord=0;

    public GameObject LockedSafegameObject;
    public static bool SafeisClosed=false;
    // Start is called before the first frame update
    void Start()
    {
        SafeisClosed=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

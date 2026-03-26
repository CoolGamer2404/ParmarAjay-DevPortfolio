using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField]private int TrapNumber;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TheMaze.currenttrapnum = TrapNumber;
            return;
        }
    }
}

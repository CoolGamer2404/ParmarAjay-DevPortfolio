using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetsPart1Handler : MonoBehaviour
{
    public bool[] IsCabinetOpen;
    public GameObject[] Cabinets;
    public string[] CabinetName;
    public int CabinetsNumber; 
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CabinetsNumber; i++){
            CabinetName[i]=Cabinets[i].transform.name;
            IsCabinetOpen[i]=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

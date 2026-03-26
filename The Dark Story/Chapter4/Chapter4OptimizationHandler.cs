using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4OptimizationHandler : MonoBehaviour
{
    [Header("-------------------------Main References-------------------------")]
    [SerializeField] private int currentPhase = 1;

    [Header("--------------------------Phase1<Game1>--------------------------")]
    [SerializeField] private GameObject[] phase1Objects;

    [Header("--------------------------Phase2<Game2>--------------------------")]
    [SerializeField] private GameObject[] phase2Objects;

    [Header("--------------------------Phase3<Game3>--------------------------")]
    [SerializeField] private GameObject[] phase3Objects;


    void Start()
    {
        currentPhase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if(currentPhase == 1)
    }
}

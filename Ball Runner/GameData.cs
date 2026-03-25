using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public bool[] CharacterName;
    public float[] Jump;
    public int[] Health;
    public static int staticHealth;

    // Start is called before the first frame update
    void Start()
    {
        //staticHealth=Health[PlayerController.charnum];
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger_LiamQuest : MonoBehaviour
{
    [SerializeField]private LiamQuest liamQuest;
    [SerializeField]private GameObject Trigger;
    [SerializeField]private GameObject Food;
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="Player"){
            liamQuest.NextQuest();
            Trigger.SetActive(false);
            Food.SetActive(false);
        }
    }
}

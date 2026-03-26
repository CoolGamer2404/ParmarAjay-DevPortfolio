using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loottest : MonoBehaviour
{

    [SerializeField]LootTable lootTable;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Item item=lootTable.GetDrop();
            Debug.Log(item.name);
            Instantiate(item.itemDrop,transform.position,Quaternion.identity);
        }
    }
}

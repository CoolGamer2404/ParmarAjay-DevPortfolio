using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private Transform[] spawnlocation;
    [SerializeField] private Transform selectedSpawnLocation;
    [SerializeField] private Transform cardsParent;
    [SerializeField] private GameObject spawnedCard;
    // Start is called before the first frame update
    void Start()
    {
        selectedSpawnLocation = spawnlocation[Random.Range(0, spawnlocation.Length)];
        spawnedCard = Instantiate(card, selectedSpawnLocation.position, selectedSpawnLocation.rotation, cardsParent);
        spawnedCard.transform.localScale = new Vector3(10, 10, 10);
    }
}

using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float destroyTime = 5;
    [SerializeField] private bool isMultiplayer = false;
    void Update()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0f)
        {
            if (!isMultiplayer)
            {
                Destroy(gameObject);
            }
            else if (isMultiplayer)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}

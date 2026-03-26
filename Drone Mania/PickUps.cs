using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField] private PickupType _pickupType;
    [SerializeField] private IncreaseType _increaseType;
    [SerializeField] private int _increaseAmount = 1;
    private int storedValue;

    private enum PickupType
    {
        Coin1x,
        Coin3x,
        Coin5x,
        Coin10x,
        Coin25x,
        Scrap,
        RepairKit,
        Battery,
    }

    private enum IncreaseType
    {
        Coin,
        Scrap,
        RepairKit,
        Battery,
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log(_pickupType.ToString());
            storedValue = PlayerPrefs.GetInt(_increaseType.ToString());
            if (storedValue != null)
            {
                PlayerPrefs.SetInt(_increaseType.ToString(), storedValue + _increaseAmount);
                Destroy(gameObject);
            }
            if (storedValue == null)
            {
                PlayerPrefs.SetInt(_increaseType.ToString(), _increaseAmount);
                Destroy(gameObject);
            }
        }
    }
}

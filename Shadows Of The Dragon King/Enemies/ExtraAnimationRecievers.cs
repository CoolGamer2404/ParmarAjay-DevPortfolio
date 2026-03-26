using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraAnimationRecievers : MonoBehaviour
{
    public void StartDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    }
    public void EndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }
}

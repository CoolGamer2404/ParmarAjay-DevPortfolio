using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Attack_Trigger_Ritual : MonoBehaviour
{
    private Semaphore giveDMGSemaphore = new Semaphore(1, 1);
    [SerializeField]private float coolDownTime=1f;
    [SerializeField]private Player_Stats player_Stats;
    [SerializeField]private bool isCoolDown=false;
    void OnCollisionEnter(Collision collider){
        if(collider.gameObject.tag=="Attack"){
            GiveDMG();
        }
    }

    void GiveDMG(){
        giveDMGSemaphore.WaitOne();
        try{
            if(!isCoolDown){
                player_Stats.Health-=1;
                player_Stats.UpdateHealth();
                isCoolDown=true;
                StartCoroutine(CD());
            }
        }
        finally
        {
            giveDMGSemaphore.Release();
        }
    }
    private IEnumerator CD(){
        yield return new WaitForSeconds(coolDownTime);
        isCoolDown=false;
    }
}

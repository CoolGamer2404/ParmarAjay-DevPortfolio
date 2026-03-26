using UnityEngine;

public class BossFightTrigger : MonoBehaviour
{
    [Header("Boss Reference")]
    public BossController boss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (boss == null)
        {
            Debug.LogWarning("BossFightTrigger: Boss reference not set.");
            return;
        }

        if (!boss.fightStarted)
        {
            boss.EnableBossFight();
            Debug.Log("Boss fight started.");
        }
        else
        {
            boss.ResumeBossFight();
            Debug.Log("Boss fight resumed.");
        }

        // Disable trigger after use
        gameObject.SetActive(false);
    }
}

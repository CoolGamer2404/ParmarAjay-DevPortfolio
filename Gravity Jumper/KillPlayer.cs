using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public int damageAmount = 3;
    public bool trueDamage = false; // Bypasses invincibility

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DeathHandler handler = other.GetComponent<DeathHandler>();
            MagneBoyController player = other.GetComponent<MagneBoyController>();

            if (handler != null && player != null)
            {
                if (trueDamage || !player.IsInvincible())
                {
                    handler.TakeDamage(damageAmount,trueDamage);
                }
                else
                {
                    // Optional: play block sound or visual
                }
            }
        }
    }
}

using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    public AbilityType abilityType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && AbilityManager.instance != null)
        {
            AbilityManager.instance.SetAbility(abilityType);
            Destroy(gameObject);
        }
    }
}

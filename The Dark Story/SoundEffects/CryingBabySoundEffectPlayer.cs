using UnityEngine;

public class CryingBabySoundEffectPlayer : MonoBehaviour
{
    public AudioClip soundToPlay; // Define your audio clip in the Inspector
    private AudioSource audioSource;
    private bool recentlyPlayed = false;
    private float cooldownTimer = 0f;
    private float cooldownDuration = 5f; // Adjust this as needed

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Assuming the AudioSource is attached to the same GameObject as this script
    }

    private void Update()
    {
        // Cooldown timer counting down
        if (recentlyPlayed)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                recentlyPlayed = false;
                cooldownTimer = 0f;
            }
        }
    }

    public void PlaySound()
    {
        if (soundToPlay != null && !recentlyPlayed)
        {
            if (Random.value < CalculateProbability())
            {
                audioSource.PlayOneShot(soundToPlay);
                recentlyPlayed = true;
                cooldownTimer = cooldownDuration;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySound();
        }
    }


    private float CalculateProbability()
    {
        // Adjust the base chance here
        float baseChance = 0.5f;

        // Increase the probability if it hasn't been played recently
        if (!recentlyPlayed)
        {
            baseChance += 0.2f; // Increase by 20%
        }

        // Decrease the probability if it was recently played
        // and the cooldown timer is not expired yet
        if (recentlyPlayed && cooldownTimer > 0f)
        {
            baseChance -= 0.3f; // Decrease by 30%
        }

        return Mathf.Clamp01(baseChance); // Clamp between 0 and 1
    }
}

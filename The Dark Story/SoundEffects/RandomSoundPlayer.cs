using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    [SerializeField]public AudioClip soundToPlay; // Define your audio clip in the Inspector
    private AudioSource audioSource;
    private bool canPlaySound = true;
    [SerializeField]private float cooldownDuration = 240f; // Minimum time between playing sounds
    [SerializeField]private float nextSoundTime; // Time for the next sound
    [SerializeField] private float minVolume= 0.15f;
    [SerializeField] private float maxVolume= 0.3f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Assuming the AudioSource is attached to the same GameObject as this script

        // Set initial time for next sound
        nextSoundTime = Time.time + Random.Range(0f, cooldownDuration);
    }

    private void Update()
    {
        if (canPlaySound && Time.time >= nextSoundTime)
        {
            PlayRandomSound();
        }
    }

    private void PlayRandomSound()
    {
        if (soundToPlay != null)
        {
            // Generate random volume between 0.2 and 1
            float randomVolume = Random.Range(minVolume, maxVolume);

            // Set the audio source volume to the random volume
            audioSource.volume = randomVolume;

            // Play the sound
            audioSource.PlayOneShot(soundToPlay);

            // Update next sound time with a random value within cooldownDuration
            nextSoundTime = Time.time + Random.Range(cooldownDuration * 2f, cooldownDuration);

            // Prevent playing sounds until cooldown finishes
            canPlaySound = false;

            // Start cooldown timer
            Invoke(nameof(ResetCanPlaySound), cooldownDuration);
        }
    }

    private void ResetCanPlaySound()
    {
        canPlaySound = true;
    }
}

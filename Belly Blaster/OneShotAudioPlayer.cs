using UnityEngine;

public class OneShotAudioPlayer : MonoBehaviour
{
    public AudioSource audioManager;
    public AudioClip oneShotAudioClip;

    public void PlayOneShotAudio()
    {
        audioManager.PlayOneShot(oneShotAudioClip);
    }
}
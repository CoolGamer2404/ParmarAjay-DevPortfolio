using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySoundOneShot : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    public void PlayOneShot(AudioClip audioClip){
        audioSource.PlayOneShot(audioClip);
    }
}

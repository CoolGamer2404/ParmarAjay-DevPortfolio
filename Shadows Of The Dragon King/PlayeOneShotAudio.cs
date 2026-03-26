using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeOneShotAudio : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource;
    [SerializeField]private AudioClip audioClip;
   public void PlayAudio(){
        audioSource.PlayOneShot(audioClip);
   }
}

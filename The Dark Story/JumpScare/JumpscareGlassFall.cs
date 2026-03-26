using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareGlassFall : MonoBehaviour
{

    [SerializeField]private GameObject brokenGlass;
    [SerializeField]private AudioSource brokenGalssAudioSource;
    [SerializeField]private AudioClip glassBrakeAudioClip;

    void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            //Debug.Log("PlayerEntered");
            StartCoroutine(PlayJumpscare());
        }
    }

    private IEnumerator PlayJumpscare(){
        brokenGlass.SetActive(true);
        brokenGalssAudioSource.PlayOneShot(glassBrakeAudioClip);

        yield return new WaitForSeconds(3);
        brokenGalssAudioSource.enabled=false;
        gameObject.SetActive(false);
    }
}

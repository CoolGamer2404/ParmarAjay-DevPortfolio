using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsActivator : MonoBehaviour
{
    [SerializeField] private Light[] spotLights;
    [SerializeField] private Light[] contentmentRoomlights;
    [SerializeField] private Light[] mainRoomLights;

    [SerializeField]public bool isGreenOn;
    [SerializeField]public bool isRedOn;

    [SerializeField]public bool isBlueOn;

    [SerializeField]private AudioSource audioSource;
    [SerializeField]private AudioClip audioClip;

    [SerializeField]private bool lightsActivated=false;

    /// <summary>
    /// use this if we decide to use camera and wanted to show lights turning on
    /// </summary>
    //[SerializeField]private Light[] allLights;

    void Start()
    {
        for (int i = 0; i < spotLights.Length; i++)
        {
            spotLights[i].enabled=false;
        }
        for (int i = 0; i < contentmentRoomlights.Length; i++)
        {
            contentmentRoomlights[i].enabled=false;
        }
        for (int i = 0; i < mainRoomLights.Length; i++)
        {
            mainRoomLights[i].enabled=false;
        }
        lightsActivated = false;
    }

    void Update(){
        if(isBlueOn && isGreenOn && isRedOn && lightsActivated!=true){
            StartLightsActivating();
        }
    }

    public void StartLightsActivating()
    {
        StartCoroutine(TurnOnSpotLight());
    }

    private IEnumerator TurnOnSpotLight()
    {
        for (int i = 0; i < spotLights.Length; i++)
        {
            spotLights[i].enabled = true;
            yield return new WaitForSeconds(0.5f);
            //audioSource.PlayOneShot(audioClip);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(TurnOnContentmentRoomlights());
    }
    private IEnumerator TurnOnContentmentRoomlights()
    {
        for (int i = 0; i < contentmentRoomlights.Length; i++)
        {
            contentmentRoomlights[i].enabled = true;
            yield return new WaitForSeconds(0.5f);
            //audioSource.PlayOneShot(audioClip);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(TurnOnMainRoomLights());
    }

    private IEnumerator TurnOnMainRoomLights()
    {
        for (int i = 0; i < mainRoomLights.Length; i++)
        {
            mainRoomLights[i].enabled = true;
            
            yield return new WaitForSeconds(0.5f);
            //audioSource.PlayOneShot(audioClip);
        }
        yield return new WaitForSeconds(1f);
        lightsActivated = true;
        StopAllCoroutines();
    }
}

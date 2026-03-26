using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.Rendering;

public class JumpScareHandler : MonoBehaviour
{

    public CharacterController characterController;
    public GameObject Character;
    public float CharNewRotation;
    public float timer;
    public bool isTimer = false;
    public Volume volume;
    public float initialVolumeWeight = 1f;
    public GameObject postProcessingGameObject;
    public bool isTimerActive = false;
    [SerializeField] private bool changeRotationOfPlayer=false;


    public void Update()
    {
        if (isTimer & timer >=0.1f && isTimerActive)
        {
            timer -= Time.deltaTime;
            float normalizedTime = timer / 60.0f; // Assuming the timer starts from 60 seconds

            // Decrease the volume weight according to the normalized time
            float newVolumeWeight = Mathf.Lerp(initialVolumeWeight, 0f, 1.0f - normalizedTime);
            volume.weight = newVolumeWeight;
        }
        if (isTimer & timer <= 0f && isTimerActive)
        {
            float normalizedTime = timer / 60.0f; // Assuming the timer starts from 60 seconds

            // Decrease the volume weight according to the normalized time
            float newVolumeWeight = Mathf.Lerp(initialVolumeWeight, 0f, 1.0f - normalizedTime);
            volume.weight = newVolumeWeight;
        }
    }
    public void JumpScareStarted()
    {
        //Making Player Freeze After JumpScare Starts
        characterController.enabled = false;
    }

    public void JumpScareIsAboutToEnd()
    {
        //For Changing Things Before Ending JumpScare
        if (changeRotationOfPlayer) {
            Quaternion newRotation = Quaternion.Euler(Character.transform.rotation.eulerAngles.x, CharNewRotation, Character.transform.rotation.eulerAngles.z);
            Character.transform.rotation = newRotation;
        }
    }

    public void SetActivePostProcessingAndTimer()
    {
        isTimerActive = true;
        postProcessingGameObject.SetActive(true);
    }

    public void JumpScareEnded()
    {
        //Making Player UnFreeze After JumpScare Ends
        characterController.enabled = true;
    }
}

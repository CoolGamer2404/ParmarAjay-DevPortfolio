using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{

    public Camera cameraB;
    public Material cameraMatB;

    private bool playerInCollider = false;
    private bool checkPlayerPresence = false;

    
    // Use this for initialization
    void Start()
    {
        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;
        DeactivatePortalCamera();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = true;
            checkPlayerPresence = true;
            ActivatePortalCamera();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = false;
            checkPlayerPresence = false;
            DeactivatePortalCamera();
        }
    }

    void ActivatePortalCamera()
    {
        cameraB.enabled = true;
        if (checkPlayerPresence)
        {
            StartCoroutine(CheckPlayerPresenceRoutine());
        }
    }

    void DeactivatePortalCamera()
    {
        cameraB.enabled = false;
        if (checkPlayerPresence)
        {
            StopCoroutine(CheckPlayerPresenceRoutine());
        }
    }

    IEnumerator CheckPlayerPresenceRoutine()
    {
        while (checkPlayerPresence)
        {
            yield return new WaitForSeconds(5f); // Check every 5 seconds
            if (!playerInCollider)
            {
                DeactivatePortalCamera();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class DocumentsViewer : MonoBehaviour
{
    [SerializeField] private GameObject documentUI;
    [SerializeField] private Escape escape;
    [SerializeField] private GameObject note;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;

    // Update is called once per frame
    public void Update()
    {
        if (documentUI.activeSelf)
        {
            escape.isdmenuActive = true;
            starterAssetsInputs.cursorLocked = false;
            starterAssetsInputs.cursorInputForLook = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale=0f;
        }
    }

    public void Collect()
    {
        note.SetActive(false);
        documentUI.SetActive(false);
        escape.isdmenuActive = false;
        starterAssetsInputs.cursorLocked = true;
        starterAssetsInputs.cursorInputForLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale=1f;
        TaskTextHandler.documentsCollected += 1;
        return;
    }
}

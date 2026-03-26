using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class HelpPanel : MonoBehaviour
{
    public StarterAssetsInputs starterAssetsInputs;
    // Start is called before the first frame update
    void Start()
    {
        starterAssetsInputs.cursorLocked = false;
        starterAssetsInputs.cursorInputForLook = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void DeActiveUI(){
        starterAssetsInputs.cursorLocked = true;
        starterAssetsInputs.cursorInputForLook = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

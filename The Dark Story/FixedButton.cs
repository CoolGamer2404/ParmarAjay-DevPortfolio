using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

public class FixedButton : MonoBehaviour
{
    public StarterAssetsInputs starterAssetsInputs;
    public bool isPressed;

    //For Sprint
    public bool isSprintButton;
    public static bool isSprint = false;
    public bool isSprintTrue;

    //For Shoot
    public bool isShootButton;
    public static bool isShooting = false;
    public bool isShootTrue;

    //public MyPlayer player;

    //public void SetPlayer(MyPlayer _player)
    //{
    //player = _player;
    //}

    private void Update()
    {
        isSprintTrue = isSprint;
        isShootTrue = isShooting;
    }
    public void pointerDown()
    {
        //player.Jump();
        //isPressed = true;
        if (isShootButton)
        {
            isShooting = true;
        }
        else if (isSprintButton)
        {
            isSprint = true;
        }
    }

    public void pointerUp()
    {
        //isPressed = false;
        if (isShootButton)
        {
            isShooting = false;
        }
        else if (isSprintButton)
        {
            isSprint = false;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    public void VirtualSprintInput(bool virtualSprintState)
    {
        if (isSprint)
            starterAssetsInputs.SprintInput(virtualSprintState);
    }
}

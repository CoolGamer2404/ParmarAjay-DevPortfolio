using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations;

public class CutScene1Handler : MonoBehaviour
{
    public Animator Enemy1CutScene;
    public GameObject Enemy1;
    public CinemachineVirtualCamera CarFollowFromBackCamera;
    public CinemachineVirtualCamera CarFollowFromFrontCamera;
    public CinemachineVirtualCamera LookAtCarCamera;
    public CinemachineVirtualCamera LookAtCar2Camera;
    public CinemachineVirtualCamera LookAtCarFromLeftCamera;
    public CinemachineVirtualCamera LookAtMoonCamera;
    public CinemachineVirtualCamera LookAtBoard1Camera;
    public CinemachineVirtualCamera LookAtBoard2Camera;
    public CinemachineVirtualCamera CarInteriorCam;
    public CinemachineVirtualCamera CharCam1;

    // Start is called before the first frame update
    void Start()
    {
        Enemy1CutScene=Enemy1.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCarFollowFromBackCamera(){
        CarFollowFromFrontCamera.Priority=0;
        LookAtCarCamera.Priority=0;
        LookAtCarFromLeftCamera.Priority=0;
        LookAtMoonCamera.Priority=0;
        LookAtBoard1Camera.Priority=0;
        LookAtBoard2Camera.Priority=0;
        LookAtCar2Camera.Priority=0;
        CarInteriorCam.Priority=0;
        CarFollowFromBackCamera.Priority=1;
    }

    public void SetCarInteriorCam(){
        CarFollowFromFrontCamera.Priority=0;
        LookAtCarCamera.Priority=0;
        LookAtCarFromLeftCamera.Priority=0;
        LookAtMoonCamera.Priority=0;
        LookAtBoard1Camera.Priority=0;
        LookAtBoard2Camera.Priority=0;
        LookAtCar2Camera.Priority=0;
        CarFollowFromBackCamera.Priority=0;
        CharCam1.Priority=0;
        CarInteriorCam.Priority=1;
    }

    public void SetCarFollowFromFrontCamera(){
        LookAtCarCamera.Priority=0;
        LookAtMoonCamera.Priority=0;
        LookAtCarFromLeftCamera.Priority=0;
        LookAtBoard1Camera.Priority=0;
        LookAtBoard2Camera.Priority=0;
        CarFollowFromBackCamera.Priority=0;
        LookAtCar2Camera.Priority=0;
        CarInteriorCam.Priority=0;
        CharCam1.Priority=0;
        CarFollowFromFrontCamera.Priority=1;
    }

    public void SetLookAtMoonCamera(){
        CarFollowFromFrontCamera.Priority=0;
        LookAtCarCamera.Priority=0;
        LookAtCarFromLeftCamera.Priority=0;
        LookAtBoard1Camera.Priority=0;
        LookAtBoard2Camera.Priority=0;
        CarFollowFromBackCamera.Priority=0;
        LookAtCar2Camera.Priority=0;
        CarInteriorCam.Priority=0;
        CharCam1.Priority=0;
        LookAtMoonCamera.Priority=1;
    }

    public void SetLookAtCarCamera(){
        CarFollowFromFrontCamera.Priority=0;
        LookAtMoonCamera.Priority=0;
        LookAtCarFromLeftCamera.Priority=0;
        LookAtBoard1Camera.Priority=0;
        LookAtBoard2Camera.Priority=0;
        CarFollowFromBackCamera.Priority=0;
        LookAtCar2Camera.Priority=0;
        CarInteriorCam.Priority=0;
        CharCam1.Priority=0;
        LookAtCarCamera.Priority=1;
    }

    public void SetLookAtCar2Camera(){
        CarFollowFromFrontCamera.Priority=0;
        LookAtMoonCamera.Priority=0;
        LookAtCarFromLeftCamera.Priority=0;
        LookAtBoard1Camera.Priority=0;
        LookAtBoard2Camera.Priority=0;
        CarFollowFromBackCamera.Priority=0;
        LookAtCarCamera.Priority=0;
        CharCam1.Priority=0;
        LookAtCar2Camera.Priority=1;
    }

    public void SetLookAtBoard1Camera(){
        CarFollowFromFrontCamera.Priority=0;
        LookAtCarCamera.Priority=0;
        LookAtMoonCamera.Priority=0;
        LookAtCarFromLeftCamera.Priority=0;
        LookAtBoard2Camera.Priority=0;
        CarFollowFromBackCamera.Priority=0;
        LookAtCar2Camera.Priority=0;
        CarInteriorCam.Priority=0;
        CharCam1.Priority=0;
        LookAtBoard1Camera.Priority=1;
    }

    public void SetLookAtBoard2Camera(){
        CarFollowFromFrontCamera.Priority=0;
        LookAtCarCamera.Priority=0;
        LookAtMoonCamera.Priority=0;
        LookAtCarFromLeftCamera.Priority=0;
        LookAtBoard1Camera.Priority=0;
        CarFollowFromBackCamera.Priority=0;
        LookAtCar2Camera.Priority=0;
        CarInteriorCam.Priority=0;
        CharCam1.Priority=0;
        LookAtBoard2Camera.Priority=1;
    }

    public void SetLookAtCarFromLeftCamera(){
        CarFollowFromFrontCamera.Priority=0;
        LookAtCarCamera.Priority=0;
        LookAtMoonCamera.Priority=0;
        LookAtBoard1Camera.Priority=0;
        CarFollowFromBackCamera.Priority=0;
        LookAtBoard2Camera.Priority=0;
        LookAtCar2Camera.Priority=0;
        CarInteriorCam.Priority=0;
        CharCam1.Priority=0;
        LookAtCarFromLeftCamera.Priority=1;
    }

    public void SetCharCam1(){
        CarFollowFromFrontCamera.Priority=0;
        LookAtCarCamera.Priority=0;
        LookAtMoonCamera.Priority=0;
        LookAtBoard1Camera.Priority=0;
        CarFollowFromBackCamera.Priority=0;
        LookAtBoard2Camera.Priority=0;
        LookAtCar2Camera.Priority=0;
        CarInteriorCam.Priority=0;
        LookAtCarFromLeftCamera.Priority=0;
        CharCam1.Priority=1;
    }
    public void Enemy1Attack(){
        Enemy1CutScene.SetBool("Attacking",true);
    }
}

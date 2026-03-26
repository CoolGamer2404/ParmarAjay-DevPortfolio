using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class DoorLockHandler : MonoBehaviour
{
    public static string PassWord;
    public float distance;
    public Transform PlayerCamera;
    public float InteractionRange;
    public static bool InteractableWithDoorLock;
    public GameObject Button;
    private static string Button1="Button1";
    private static string Button2="Button2";
    private static string Button3="Button3";
    private static string Button4="Button4";
    private static string Button5="Button5";
    private static string Button6="Button6";
    private static string Button7="Button7";
    private static string Button8="Button8";
    private static string Button9="Button9";
    private static string Button0="Button0";
    private static string ButtonOk="ButtonOk";
    private static string ButtonX="ButtonX";

    public Text PanelText;
    private static int CurrentPass;
    private static int CurrentNumInput;
    private static int firstInput;
    private static int secondInput;
    private static int thirdInput;
    private static int fourthInput;
    private static string firstInputstring;
    private static string secondInputstring;
    private static string thirdInputstring;
    private static string fourthInputstring;

    private static string PassChar1="-";
    private static string PassChar2="-";
    private static string PassChar3="-";
    private static string PassChar4="-";

    public static int GenratedPassChar1=0;
    public static int GenratedPassChar2=0;
    public static int GenratedPassChar3=0;
    public static int GenratedPassChar4=0;
    public static int GenratedPassWord=0;

    public GameObject LockedDoorgameObject;
    private static string DoorScriptName="Door";
    public static bool DoorisClosed=false;
    // Start is called before the first frame update
    void Start()
    {
        firstInputstring=null;
        secondInputstring=null;
        thirdInputstring=null;
        fourthInputstring=null;
        Button=null;
        PanelText.text="----";
        GenratedPassChar1=Random.Range(1,9)*1000;
        GenratedPassChar2=Random.Range(0,9)*100;
        GenratedPassChar3=Random.Range(0,9)*10;
        GenratedPassChar4=Random.Range(0,9)*1;
        (LockedDoorgameObject.transform.GetComponent(DoorScriptName) as MonoBehaviour).enabled=false;
        Debug.Log(GenratedPassChar1+GenratedPassChar2+GenratedPassChar3+GenratedPassChar4);
        GenratedPassWord=GenratedPassChar1+GenratedPassChar2+GenratedPassChar3+GenratedPassChar4;
    }

    // Update is called once per frame
    void Update()
    {
        if(DoorisClosed==false){
            (LockedDoorgameObject.transform.GetComponent(DoorScriptName) as MonoBehaviour).enabled=true;
        }
        if(DoorisClosed==true){
            (LockedDoorgameObject.transform.GetComponent(DoorScriptName) as MonoBehaviour).enabled=false;
        }
        Vector3 distanceToPlayer = PlayerCamera.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= InteractionRange)
        {
            InteractableWithDoorLock = true;
        }
        if (distanceToPlayer.magnitude >= InteractionRange)
        {
            InteractableWithDoorLock = false;
        }

        if(InteractableWithDoorLock==true){
            RayCast();
        }

        if(CurrentPass==0){
            PanelText.text="----";
        }
        if(CurrentPass!=0){
            PanelText.text=CurrentPass.ToString();
        }
    }
    void RayCast(){
        RaycastHit doorlockhit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorlockhit, distance)){
            if(doorlockhit.transform.tag=="Button"){
                Button=doorlockhit.transform.gameObject;
                if(CrossPlatformInputManager.GetButtonDown("ItemUse")){
                    Interact();
                }
            }
            if(doorlockhit.transform.tag!="Button"){
                Button=null;
                CurrentNumInput=0;
            }
        }
    }
    void Interact(){
        if(Button.name==Button0){
            CurrentNumInput=0;
        }
        if(Button.name==Button1){
            CurrentNumInput=1;
        }
        if(Button.name==Button2){
            CurrentNumInput=2;
        }
        if(Button.name==Button3){
            CurrentNumInput=3;
        }
        if(Button.name==Button4){
            CurrentNumInput=4;
        }
        if(Button.name==Button5){
            CurrentNumInput=5;
        }
        if(Button.name==Button6){
            CurrentNumInput=6;
        }
        if(Button.name==Button7){
            CurrentNumInput=7;
        }
        if(Button.name==Button8){
            CurrentNumInput=8;
        }
        if(Button.name==Button9){
            CurrentNumInput=9;
        }
        Calculate();
    }
    void Calculate(){
        if(firstInputstring==null&&Button.name!=ButtonOk&&Button.name!=ButtonX){
            firstInput=CurrentNumInput;
            firstInputstring=CurrentNumInput.ToString();
            CurrentPass=firstInput;
            Debug.Log(CurrentPass.ToString());
            return;
        }
        if(firstInputstring!=null&&secondInputstring==null&&Button.name!=ButtonOk&&Button.name!=ButtonX){
            secondInput=CurrentNumInput;
            secondInputstring=CurrentNumInput.ToString();
            CurrentPass=firstInput*10+secondInput;
            Debug.Log(CurrentPass.ToString());
            return;
        }
        if(firstInputstring!=null&&secondInputstring!=null&&thirdInputstring==null&&Button.name!=ButtonOk&&Button.name!=ButtonX){
            thirdInput=CurrentNumInput;
            thirdInputstring=CurrentNumInput.ToString();
            CurrentPass=firstInput*100+secondInput*10+thirdInput;
            Debug.Log(CurrentPass.ToString());
            return;
        }
        if(firstInputstring!=null&&secondInputstring!=null&&thirdInputstring!=null&&fourthInputstring==null&&Button.name!=ButtonOk&&Button.name!=ButtonX){
            fourthInput=CurrentNumInput;
            fourthInputstring=CurrentNumInput.ToString();
            CurrentPass=firstInput*1000+secondInput*100+thirdInput*10+fourthInput;
            Debug.Log(CurrentPass.ToString());
        }
        if(Button.name==ButtonOk){
            if(CurrentPass==GenratedPassWord){
                Debug.Log("RightPassword");
                CurrentPass=0;
                DoorisClosed=false;
            }
            if(CurrentPass!=GenratedPassWord){
                Debug.Log("WrongPassword");
                CurrentPass=0;
            }
        }
        if(Button.name==ButtonX){
            if(fourthInputstring!=null){
                CurrentPass=firstInput*100+secondInput*10+thirdInput;
                fourthInputstring=null;
                return;
            }
            if(thirdInputstring!=null&&fourthInputstring==null){
                CurrentPass=firstInput*10+secondInput;
                thirdInputstring=null;
                return;
            }
            if(secondInputstring!=null&&thirdInputstring==null&&fourthInputstring==null){
                CurrentPass=firstInput;
                secondInputstring=null;
                return;
            }
            if(firstInputstring!=null&&secondInputstring==null&&thirdInputstring==null&&fourthInputstring==null){
                CurrentPass=0;
                firstInputstring=null;
                return;
            }
        }
    }
}

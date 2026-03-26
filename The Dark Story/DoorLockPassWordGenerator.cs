using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockPassWordGenerator : MonoBehaviour
{
    public Transform PassWordChar1ObjLocation;
    public Transform PassWordChar2ObjLocation;
    public Transform PassWordChar3ObjLocation;
    public Transform PassWordChar4ObjLocation;

    public GameObject Number1gameObject;
    public GameObject Number2gameObject;
    public GameObject Number3gameObject;
    public GameObject Number4gameObject;
    public GameObject Number5gameObject;
    public GameObject Number6gameObject;
    public GameObject Number7gameObject;
    public GameObject Number8gameObject;
    public GameObject Number9gameObject;
    public GameObject Number0gameObject;

    public static int GenPassChar1;
    public static int GenPassChar2;
    public static int GenPassChar3;
    public static int GenPassChar4;

    private static bool GenFirst=false;
    private static bool GenSecond=false;
    private static bool GenThird=false;
    private static bool GenFourth=false;

    private float GenTime=0f;



    // Start is called before the first frame update
    void Start()
    {
        GenTime=0f;
        GenFirst=false;
        GenSecond=false;
        GenThird=false;
        GenFourth=false;
    }
    void Update(){
        if(GenTime<=6f && DoorLockHandler.DoorisClosed==true){
            GenTime+=Time.deltaTime;
        }
        GenPassChar1=DoorLockHandler.GenratedPassChar1;
        GenPassChar2=DoorLockHandler.GenratedPassChar2;
        GenPassChar3=DoorLockHandler.GenratedPassChar3;
        GenPassChar4=DoorLockHandler.GenratedPassChar4;
        if(GenTime>=5f && DoorLockHandler.DoorisClosed==true){
            if(GenFirst==false){
                GenerateOne();
            }
            if(GenSecond==false){
                GenerateTwo();
            }
            if(GenThird==false){
                GenerateThird();
            }
            if(GenFourth==false){
                GenerateFourth();
            }
        } 
    }
    void GenerateOne(){
        if(GenPassChar1==1000){
            Instantiate(Number1gameObject,PassWordChar1ObjLocation.position,PassWordChar1ObjLocation.rotation);
            GenFirst=true;
        }
        if(GenPassChar1==2000){
            Instantiate(Number2gameObject,PassWordChar1ObjLocation.position,PassWordChar1ObjLocation.rotation);
            GenFirst=true;
        }
        if(GenPassChar1==3000){
            Instantiate(Number3gameObject,PassWordChar1ObjLocation.position,PassWordChar1ObjLocation.rotation);
            GenFirst=true;
        }
        if(GenPassChar1==4000){
            Instantiate(Number4gameObject,PassWordChar1ObjLocation.position,PassWordChar1ObjLocation.rotation);
            GenFirst=true;
        }
        if(GenPassChar1==5000){
            Instantiate(Number5gameObject,PassWordChar1ObjLocation.position,PassWordChar1ObjLocation.rotation);
            GenFirst=true;
        }
        if(GenPassChar1==6000){
            Instantiate(Number6gameObject,PassWordChar1ObjLocation.position,PassWordChar1ObjLocation.rotation);
            GenFirst=true;
        }
        if(GenPassChar1==7000){
            Instantiate(Number7gameObject,PassWordChar1ObjLocation.position,PassWordChar1ObjLocation.rotation);
            GenFirst=true;
        }
        if(GenPassChar1==8000){
            Instantiate(Number8gameObject,PassWordChar1ObjLocation.position,PassWordChar1ObjLocation.rotation);
            GenFirst=true;
        }
        if(GenPassChar1==9000){
            Instantiate(Number9gameObject,PassWordChar1ObjLocation.position,PassWordChar1ObjLocation.rotation);
            GenFirst=true;
        }
    }
    void GenerateTwo(){
        if(GenPassChar2==100){
            Instantiate(Number1gameObject,PassWordChar2ObjLocation.position,PassWordChar2ObjLocation.rotation);
            GenSecond=true;
        }
        if(GenPassChar2==200){
            Instantiate(Number2gameObject,PassWordChar2ObjLocation.position,PassWordChar2ObjLocation.rotation);
            GenSecond=true;
        }
        if(GenPassChar2==300){
            Instantiate(Number3gameObject,PassWordChar2ObjLocation.position,PassWordChar2ObjLocation.rotation);
            GenSecond=true;
        }
        if(GenPassChar2==400){
            Instantiate(Number4gameObject,PassWordChar2ObjLocation.position,PassWordChar2ObjLocation.rotation);
            GenSecond=true;
        }
        if(GenPassChar2==500){
            Instantiate(Number5gameObject,PassWordChar2ObjLocation.position,PassWordChar2ObjLocation.rotation);
            GenSecond=true;
        }
        if(GenPassChar2==600){
            Instantiate(Number6gameObject,PassWordChar2ObjLocation.position,PassWordChar2ObjLocation.rotation);
            GenSecond=true;
        }
        if(GenPassChar2==700){
            Instantiate(Number7gameObject,PassWordChar2ObjLocation.position,PassWordChar2ObjLocation.rotation);
            GenSecond=true;
        }
        if(GenPassChar2==800){
            Instantiate(Number8gameObject,PassWordChar2ObjLocation.position,PassWordChar2ObjLocation.rotation);
            GenSecond=true;
        }
        if(GenPassChar2==900){
            Instantiate(Number9gameObject,PassWordChar2ObjLocation.position,PassWordChar2ObjLocation.rotation);
            GenSecond=true;
        }
        if(GenPassChar2==000){
            Instantiate(Number0gameObject,PassWordChar2ObjLocation.position,PassWordChar2ObjLocation.rotation);
            GenSecond=true;
        }
    }
    void GenerateThird(){
        if(GenPassChar3==10){
            Instantiate(Number1gameObject,PassWordChar3ObjLocation.position,PassWordChar3ObjLocation.rotation);
            GenThird=true;
        }
        if(GenPassChar3==20){
            Instantiate(Number2gameObject,PassWordChar3ObjLocation.position,PassWordChar3ObjLocation.rotation);
            GenThird=true;
        }
        if(GenPassChar3==30){
            Instantiate(Number3gameObject,PassWordChar3ObjLocation.position,PassWordChar3ObjLocation.rotation);
            GenThird=true;
        }
        if(GenPassChar3==40){
            Instantiate(Number4gameObject,PassWordChar3ObjLocation.position,PassWordChar3ObjLocation.rotation);
            GenThird=true;
        }
        if(GenPassChar3==50){
            Instantiate(Number5gameObject,PassWordChar3ObjLocation.position,PassWordChar3ObjLocation.rotation);
            GenThird=true;
        }
        if(GenPassChar3==60){
            Instantiate(Number6gameObject,PassWordChar3ObjLocation.position,PassWordChar3ObjLocation.rotation);
            GenThird=true;
        }
        if(GenPassChar3==70){
            Instantiate(Number7gameObject,PassWordChar3ObjLocation.position,PassWordChar3ObjLocation.rotation);
            GenThird=true;
        }
        if(GenPassChar3==80){
            Instantiate(Number8gameObject,PassWordChar3ObjLocation.position,PassWordChar3ObjLocation.rotation);
            GenThird=true;
        }
        if(GenPassChar3==90){
            Instantiate(Number9gameObject,PassWordChar3ObjLocation.position,PassWordChar3ObjLocation.rotation);
            GenThird=true;
        }
        if(GenPassChar3==00){
            Instantiate(Number0gameObject,PassWordChar3ObjLocation.position,PassWordChar3ObjLocation.rotation);
            GenThird=true;
        }
    }
    void GenerateFourth(){
        if(GenPassChar4==1){
            Instantiate(Number1gameObject,PassWordChar4ObjLocation.position,PassWordChar4ObjLocation.rotation);
            GenFourth=true;
        }
        if(GenPassChar4==2){
            Instantiate(Number2gameObject,PassWordChar4ObjLocation.position,PassWordChar4ObjLocation.rotation);
            GenFourth=true;
        }
        if(GenPassChar4==3){
            Instantiate(Number3gameObject,PassWordChar4ObjLocation.position,PassWordChar4ObjLocation.rotation);
            GenFourth=true;
        }
        if(GenPassChar4==4){
            Instantiate(Number4gameObject,PassWordChar4ObjLocation.position,PassWordChar4ObjLocation.rotation);
            GenFourth=true;
        }
        if(GenPassChar4==5){
            Instantiate(Number5gameObject,PassWordChar4ObjLocation.position,PassWordChar4ObjLocation.rotation);
            GenFourth=true;
        }
        if(GenPassChar4==6){
            Instantiate(Number6gameObject,PassWordChar4ObjLocation.position,PassWordChar4ObjLocation.rotation);
            GenFourth=true;
        }
        if(GenPassChar4==7){
            Instantiate(Number7gameObject,PassWordChar4ObjLocation.position,PassWordChar4ObjLocation.rotation);
            GenFourth=true;
        }
        if(GenPassChar4==8){
            Instantiate(Number8gameObject,PassWordChar4ObjLocation.position,PassWordChar4ObjLocation.rotation);
            GenFourth=true;
        }
        if(GenPassChar4==9){
            Instantiate(Number9gameObject,PassWordChar4ObjLocation.position,PassWordChar4ObjLocation.rotation);
            GenFourth=true;
        }
        if(GenPassChar4==0){
            Instantiate(Number0gameObject,PassWordChar4ObjLocation.position,PassWordChar4ObjLocation.rotation);
            GenFourth=true;
        }
    }
}

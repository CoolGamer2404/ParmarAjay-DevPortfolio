using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeHandler : MonoBehaviour
{
    public static int Char1;
    public static int Char2;
    public static int Char3;
    public static int Char4;

    public static int Sequence1;
    public static int Sequence2;
    public static int Sequence3;
    public static int Sequence4;

    private static int RandomSequence;
    private static bool RandomSequenceGenrated;
    private static bool PassGenerated;
    public static int Password;

    private static int FirstChar;
    private static int SecondChar;
    private static int ThirdChar;
    private static int FourthChar;

    public Transform transform;
    public Transform safeTransForm;
    private static string Script1="SafeHandler";
    private static string Script2="SafePassWordSpawner";
    private static string Script3="Safe";

    // Start is called before the first frame update
    void Start()
    {
        RandomSequenceGenrated=false;
        PassGenerated=false;
        Password=0000;
        Char1=Random.Range(1,9);
        Char2=Random.Range(0,9);
        Char3=Random.Range(0,9);
        Char4=Random.Range(0,9);

        FirstChar=0;
        SecondChar=0;
        ThirdChar=0;
        FourthChar=0;

        Debug.Log(Char1);
        Debug.Log(Char2);
        Debug.Log(Char3);
        Debug.Log(Char4);

        RandomSequence=Random.Range(1,24);
        Debug.Log(RandomSequence);
    }

    // Update is called once per frame
    void Update()
    {
        if(RandomSequenceGenrated==false){
            Genrate();
        }
        if(RandomSequenceGenrated==true){
            ConvertToPass();
        }
        if(PassGenerated==false){
            GenratePass();
        }
        if(RandomSequenceGenrated==true && PassGenerated==true){
            (transform.GetComponent(Script2) as MonoBehaviour).enabled=true;
            (transform.GetComponent(Script1) as MonoBehaviour).enabled=false;
        }
    }
    void Genrate(){
        if(RandomSequence==1){
            Sequence1=1;
            Sequence2=2;
            Sequence3=3;
            Sequence4=4;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==2){
            Sequence1=2;
            Sequence2=3;
            Sequence3=4;
            Sequence4=1;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==3){
            Sequence1=2;
            Sequence2=4;
            Sequence3=1;
            Sequence4=3;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==4){
            Sequence1=3;
            Sequence2=1;
            Sequence3=2;
            Sequence4=4;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==5){
            Sequence1=1;
            Sequence2=2;
            Sequence3=4;
            Sequence4=3;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==6){
            Sequence1=4;
            Sequence2=1;
            Sequence3=3;
            Sequence4=2;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==7){
            Sequence1=4;
            Sequence2=3;
            Sequence3=2;
            Sequence4=1;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==8){
            Sequence1=3;
            Sequence2=2;
            Sequence3=4;
            Sequence4=1;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==9){
            Sequence1=2;
            Sequence2=1;
            Sequence3=4;
            Sequence4=3;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==10){
            Sequence1=4;
            Sequence2=2;
            Sequence3=3;
            Sequence4=1;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==11){
            Sequence1=1;
            Sequence2=3;
            Sequence3=4;
            Sequence4=2;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==12){
            Sequence1=2;
            Sequence2=1;
            Sequence3=3;
            Sequence4=4;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==13){
            Sequence1=3;
            Sequence2=4;
            Sequence3=2;
            Sequence4=1;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==14){
            Sequence1=3;
            Sequence2=4;
            Sequence3=1;
            Sequence4=2;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==15){
            Sequence1=1;
            Sequence2=3;
            Sequence3=4;
            Sequence4=2;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==16){
            Sequence1=2;
            Sequence2=4;
            Sequence3=3;
            Sequence4=1;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==17){
            Sequence1=2;
            Sequence2=3;
            Sequence3=1;
            Sequence4=4;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==18){
            Sequence1=4;
            Sequence2=3;
            Sequence3=1;
            Sequence4=2;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==19){
            Sequence1=1;
            Sequence2=4;
            Sequence3=2;
            Sequence4=3;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==20){
            Sequence1=4;
            Sequence2=2;
            Sequence3=1;
            Sequence4=3;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==21){
            Sequence1=3;
            Sequence2=1;
            Sequence3=4;
            Sequence4=2;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==22){
            Sequence1=4;
            Sequence2=1;
            Sequence3=2;
            Sequence4=3;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==23){
            Sequence1=1;
            Sequence2=4;
            Sequence3=3;
            Sequence4=2;
            RandomSequenceGenrated=true;
            return;
        }
        if(RandomSequence==24){
            Sequence1=3;
            Sequence2=2;
            Sequence3=1;
            Sequence4=4;
            RandomSequenceGenrated=true;
            return;
        }
    }
    void ConvertToPass(){
        //For Seq1
        if(Sequence1==1){
            FirstChar=Char1*1000;
        }
        if(Sequence1==2){
            SecondChar=Char1*100;
        }
        if(Sequence1==3){
            ThirdChar=Char1*10;
        }
        if(Sequence1==4){
            FourthChar=Char1;
        }
        //For Seq2
        if(Sequence2==1){
            FirstChar=Char2*1000;
        }
        if(Sequence2==2){
            SecondChar=Char2*100;
        }
        if(Sequence2==3){
            ThirdChar=Char2*10;
        }
        if(Sequence2==4){
            FourthChar=Char2;
        }
        //For Seq3
        if(Sequence3==1){
            FirstChar=Char3*1000;
        }
        if(Sequence3==2){
            SecondChar=Char3*100;
        }
        if(Sequence3==3){
            ThirdChar=Char3*10;
        }
        if(Sequence3==4){
            FourthChar=Char3;
        }
        //For Seq4
        if(Sequence4==1){
            FirstChar=Char4*1000;
        }
        if(Sequence4==2){
            SecondChar=Char4*100;
        }
        if(Sequence4==3){
            ThirdChar=Char4*10;
        }
        if(Sequence4==4){
            FourthChar=Char4;
        }
        return;
    }
    void GenratePass(){
        Password=FirstChar+SecondChar+ThirdChar+FourthChar;
        (safeTransForm.GetComponent(Script3) as MonoBehaviour).enabled=true;
        Safe.GenratedPassWord=Password;
        Debug.Log("Your Password For Locker Is:"+Password);
        PassGenerated=true;
        return;
    }
}

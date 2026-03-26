using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePassWordSpawner : MonoBehaviour
{
    public Sprite c1,c2,c3,c4,c5,c6,c7,c8,c9,c0;
    public Sprite d1,d2,d3,d4,d5,d6,d7,d8,d9,d0;
    public Sprite h1,h2,h3,h4,h5,h6,h7,h8,h9,h0;
    public Sprite s1,s2,s3,s4,s5,s6,s7,s8,s9,s0;

    public Transform transform;

    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;
    public SpriteRenderer spriteRenderer4;

    public SpriteRenderer T11,T12,T13,T14;
    public SpriteRenderer T21,T22,T23,T24;
    public SpriteRenderer T31,T32,T33,T34;
    public SpriteRenderer T41,T42,T43,T44;
    public SpriteRenderer T51,T52,T53,T54;

    public Sprite c,h,d,s;
    public int TS1, TS2, TS3, TS4;
    private static int RS;
    private static bool isProcessCompleted;

    // Start is called before the first frame update
    void Start()
    {
        //1
        if(SafeHandler.Char1==0){
            spriteRenderer1.sprite=c0;
        }
        if(SafeHandler.Char1==1){
            spriteRenderer1.sprite=c1;
        }
        if(SafeHandler.Char1==2){
            spriteRenderer1.sprite=c2;
        }
        if(SafeHandler.Char1==3){
            spriteRenderer1.sprite=c3;
        }
        if(SafeHandler.Char1==4){
            spriteRenderer1.sprite=c4;
        }
        if(SafeHandler.Char1==5){
            spriteRenderer1.sprite=c5;
        }
        if(SafeHandler.Char1==6){
            spriteRenderer1.sprite=c6;
        }
        if(SafeHandler.Char1==7){
            spriteRenderer1.sprite=c7;
        }
        if(SafeHandler.Char1==8){
            spriteRenderer1.sprite=c8;
        }
        if(SafeHandler.Char1==9){
            spriteRenderer1.sprite=c9;
        }
        //2
        if(SafeHandler.Char2==0){
            spriteRenderer2.sprite=d0;
        }
        if(SafeHandler.Char2==1){
            spriteRenderer2.sprite=d1;
        }
        if(SafeHandler.Char2==2){
            spriteRenderer2.sprite=d2;
        }
        if(SafeHandler.Char2==3){
            spriteRenderer2.sprite=d3;
        }
        if(SafeHandler.Char2==4){
            spriteRenderer2.sprite=d4;
        }
        if(SafeHandler.Char2==5){
            spriteRenderer2.sprite=d5;
        }
        if(SafeHandler.Char2==6){
            spriteRenderer2.sprite=d6;
        }
        if(SafeHandler.Char2==7){
            spriteRenderer2.sprite=d7;
        }
        if(SafeHandler.Char2==8){
            spriteRenderer2.sprite=d8;
        }
        if(SafeHandler.Char2==9){
            spriteRenderer2.sprite=d9;
        }
        //3
        if(SafeHandler.Char3==0){
            spriteRenderer3.sprite=s0;
        }
        if(SafeHandler.Char3==1){
            spriteRenderer3.sprite=s1;
        }
        if(SafeHandler.Char3==2){
            spriteRenderer3.sprite=s2;
        }
        if(SafeHandler.Char3==3){
            spriteRenderer3.sprite=s3;
        }
        if(SafeHandler.Char3==4){
            spriteRenderer3.sprite=s4;
        }
        if(SafeHandler.Char3==5){
            spriteRenderer3.sprite=s5;
        }
        if(SafeHandler.Char3==6){
            spriteRenderer3.sprite=s6;
        }
        if(SafeHandler.Char3==7){
            spriteRenderer3.sprite=s7;
        }
        if(SafeHandler.Char3==8){
            spriteRenderer3.sprite=s8;
        }
        if(SafeHandler.Char3==9){
            spriteRenderer3.sprite=s9;
        }
        //4
        if(SafeHandler.Char4==0){
            spriteRenderer4.sprite=h0;
        }
        if(SafeHandler.Char4==1){
            spriteRenderer4.sprite=h1;
        }
        if(SafeHandler.Char4==2){
            spriteRenderer4.sprite=h2;
        }
        if(SafeHandler.Char4==3){
            spriteRenderer4.sprite=h3;
        }
        if(SafeHandler.Char4==4){
            spriteRenderer4.sprite=h4;
        }
        if(SafeHandler.Char4==5){
            spriteRenderer4.sprite=h5;
        }
        if(SafeHandler.Char4==6){
            spriteRenderer4.sprite=h6;
        }
        if(SafeHandler.Char4==7){
            spriteRenderer4.sprite=h7;
        }
        if(SafeHandler.Char4==8){
            spriteRenderer4.sprite=h8;
        }
        if(SafeHandler.Char4==9){
            spriteRenderer4.sprite=h9;
        }

        //Spawn Symbols Sequence Wise
        TS1 = SafeHandler.Sequence1;
        TS2 = SafeHandler.Sequence2;
        TS3 = SafeHandler.Sequence3;
        TS4 = SafeHandler.Sequence4;

        RS=Random.Range(0,5);
        isProcessCompleted=false;


            
    }

    // Update is called once per frame
    void Update()
    {
        if(isProcessCompleted==false){
            GenSequence();
        }
    }
    void GenSequence(){
        if(RS==0){
            //1
            if(TS1==1){
                T11.sprite=c;
            }
            if(TS1==2){
                T12.sprite=c;
            }
            if(TS1==3){
                T13.sprite=c;
            }
            if(TS1==4){
                T14.sprite=c;
            }
            //2
            if(TS2==1){
                T11.sprite=d;
            }
            if(TS2==2){
                T12.sprite=d;
            }
            if(TS2==3){
                T13.sprite=d;
            }
            if(TS2==4){
                T14.sprite=d;
            }
            //3
            if(TS3==1){
                T11.sprite=s;
            }
            if(TS3==2){
                T12.sprite=s;
            }
            if(TS3==3){
                T13.sprite=s;
            }
            if(TS3==4){
                T14.sprite=s;
            }
            //4
            if(TS4==1){
                T11.sprite=h;
            }
            if(TS4==2){
                T12.sprite=h;
            }
            if(TS4==3){
                T13.sprite=h;
            }
            if(TS4==4){
                T14.sprite=h;
            }
            //Fake
            T21.gameObject.SetActive(false);
            T22.gameObject.SetActive(false);
            T23.gameObject.SetActive(false);
            T24.gameObject.SetActive(false);

            //Fake 2
            T31.gameObject.SetActive(false);
            T32.gameObject.SetActive(false);
            T33.gameObject.SetActive(false);
            T34.gameObject.SetActive(false);

            //Fake 3
            T41.gameObject.SetActive(false);
            T42.gameObject.SetActive(false);
            T43.gameObject.SetActive(false);
            T44.gameObject.SetActive(false);

           //Fake
            T51.gameObject.SetActive(false);
            T52.gameObject.SetActive(false);
            T53.gameObject.SetActive(false);
            T54.gameObject.SetActive(false);
        /*
            T21.sprite=c;
            T22.sprite=d;
            T23.sprite=s;
            T24.sprite=h;

            //Fake 2
            T31.sprite=s;
            T32.sprite=h;
            T33.sprite=c;
            T34.sprite=d;

            //Fake 3
            T41.sprite=d;
            T42.sprite=h;
            T43.sprite=s;
            T44.sprite=c;

            //Fake
            T51.sprite=h;
            T52.sprite=d;
            T53.sprite=s;
            T54.sprite=c;*/
        }
        if(RS==1){
            //1
            if(TS1==1){
                T31.sprite=c;
            }
            if(TS1==2){
                T32.sprite=c;
            }
            if(TS1==3){
                T33.sprite=c;
            }
            if(TS1==4){
                T34.sprite=c;
            }
            //2
            if(TS2==1){
                T31.sprite=d;
            }
            if(TS2==2){
                T32.sprite=d;
            }
            if(TS2==3){
                T33.sprite=d;
            }
            if(TS2==4){
                T34.sprite=d;
            }
            //3
            if(TS3==1){
                T31.sprite=s;
            }
            if(TS3==2){
                T32.sprite=s;
            }
            if(TS3==3){
                T33.sprite=s;
            }
            if(TS3==4){
                T34.sprite=s;
            }
            //4
            if(TS4==1){
                T31.sprite=h;
            }
            if(TS4==2){
                T32.sprite=h;
            }
            if(TS4==3){
                T33.sprite=h;
            }
            if(TS4==4){
                T34.sprite=h;
            }
            //Fake
            T21.gameObject.SetActive(false);
            T22.gameObject.SetActive(false);
            T23.gameObject.SetActive(false);
            T24.gameObject.SetActive(false);

            //Fake 2
            T11.gameObject.SetActive(false);
            T12.gameObject.SetActive(false);
            T13.gameObject.SetActive(false);
            T14.gameObject.SetActive(false);

            //Fake 3
            T41.gameObject.SetActive(false);
            T42.gameObject.SetActive(false);
            T43.gameObject.SetActive(false);
            T44.gameObject.SetActive(false);

            //Fake
            T51.gameObject.SetActive(false);
            T52.gameObject.SetActive(false);
            T53.gameObject.SetActive(false);
            T54.gameObject.SetActive(false);

         /*   //Fake
            T21.sprite=c;
            T22.sprite=d;
            T23.sprite=s;
            T24.sprite=h;

            //Fake 2
            T11.sprite=s;
            T12.sprite=h;
            T13.sprite=c;
            T14.sprite=d;

            //Fake 3
            T41.sprite=d;
            T42.sprite=h;
            T43.sprite=s;
            T44.sprite=c;

            //Fake
            T51.sprite=h;
            T52.sprite=d;
            T53.sprite=s;
            T54.sprite=c;*/
        }
        if(RS==2){
            //1
            if(TS1==1){
                T51.sprite=c;
            }
            if(TS1==2){
                T52.sprite=c;
            }
            if(TS1==3){
                T53.sprite=c;
            }
            if(TS1==4){
                T54.sprite=c;
            }
            //2
            if(TS2==1){
                T51.sprite=d;
            }
            if(TS2==2){
                T52.sprite=d;
            }
            if(TS2==3){
                T53.sprite=d;
            }
            if(TS2==4){
                T54.sprite=d;
            }
            //3
            if(TS3==1){
                T51.sprite=s;
            }
            if(TS3==2){
                T52.sprite=s;
            }
            if(TS3==3){
                T53.sprite=s;
            }
            if(TS3==4){
                T54.sprite=s;
            }
            //4
            if(TS4==1){
                T51.sprite=h;
            }
            if(TS4==2){
                T52.sprite=h;
            }
            if(TS4==3){
                T53.sprite=h;
            }
            if(TS4==4){
                T54.sprite=h;
            }
            //Fake
            T21.gameObject.SetActive(false);
            T22.gameObject.SetActive(false);
            T23.gameObject.SetActive(false);
            T24.gameObject.SetActive(false);

            //Fake 2
            T31.gameObject.SetActive(false);
            T32.gameObject.SetActive(false);
            T33.gameObject.SetActive(false);
            T34.gameObject.SetActive(false);

            //Fake 3
            T41.gameObject.SetActive(false);
            T42.gameObject.SetActive(false);
            T43.gameObject.SetActive(false);
            T44.gameObject.SetActive(false);

            //Fake
            T11.gameObject.SetActive(false);
            T12.gameObject.SetActive(false);
            T13.gameObject.SetActive(false);
            T14.gameObject.SetActive(false);

        /*    //Fake
            T21.sprite=c;
            T22.sprite=d;
            T23.sprite=s;
            T24.sprite=h;

            //Fake 2
            T31.sprite=s;
            T32.sprite=h;
            T33.sprite=c;
            T34.sprite=d;

            //Fake 3
            T41.sprite=d;
            T42.sprite=h;
            T43.sprite=s;
            T44.sprite=c;

            //Fake
            T11.sprite=h;
            T12.sprite=d;
            T13.sprite=s;
            T14.sprite=c;*/
        }
        if(RS==3){
            //1
            if(TS1==1){
                T41.sprite=c;
            }
            if(TS1==2){
                T42.sprite=c;
            }
            if(TS1==3){
                T43.sprite=c;
            }
            if(TS1==4){
                T44.sprite=c;
            }
            //2
            if(TS2==1){
                T41.sprite=d;
            }
            if(TS2==2){
                T42.sprite=d;
            }
            if(TS2==3){
                T43.sprite=d;
            }
            if(TS2==4){
                T44.sprite=d;
            }
            //3
            if(TS3==1){
                T41.sprite=s;
            }
            if(TS3==2){
                T42.sprite=s;
            }
            if(TS3==3){
                T43.sprite=s;
            }
            if(TS3==4){
                T44.sprite=s;
            }
            //4
            if(TS4==1){
                T41.sprite=h;
            }
            if(TS4==2){
                T42.sprite=h;
            }
            if(TS4==3){
                T43.sprite=h;
            }
            if(TS4==4){
                T44.sprite=h;
            }
            //Fake
            T21.gameObject.SetActive(false);
            T22.gameObject.SetActive(false);
            T23.gameObject.SetActive(false);
            T24.gameObject.SetActive(false);

            //Fake 2
            T11.gameObject.SetActive(false);
            T12.gameObject.SetActive(false);
            T13.gameObject.SetActive(false);
            T14.gameObject.SetActive(false);

            //Fake 3
            T31.gameObject.SetActive(false);
            T32.gameObject.SetActive(false);
            T33.gameObject.SetActive(false);
            T34.gameObject.SetActive(false);

            //Fake
            T51.gameObject.SetActive(false);
            T52.gameObject.SetActive(false);
            T53.gameObject.SetActive(false);
            T54.gameObject.SetActive(false);

        /*  //Fake
            T21.sprite=c;
            T22.sprite=d;
            T23.sprite=s;
            T24.sprite=h;

            //Fake 2
            T11.sprite=s;
            T12.sprite=h;
            T13.sprite=c;
            T14.sprite=d;

            //Fake 3
            T31.sprite=d;
            T32.sprite=h;
            T33.sprite=s;
            T34.sprite=c;

            //Fake
            T51.sprite=h;
            T52.sprite=d;
            T53.sprite=s;
            T54.sprite=c;*/
        }
        if(RS==4){
            //1
            if(TS1==1){
                T21.sprite=c;
            }
            if(TS1==2){
                T22.sprite=c;
            }
            if(TS1==3){
                T23.sprite=c;
            }
            if(TS1==4){
                T24.sprite=c;
            }
            //2
            if(TS2==1){
                T21.sprite=d;
            }
            if(TS2==2){
                T22.sprite=d;
            }
            if(TS2==3){
                T23.sprite=d;
            }
            if(TS2==4){
                T24.sprite=d;
            }
            //3
            if(TS3==1){
                T21.sprite=s;
            }
            if(TS3==2){
                T22.sprite=s;
            }
            if(TS3==3){
                T23.sprite=s;
            }
            if(TS3==4){
                T24.sprite=s;
            }
            //4
            if(TS4==1){
                T21.sprite=h;
            }
            if(TS4==2){
                T22.sprite=h;
            }
            if(TS4==3){
                T23.sprite=h;
            }
            if(TS4==4){
                T24.sprite=h;
            }
            //Fake
            T11.gameObject.SetActive(false);;
            T12.gameObject.SetActive(false);;
            T13.gameObject.SetActive(false);;
            T14.gameObject.SetActive(false);;

            //Fake 2
            T31.gameObject.SetActive(false);;
            T32.gameObject.SetActive(false);;
            T33.gameObject.SetActive(false);;
            T34.gameObject.SetActive(false);;

            //Fake 3
            T41.gameObject.SetActive(false);;
            T42.gameObject.SetActive(false);;
            T43.gameObject.SetActive(false);;
            T44.gameObject.SetActive(false);;

            //Fake
            T51.gameObject.SetActive(false);;
            T52.gameObject.SetActive(false);;
            T53.gameObject.SetActive(false);;
            T54.gameObject.SetActive(false);;

        /*    //Fake
            T11.sprite=c;
            T12.sprite=d;
            T13.sprite=s;
            T14.sprite=h;

            //Fake 2
            T31.sprite=s;
            T32.sprite=h;
            T33.sprite=c;
            T34.sprite=d;

            //Fake 3
            T41.sprite=d;
            T42.sprite=h;
            T43.sprite=s;
            T44.sprite=c;

            //Fake
            T51.sprite=h;
            T52.sprite=d;
            T53.sprite=s;
            T54.sprite=c;*/
        }
    }
}

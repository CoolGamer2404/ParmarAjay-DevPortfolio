using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe2PassWordHandler : MonoBehaviour
{
    public static int Char1;
    public static int Char2;
    public static int Char3;
    public static int Char4;
    private static bool PassGenerated;
    public static int Password;

    private static int Sequence=0;

    //PassWordSpawnTransforms
    public GameObject Seq01;
    public GameObject Seq02;
    public GameObject Seq03;
    public GameObject Seq04;

    public GameObject Seq11;
    public GameObject Seq12;
    public GameObject Seq13;
    public GameObject Seq14;

    public GameObject Seq21;
    public GameObject Seq22;
    public GameObject Seq23;
    public GameObject Seq24;

    public GameObject Seq31;
    public GameObject Seq32;
    public GameObject Seq33;
    public GameObject Seq34;

    public GameObject Seq41;
    public GameObject Seq42;
    public GameObject Seq43;
    public GameObject Seq44;

    public GameObject Seq51;
    public GameObject Seq52;
    public GameObject Seq53;
    public GameObject Seq54;

    public GameObject Seq61;
    public GameObject Seq62;
    public GameObject Seq63;
    public GameObject Seq64;

    public GameObject Seq71;
    public GameObject Seq72;
    public GameObject Seq73;
    public GameObject Seq74;
    
    public GameObject Seq81;
    public GameObject Seq82;
    public GameObject Seq83;
    public GameObject Seq84;

    public GameObject Seq91;
    public GameObject Seq92;
    public GameObject Seq93;
    public GameObject Seq94;

    public GameObject Seq101;
    public GameObject Seq102;
    public GameObject Seq103;
    public GameObject Seq104;

    //Sprites
    public Sprite sprite1,sprite2,sprite3,sprite4,sprite5,sprite6,sprite7,sprite8,sprite9,sprite0;
    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;
    public SpriteRenderer spriteRenderer4;
    // Start is called before the first frame update
    void Start()
    {
        Sequence=Random.Range(0,10);
        PassGenerated=false;
        Password=0000;
        Char1=Random.Range(1,9);
        Char2=Random.Range(1,9);
        Char3=Random.Range(1,9);
        Char4=Random.Range(0,9);
        GenPass();
        Seq01.SetActive(false);
        Seq02.SetActive(false);
        Seq03.SetActive(false);
        Seq04.SetActive(false);
        Seq11.SetActive(false);
        Seq12.SetActive(false);
        Seq13.SetActive(false);
        Seq14.SetActive(false);
        Seq21.SetActive(false);
        Seq22.SetActive(false);
        Seq23.SetActive(false);
        Seq24.SetActive(false);
        Seq31.SetActive(false);
        Seq32.SetActive(false);
        Seq33.SetActive(false);
        Seq34.SetActive(false);
        Seq41.SetActive(false);
        Seq42.SetActive(false);
        Seq43.SetActive(false);
        Seq44.SetActive(false);
        Seq51.SetActive(false);
        Seq52.SetActive(false);
        Seq53.SetActive(false);
        Seq54.SetActive(false);
        Seq61.SetActive(false);
        Seq62.SetActive(false);
        Seq63.SetActive(false);
        Seq64.SetActive(false);
        Seq71.SetActive(false);
        Seq72.SetActive(false);
        Seq73.SetActive(false);
        Seq74.SetActive(false);
        Seq81.SetActive(false);
        Seq82.SetActive(false);
        Seq83.SetActive(false);
        Seq84.SetActive(false);
        Seq91.SetActive(false);
        Seq92.SetActive(false);
        Seq93.SetActive(false);
        Seq94.SetActive(false);
        Seq101.SetActive(false);
        Seq102.SetActive(false);
        Seq103.SetActive(false);
        Seq104.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Sequence==0){
            Seq01.SetActive(true);
            Seq02.SetActive(true);
            Seq03.SetActive(true);
            Seq04.SetActive(true);
            spriteRenderer1=Seq01.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq02.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq03.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq04.GetComponent<SpriteRenderer>();
        }
        if(Sequence==1){
            Seq11.SetActive(true);
            Seq12.SetActive(true);
            Seq13.SetActive(true);
            Seq14.SetActive(true);
            spriteRenderer1=Seq11.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq12.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq13.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq14.GetComponent<SpriteRenderer>();
        }
        if(Sequence==2){
            Seq21.SetActive(true);
            Seq22.SetActive(true);
            Seq23.SetActive(true);
            Seq24.SetActive(true);
            spriteRenderer1=Seq21.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq22.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq23.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq24.GetComponent<SpriteRenderer>();
        }
        if(Sequence==3){
            Seq31.SetActive(true);
            Seq32.SetActive(true);
            Seq33.SetActive(true);
            Seq34.SetActive(true);
            spriteRenderer1=Seq31.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq32.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq33.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq34.GetComponent<SpriteRenderer>();
        }
        if(Sequence==4){
            Seq41.SetActive(true);
            Seq42.SetActive(true);
            Seq43.SetActive(true);
            Seq44.SetActive(true);
            spriteRenderer1=Seq41.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq42.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq43.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq44.GetComponent<SpriteRenderer>();
        }
        if(Sequence==5){
            Seq51.SetActive(true);
            Seq52.SetActive(true);
            Seq53.SetActive(true);
            Seq54.SetActive(true);
            spriteRenderer1=Seq51.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq52.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq53.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq54.GetComponent<SpriteRenderer>();
        }
        if(Sequence==6){
            Seq61.SetActive(true);
            Seq62.SetActive(true);
            Seq63.SetActive(true);
            Seq64.SetActive(true);
            spriteRenderer1=Seq61.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq62.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq63.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq64.GetComponent<SpriteRenderer>();
        }
        if(Sequence==7){
            Seq71.SetActive(true);
            Seq72.SetActive(true);
            Seq73.SetActive(true);
            Seq74.SetActive(true);
            spriteRenderer1=Seq71.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq72.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq73.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq74.GetComponent<SpriteRenderer>();
        }
        if(Sequence==8){
            Seq81.SetActive(true);
            Seq82.SetActive(true);
            Seq83.SetActive(true);
            Seq84.SetActive(true);
            spriteRenderer1=Seq81.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq82.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq83.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq84.GetComponent<SpriteRenderer>();
        }
        if(Sequence==9){
            Seq91.SetActive(true);
            Seq92.SetActive(true);
            Seq93.SetActive(true);
            Seq94.SetActive(true);
            spriteRenderer1=Seq91.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq92.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq93.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq94.GetComponent<SpriteRenderer>();
        }
        if(Sequence==10){
            Seq101.SetActive(true);
            Seq102.SetActive(true);
            Seq103.SetActive(true);
            Seq104.SetActive(true);
            spriteRenderer1=Seq101.GetComponent<SpriteRenderer>();
            spriteRenderer2=Seq102.GetComponent<SpriteRenderer>();
            spriteRenderer3=Seq103.GetComponent<SpriteRenderer>();
            spriteRenderer4=Seq104.GetComponent<SpriteRenderer>();
        }
        if(Char1==1){
            spriteRenderer1.sprite=sprite1;
        }
        if(Char2==1){
            spriteRenderer2.sprite=sprite1;
        }
        if(Char3==1){
            spriteRenderer3.sprite=sprite1;
        }
        if(Char4==1){
            spriteRenderer4.sprite=sprite1;
        }

        if(Char1==2){
            spriteRenderer1.sprite=sprite2;
        }
        if(Char2==2){
            spriteRenderer2.sprite=sprite2;
        }
        if(Char3==2){
            spriteRenderer3.sprite=sprite2;
        }
        if(Char4==2){
            spriteRenderer4.sprite=sprite2;
        }

        if(Char1==3){
            spriteRenderer1.sprite=sprite3;
        }
        if(Char2==3){
            spriteRenderer2.sprite=sprite3;
        }
        if(Char3==3){
            spriteRenderer3.sprite=sprite3;
        }
        if(Char4==3){
            spriteRenderer4.sprite=sprite3;
        }

        if(Char1==4){
            spriteRenderer1.sprite=sprite4;
        }
        if(Char2==4){
            spriteRenderer2.sprite=sprite4;
        }
        if(Char3==4){
            spriteRenderer3.sprite=sprite4;
        }
        if(Char4==4){
            spriteRenderer4.sprite=sprite4;
        }

        if(Char1==5){
            spriteRenderer1.sprite=sprite5;
        }
        if(Char2==5){
            spriteRenderer2.sprite=sprite5;
        }
        if(Char3==5){
            spriteRenderer3.sprite=sprite5;
        }
        if(Char4==5){
            spriteRenderer4.sprite=sprite5;
        }

        if(Char1==6){
            spriteRenderer1.sprite=sprite6;
        }
        if(Char2==6){
            spriteRenderer2.sprite=sprite6;
        }
        if(Char3==6){
            spriteRenderer3.sprite=sprite6;
        }
        if(Char4==6){
            spriteRenderer4.sprite=sprite6;
        }

        if(Char1==7){
            spriteRenderer1.sprite=sprite7;
        }
        if(Char2==7){
            spriteRenderer2.sprite=sprite7;
        }
        if(Char3==7){
            spriteRenderer3.sprite=sprite7;
        }
        if(Char4==7){
            spriteRenderer4.sprite=sprite7;
        }

        if(Char1==8){
            spriteRenderer1.sprite=sprite8;
        }
        if(Char2==8){
            spriteRenderer2.sprite=sprite8;
        }
        if(Char3==8){
            spriteRenderer3.sprite=sprite8;
        }
        if(Char4==8){
            spriteRenderer4.sprite=sprite8;
        }

        if(Char1==9){
            spriteRenderer1.sprite=sprite9;
        }
        if(Char2==9){
            spriteRenderer2.sprite=sprite9;
        }
        if(Char3==9){
            spriteRenderer3.sprite=sprite9;
        }
        if(Char4==9){
            spriteRenderer4.sprite=sprite9;
        }

        if(Char4==0){
            spriteRenderer4.sprite=sprite0;
        }

    }
    void GenPass(){
        Password=Char1*1000+Char2*100+Char3*10+Char4;
        Safe2Handler.GenratedPassWord=Password;
        Debug.Log("PassForSafe2 Is:"+Password.ToString());
    }
}

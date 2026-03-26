using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnpoint;
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject PlayButton;
    public GameObject Player;

    //Health 
    public static int Health=3;
    public GameObject Heart1,Heart2,Heart3,Heart4,Heart5;


    //For Char Equip & UnEquip
    public GameObject[] Characters;
    public bool[] IsEquipped;

    // Start is called before the first frame update
    void Start()
    {
       score=0; 
       Health=3;
       for(int i = 0; i < Characters.Length; i++)
       {
           if(IsEquipped[i]==true)
           {
            Player=Characters[i];

           }
       }
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Health==1){
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
            Heart5.SetActive(false);
        }
         if(Health==2){
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
            Heart5.SetActive(false);
        }
         if(Health==3){
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(false);
            Heart5.SetActive(false);
        }
         if(Health==4){
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(true);
            Heart5.SetActive(false);
        }
         if(Health==5){
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(true);
            Heart5.SetActive(true);
        }
        
        if(Health<=0){
             SceneManager.LoadScene(0);
        }

    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(0.6f, 2f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawnpoint.position, Quaternion.identity);
        }
        
    }

    void ScoreUp()
    {
       //score++;
        scoreText.text = score.ToString();
    }
    public void GameStart()
    {
        Player.SetActive(true);
        PlayButton.SetActive(false);

        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreUp",2f,1f);
    }
}

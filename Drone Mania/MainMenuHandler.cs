using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text coinAmount;
    [SerializeField] private TMP_Text scrapAmount;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Coin") == null)
        {
            PlayerPrefs.SetInt("Coin", 0);
        }
        if (PlayerPrefs.GetInt("Scrap") == null)
        {
            PlayerPrefs.SetInt("Scrap", 0);
        }
    }
    void Start()
    {
        coinAmount.text = PlayerPrefs.GetInt("Coin").ToString();
        scrapAmount.text = PlayerPrefs.GetInt("Scrap").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateData(){
        coinAmount.text = PlayerPrefs.GetInt("Coin").ToString();
        scrapAmount.text = PlayerPrefs.GetInt("Scrap").ToString();
        return;
    }

    public void GetScrap(){
        int value=PlayerPrefs.GetInt("Scrap");
        PlayerPrefs.SetInt("Scrap",value+100);
        UpdateData();
        return;
    }
    public void GetCoin(){
        int value=PlayerPrefs.GetInt("Coin");
        PlayerPrefs.SetInt("Coin",value+100);
        UpdateData();
        return;
    }
}

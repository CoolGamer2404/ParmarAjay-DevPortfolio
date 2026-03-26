using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField]private ItemType itemType;
    [SerializeField]private int amount;
    [SerializeField]private int cost;
    [SerializeField]private MainMenuHandler mainMenuHandler;

    private enum ItemType{
        RepairKit,
        Battery,
    }

int coins;
int requiredCoins;
int newAmount;
    public void PurchaseItems(){
        if(PlayerPrefs.GetInt("Coin")>=cost){
            coins=PlayerPrefs.GetInt("Coin")-cost;
            newAmount=PlayerPrefs.GetInt(itemType.ToString())+amount;
            //Debug.Log("You Can purchgase");
            PlayerPrefs.SetInt("Coin",coins);
            PlayerPrefs.SetInt(itemType.ToString(),newAmount);
            mainMenuHandler.UpdateData();
            Debug.Log("You Have Currently "+itemType.ToString()+" :- "+PlayerPrefs.GetInt(itemType.ToString()).ToString());
        }
        else if(PlayerPrefs.GetInt("Coin")<cost){
            requiredCoins=cost-PlayerPrefs.GetInt("Coin");
            Debug.Log("You Need This Much Coins"+requiredCoins);
        }
    }
}

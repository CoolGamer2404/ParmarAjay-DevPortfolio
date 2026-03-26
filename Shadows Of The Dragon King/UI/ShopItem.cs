using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]private ItemDataScriptableObject itemData;
    [SerializeField]private ShopHandler shopHandler;
    [SerializeField]private GameObject selectedShader;
    [SerializeField]private Image slotImage;
    public bool isItemSelected;

    void Start()
    {
        if(itemData!=null){
            slotImage.sprite=itemData.icon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Showcase(){
        shopHandler.ShowcaseItem(itemData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button==PointerEventData.InputButton.Left){
            Select();
        }
    }

    public void Select(){
        shopHandler.DeselectAll();
        selectedShader.SetActive(true);
        isItemSelected=true;
        Showcase();
    }
    public void DeSelect(){
        selectedShader.SetActive(false);
        isItemSelected=false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StockBuyBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameManager gameManager;
    public StockItem stock;
    public StreamerSkillManager skillManager;
    bool isPress;
    public void OnPointerDown(PointerEventData eventData){
        isPress = true;
    }
    public void OnPointerUp(PointerEventData eventData){
        isPress = false;
    }

    private void Update() {
        if(isPress){
            BuyStock();
        }
    }

    public void BuyStock(){
        if(stock.totalStock > stock.myStock && gameManager.money > stock.stockPrice){
            gameManager.money -= (int)(stock.stockPrice * skillManager.skillList[17]._functionDesc[skillManager.skillList[17]._level]);
            stock.myStock++;
            stock.totalStockText.text = stock.myStock +"/" + stock.totalStock;
        }
    }

}

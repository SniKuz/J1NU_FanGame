using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StockSellBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
            SellStock();
        }
    }

        public void SellStock(){
        if(stock.myStock>0){
            gameManager.money += (int)(stock.stockPrice * skillManager.skillList[18]._functionDesc[skillManager.skillList[18]._level]);
            stock.myStock--;
            stock.totalStockText.text = stock.myStock +"/" + stock.totalStock;
        }
    }
}

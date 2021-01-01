using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockItem : MonoBehaviour
{
    public GameManager gameManager;
    public string stockName; //Name of stock
    public int stockPrice; //How much
    public int totalStock; // How many stock
    public int myStock; // how many stock I have

    public TextMeshProUGUI stockNameText;
    public TextMeshProUGUI stockPriceText;
    public TextMeshProUGUI totalStockText;
    public TextMeshProUGUI stockPriceChangeText;
    public Image stockImg;
    public Image stockVolatilityImg;
    public Sprite stockUpImgae;
    public Sprite stockSameImage;
    public Sprite stockDownImage;
    public Button buyStockBtn;
    public Button sellStockBtn;

//moneyText.text = string.Format("{0:n0}", gameManager.money);
    public StockItem(string stockName, int stockPrice, int totalStock){
        this.stockName = stockName;
        this.stockPrice = stockPrice;
        this.totalStock = totalStock;
        this.myStock = 0;
        stockNameText.text = stockName;
        stockPriceText.text = string.Format("{0:n0}", stockPrice);
        totalStockText.text = myStock +"/" +totalStock;
    }
    
    public string GetStockName(){
        return this.stockName;
    }

    public void SetStockName(string name){
        this.stockName = name;
        stockNameText.text = stockName;
    }

    public int  GetStockPrice(){
        return this.stockPrice;
    }

    public void SetStockPrice(int stockPrice){
        this.stockPrice = stockPrice;
        stockPriceText.text = string.Format("{0:n0}", stockPrice);
    }

    public int GetTotalStock(){
        return this.totalStock;
    }

    public void SetTotalStock(int total){
        this.totalStock = total;
        totalStockText.text = myStock +"/" +totalStock;
    }

    public int GetMyStock(){
        return this.myStock;
    }

    public void BuyStock(){
        if(this.totalStock > this.myStock){
            gameManager.money -= stockPrice;
            this.myStock++;
            totalStockText.text = myStock +"/" + totalStock;
        }
    }

    public void SellStock(){
        if(this.myStock>0){
            gameManager.money += stockPrice;
            this.myStock--;
            totalStockText.text = myStock +"/" + totalStock;
        }
    }

    public void ChangeStockPrice(){
        int Volatility = Random.Range(-50, 51);
        this.stockPrice = stockPrice + stockPrice * Volatility/100; // -50~50% 변동
        SetStockPrice(this.stockPrice);
        if(Volatility > 0){
            this.stockVolatilityImg.gameObject.GetComponent<Image>().sprite = stockUpImgae;
            this.stockPriceChangeText.color = Color.red;
        }else if(Volatility == 0){
            this.stockVolatilityImg.gameObject.GetComponent<Image>().sprite = stockSameImage;
            this.stockPriceChangeText.color = Color.gray;
        }else{
            this.stockVolatilityImg.gameObject.GetComponent<Image>().sprite = stockDownImage;
            this.stockPriceChangeText.color = Color.blue;
        }
        stockPriceChangeText.text = Volatility +"%";
    }
}

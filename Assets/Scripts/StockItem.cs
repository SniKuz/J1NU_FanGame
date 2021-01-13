using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockItem : MonoBehaviour
{
    public GameManager gameManager;
    public StreamerSkillManager skillManager;
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

    public static int volatilityLow; //stock low. All stock must have same volatility
    public static int volatilityHigh; //stock high. All stock must have same volatility

//moneyText.text = string.Format("{0:n0}", gameManager.money);
    public StockItem(string stockName, int stockPrice, int totalStock, Sprite ranStockImg){
        this.stockName = stockName;
        this.stockPrice = stockPrice;
        this.totalStock = totalStock;
        this.myStock = 0;
        stockImg.sprite = ranStockImg;
        stockNameText.text = stockName;
        stockPriceText.text = string.Format("{0:n0}", stockPrice);
        totalStockText.text = myStock +"/" +totalStock;
    }

    private void Awake() {
        volatilityLow = -50;
        volatilityHigh = 31;
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

    public void SetMyStock(int my){
        this.myStock = my;
        totalStockText.text = myStock+"/"+totalStock;
    }

    public void BuyStock(){
        if(this.totalStock > this.myStock){
            gameManager.money -= (int)(stockPrice * skillManager.skillList[17]._functionDesc[skillManager.skillList[17]._level]);
            this.myStock++;
            totalStockText.text = myStock +"/" + totalStock;
        }
    }

    public void SellStock(){
        if(this.myStock>0){
            gameManager.money += (int)(stockPrice * skillManager.skillList[18]._functionDesc[skillManager.skillList[18]._level]);
            this.myStock--;
            totalStockText.text = myStock +"/" + totalStock;
        }
    }

    public void ChangeStockPrice(){
        int stockVolatilityLow = volatilityLow + (int)(skillManager.skillList[12]._functionDesc[skillManager.skillList[12]._level] + skillManager.skillList[15]._functionDesc[skillManager.skillList[15]._level]);;
        int stockVolatilityHigh = volatilityHigh + (int)skillManager.skillList[16]._functionDesc[skillManager.skillList[16]._level];

        int Volatility = Random.Range(stockVolatilityLow, stockVolatilityHigh);
        this.stockPrice = stockPrice + stockPrice * Volatility/100; // -50~30% 변동
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

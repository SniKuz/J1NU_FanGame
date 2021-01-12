using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject stockItem;
    public GameObject stockManger;//for newStockItem Instantiate

    private GameObject[] subStock = new GameObject[10];

    public int checkDayChange; //for check gamemanager day change
    public int checkGuageChange; //for check gamemanager guage change

    public GameObject mainStock;

    public Sprite[] ranStockImg;
    public Sprite[] mainStockImg;

    private void Awake() {
        for(int i=0; i<10; i++){
            int ranImg = Random.Range(0, 5);
            subStock[i] = newStock("SubStock"+i, i*10, i*1000, ranStockImg[ranImg]);
        }
        checkDayChange = gameManager.day;
        checkGuageChange = gameManager.guage;
    }

    private void Update() {
        ChangeDogStocks();
        ChangeAllStockPrice();
    }



    public GameObject newStock(string name, int price, int totalStock, Sprite ranStockImg){
        GameObject newStockItem = Instantiate(stockItem, new Vector3(0, 0, 0), Quaternion.identity);
        newStockItem.transform.SetParent(stockManger.transform);
        newStockItem.GetComponent<StockItem>().SetStockName(name);
        newStockItem.GetComponent<StockItem>().SetStockPrice(price);
        newStockItem.GetComponent<StockItem>().SetTotalStock(totalStock);
        newStockItem.GetComponent<StockItem>().stockImg.sprite = ranStockImg;
        newStockItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        return newStockItem;
    }
    public void DestroyStock(int i){
        Destroy(subStock[i]);
    }

    public void ChangeDogStocks(){
        if(gameManager.day > checkDayChange){
            int changeStock = Random.Range(0, 5);
            while(changeStock>=0){
                int i = Random.Range(0, 10);
                int ranImg = Random.Range(0, 5);
                DestroyStock(i);
                subStock[i] = newStock("NewStock"+i, i*200, i*20000, ranStockImg[ranImg]);  
                changeStock--;
            }
            checkDayChange = gameManager.day;
        }
    }

    public void ChangeAllStockPrice(){
        if(gameManager.guage != checkGuageChange){
            for(int i = 0; i<10; i++){
                subStock[i].GetComponent<StockItem>().ChangeStockPrice();
            }
            checkGuageChange = gameManager.guage;
        }
    }

    public void MainStockChange(string name, int price, int totalStock){
        mainStock.GetComponent<StockItem>().SetMyStock(0); //가지고 있는 주 개수 초기화 
        mainStock.GetComponent<StockItem>().SetStockName(name);
        mainStock.GetComponent<StockItem>().SetStockPrice(price);
        mainStock.GetComponent<StockItem>().SetTotalStock(totalStock);
    }
}

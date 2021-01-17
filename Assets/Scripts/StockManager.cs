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

    public string[] subStockName;


    private void Awake() {
        subStockName = new string[] {"도넛 컴퍼니","뿡뿡이 컴퍼니", "안경 컴퍼니", "장미 컴퍼니", "다이아몬드 컴퍼니","상섬 컴퍼니", "데이바이 컴퍼니", "뿌요요 컴퍼니", "레인보우 컴퍼니","공팔이팔 컴퍼니", "똘띠 컴퍼니","푸르르린 컴퍼니","질풍 컴퍼니","쫀드기 컴퍼니","애니덕 컴퍼니"};

        for(int i=0; i<10; i++){
            int ranImg = Random.Range(0, 5);
            int ranPrice = Random.Range(1000, 30000);
            int ranTotal = Random.Range(50, 1000);
            int ranName = Random.Range(0, 15);
            subStock[i] = newStock(subStockName[ranName], ranPrice, ranTotal, ranStockImg[ranImg]);
        }
        checkDayChange = gameManager.day;
        checkGuageChange = gameManager.guage;
    }

    private void Update() {
        ChangeSubStocks();
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

    public void ChangeSubStocks(){
        if(gameManager.day > checkDayChange){
            int changeStock = Random.Range(0, 6);
            while(changeStock>=0){
                int i = Random.Range(0, 10);
                int ranImg = Random.Range(0, 5);
                int ranPrice = Random.Range(1000, 50000);
                int ranTotal = Random.Range(50, 1000);
                int ranName = Random.Range(0, 15);
                DestroyStock(i);
                subStock[i] = newStock(subStockName[ranName], ranPrice, ranTotal, ranStockImg[ranImg]);  
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

    public void MainStockChange(string name, int price, int totalStock, int spriteNum){
        mainStock.GetComponent<StockItem>().SetMyStock(0); //가지고 있는 주 개수 초기화 
        mainStock.GetComponent<StockItem>().SetStockName(name);
        mainStock.GetComponent<StockItem>().SetStockPrice(price);
        mainStock.GetComponent<StockItem>().SetTotalStock(totalStock);
        mainStock.GetComponent<StockItem>().stockImg.sprite = mainStockImg[spriteNum];
    }
}

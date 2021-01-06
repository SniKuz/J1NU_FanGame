using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject stockItem;
    public GameObject stockManger;//for newStockItem Instantiate

    private GameObject[] DogStock = new GameObject[10];

    public int checkDayChange; //for check gamemanager day change
    public int checkGuageChange; //for check gamemanager guage change

    private void Awake() {
        for(int i=0; i<10; i++){
            DogStock[i] = newStock("개잡주"+i, i*10, i*1000);
        }
        checkDayChange = gameManager.day;
        checkGuageChange = gameManager.guage;
    }

    private void Update() {
        ChangeDogStocks();
        ChangeAllStockPrice();
    }



    public GameObject newStock(string name, int price, int totalStock){
        GameObject newStockItem = Instantiate(stockItem, new Vector3(0, 0, 0), Quaternion.identity);
        newStockItem.transform.SetParent(stockManger.transform);
        newStockItem.GetComponent<StockItem>().SetStockName(name);
        newStockItem.GetComponent<StockItem>().SetStockPrice(price);
        newStockItem.GetComponent<StockItem>().SetTotalStock(totalStock);
        newStockItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        return newStockItem;
    }
    public void DestroyStock(int i){
        Destroy(DogStock[i]);
    }

    public void ChangeDogStocks(){
        if(gameManager.day > checkDayChange){
            int changedDogStock = Random.Range(0, 2);
            while(changedDogStock>=0){
                int i = Random.Range(0, 10);
                DestroyStock(i);
                DogStock[i] = newStock("Change개잡주"+i, i*200, i*20000);  
                changedDogStock--;
            }
            checkDayChange = gameManager.day;
        }
    }

    public void ChangeAllStockPrice(){
        if(gameManager.guage != checkGuageChange){
            for(int i = 0; i<10; i++){
                DogStock[i].GetComponent<StockItem>().ChangeStockPrice();
            }
            checkGuageChange = gameManager.guage;
        }
    }
}

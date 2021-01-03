using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameManager gameManager;
    public GoodsSystem goodsSystem;
    public StaffManager staffManager;

    public Transform backGround;
    public enum Type {GoodsRoom, BossRoom, StreamingRoom};
    public Type curType;
    public int day;
    public int guage; // Event check(Battery Guage)
    public int money; // moeny
    public int goods; // goods
    public int viwer; // Twitch viwer

    public float time; //20s check
    public float timeMPS; // StaffMps Time

    private void Update() {
        TimeFlow();
    }

    void TimeFlow(){

        //#.Guage Time
        time -= Time.deltaTime;
        timeMPS += Time.deltaTime;

        //#.Guage Over
        if(time <= 0f){
            guage--;
            if(guage < 1){
                guage = 5;
                day++;
                //Important Event 발생
            }

            money -= 1000; // 매 게이지마다 상환해야하는 금액 시간 지날수록 증가.
            money = money > 999999999 ? 999999999 : money; // 돈 최대 제한 9억9...
            
            time = 20f;
        }

        //#.Auto Making by staffs- StaffMPS Time
        if(timeMPS >=1f){
            for(int i = 0; i < 4; i++){
                goods += (int)staffManager.staffCnt[0, i];
                viwer += (int)staffManager.staffCnt[2, i];
            }
            timeMPS = 0f;
        }

        goods = goods > goodsSystem.maxGoodsCapacity ? goodsSystem.maxGoodsCapacity : gameManager.goods; // goods는 최대 goods 용량 못넘어감
    }

    //#. Map Move
    public void TypeBtnClick(string dir){
        if(dir == "Right" && (int)gameManager.curType < 2){
            gameManager.curType++;

        }else if(dir == "Left"&&(int)gameManager.curType > 0){
            gameManager.curType--;
        }

        switch(gameManager.curType)
        {
            case GameManager.Type.GoodsRoom:
                break;

            case GameManager.Type.BossRoom:
                break;

            case GameManager.Type.StreamingRoom:
                break;

            default:
                break;
        }

        //#.Move BackGround
        gameManager.ChangeMap();
    }


    //Change Map btn
    public void ChangeMap()
    {
        switch(curType){
            case Type.GoodsRoom:
                backGround.DOMoveX((float)3.61, 0.6f).SetEase(Ease.OutBack);
                break;
            case Type.BossRoom:
                backGround.DOMoveX(0, 0.6f).SetEase(Ease.OutBack);
                break;
            case Type.StreamingRoom:
                backGround.DOMoveX((float)-3.61, 0.6f).SetEase(Ease.OutBack);
                break;
            default:
                break;
        }
    }

    public void StockSystem(){
        
    }
}

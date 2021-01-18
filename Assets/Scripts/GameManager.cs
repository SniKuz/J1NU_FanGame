using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public GameManager gameManager;
    public UIManager uiManager;
    public StreamerSkillManager skillManager;
    public GoodsSystem goodsSystem;
    public StockManager stockManager;
    public StaffManager staffManager;
    public EventManager eventManager;
    public SoundManager soundManager;
    public TutorialManager tutorialManager;
    public MainStoryManager mainStoryManager;

    public Transform backGround;
    public enum Type {GoodsRoom, BossRoom, StreamingRoom};
    public Type curType;
    public bool isStopTime;
    public bool isStopUI;
    public int day;
    public int guage; // Event check(Battery Guage)
    public int money; // moeny
    public int goods; // goods
    public int viwer; // viwer
    public int donationPrice; //donationPrice
    public int maxCapacity; //총 굿즈 개수
    public int staffCapacity;
    public float time; 
    public float finalTime;//시작 시간. 몇초인지
    public int totalstaffCost;//totalStaffCost
    public int workStaff;// How many staff working

    //#.------싱글톤-------
    private void Awake() {
        if(null == instance){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }
    public static GameManager Instance{
        get{
            if (null == instance){
                return null;
            }
            return instance;
        }
    }

    private void Start() {
        staffCapacity = 2 + ((int)maxCapacity/20); //staffCapcity는 default 2 + maxCapacity/50 + 게이지마다 1명씩 상승? 밸런스 조절 ㄱ
        
        money = GlobalVar.startMoney;
        donationPrice = GlobalVar.donationPrice;
        finalTime = GlobalVar.startFinalTime;
        time = finalTime;

        stockManager.MainStockChange("코렛샤 컴퍼니", 2000, 150, 0);//30만원
    }

    private void Update() {
        TimeFlow();
    }

    void TimeFlow(){
        if(isStopTime) return;

        //0.Guage Time
        time -= Time.deltaTime;

        //1.Guage Over Event
        if(time <= 0f){
            guage--;

            //#2. Day Change Event
            if(guage < 1){
                guage = 3;
                day++;

                goodsSystem.goodsDesignBonusCnt += 1;

                int Bang = Random.Range(0, 1000);
                if(Bang <= 2) money += (int)(skillManager.skillList[8]._functionDesc[skillManager.skillList[8]._level] * 35000000);
                money += (int)skillManager.skillList[10]._functionDesc[skillManager.skillList[10]._level];
                //Important Event 발생
            }
            //게이지마다 t자원 증가 스킬
            money += (int)(viwer * donationPrice * skillManager.skillList[13]._functionDesc[skillManager.skillList[13]._level]);

            //#.Auto Making by staffs- StaffMPS Time
            for(int i = 0; i < 4; i++){
                goods += (int)(staffManager.staffCnt[0, i] * staffManager.staffMPS[0, i] * skillManager.skillList[6]._functionDesc[skillManager.skillList[6]._level]);
                goodsSystem.goodsDesignBonusCnt += (int)(staffManager.staffCnt[1, i] * staffManager.staffMPS[1, i] * skillManager.skillList[6]._functionDesc[skillManager.skillList[6]._level]); 
                gameManager.maxCapacity += (int)(staffManager.staffCnt[1, i] * staffManager.staffMPS[1, i] * skillManager.skillList[6]._functionDesc[skillManager.skillList[6]._level]); 
                staffCapacity +=(int)((staffManager.staffCnt[1, i] * staffManager.staffMPS[0, i] * skillManager.skillList[6]._functionDesc[skillManager.skillList[6]._level])/10); 
                viwer += (int)(staffManager.staffCnt[2, i] * staffManager.staffMPS[2, i] * (skillManager.skillList[14]._functionDesc[skillManager.skillList[14]._level] + skillManager.skillList[19]._functionDesc[skillManager.skillList[19]._level] ));
            }
            
            //#.샤샤스킬.게이지마다 시청자수 증가
            viwer += (int)skillManager.skillList[7]._functionDesc[skillManager.skillList[7]._level];
            

            //#.Goods Price, Donation Price Change
            int changeGoodsPrice = Random.Range(-5, 6);
            int changeDonationPrice = Random.Range(-5, 6);
            goodsSystem.goodsPrice += goodsSystem.goodsPrice * changeGoodsPrice / 100;
            donationPrice += donationPrice * changeDonationPrice / 100;

            money -= (int)(totalstaffCost); // each month -> staff cost pay


            //#스태프용량, 기본용량, 디자인 수 등 증가부분
            staffCapacity++;
            maxCapacity += 5;

            time = finalTime;
        }


        //Check Event
        if(eventManager.CheckEvent(day)){ //이건 날마다 있는 이벤트. 튜토리얼 이벤트는 UI돌아가야함.
            uiManager.EventUpdate(eventManager.curEvent);
            isStopTime = true;
            isStopUI = true;
        }

        //Check Main Story
        if(!mainStoryManager.isColletStoryStart && day == 5){
            if(stockManager.mainStock.GetComponent<StockItem>().myStock == stockManager.mainStock.GetComponent<StockItem>().totalStock){
                uiManager.ColletStoryStart();
                mainStoryManager.isColletStoryStart = true;
                stockManager.MainStockChange("밀감 컴퍼니", 10000, 200, 1);//200만원
            }else{
                StartCoroutine(Ending(false));
            }
        }
        if(!mainStoryManager.isTamX2StoryStart && day == 10){
            if(stockManager.mainStock.GetComponent<StockItem>().myStock == stockManager.mainStock.GetComponent<StockItem>().totalStock){
                uiManager.TamX2StoryStart();
                mainStoryManager.isTamX2StoryStart = true;
                stockManager.MainStockChange("우주대스타 컴퍼니", 20000, 300, 2);//600만원
            }else{
                StartCoroutine(Ending(false));
            }
        }
        if(!mainStoryManager.isNanayangtoryStart && day == 15){
            if(stockManager.mainStock.GetComponent<StockItem>().myStock == stockManager.mainStock.GetComponent<StockItem>().totalStock){
                uiManager.NanayangStoryStart();
                mainStoryManager.isNanayangtoryStart = true;
                stockManager.MainStockChange("원두컴퍼니", 30000, 500, 3);//1500만원
            }else{
                StartCoroutine(Ending(false));
            }
        }
        if(day == 20){
            if(stockManager.mainStock.GetComponent<StockItem>().myStock == stockManager.mainStock.GetComponent<StockItem>().totalStock){
                StartCoroutine(Ending(true));
            }else{
                StartCoroutine(Ending(false));
            }
        }

        goods = goods > maxCapacity ? maxCapacity : goods; // goods는 최대 goods 용량 못넘어감
        money = money > 1999999999 ? 1999999999 : money; // 돈 최대 제한 19억9...
    }

    //#. Map Move
    public void TypeBtnClick(string dir){
        if(dir == "Right" && (int)gameManager.curType < 2){
            if(!tutorialManager.isTutorialEnd
                && tutorialManager.tutorialIndex < 17) 
                return;
            gameManager.curType++;

        }else if(dir == "Left"&&(int)gameManager.curType > 0){
            gameManager.curType--;
        }
        //#.Move BackGround
        gameManager.ChangeMap();
        soundManager.PanelClick();
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


    IEnumerator Ending(bool isClear){

        //#.Stop All Active

        if(isClear){//HappyEnding
            soundManager.MuteAll();
            uiManager.Ending(isClear);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(4);
        }else{//Bad Ending
            uiManager.Ending(isClear);

            yield return new WaitForSeconds(2f);
            uiManager.BankruptcyScale();
            yield return new WaitForSeconds(3f);
            
            Application.Quit();
        }
    }
}

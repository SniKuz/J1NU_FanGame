using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsSystem : MonoBehaviour
{

    public GameManager gameManager;

    public GameObject DesignOnOffBtn;

    public Animator designAnim;
    public Animator makeleftArmAnim;
    public Animator leftArmSpark;
    public Animator makerightArmAnim;
    public Animator rightArmSpark;
    public Animator capacityAnim;
    public Animator transportAnim;

    public Sprite[] onOffBtnSprite;
    private Ray ray;
    private RaycastHit raycastHit;

    private int goodsPrice; // 1 goods price
    private bool goodsDesigning;
    private float goodsDesigningTime;
    public int goodsDesignCnt; // cnt for how many click is one goodDesignBonusCnt
    public int goodsDesignBonusCnt; // goodsDesingTime
    private int designBonus; // Bonus about goods price
    public int goodsMakeCnt;
    public int goodsCapacityCnt;
    private bool goodsTransporting;
    public float goodsTransportTime;
    private float goodsTransportSpeed; // goods sell speed
    private int goodsTransPortCapacity; // How many goods can sell in one time

    private void Start() {
        //추후 데이터 저장해서 업그레이드 반영해야함
        goodsPrice = 10; 
        goodsDesigning = false;
        goodsDesignCnt = 10;
        goodsDesigningTime = 5; 
        goodsDesignBonusCnt = 3;
        designBonus = 2;
        goodsMakeCnt = 10;
        goodsCapacityCnt = 30;
        goodsTransporting = false;
        goodsTransportSpeed = 1;
        goodsTransPortCapacity = 5;
        goodsTransportTime = 5;
    }


    private void Update() {
        if(GameManager.Instance.isStopTime) return;

        TouchGoodsCreate();
        if(Input.GetKeyDown(KeyCode.D)) ChangeGoodsDesigning();
        if(Input.GetKeyDown(KeyCode.S)) ChangeGoodsTransporting(); 

        if(goodsTransporting){
            GoodsTrnasport();
        } else transportAnim.SetBool("on", false);

        if(goodsDesigning){
            GoodsDesignBonus();
        } 
    }

    void TouchGoodsCreate(){
    if(GameManager.Instance.isStopTime) return;//시간 멈출시 Touch불가
#if UNITY_ANDROID
        if(Input.touchCount > 0){
            if(Input.GetTouch(0).phase == TouchPhase.Began){
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                Physics.Raycast(ray, out raycastHit);
                switch(raycastHit.collider.gameObject.name){
                    case "Design_Btn_OnOff":
                        ChangeGoodsDesigning();
                        break;
                    case "Goods_Design":
                        GoodsDesignCntUp();
                        break;
                    case "Goods_Make":
                        GoodsMakeBtn();
                        break;
                    case "GoodsPacking":
                        GoodsCapacityBtn();
                        break;
                    case "Goods_Transport_Box":
                        ChangeGoodsTransporting();
                        break;
                }
            }
        }
#endif
#if UNITY_EDITOR 
        if(Input.GetMouseButtonDown(0)){
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity)){
                switch (raycastHit.collider.gameObject.name)
                {
                    case "Design_Btn_OnOff":
                        ChangeGoodsDesigning();
                        break;
                    case "Goods_Design":
                        GoodsDesignCntUp();
                        break;
                    case "Goods_Make":
                        GoodsMakeBtn();
                        break;
                    case "Goods_Packing":
                        GoodsCapacityBtn();
                        break;
                    case "Goods_Transport_Box":
                        ChangeGoodsTransporting();
                        break;
                    default:
                        break;
                }
            }
        }
#endif
    }

    void GoodsDesignCntUp(){
        goodsDesignCnt-=1;
        if(goodsDesignCnt <= 0){
            goodsDesignCnt = 10;
            goodsDesignBonusCnt++;
        }
    }

    public void ChangeGoodsDesigning(){
        if(GameManager.Instance.isStopTime) return;//시간 멈출시

        if(goodsDesignBonusCnt <= 0 ) goodsDesigning = false;
        else goodsDesigning  = !goodsDesigning;
        BtnSpriteChange(goodsDesigning);
        designAnim.SetBool("on", goodsDesigning);
    }

    public void GoodsDesignBonus(){
        goodsDesigningTime -= Time.deltaTime;
        if(goodsDesigningTime <= 0f && goodsTransporting){
            goodsDesigningTime = 5f;
            gameManager.money += goodsPrice * designBonus ;
            goodsDesignBonusCnt--;

        } else if (goodsDesigningTime <= 0f && !goodsTransporting) {
            goodsDesigningTime = 5f;
            goodsDesignBonusCnt --;
        }

        
        if(goodsDesignBonusCnt <=0) {
            goodsDesigning = false;
            designAnim.SetBool("on", false);
            BtnOff(DesignOnOffBtn);
        }
    }

    void GoodsMakeBtn(){
        goodsMakeCnt-= 1;
        if(goodsMakeCnt <= 0){
            goodsMakeCnt = 10;
            gameManager.prevGoods = gameManager.goods;
            gameManager.goods += 1;
        }
        GoodsMakeAnimOn();
    }

    public void GoodsMakeAnimOn(){
        makeleftArmAnim.SetTrigger("on");
        makerightArmAnim.SetTrigger("on");
        leftArmSpark.SetTrigger("on");
        rightArmSpark.SetTrigger("on");

    }

    void MaxCapacityUp(){
        gameManager.maxCapacity += 1;
    }

    void GoodsCapacityBtn(){
        goodsCapacityCnt -= 1;
        capacityAnim.SetTrigger("on");
        if(goodsCapacityCnt <= 0){
            goodsCapacityCnt = 30;
            MaxCapacityUp();
        }
    }


    //To Change Goods Transprting. btn and keydown
    public void ChangeGoodsTransporting(){ 
        if(gameManager.goods <= 0f) goodsTransporting = false;
        else goodsTransporting = ! goodsTransporting;
        transportAnim.SetBool("on", goodsTransporting);
    }


    //goods 판매. 만약 디자인중이면 추가금액. 일단 대충 진행 transportTime의 1번씩 판매
    //계속 파는상태로 둘 때 어떻게 해야할까? 좀 고민
    public void GoodsTrnasport()
    {
        goodsTransportTime -=  Time.deltaTime * goodsTransportSpeed;
        if(goodsTransportTime <= 0f)
        {
            goodsTransportTime = 5; // 시간 초기화
            if(gameManager.goods < goodsTransPortCapacity){ // 굿즈 개수가 포팅 최대 개수가 안된다면
                gameManager.money += goodsPrice * gameManager.goods;
                gameManager.goods = 0;
                goodsTransporting = false;
            }
            else {                    
                gameManager.money += goodsPrice * goodsTransPortCapacity;
                gameManager.goods -= goodsTransPortCapacity;
            }
        }
    }

    public void BtnSpriteChange(bool on){
        if(on) raycastHit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = onOffBtnSprite[0];
        else raycastHit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = onOffBtnSprite[1];
    }

    public void BtnOff(GameObject btn){
        btn.GetComponent<SpriteRenderer>().sprite = onOffBtnSprite[1];
    }
}

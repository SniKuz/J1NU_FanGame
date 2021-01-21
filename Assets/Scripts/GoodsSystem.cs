using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoodsSystem : MonoBehaviour
{

    public GameManager gameManager;
    public StreamerSkillManager skillManager;
    public SoundManager soundManager;

    public GameObject DesignOnOffBtn;
    public GameObject goodsMakeMachine;
    public bool whileGoodsMakePunchScale;

    public GameObject goodsTransportMachine;

    public Animator designAnim;
    public Animator makeleftArmAnim;
    public Animator leftArmSpark;
    public Animator makerightArmAnim;
    public Animator rightArmSpark;
    public Animator capacityAnim;
    public Animator transportAnim;
    public Animator transportEarthAnim;

    public int[] maxCnt; // each touch max. 0:Design, 1:Make, 2:Capacity
    public Sprite[] onOffBtnSprite;
    private Ray ray;
    private RaycastHit raycastHit;
    public int goodsPrice; // 1 goods price
    private bool goodsDesigning;
    private float goodsDesigningTime;
    public int goodsDesignCnt; // cnt for how many click is one goodDesignBonusCnt
    public int goodsDesignBonusCnt; // goodsDesingTime
    private int designBonus; // Bonus about goods price
    public int goodsMakeCnt;
    public int goodsCapacityCnt;
    private bool goodsTransporting;
    public float goodsTransportTime;
    public int goodsTransPortCapacity; // How many goods can sell in one time


//#. -------GoodsMakeClickGuage
    public GameObject goodsClickGuage;
    

    private void Start() {
        //추후 데이터 저장해서 업그레이드 반영해야함
        goodsDesigning = false;
        goodsDesigningTime = 5; 
        designBonus = 2;
        goodsTransporting = false;
        goodsTransPortCapacity = 5;

        for(int i=0; i<3; i++){
            maxCnt[i] = GlobalVar.clickCnt;
        }
        goodsPrice = GlobalVar.goodsPrice;
    }


    private void Update() {

        if(gameManager.isStopUI) return;

        TouchGoodsCreate();

        if(goodsTransporting){
            GoodsTrnasport();
        } else{
            transportAnim.SetBool("on", false);
            transportEarthAnim.SetBool("on", false);
        }

        if(goodsDesigning){
            GoodsDesignBonus();
        } 
    }

    void TouchGoodsCreate(){
#if UNITY_ANDROID
        if(Input.touchCount > 0){
            if(Input.GetTouch(0).phase == TouchPhase.Began){
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                Physics.Raycast(ray, out raycastHit);
                switch(raycastHit.collider.gameObject.name){
                    case "Design_Btn_OnOff":
                        ChangeGoodsDesigning();
                        break;
                    // case "Goods_Design":
                    //     GoodsDesignCntUp();
                    //     break;
                    case "Goods_Make":
                        GoodsMakeBtn();
                        break;
                    // case "Goods_Packing":
                    //     GoodsCapacityBtn();
                    //     break;
                    case "Goods_Transport_Box":
                        ChangeGoodsTransporting();
                        break;
                }
            }
        }
        if(gameManager.curType == 0){
            // if(Input.GetKeyDown(KeyCode.Q)){
            //     GoodsDesignCntUp();
            // }
            // if(Input.GetKeyDown(KeyCode.W)){
            //     GoodsMakeBtn();
            // }
            if(Input.GetKeyDown(KeyCode.Space)){
                GoodsMakeBtn();
            }
            // if(Input.GetKeyDown(KeyCode.E)){
            //     GoodsCapacityBtn();
            // }
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
                    // case "Goods_Design":
                    //     GoodsDesignCntUp();
                    //     break;
                    case "Goods_Make":
                        GoodsMakeBtn();
                        break;
                    // case "Goods_Packing":
                    //     GoodsCapacityBtn();
                    //     break;
                    case "Goods_Transport_Box":
                        ChangeGoodsTransporting();
                        break;
                    default:
                        break;
                }
            }
        }

        if(gameManager.curType == 0){
            // if(Input.GetKeyDown(KeyCode.Q)){
            //     GoodsDesignCntUp();
            // }
            // if(Input.GetKeyDown(KeyCode.W)){
            //     GoodsMakeBtn();
            // }
            if(Input.GetKeyDown(KeyCode.Space)){
                GoodsMakeBtn();
            }
            // if(Input.GetKeyDown(KeyCode.E)){
            //     GoodsCapacityBtn();
            // }
        }
#endif
    }

    void GoodsDesignCntUp(){
        designAnim.SetTrigger("on");
        goodsDesignCnt += 1  ;
        if(goodsDesignCnt >= maxCnt[0]){
            goodsDesignCnt -= maxCnt[0];
            goodsDesignBonusCnt++;
        }
    }

    public void ChangeGoodsDesigning(){
        if(gameManager.isStopUI) return;//UI멈출시

        if(goodsDesignBonusCnt <= 0 ) goodsDesigning = false;
        else goodsDesigning  = !goodsDesigning;
        BtnSpriteChange(goodsDesigning);
        soundManager.PanelClick();
    }

    public void GoodsDesignBonus(){
        goodsDesigningTime -= Time.deltaTime;
        if(goodsDesigningTime <= 0f && goodsTransporting){
            goodsDesigningTime = 5f;
            gameManager.money += goodsPrice * designBonus * goodsTransPortCapacity;
            goodsDesignBonusCnt--;

        } else if (goodsDesigningTime <= 0f && !goodsTransporting) {
            goodsDesigningTime = 5f;
            goodsDesignBonusCnt --;
        }

        if(goodsDesignBonusCnt <=0) {
            goodsDesigning = false;
            BtnOff(DesignOnOffBtn);
        }
    }

    void GoodsMakeBtn(){
        goodsMakeCnt+= 1 + (int)skillManager.skillList[5]._functionDesc[skillManager.skillList[5]._level]; //Collet0 Skill

        int goldSaHyang0 = Random.Range(0, 100);
        if( goldSaHyang0 < (int)skillManager.skillList[0]._functionDesc[skillManager.skillList[0]._level]){
            goodsMakeCnt += (int)skillManager.skillList[0]._functionDesc[skillManager.skillList[0]._level]/10;
        }

            while(goodsMakeCnt>=maxCnt[1]){
                goodsMakeCnt -= maxCnt[1];
                if(gameManager.maxCapacity > gameManager.goods){
                    int copyGoods = Random.Range(0, 100);
                    if(copyGoods < skillManager.skillList[9]._functionDesc[skillManager.skillList[9]._level]){
                        gameManager.goods += 1;
                        MakeItem();
                    }
                    gameManager.goods += 1;

                    int goodsMakeOtherSource = Random.Range(0, 100);
                    if(goodsMakeOtherSource < skillManager.skillList[3]._functionDesc[skillManager.skillList[3]._level]){
                    designBonus++;
                    gameManager.maxCapacity++;
                    gameManager.viwer++;
                }

                if(!whileGoodsMakePunchScale){
                    whileGoodsMakePunchScale = true;
                    goodsMakeMachine.transform.DOPunchScale(new Vector3(1,1,1),1f, 5);
                        Invoke("GoodsMakePunchScale", 1f);
                    }
                    MakeItem();
                    soundManager.SkillUp();
                }
            }
        GoodsMakeAnimOn();
        soundManager.DrillSound();

        //Guage무브
        goodsClickGuage.transform.localScale = new Vector3((float)goodsMakeCnt/(float)maxCnt[1],1,1);
    }

    void GoodsMakePunchScale(){
        whileGoodsMakePunchScale = false;
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
        goodsCapacityCnt += 1 ;
        capacityAnim.SetTrigger("on");
        if(goodsCapacityCnt >= maxCnt[2]){
            goodsCapacityCnt -= maxCnt[2];
            MaxCapacityUp();
        }
    }


    //To Change Goods Transprting. btn and keydown
    public void ChangeGoodsTransporting(){ 
        if(gameManager.goods <= 0f) goodsTransporting = false;
        else goodsTransporting = ! goodsTransporting;
        transportAnim.SetBool("on", goodsTransporting);
        transportEarthAnim.SetBool("on", goodsTransporting);
    }


    //goods 판매. 만약 디자인중이면 추가금액. 일단 대충 진행 transportTime의 1번씩 판매
    //계속 파는상태로 둘 때 어떻게 해야할까? 좀 고민
    public void GoodsTrnasport()
    {
        goodsTransportTime +=  Time.deltaTime;
        if(goodsTransportTime >= 5f * skillManager.skillList[1]._functionDesc[skillManager.skillList[1]._level])//굿즈 판매속도 증가
        {
            goodsTransportTime = 0; // 시간 초기화
            if(gameManager.goods < goodsTransPortCapacity + skillManager.skillList[2]._functionDesc[skillManager.skillList[2]._level]){ // 굿즈 개수가 포팅 최대 개수가 안된다면
                gameManager.money += goodsPrice * gameManager.goods * (int)skillManager.skillList[4]._functionDesc[skillManager.skillList[4]._level];//GoldSaHayng4 Skill
                gameManager.goods = 0;
                goodsTransporting = false;
            }
            else {                    
                gameManager.money += goodsPrice * (int)((goodsTransPortCapacity + skillManager.skillList[2]._functionDesc[skillManager.skillList[2]._level]) //최대 판매 개수 + 스킬 추가 판매 개수
                * (skillManager.skillList[4]._functionDesc[skillManager.skillList[4]._level]));
                gameManager.goods -= (int)(goodsTransPortCapacity + skillManager.skillList[2]._functionDesc[skillManager.skillList[2]._level]);
            }
            goodsTransportMachine.transform.DOPunchScale(new Vector3(1,1,1), 1.5f, 2);
            soundManager.TransportSellSound();
        }
    }

    public void BtnSpriteChange(bool on){
        if(on) raycastHit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = onOffBtnSprite[0];
        else raycastHit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = onOffBtnSprite[1];
    }

    public void BtnOff(GameObject btn){
        btn.GetComponent<SpriteRenderer>().sprite = onOffBtnSprite[1];
    }

    public void MakeItem(){
        GameObject item  = GoodsCupObjectPool.GetObject();
        item.transform.position = Vector3.zero;
        float ranScale = Random.Range(0.1f, 0.7f);
        item.transform.localScale = new Vector3(ranScale, ranScale, 0.3f);
        Rigidbody2D itemRigid = item.GetComponent<Rigidbody2D>();

        Vector2 popVect = new Vector2(Random.Range(-1f, 1f), Random.Range(2f, 3f));
        itemRigid.AddForce(popVect, ForceMode2D.Impulse);

        StartCoroutine("DestroyGoods", item);
    }
    IEnumerator DestroyGoods(GameObject returnThis){
        yield return new WaitForSeconds(3f);
        GoodsCupObjectPool.ReturnObject(returnThis);
    }
}

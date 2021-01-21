using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
	public GameManager gameManager;
	public GoodsSystem goodsSystem;
    public StockManager stockManager;
    public StreamerSkillManager skillManager;
    public StaffManager staffManager;
    public EventManager eventManager;
    public SoundManager soundManager;
    public TalkManager talkManager;
    public TutorialManager tutorialManager;
    public MainStoryManager mainStoryManager;

	public Image dateImage;
	public Sprite[] guageImage;
	public GameObject battery;
	public TextMeshProUGUI dateText;
	public TextMeshProUGUI moneyText;
	public TextMeshProUGUI goodsText;
	public TextMeshProUGUI viwerText;
    public TextMeshProUGUI designBonusText;

	public RectTransform stockPanel;
	public RectTransform streamerPanel;
    public RectTransform staffPanel;
    public RectTransform informationPanel;

    public RectTransform alertSet;

    //#.--------Streamer Skill
	public GameObject GoldSaHyangUpgradeSet;
    public GameObject GoldSaHyangPanelBnt;
	public GameObject ColletUpgradeSet;
    public GameObject ColletPanelBtn;
	public GameObject Tamx2UpgradeSet;
    public GameObject Tamx2PanelBtn;
	public GameObject NanayangUpgradeSet;
    public GameObject NanayangPanelBtn;

    public Image[] skillTreeIcons;
    public TextMeshProUGUI[] skillTreeLevel;
    public Button skillGuideBtn;
    public Image SkillDescImg;
    public TextMeshProUGUI skillDescName;
    public TextMeshProUGUI skillDescLevel;
    public TextMeshProUGUI skillDescFunc;
    public TextMeshProUGUI skillDescIntroduce;
    public TextMeshProUGUI skillDescGold;
    public StreamerSkillVo selectedSkill;

    //#.---------Staff
    public TextMeshProUGUI staffCostText;
    public TextMeshProUGUI maxStaffCapasityText;
    public GameObject staffSetBtn;
    public GameObject staffSet;
    public GameObject staffGetBtn;
    public GameObject staffGet;
    public TextMeshProUGUI staffSInText;
    public TextMeshProUGUI staffSOutText;
    public TextMeshProUGUI staffAInText;
    public TextMeshProUGUI staffAOutText;
    public TextMeshProUGUI staffBInText;
    public TextMeshProUGUI staffBOutText;
    public TextMeshProUGUI staffCInText;
    public TextMeshProUGUI staffCOutText;
    public TextMeshProUGUI staffGoldPerGuage;
    public TextMeshProUGUI staffCapacity;

    //#.StaffDraw
    public GameObject BackGroundForDontTouchOnemoreDraw;
    public GameObject staffOneRecruitBtn;
    public GameObject staffTenRecruitBtn;

    //#.----------------status
    public TextMeshProUGUI statusGoodsPrice;
    public TextMeshProUGUI statusDonationPrice;
    public TextMeshProUGUI statusGoodsSellTime;
    public TextMeshProUGUI statusGoodsSellCapacity;
    public TextMeshProUGUI statusDesignMakeBtn;
    public TextMeshProUGUI statusDesignAutoMake;
    public TextMeshProUGUI statusGoodsMakeBtn;
    public TextMeshProUGUI statusGoodsAutoMake;
    public TextMeshProUGUI statusCapacityMakeBtn;
    public TextMeshProUGUI statusCapacityAutoMake;

    //#.------------event
    public RectTransform eventSet;
    public TextMeshProUGUI eventTitle;
    public TextMeshProUGUI eventContent;
    public GameObject eventEffect;
    public GameObject stopTimeWindow;

    //#.------------talk panel
    public RectTransform talkBackGround;
    public Image talkPortrait;
    public TextMeshProUGUI talkName;
    public TextTypeEffect talkText;
    public GameObject talkEndCursor;

    public GameObject tutorailSkipBtn;
    public GameObject tutorialNotSkipBtn;

    public Image fadeImg;
    public GameObject badEnd; //파산


    

    private void Start(){
        skillUIUpdate();

        //#T. Test Tutorial talk
        if(!tutorialManager.isTutorialEnd)
            gameManager.isStopTime = true;
            gameManager.isStopUI = true;
            stopTimeWindow.SetActive(true);
            tutorailSkipBtn.SetActive(true);
            tutorialNotSkipBtn.SetActive(true);
    }

	private void LateUpdate() {
        if(gameManager.isStopUI) return;

        //#0. 
		dateImage.fillAmount = gameManager.time/gameManager.finalTime;
		dateText.text = gameManager.day+"" ;	

        //#.Money UI	
		if(gameManager.money > 10000000) moneyText.text = string.Format("{0:n0}", gameManager.money/1000)+"k";
		else moneyText.text = string.Format("{0:n0}", gameManager.money);

        //#.Goods UI
		if(gameManager.goods > 10000000) goodsText.text = gameManager.goods/1000 +"k/" + gameManager.maxCapacity/1000 +"k";
		else goodsText.text = gameManager.goods + "/" + gameManager.maxCapacity;

        //#.DesignBonus UI
        designBonusText.text = goodsSystem.goodsDesignBonusCnt+"";



        //#.Viwer UI
		if(gameManager.viwer > 100000) viwerText.text = string.Format("{0:n0}", gameManager.viwer/1000)+"k";
		else viwerText.text = string.Format("{0:n0}", gameManager.viwer);

		battery.gameObject.GetComponent<Image>().sprite = guageImage[3 - gameManager.guage]; // battery change

        //#.Staff UI
        staffSInText.text = string.Format("{0:n0}", staffManager.staffCnt[(int)gameManager.curType, 0]);
        staffAInText.text = string.Format("{0:n0}", staffManager.staffCnt[(int)gameManager.curType, 1]);
        staffBInText.text = string.Format("{0:n0}", staffManager.staffCnt[(int)gameManager.curType, 2]);
        staffCInText.text = string.Format("{0:n0}", staffManager.staffCnt[(int)gameManager.curType, 3]);
        staffSOutText.text = string.Format("{0:n0}", staffManager.waitStaffCnt[0]);
        staffAOutText.text = string.Format("{0:n0}", staffManager.waitStaffCnt[1]);
        staffBOutText.text = string.Format("{0:n0}", staffManager.waitStaffCnt[2]);
        staffCOutText.text = string.Format("{0:n0}", staffManager.waitStaffCnt[3]);
        if(staffManager.staffCnt[0, 0]>0) goodsSystem.GoodsMakeAnimOn();
        if(staffManager.staffCnt[0, 1]>0) goodsSystem.GoodsMakeAnimOn();
        if(staffManager.staffCnt[0, 2]>0) goodsSystem.GoodsMakeAnimOn();
        if(staffManager.staffCnt[0, 3]>0) goodsSystem.GoodsMakeAnimOn();
        if(staffManager.staffCnt[1, 0]>0) {
            goodsSystem.designAnim.SetTrigger("on");
            goodsSystem.capacityAnim.SetTrigger("on");
        }
        if(staffManager.staffCnt[1, 1]>0) {
            goodsSystem.designAnim.SetTrigger("on");
            goodsSystem.capacityAnim.SetTrigger("on");
        }
        if(staffManager.staffCnt[1, 2]>0) {
            goodsSystem.designAnim.SetTrigger("on");
            goodsSystem.capacityAnim.SetTrigger("on");
        }
        if(staffManager.staffCnt[1, 3]>0) {
            goodsSystem.designAnim.SetTrigger("on");
            goodsSystem.capacityAnim.SetTrigger("on");
        }
        


        //#.StaffCost and Staff Max Capacity
        staffCostText.text = string.Format("{0:n0}", gameManager.totalstaffCost);
        maxStaffCapasityText.text = gameManager.workStaff +"/"+ gameManager.staffCapacity;

        //#.Status Panel Update
        float staffAutoMakeDesign = 0;
        float staffAutoMakeGoods = 0;
        for(int i = 0; i < 4; i++){
            staffAutoMakeDesign += (staffManager.staffCnt[1, i] * staffManager.staffMPS[1, i] * skillManager.skillList[6]._functionDesc[skillManager.skillList[6]._level]);
            staffAutoMakeGoods += (staffManager.staffCnt[0, i] * staffManager.staffMPS[0, i] * skillManager.skillList[6]._functionDesc[skillManager.skillList[6]._level]); 
        }
        statusDesignAutoMake.text = (int)staffAutoMakeDesign + "";
        statusGoodsAutoMake.text = (int)staffAutoMakeGoods +"";
        statusCapacityAutoMake.text = (int)staffAutoMakeDesign+"";
        StatusPanelUpdate();


	}

//------------------------------------------------[하단 Panle Btn]
	public void PanelBtn(string panelName){
		if(panelName == "StockPanel"){
			if(stockPanel.localPosition.y == -878){
				stockPanel.DOLocalMoveY(0, 0.4f).SetEase(Ease.OutBack);

				//#.Other UI Panel Hide
				if(streamerPanel.localPosition.y == 0){
					streamerPanel.DOLocalMoveY(-878, 0.4f);
				}
                if(staffPanel.localPosition.y == 0){
					staffPanel.DOLocalMoveY(-878, 0.4f);
				}
                if(informationPanel.localPosition.y == 0){
                    informationPanel.DOLocalMoveY(-878, 0.4f);
                }
			}else if(stockPanel.localPosition.y == 0){
				stockPanel.DOLocalMoveY(-878, 0.4f).SetEase(Ease.InBack);
			}
		}
		if(panelName == "StreamerPanel"){
			if(streamerPanel.localPosition.y == -878){
				streamerPanel.DOLocalMoveY(0, 0.4f).SetEase(Ease.OutBack);

				//#.Other UI Panel Hide
				if(stockPanel.localPosition.y == 0){
					stockPanel.DOLocalMoveY(-878, 0.4f);
				}
                if(staffPanel.localPosition.y == 0){
					staffPanel.DOLocalMoveY(-878, 0.4f);
				}
                if(informationPanel.localPosition.y == 0){
                    informationPanel.DOLocalMoveY(-878, 0.4f);
                }
			}else if(streamerPanel.localPosition.y == 0){
				streamerPanel.DOLocalMoveY(-878, 0.4f).SetEase(Ease.InBack);
			}
		}
        if(panelName == "StaffPanel"){
			if(staffPanel.localPosition.y == -878){
				staffPanel.DOLocalMoveY(0, 0.4f).SetEase(Ease.OutBack);

				//#.Other UI Panel Hide
				if(stockPanel.localPosition.y == 0){
					stockPanel.DOLocalMoveY(-878, 0.4f);
				}
                if(streamerPanel.localPosition.y == 0){
                    streamerPanel.DOLocalMoveY(-878, 0.4f);
                }
                if(informationPanel.localPosition.y == 0){
                    informationPanel.DOLocalMoveY(-878, 0.4f);
                }
			}else if(staffPanel.localPosition.y == 0){
				staffPanel.DOLocalMoveY(-878, 0.4f).SetEase(Ease.InBack);
			}
		}
        if(panelName == "InformationPanel"){
			if(informationPanel.localPosition.y == -878){
				informationPanel.DOLocalMoveY(0, 0.4f).SetEase(Ease.OutBack);

				//#.Other UI Panel Hide
				if(stockPanel.localPosition.y == 0){
					stockPanel.DOLocalMoveY(-878, 0.4f);
				}
                if(streamerPanel.localPosition.y == 0){
                    streamerPanel.DOLocalMoveY(-878, 0.4f);
                }
                if(staffPanel.localPosition.y == 0){
                    staffPanel.DOLocalMoveY(-878, 0.4f);
                }
			}else if(informationPanel.localPosition.y == 0){
				informationPanel.DOLocalMoveY(-878, 0.4f).SetEase(Ease.InBack);
			}
		}
        soundManager.PanelClick();
	}

    //------------------------------------[StreamerPanel TabBtn]
	public void TabStreamerBtn(string streamerName){
		switch (streamerName){
			case "GoldSaHyang":
				GoldSaHyangUpgradeSet.SetActive(true);
                ColletUpgradeSet.SetActive(false);
                Tamx2UpgradeSet.SetActive(false);
                NanayangUpgradeSet.SetActive(false);

                GoldSaHyangPanelBnt.GetComponent<Image>().color = Color.white;
                ColletPanelBtn.GetComponent<Image>().color = new Color32(211, 112, 231, 255);
                Tamx2PanelBtn.GetComponent<Image>().color = new Color32(243, 194, 54, 255);
                NanayangPanelBtn.GetComponent<Image>().color = new Color32(250, 243, 91, 255);

                GoldSaHyangPanelBnt.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(50, 50, 50, 255);
                ColletPanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Tamx2PanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                NanayangPanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;

                SelectSkill(0);
				break;
			case "Collet":
                GoldSaHyangUpgradeSet.SetActive(false);
                ColletUpgradeSet.SetActive(true);
                Tamx2UpgradeSet.SetActive(false);
                NanayangUpgradeSet.SetActive(false);

                GoldSaHyangPanelBnt.GetComponent<Image>().color = new Color32(255, 180, 200, 255);
                ColletPanelBtn.GetComponent<Image>().color = Color.white;
                Tamx2PanelBtn.GetComponent<Image>().color = new Color32(243, 194, 54, 255);
                NanayangPanelBtn.GetComponent<Image>().color = new Color32(250, 243, 91, 255);

                GoldSaHyangPanelBnt.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                ColletPanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(50, 50, 50, 255);
                Tamx2PanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                NanayangPanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;

                SelectSkill(5);
				break;
            case "Tamx2":
                GoldSaHyangUpgradeSet.SetActive(false);
                ColletUpgradeSet.SetActive(false);
                Tamx2UpgradeSet.SetActive(true);
                NanayangUpgradeSet.SetActive(false);

                GoldSaHyangPanelBnt.GetComponent<Image>().color = new Color32(255, 180, 200, 255);
                ColletPanelBtn.GetComponent<Image>().color = new Color32(211, 112, 231, 255);
                Tamx2PanelBtn.GetComponent<Image>().color = Color.white;
                NanayangPanelBtn.GetComponent<Image>().color = new Color32(250, 243, 91, 255);

                GoldSaHyangPanelBnt.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                ColletPanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Tamx2PanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(50, 50, 50, 255);
                NanayangPanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;

                SelectSkill(10);
                break;
			case "Nanayang":
                GoldSaHyangUpgradeSet.SetActive(false);
                ColletUpgradeSet.SetActive(false);
                Tamx2UpgradeSet.SetActive(false);
                NanayangUpgradeSet.SetActive(true);

                GoldSaHyangPanelBnt.GetComponent<Image>().color = new Color32(255, 180, 200, 255);
                ColletPanelBtn.GetComponent<Image>().color = new Color32(211, 112, 231, 255);
                Tamx2PanelBtn.GetComponent<Image>().color = new Color32(243, 194, 54, 255);
                NanayangPanelBtn.GetComponent<Image>().color = Color.white;

                GoldSaHyangPanelBnt.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                ColletPanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                Tamx2PanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                NanayangPanelBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(50, 50, 50, 255);

                SelectSkill(15);
                break;
		}
        soundManager.PanelClick();
	}


    //------------------------------------------[Streamer - Skill]
    public void SelectSkill(int id){
        selectedSkill = skillManager.GetSkill(id); //skillSelect

        if(selectedSkill._level >=5){
                SkillDescImg.sprite = selectedSkill._icon;
                skillDescName.text = selectedSkill._skillName;
                skillDescLevel.text = "LV.MAX";
                skillDescGold.text = "최대 레벨입니다.";
                skillDescFunc.text = selectedSkill._function[5];
                skillDescIntroduce.text = selectedSkill._skillIntroduce;
        }else{
            SkillDescImg.sprite = selectedSkill._icon;
            skillDescName.text = selectedSkill._skillName;
            skillDescLevel.text = "LV." + selectedSkill._level;
            skillDescFunc.text = selectedSkill._function[selectedSkill._level];
            skillDescIntroduce.text = selectedSkill._skillIntroduce;
            skillDescGold.text = "필요골드" + selectedSkill._nextLevelGold[selectedSkill._level];
        }
    }

    public void skillUIUpdate(){ //icon, SkillLevel Update
        //#. SkillTree Init
        for(int i = 0; i<20; i++){
            StreamerSkillVo skill = skillManager.GetSkill(i);
            skillTreeIcons[i].sprite = skill._icon;
            skillTreeLevel[i].text = "Lv." + skill._level;
        }
    }


    public void SkillUpBtn(){
        if(selectedSkill == null || selectedSkill._level>=5) return ;
        if(selectedSkill._level <5 && gameManager.money >= selectedSkill._nextLevelGold[selectedSkill._level]){
            gameManager.money -= selectedSkill._nextLevelGold[selectedSkill._level];//다음 레벨 가는 가격 빼고
            skillManager.SkillLevelUp(selectedSkill._id); // level++;
            skillUIUpdate(); //

            if(selectedSkill._level >=5){
                skillDescLevel.text = "LV.MAX";
                skillDescGold.text = "최대 레벨입니다.";
                skillDescFunc.text = selectedSkill._function[5];
            }else{
                skillDescLevel.text = "LV." + selectedSkill._level;
                skillDescGold.text = "필요골드" + selectedSkill._nextLevelGold[selectedSkill._level];
                skillDescFunc.text = selectedSkill._function[selectedSkill._level];
            }
            
            //#.SkillGuideAnim
            soundManager.SkillUp();
            skillGuideBtn.enabled = false;//잠시 버튼 끄고
            skillDescLevel.transform.DOPunchScale(new Vector3(1, 1, 1), 0.3f);
            skillDescGold.transform.DOPunchScale(new Vector3(1, 1, 1), 0.3f);
            skillDescFunc.transform.DOPunchScale(new Vector3(1, 1, 1), 0.3f);
            Invoke("SkillGuideBtnOn", 0.5f);//애니메이션 끝나고 버튼 다시 온. 애니메이션때문에 버튼 안터지게
        }
    }
    public void SkillGuideBtnOn(){
        skillGuideBtn.enabled = true;
    }


    //----------------------------------[StaffPanel]
    public void TabStaffBtn(string staffGetSet){
        switch(staffGetSet){
            case "SetStaffPanel":
                staffSet.SetActive(true);
                staffGet.SetActive(false);

                staffSetBtn.GetComponent<Image>().color = Color.white;
                staffGetBtn.GetComponent<Image>().color = new Color32(200, 200, 200, 255);   

                staffSetBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(50, 50, 50, 255);
                staffGetBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;     
                break;

            case "GetStaffPanel":
                staffSet.SetActive(false);
                staffGet.SetActive(true);

                staffSetBtn.GetComponent<Image>().color = new Color32(200, 200, 200, 255); 
                staffGetBtn.GetComponent<Image>().color = Color.white;  

                staffSetBtn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                staffGetBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(50, 50, 50, 255);   
                break;
        }
        soundManager.PanelClick();
    }

    public void StaffIn(string rank){
        if(gameManager.staffCapacity <= gameManager.workStaff) return;
        switch(rank){
            case "S":
                if(staffManager.waitStaffCnt[0] > 0){
                    staffManager.staffCnt[(int)gameManager.curType, 0]++;
                    staffManager.waitStaffCnt[0]--;
                }
                break;
            case "A":
                if(staffManager.waitStaffCnt[1] > 0){
                    staffManager.staffCnt[(int)gameManager.curType, 1]++;
                    staffManager.waitStaffCnt[1]--;
                }
                break;
            case "B":
                if(staffManager.waitStaffCnt[2] > 0){
                    staffManager.staffCnt[(int)gameManager.curType, 2]++;
                    staffManager.waitStaffCnt[2]--;
                }
                break;
            case "C":
                if(staffManager.waitStaffCnt[3] > 0){
                    staffManager.staffCnt[(int)gameManager.curType, 3]++;
                    staffManager.waitStaffCnt[3]--;
                }
                break;
        }

        int totalStaffCost = 0;
        int totalWorkStaff = 0;
        for(int i =0; i<3; i++){
            for(int j = 0; j<4; j++){
                totalStaffCost += staffManager.staffCnt[i, j] * staffManager.staffCost[j];
                totalWorkStaff += staffManager.staffCnt[i, j];
            }
        }
        gameManager.totalstaffCost = totalStaffCost;
        gameManager.workStaff = totalWorkStaff;
    }

    public void StaffOut(string rank){
        switch(rank){
            case "S":
                if(staffManager.staffCnt[(int)gameManager.curType, 0] >0){
                    staffManager.staffCnt[(int)gameManager.curType, 0]--;
                    staffManager.waitStaffCnt[0]++;
                }
                break;
            case "A":
                if(staffManager.staffCnt[(int)gameManager.curType, 1] >0){
                    staffManager.staffCnt[(int)gameManager.curType, 1]--;
                    staffManager.waitStaffCnt[1]++;
                }
                break;
            case "B":
                if(staffManager.staffCnt[(int)gameManager.curType, 2] >0){
                    staffManager.staffCnt[(int)gameManager.curType, 2]--;
                    staffManager.waitStaffCnt[2]++;
                }
                break;
            case "C":
                if(staffManager.staffCnt[(int)gameManager.curType, 3] >0){
                    staffManager.staffCnt[(int)gameManager.curType, 3]--;
                    staffManager.waitStaffCnt[3]++;
                }
                break;
        }

        int totalStaffCost = 0;
        int totalWorkStaff = 0;
        for(int i =0; i<3; i++){
            for(int j = 0; j<4; j++){
                totalStaffCost += staffManager.staffCnt[i, j] * staffManager.staffCost[j];
                totalWorkStaff += staffManager.staffCnt[i, j];
            }
        }
        gameManager.totalstaffCost = totalStaffCost;
        gameManager.workStaff = totalWorkStaff;
    }

    public void StaffDrawBtn(int num){

        //#.Cost Check
        if((num == 1 && gameManager.money < 10000) || 
        (num == 10 && gameManager.money < 90000)) return;
        gameManager.money -= num == 1 ? 10000 : 90000;

        //#.Draw Start Anim
        staffManager.StartDrawStaff(num);
        BackGroundForDontTouchOnemoreDraw.SetActive(true);
    }

    public void StaffDrawOpenBtn(int num){
        staffManager.OpenDrawStaff(num);
        if(num == 1){
            Invoke("StaffOneRecruitBtnSetActiveTrueAnim", 1f);
        }else{
            Invoke("StaffTenRecruitBtnSetActiveTrueAnim", 1f);
        }
    }

    public void StaffOneRecruitBtn(){
        staffManager.Recruit(1);
        staffOneRecruitBtn.transform.localScale = new Vector3(0,0,0);
        staffOneRecruitBtn.SetActive(false);
        BackGroundForDontTouchOnemoreDraw.SetActive(false);
    }
    public void StaffTenRecruitBtn(){
        staffManager.Recruit(10);
        staffTenRecruitBtn.transform.localScale = new Vector3(0,0,0);
        staffTenRecruitBtn.SetActive(false);
        BackGroundForDontTouchOnemoreDraw.SetActive(false);
    }

    //#.This code for staff recruit btn Dotween Animation
    void StaffOneRecruitBtnSetActiveTrueAnim(){
        staffOneRecruitBtn.SetActive(true);
        staffOneRecruitBtn.GetComponent<Button>().enabled = false;
        staffOneRecruitBtn.transform.DOScale(new Vector3(1,1,1), 2).SetEase(Ease.OutBack);
        Invoke("InvokeEnableOneRecruitBtn", 2f);
    }
    void StaffTenRecruitBtnSetActiveTrueAnim(){
        staffTenRecruitBtn.SetActive(true);
        staffTenRecruitBtn.GetComponent<Button>().enabled = false;
        staffTenRecruitBtn.transform.DOScale(new Vector3(1,1,1), 2).SetEase(Ease.OutBack);
        Invoke("InvokeEnableTenRecruitBtn", 2f);
    }

    void InvokeEnableOneRecruitBtn(){
        staffOneRecruitBtn.GetComponent<Button>().enabled = true;
    }
    void InvokeEnableTenRecruitBtn(){
        staffTenRecruitBtn.GetComponent<Button>().enabled = true;
    }

    //#.---------------------[Status]

    void StatusPanelUpdate(){
        statusGoodsPrice.text = (int)(goodsSystem.goodsPrice * skillManager.skillList[4]._functionDesc[skillManager.skillList[4]._level]) +"";
        statusDonationPrice.text = (int)gameManager.donationPrice * skillManager.skillList[13]._functionDesc[skillManager.skillList[13]._level] +"";
        statusGoodsSellTime.text =  5f * skillManager.skillList[1]._functionDesc[skillManager.skillList[1]._level]+"";
        statusGoodsSellCapacity.text = goodsSystem.goodsTransPortCapacity + skillManager.skillList[2]._functionDesc[skillManager.skillList[2]._level] +"";
        statusDesignMakeBtn.text = goodsSystem.maxCnt[0]+"";
        statusGoodsMakeBtn.text = goodsSystem.maxCnt[1]+"";
        statusCapacityMakeBtn.text = goodsSystem.maxCnt[2]+"";
    }



    //#.---------------------[Event]
    public void EventUpdate(EventVo curEvent){
        eventManager.MakeEventBtn(curEvent._id);
        eventTitle.text = curEvent._title;
        eventContent.text = curEvent._content;
        eventSet.transform.DOScale(new Vector3(1,1,1),0.4f);

        stopTimeWindow.SetActive(true);
    }

    //id->btnIndex : Event branch. 아이디 버튼별로 이벤트 분기. 
    public void EventBtn(int btn){
        switch(eventManager.curEvent._id){
            case 0:
                if(btn == 0){
                    EventBtnEffect("그렇지 다행히 군적금에 제대로 있네. 28일동안 남은 모든것...\n돈 + 10000");
                    gameManager.money += 10000;
                }
                else if(btn == 1){
                    EventBtnEffect("너무 든든하게 먹었나? 주식에 남은게 없네.\n돈 + 3000");
                    gameManager.money += 3000;
                }
                else if(btn == 2){
                    EventBtnEffect("X트코인으로 생긴 빚이 1억 2천이라고 이 XXX끼야!!\n돈 = 0");
                    gameManager.money = 0;
                }
                break;
            case 1:
                if(btn == 0){
                    EventBtnEffect("후 잘 따돌린 것 같다. 더 이상 이상한 꿀꿀소리는 들리지 않는다... 근데 대체 누구지?");
                }else if(btn ==1){
                    EventBtnEffect("놀랍게도 문을 두드린 사람은 꽃핀누나였다! 또 한번 큰 은총을 받았다... 근데 대체 그 소리는 뭐였지?\n돈 + 100000");
                    gameManager.money += 100000;
                }
                break;
            case 2:
                if(btn == 0){
                    EventBtnEffect("내가 발전기 실수를 할리가 없지. 탬탬버린도 아니고 \n발전기를 무사히 고쳤습니다.");
                }else if(btn ==1){
                    EventBtnEffect("아 진짜 갑자기 옆에서 튀어나와서 실수한거라니까!\n굿즈 필요 터치 수 + 1");;
                    goodsSystem.maxCnt[1] += 1;
                }else if(btn ==2){
                    EventBtnEffect("발전기는 망가졌지만 아예 새로운 발전기를 디자인했습니다!\n굿즈 필요 터치수 -1");
                    goodsSystem.maxCnt[1] -= 1;
                }
                break;
            case 3:
                if(btn == 0){
                    EventBtnEffect("지뿌 콘텐츠는 역시 성능 확실하구만! 몸은 박살났지만 말이야...\n시청자수 + 50\n굿즈 필요 터치 수 + 2");
                    goodsSystem.maxCnt[1] += 2;
                    gameManager.viwer += 50;
                }else if(btn ==1){
                    EventBtnEffect("후... 뿌요를 위해 절대 그런일을 할 수는 없어... 절대 내가 아파서 그런게 아니야.\n아니라면 아닌거야");
                }
                break;

            case 4:
                if(btn == 0){
                    EventBtnEffect("서로 노려보던 둘은 다음날부터 같이 방송을 하기 시작했다. 둘은 서로의 가능성을 보고 싸우기보다 타협을 한 것이다! 이 조합은 사기가 아닌가? 코렛샤 컴퍼니가 코요코요 컴퍼니가 되는 순간을 나는 목격했다.\n 시청자수 + 50");
                    gameManager.viwer += 50;
                }else if(btn ==1){
                    EventBtnEffect("왜 이렇게 사이가 안좋 아아아악! 뿌요야!! 그만 좀 물라고 진짜!!!");
                }
                break;
            case 5:
                if(btn == 0){
                    EventBtnEffect("지원금을 통해 반탬탬파는 급격히 몸집을 불려 밀감 컴퍼니를 향해 방해공작을 펼쳤습니다. 하지만 배신자로 인하여 빠르게 진압 됐으며 대부분이 처단 당했습니다.\n지원금 - 100000");
                    gameManager.money -= 100000;
                }else if(btn ==1){
                    EventBtnEffect("속보 - 신원불명의 밀고자? 밀감 컴퍼니 CEO 탬탬버린 회사 자금을 횡령한 것으로 드러나...\n해당 자금은 현재 모게임사로 흘러들어갔으며 이에 그녀는 해당 게임사로부터 적우의 칭호를 받은 것으로 밝혀졌다. 현재까지 발생한 피해액만 340억으로 알려져 이에 투자자들은 극심한 분노를 터트리고 있다.\n주식가격 -40%");
                    int milgamStockPrice = (int)(stockManager.mainStock.GetComponent<StockItem>().GetStockPrice() * 0.6f);
                    stockManager.mainStock.GetComponent<StockItem>().SetStockPrice(milgamStockPrice);
                }
                break;
            case 6:
                if(btn == 0){
                    EventBtnEffect("배상금으로 그분의 분노를 해소합니다.\n배상금 -500000");
                    gameManager.money -= 500000;
                }else if(btn ==1){
                    EventBtnEffect("주식으로 그분의 분노를 해소합니다.\n보유 밀감 컴퍼니 주식 20% 양도");
                    stockManager.mainStock.GetComponent<StockItem>().SetMyStock((int)(stockManager.mainStock.GetComponent<StockItem>().myStock * 8 /10));
                }else if(btn == 2){
                    EventBtnEffect("굿즈 공장을 개박살을 냅니다. 굿즈 공장에 모든 생산 기계들이 효율이 떨어집니다.\n생산 기계 필요 터치 수 50% 증가");//2배도 ㄱㅊ은듯
                    for(int i =0; i<3; i++){
                        goodsSystem.maxCnt[i] += (int)(goodsSystem.maxCnt[i] / 0.5f);
                    }
                }
                break;
            case 7:
                if(btn == 0){
                    EventBtnEffect("역시 그 모자의 명성과 업적 때문이었을까요? 상상이상의 거액을 투자 받습니다.\n돈 + 700000");
                    gameManager.money += 700000;
                }
                break;

            case 8:
                if(btn == 0){
                    EventBtnEffect("설마 그걸 보고도 당신은 이것을 고른 걸까요? 당신은 미친게 분명합니다. 일부 투자자들은 당신에게 실망해 투자금을 돌려달라합니다.\n돈 - 300000");
                    gameManager.money -= gameManager.money > 300000 ? 300000 : gameManager.money;
                }else if(btn ==1){
                    EventBtnEffect("평행세계의 당신이 보낸 시그널을 믿은 당신은 도전하지 않았습니다. 하지만 조금 아쉽네요... 설마 그 돈으로 실패를 할 수 있을까요?");
                }
                break;
            case 9:
                if(btn == 0){
                    EventBtnEffect("지누님! 지누님. 지누님? 지...누..님..? 지누가 누구..?\n수 많은 시청자들의 꿈, 희망, 추억이 사라졌습니다. 하지만 더 많은 도네와 참여율로 방송은 뜨거워졌습니다.\n시청자수 - 100\n도네가격 +300");
                    gameManager.viwer -= gameManager.viwer >100 ? 100 : gameManager.viwer;
                    gameManager.donationPrice +=300;
                }else if(btn ==1){
                    EventBtnEffect("이곳은 도박이 없는 클린방입니다. 시청자들은 아쉬워하지만 그들은 꿈, 희망, 추억을 지킬 수 있었습니다.\n시청자수 + 30");
                    gameManager.viwer += 30;
                }
                break;
            case 10:
                if(btn == 0){
                    EventBtnEffect("속보 - 김진우, 나나양 상반되는 해명?\n(전) 픽셀 CEO 김진우는 이는 오해에서 비롯한 악의적인 편집이라며 이런 허무맹랑한 주장은 법적으로 처리할 것이라 공식 입장을 표명했다. 하지만 같은 시기 우주대스타 컴퍼니 측에서는 아직 당사자간의 대화가 오가지 않았으니 언급을 자제해주길 바라며 심한 경우 사실적시 명예훼손으로 강경 대응할 것으로 밝히며 악성 단체의 주장을 부정하지 않고 있다. 이에 수많은 사람들의 관심이 쏠리고 있다.\n시청자 수 + 100");
                    gameManager.viwer += 100;
                }else if(btn ==1){
                    EventBtnEffect("속보 - 우주대스타 컴퍼니 나나양 CEO 의문의 습격?\n우주대스타 컴퍼니 나나양 CEO가 금일 에란겔에서 파밍을 하던 도중 의문의 습격을 받았다고 전해진다. 이에 평소 그녀는 수 많은 스캔들로 인하여 악성 단체가 많았으며, 단체 대다수가 코인 종목을 투자한 것으로 밝혀져 논란이 되고 있다.\n우주대스타 컴퍼니 주가 -15%");
                    stockManager.mainStock.GetComponent<StockItem>().stockPrice -= (int)(stockManager.mainStock.GetComponent<StockItem>().stockPrice  * 0.15f);
                }
                break;
            case 11:
                if(btn == 0){
                    EventBtnEffect("하지만 컴퓨터 이슈는 곧 해결되었고, 합방은 성공적으로 끝나게 된다.\n탬혐 증가에 따른 시청자 수 - 100\n탬혐으로 인한 도네가격 + 300");
                    gameManager.viwer -= 100;
                    gameManager.donationPrice += 300;
                }else if(btn ==1){
                    EventBtnEffect("그들을 막을수는 없었다! 젠장 이게 게임인가? 숟가락과 도구, 백정이 환상의 쇼를 보여줘도 게임은 속수무책이었다. 하지만 방송은 최고의 결과로 끝났다.\n도네가격 + 100\n조이 신뢰도 -40%");
                    gameManager.donationPrice += 100;
                }else if(btn ==2){
                    EventBtnEffect("데바데는 합방을 성공적으로 이끌었다! 하지만 어째서 귀가 들리지 않지?\n시청자 수 + 50");
                    gameManager.viwer += 50;
                }
                break;

            case 12:
                if(btn == 0){
                    EventBtnEffect("그들은 미친게 분명합니다. 무제한으로 굿즈, 도네기능을 무료로 뿌리고 있습니다.\n굿즈 가격 = 0\n도네 가격 = 0");
                    goodsSystem.goodsPrice = 0;
                    gameManager.donationPrice = 0;
                }
                break;
            case 13:
                if(btn == 0){
                    EventBtnEffect("시장은 한치 앞을 보기 힘들정도입니다. 일반주는 -80 ~ 50% 변동률을 가집니다.");
                    StockItem.volatilityLow = -80;
                    StockItem.volatilityHigh = 50;
                }
                break;
            case 14:
                if(btn == 0){
                    EventBtnEffect("원두컴퍼니가 무차별적으로 시장을 혼란스럽게 만들고 PIXEL을 사들이고 있습니다. 원두 컴퍼니가 주식을 매수합니다.\n보유 원두컴퍼니 주식 -30");
                    stockManager.mainStock.GetComponent<StockItem>().myStock -= stockManager.mainStock.GetComponent<StockItem>().myStock<=30 ? stockManager.mainStock.GetComponent<StockItem>().myStock : 30;
                }
                break;
            case 15:
                if(btn == 0){
                    EventBtnEffect("원두컴퍼니가 영혼을 끌어모아 매수를 시작합니다. 매 게이지마다 사는 주식수가 늘어납니다.\n보유 원두 컴퍼니 주식 -50");
                    stockManager.mainStock.GetComponent<StockItem>().myStock -= stockManager.mainStock.GetComponent<StockItem>().myStock<=50 ? stockManager.mainStock.GetComponent<StockItem>().myStock : 50;
                }
                break;
        }
        for(int i=0; i<3; i++){
            Destroy(eventManager.eventBtnPocket[i]);
        }
    }

    public void EventBtnEffect(string effect){
        eventEffect.transform.localScale = new Vector3(1, 1, 1);
        eventEffect.GetComponentInChildren<TextMeshProUGUI>().text = effect;
    }
    public void CloseEventBtnEffect(){
        eventSet.transform.localScale = new Vector3(0, 0, 0);
        eventEffect.transform.localScale = new Vector3(0, 0, 0);
        gameManager.isStopTime = false;
        gameManager.isStopUI = false;
        stopTimeWindow.SetActive(false);
    }

    //#.------------------[Talk]-------------
    public void SetTalkBackGround(bool isTalking){
        if(isTalking){
            if(talkBackGround.anchoredPosition.y < 0)
                talkBackGround.DOAnchorPos(new Vector2(0, 0), 0.2f).SetEase(Ease.OutQuad); //
        }
        else{
            if(talkBackGround.anchoredPosition.y == 0)
                talkBackGround.DOAnchorPos(new Vector2(0, -500), 0.2f).SetEase(Ease.OutQuad);
        }
    }

     public void StoryTalk(){
        // talkManager.curTalkActor = (int)TalkManager.Actor.지누; //Actor정하기
        talkManager.NextTalk();
        talkText.isStart = true;
        Talk();
    }


    public void Talk(){
        //#.Talk Set
        talkName.text = talkManager.GetName();
        talkText.SetMsg(talkManager.GetTalk());
        switch((int)talkManager.curTalkActor){
            case 0:
                talkName.color = new Color32(143, 86, 59, 255);
                break;
            case 1:
                talkName.color = new Color32(180, 180, 180, 255);
                break;
            case 2:
                talkName.color = new Color32(50, 50, 50, 255);
                break;
            case 3:
                talkName.color = new Color32(211, 47, 239, 255);
                break;
            case 4:
                talkName.color = new Color32(255, 218, 59, 255);
                break;
            case 5:
                talkName.color = new Color32(255, 150, 0, 255);
                break;
        }

        if(talkText.isEnd){
            //#.Restart Time & TalkBackGround Down
            SetTalkBackGround(false);
            
            if(!tutorialManager.isTutorialEnd){
                tutorialManager.NextTutorial();
            }
            if(!mainStoryManager.isColletStoryEnd && gameManager.day == 5){
                mainStoryManager.NextTalk();
            }
            if(!mainStoryManager.isTamX2StoryEnd && gameManager.day == 10){
                mainStoryManager.NextTalk();
            }
            if(!mainStoryManager.isNanayangStoryEnd && gameManager.day == 15){
                mainStoryManager.NextTalk();
            }
        }
        else{ //talkEnd아닐때만
            talkPortrait.sprite = talkManager.GetPortrait();//표정이 제일 마지막이어함
            SetTalkBackGround(true);
        }
    }
    public void TalkBtnClick(){
        if(talkText.isAnim){
            talkText.SetMsg(talkText.msgText.text);
        }else
            Talk();
    }

    public void TutorialSkipBtn(int i){
        if(i == 0){//No
            talkManager.curTalkActor = (int)TalkManager.Actor.지누; //Actor정하기
            Invoke("StoryTalk", 1f);
            tutorailSkipBtn.SetActive(false);
            tutorialNotSkipBtn.SetActive(false);
            gameManager.isStopUI = false;
            stopTimeWindow.SetActive(false);
        }else if(i == 1){//Yes
        tutorialManager.isTutorialEnd = true;
        tutorialManager.tutorialIndex = 18;
        gameManager.isStopTime = false;
        gameManager.isStopUI = false;
        stopTimeWindow.SetActive(false);
        talkManager.talkState[0] = 4;//튜토리얼 중 대사량
        talkManager.talkState[1] = 14;//튜토리얼 중 대사량
        talkManager.talkState[2] = 0;
        tutorailSkipBtn.SetActive(false);
        tutorialNotSkipBtn.SetActive(false);
        
        tutorialManager.GoodsDesignEnable();
        tutorialManager.GoodsMakeEnable();
        tutorialManager.GoodsPackingEnable();
        tutorialManager.GoodsTransportEnable();

        stockPanel.gameObject.SetActive(true);
        streamerPanel.gameObject.SetActive(true);
        staffPanel.gameObject.SetActive(true);
        informationPanel.gameObject.SetActive(true);
        }
    }

    //#.MainStory
    public void ColletStoryStart(){
        gameManager.isStopTime = true;
        gameManager.isStopUI = true;
        stopTimeWindow.SetActive(true);
        talkManager.curTalkActor = (int)TalkManager.Actor.지누; //Actor정하기
        Invoke("StoryTalk", 1f);
    }

    public void TamX2StoryStart(){
        gameManager.isStopTime = true;
        gameManager.isStopUI = true;
        stopTimeWindow.SetActive(true);
        talkManager.curTalkActor = TalkManager.Actor.탬탬버린; //Actor정하기
        Invoke("StoryTalk", 1f);
    }

    public void NanayangStoryStart(){
        gameManager.isStopTime = true;
        gameManager.isStopUI = true;
        stopTimeWindow.SetActive(true);
        talkManager.curTalkActor = (int)TalkManager.Actor.지누; //Actor정하기
        Invoke("StoryTalk", 1f);
    }

    public void Ending(bool isClear){
        fadeImg.gameObject.SetActive(true);
        if(isClear){
            fadeImg.color = new Color32(255, 255, 255, 0);
        }
        else {
            fadeImg.color = new Color32(0, 0, 0, 0);
        }

        fadeImg.DOFade(1, 1.5f).SetEase(Ease.InQuad);
    }

    public void BankruptcyScale(){
        badEnd.transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutBounce);
    }

    //#.-------------------------[Alert]--------------------

    public void AlertPanelMove(){
        if(alertSet.anchoredPosition.y > -80){
            alertSet.DOAnchorPos(new Vector2(0, -80), 0.4f).SetEase(Ease.OutQuad); //
        }else if(alertSet.anchoredPosition.y == -80){
            alertSet.DOAnchorPos(new Vector2(0, 200), 0.4f).SetEase(Ease.OutQuad); //
        }
    }
}
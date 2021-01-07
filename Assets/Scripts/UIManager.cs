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
    public StreamerSkillManager skillManager;
    public StaffManager staffManager;
    public EventManager eventManager;
    public SoundManager soundManager;

	public Image dateImage;
	public Sprite[] guageImage;
	public GameObject battery;
	public TextMeshProUGUI dateText;
	public TextMeshProUGUI moneyText;
	public TextMeshProUGUI goodsText;
	public TextMeshProUGUI viwerText;

	public RectTransform stockPanel;
	public RectTransform streamerPanel;
    public RectTransform staffPanel;
    public RectTransform informationPanel;

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
    public Image SkillDescImg;
    public TextMeshProUGUI skillDescName;
    public TextMeshProUGUI skillDescLevel;
    public TextMeshProUGUI skillDescFunc;
    public TextMeshProUGUI skillDescIntroduce;
    public TextMeshProUGUI skillDescGold;
    public StreamerSkillVo selectedSkill;

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

    public GameObject BackGroundForDontTouchOnemoreDraw;
    public GameObject staffOneRecruitBtn;
    public GameObject staffTenRecruitBtn;

    public RectTransform eventSet;
    public TextMeshProUGUI eventTitle;
    public TextMeshProUGUI eventContent;
    public GameObject eventEffect;
    public GameObject stopTimeWindow;

    

    private void Start(){
        //#. SkillTree Icon Init
        skillUIUpdate();
    }
	private void LateUpdate() {
        if(GameManager.Instance.isStopTime) return;

        //#0. 
		dateImage.fillAmount = gameManager.time/20f;
		dateText.text = gameManager.day+"" ;	

        //#.Money UI	
		if(gameManager.money > 100000) moneyText.text = string.Format("{0:n0}", gameManager.money/1000)+"k";
		else moneyText.text = string.Format("{0:n0}", gameManager.money);

        //#.Goods UI
		if(gameManager.goods > 100000) goodsText.text = gameManager.goods/1000 +"k/" + gameManager.maxCapacity/1000 +"k";
		else goodsText.text = gameManager.goods + "/" + gameManager.maxCapacity;



        //#.Viwer UI
		if(gameManager.viwer > 100000) viwerText.text = string.Format("{0:n0}", gameManager.viwer/1000)+"k";
		else viwerText.text = string.Format("{0:n0}", gameManager.viwer);

		battery.gameObject.GetComponent<Image>().sprite = guageImage[5 - gameManager.guage]; // battery change

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

        //#.StaffCost and Staff Max Capacity
        staffCostText.text = string.Format("{0:n0}", gameManager.staffCost);
        maxStaffCapasityText.text = gameManager.workStaff +"/"+ gameManager.maxCapacity /50;



	}

//------------------------------------------------[하단 Panle Btn]
	public void PanelBtn(string panelName){
		if(panelName == "StockPanel"){
			if(stockPanel.localPosition.y == -878){
				stockPanel.DOLocalMoveY(0, 0.6f).SetEase(Ease.OutBack);

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
				streamerPanel.DOLocalMoveY(0, 0.6f).SetEase(Ease.OutBack);

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
				staffPanel.DOLocalMoveY(0, 0.6f).SetEase(Ease.OutBack);

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
				informationPanel.DOLocalMoveY(0, 0.6f).SetEase(Ease.OutBack);

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
        selectedSkill = skillManager.GetSkill(id);
        SkillDescImg.sprite = selectedSkill._icon;
        skillDescName.text = selectedSkill._skillName;
        skillDescLevel.text = "LV." + selectedSkill._level;
        skillDescFunc.text = selectedSkill._function[selectedSkill._level];
        skillDescIntroduce.text = selectedSkill._skillIntroduce;
        skillDescGold.text = "필요골드" + selectedSkill._nextLevelGold[selectedSkill._level];
        
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
        if(selectedSkill._level <5){
            gameManager.money -= selectedSkill._nextLevelGold[selectedSkill._level];
            skillManager.SkillLevelUp(selectedSkill._id); // level++;
            skillUIUpdate(); 

            if(selectedSkill._level >=5){
                skillDescLevel.text = "LV.MAX";
                skillDescGold.text = "최대 레벨입니다.";
                skillDescFunc.text = selectedSkill._function[5];
            }else{
                skillDescLevel.text = "LV." + selectedSkill._level;
                skillDescGold.text = "필요골드" + selectedSkill._nextLevelGold[selectedSkill._level];
                skillDescFunc.text = selectedSkill._function[selectedSkill._level];
            }
        }
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
        if(gameManager.maxCapacity/50 <= gameManager.workStaff) return;
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
        gameManager.staffCost = totalStaffCost;
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
        gameManager.staffCost = totalStaffCost;
        gameManager.workStaff = totalWorkStaff;
    }

    public void StaffDrawBtn(int num){
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
        staffOneRecruitBtn.transform.DOScale(new Vector3(1,1,1), 1).SetEase(Ease.OutBack);
    }
    void StaffTenRecruitBtnSetActiveTrueAnim(){
        staffTenRecruitBtn.SetActive(true);
        staffTenRecruitBtn.transform.DOScale(new Vector3(1,1,1), 1).SetEase(Ease.OutBack);
    }

    //#.---------------------[Status]





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
                    EventBtnEffect("다행히 도망쳐 돈을 내지 않습니다.");
                }
                break;
            case 1:
                if(btn == 0){
                    Debug.Log("1-0");
                }else if(btn ==1){
                    Debug.Log("1-1");
                }
                break;
            case 2:
                if(btn == 0){
                    Debug.Log("2-0");
                }else if(btn ==1){
                    Debug.Log("2-1");
                }else if(btn ==2){
                    Debug.Log("2-2");
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
        stopTimeWindow.SetActive(false);
    }
}
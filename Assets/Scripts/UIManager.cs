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
    public StreamerSkillVo selectedSkill; //

    public GameObject staffGetBtn;
    public GameObject staffSetBtn;
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

    private void Start() {

        //#. SkillTree Icon Init
        skillUIUpdate();
    }
	private void LateUpdate() {

        //#0. 
		dateImage.fillAmount = gameManager.time/20f;
		dateText.text = gameManager.day+"" ;	

        //#.Money UI	
		if(gameManager.money > 100000) moneyText.text = string.Format("{0:n0}", gameManager.money/1000)+"k";
		else moneyText.text = string.Format("{0:n0}", gameManager.money);

        //#.Goods UI
		if(gameManager.goods > 100000) goodsText.text = gameManager.goods/1000 +"k/" + goodsSystem.maxGoodsCapacity/1000 +"k";
		else goodsText.text = gameManager.goods + "/" + goodsSystem.maxGoodsCapacity;

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
                    streamerPanel.DOLocalMoveY(-878, 0.4f).SetEase(Ease.InBack);
                }
			}else if(staffPanel.localPosition.y == 0){
				staffPanel.DOLocalMoveY(-878, 0.4f).SetEase(Ease.InBack);
			}
		}
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
            case "GetStaffPanel":

                break;
        }
    }

    public void StaffIn(string rank){
        switch(rank){
            case "S":
                break;
            case "A":
                break;
            case "B":
                break;
            case "C":
                break;
        }
    }

    public void StaffOut(string rank){
        switch(rank){
            case "S":
                break;
            case "A":
                break;
            case "B":
                break;
            case "C":
                break;
        }
    }

}

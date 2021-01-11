﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public UIManager uiManager;
    public TalkManager talkManager;
    public GoodsSystem goodsManager;
    public StaffManager staffManager;
    public bool isTutorialEnd; //튜토를 했나?
    public int tutorialIndex;
    public float timer1;
    public float timer2;
    public bool isStartedNext;
    private void Update() {
        if(isTutorialEnd) 
            return;
        //case 0:은 Start Tutorial 지누 대화.
        switch(tutorialIndex){
            case 1: //화자 : 아리스톨 : 0 :사장님 드디어 나오셨군요!
                timer1 += Time.deltaTime;

                if(timer1 > 0.6f && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 = 0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 2://화자 지누 : 1 :아리스톨! 진짜 오랜만이다...~
                timer2 += Time.deltaTime;

                if(timer2 > 0.6f && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.지누;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 3://화자 : 아리스톨 : 1 :사장님 갔다오신 동안에
                timer1 += Time.deltaTime;

                if(timer1 > 0.6f && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 = 0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 4://화자 지누 : 2 :망했다는 것치곤 배경이나쁘지 않은데
                 timer2 += Time.deltaTime;

                if(timer2 > 0.6f && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.지누;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 5://화자 : 아리스톨 : 2 :제작자가 국가의 납치를 당해서
                timer1 += Time.deltaTime;

                if(timer1 > 0.6f && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 = 0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 6://화자 : 아리스톨 : 3 : 여기는 굿즈 공장입니다.
                if((int)GameManager.Instance.curType == 0 && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 = 0;
                    timer2 = 0;
                    Invoke("InvokeTutorialTalk", 1f);
                    isStartedNext = true;
                }
                break;
            case 7://화자 : 아리스톨 : 4 : 잘하셨어요. 우측 상단에
                if(goodsManager.goodsDesignBonusCnt > 0  && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 8://화자 : 아리스톨 : 5 : 개발 잘하셨어요
                if(GameManager.Instance.goods > 0 && !isStartedNext){//굿즈 생산
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 9://화자 : 아리스톨 : 6 : 저장공간도 늘었네요 -> 주식패널 눌러보세요
                if(GameManager.Instance.maxCapacity > 10 && !isStartedNext){//굿즈 생산
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                    uiManager.stockPanel.gameObject.SetActive(true);
                }
                break;
            case 10://화자 : 아리스톨 : 7 : 주식패널 눌렀고 -> 여러 주식들이 보이죠?
                if(uiManager.stockPanel.localPosition.y == 0 && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 11://화자 : 아리스톨 : 8 : 스트리머 패널 선택 -> 여기는 소속 스트리머 
                if(uiManager.streamerPanel.localPosition.y == 0 && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 12://화자 : 아리스톨 : 9 : 스태프 패널 선택 -> 여기는 스태프를 고용하고 배치 
                if(uiManager.staffPanel.localPosition.y == 0 && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 13://화자 : 아리스톨 : 10 : 스태프 뽑기 창 -> 
                if(uiManager.staffGet.activeSelf == true && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                    GameManager.Instance.money += 10000; // 스태프 뽑기용 돈 주기
                }
                break;
            case 14://화자 : 아리스톨 : 11 : 스태프 뽑기 -> 게임 스타트
                if(GameManager.Instance.money < 10000 && !isStartedNext && !staffManager.drawingTime){ //뽑기에 썼기를 바라며
                    talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 15://화자 지누 : 3 : 설명 진짜 기네요
                 timer1 += Time.deltaTime;

                if(timer1 > 0.6f && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.지누;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;

            case 16://화자 금사향 : 0 : 내가 있으니까 걱정하지마
                 timer2 += Time.deltaTime;

                if(timer2 > 0.6f && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.금사향;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
            case 17://화자 지누 : 4 : 오우 Z같은거 봐
                 timer1 += Time.deltaTime;

                if(timer1 > 0.6f && !isStartedNext){
                    talkManager.curTalkActor = TalkManager.Actor.지누;
                    timer1 =0;
                    timer2 = 0;
                    uiManager.TutorialTalk();
                    isStartedNext = true;
                }
                break;
        }
    }
    public void NextTutorial(){
        tutorialIndex++;
        isStartedNext = false;
    }

    public void InvokeTutorialTalk(){
        uiManager.TutorialTalk();
    }

}

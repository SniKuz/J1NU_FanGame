using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStoryManager : MonoBehaviour
{
    public UIManager uiManager;
    public TalkManager talkManager;

    public GameObject colletPanel;
    public GameObject colletStreaming;
    public GameObject colletBossRoom;
    public GameObject tamx2Panel;
    public GameObject tamx2Streaming;
    public GameObject tamx2BossRoom;
    public GameObject nanayangPanel;
    public GameObject nanayangStreaming;
    public GameObject nanayangBossRoom;

    public bool isColletStoryStart;
    public bool isColletStoryEnd;
    public bool isTamX2StoryStart;
    public bool isTamX2StoryEnd;
    public bool isNanayangtoryStart;
    public bool isNanayangStoryEnd;
    public int storyIndex;

    public float timer1;
    public float timer2;
    public bool isStartedNext;

    private void Update() {
        if(!isColletStoryEnd){
            switch(storyIndex){
                case 1:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.코렛트;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 2:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 3:// 1
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.코렛트;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 4:// 7
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 5:// 2
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.코렛트;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 6:// 8
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 7:// 3
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.코렛트;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 8:// 9
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 9:// 4
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.코렛트;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 10:// 12
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 11:// 1
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.금사향;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 12:// 10
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 13:// 13
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 14:// 11
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;

                        isColletStoryEnd = true;
                        GameManager.Instance.isStopTime = false;
                        GameManager.Instance.isStopUI = false;
                        uiManager.stopTimeWindow.SetActive(false);
                        storyIndex = 0; //다음 스토리에 쓸 수 있게
                    }
                    break;
            }
        }else if(!isTamX2StoryEnd){

        }else if(!isNanayangStoryEnd){

        }
    }

    public void NextTalk(){
        storyIndex++;
        isStartedNext = false;
    }

    public void InvokeTutorialTalk(){
        uiManager.StoryTalk();
    }
}

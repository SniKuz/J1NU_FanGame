using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStoryManager : MonoBehaviour
{
    public GameManager gameManager;
    public UIManager uiManager;
    public TalkManager talkManager;
    public TextTypeEffect talkText;

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

                    if(timer2 > 0.6f  && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 3:// 1
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f  && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.코렛트;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 4:// 7
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f  && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 5:// 2
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f  && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.코렛트;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 6:// 8
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f  && !isStartedNext){
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

                    if(timer2 > 0.6f&& !isStartedNext){
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
                    }
                    break;
                case 15:
                    if(talkText.isEnd){
                        isColletStoryEnd = true;
                        gameManager.isStopTime = false;
                        gameManager.isStopUI = false;
                        uiManager.stopTimeWindow.SetActive(false);
                        storyIndex = 0; //다음 스토리에 쓸 수 있게

                        colletBossRoom.SetActive(true);
                        colletPanel.SetActive(true);
                        colletStreaming.SetActive(true);
                    }
                    break;
            }

        }else if(!isTamX2StoryEnd){
            switch(storyIndex){
                case 1:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 2:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 3:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 4:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 5:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 6:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 7:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 8:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 9:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 10:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 11:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 12:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 13:
                    timer1 += Time.deltaTime;

                    if(timer1 >0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.코렛트;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 14:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 15:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 16:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.금사향;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 17:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 18:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.금사향;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 19:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 20:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 21:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 22:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 23:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 24:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 25:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 26:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 27:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 28:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.금사향;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 29:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 30:
                    if(talkText.isEnd){
                        isTamX2StoryEnd= true;
                        gameManager.isStopTime = false;
                        gameManager.isStopUI = false;
                        uiManager.stopTimeWindow.SetActive(false);
                        storyIndex = 0; //다음 스토리에 쓸 수 있게

                        tamx2BossRoom.SetActive(true);
                        tamx2Panel.SetActive(true);
                        tamx2Streaming.SetActive(true);
                    }
                    break;
            }

        }else if(!isNanayangStoryEnd){
            switch(storyIndex){
                 case 1:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.나나양;
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
                case 3:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.나나양;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 4:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 5:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.나나양;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 6:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 7:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.나나양;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 8:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 9:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.나나양;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 10:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 11:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f&& !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.코렛트;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 12:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.탬탬버린;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 13:
                    timer1 += Time.deltaTime;

                    if(timer1 >0.6f&& !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 14:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 15:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f&& !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.지누;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 16:
                    timer2 += Time.deltaTime;

                    if(timer2 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.아리스톨;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 17:
                    timer1 += Time.deltaTime;

                    if(timer1 > 0.6f && !isStartedNext){
                        talkManager.curTalkActor = TalkManager.Actor.나나양;
                        timer1 = 0;
                        timer2 = 0;
                        uiManager.StoryTalk();
                        isStartedNext = true;
                    }
                    break;
                case 18:
                    if(talkText.isEnd){
                        isNanayangStoryEnd= true;
                        gameManager.isStopTime = false;
                        gameManager.isStopUI = false;
                        uiManager.stopTimeWindow.SetActive(false);
                        storyIndex = 0; //다음 스토리에 쓸 수 있게

                        nanayangBossRoom.SetActive(true);
                        nanayangPanel.SetActive(true);
                        nanayangStreaming.SetActive(true);
                    }
                    break;
            }
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

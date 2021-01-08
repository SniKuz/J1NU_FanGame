using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public enum Actor{지누, 아스톨프, 금사향, 코렛트, 탬탬버린, 나나양} //enum은 static
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    public Actor curTalkActor;
    public int[] talkState;
    public int curTalkIndex;

    private void Awake() {
        talkState = new int[4] {-1, -1, -1, -1};
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();

        GenerateData();
    }

    void GenerateData(){

        //#.Tutorial Talk enum*1000 = 인물
        talkData.Add(0000 + 0, new string[]{   "안녕?:0",
                                            "이곳은 처음이니?:0",
                                            "한번 둘러보도록 해:0"});//뒤에 :0은 표정
        talkData.Add(0000 + 1, new string[]{"끄아아앙:0,",
                                            "으아?:1"});
        
        talkData.Add(1000 + 0, new string[]{"ㄷㄷㄷㅈ:0,",
                                            "으아?:1"});
        talkData.Add(1000 + 1, new string[]{"끄아아앙:0,",
                                            "으아?:1"});
        
        talkData.Add(2000 + 0, new string[]{"ㄷㄷㄷㅈ:0,",
                                            "으아?:1"});
        talkData.Add(2000 + 1, new string[]{"끄아아앙:0,",
                                            "으아?:1"});
        //#.EventTalk




        //#.Portrait Data
        //#.0: 지누, 1000:아스톨프, 2000:금사향, 3000:코렛트, 4000:탬탬, 5000:나나양
        //#.0:Default 1:Speak, 2:Happy, 3:Sad, 4:Angry
        portraitData.Add(0000 + 0, portraitArr[0]);
        // portraitData.Add(1000 + 1, portraitArr[0]);
        // portraitData.Add(1000 + 2, portraitArr[0]);
    }

    public void NextTalk(){
        talkState[(int)curTalkActor]++;
        curTalkIndex = -1;
    }

    public string GetName(){
        return curTalkActor.ToString();
    }

    public string GetTalk(){
        int id = (int)curTalkActor*1000 + talkState[(int)curTalkActor];
        curTalkIndex++;

        if (curTalkIndex == talkData[id].Length)
            return null;
        else   
            return talkData[id][curTalkIndex];
    }

    public Sprite GetPortrait(){
        int id = (int)curTalkActor*1000 + talkState[(int)curTalkActor];
        string curTalkStr = talkData[id][curTalkIndex];
        if(curTalkStr == null)
            return null;
        else{
            int portraitIndex = int.Parse(curTalkStr.Split(':')[1]); //표정 :0
        return portraitData[portraitIndex];
        }
    }
}

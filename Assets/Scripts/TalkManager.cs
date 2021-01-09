using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public enum Actor{지누, 아리스톨, 금사향, 코렛트, 탬탬버린, 나나양} //enum은 static
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
        // Actor + 대사
        //#0.: 지누, 1000:아스톨프, 2000:금사향, 3000:코렛트, 4000:탬탬, 5000:나나양
        //#1.: Tutorial Talk
        talkData.Add(0000 + 0, new string[]{   "I'm Back:0",
                                                "드디어... 드디어 집에 돌아왔다.:0",
                                                "아니 근데 28일만에 돌아왔는데 왜 아무도 연락이 없어?:0"});//뒤에 :0은 표정

        talkData.Add(1000 + 0, new string[]{    "사장님 드디어 나오셨군요!:0",
                                                "지금 아주 난장판입니다!:0"});

        talkData.Add(0000 + 1, new string[]{    "아리스톨! 진짜 오랜만이다. 근데 왜 그렇게 급하게, 어라?:0",
                                                "[속보] 픽셀 네트워크 CEO J1NU 의문의 실종. 28일째 연락이 안돼:0",
                                                "[탬탬버린] 나는 내가 귀여운거 알고있어 발언...:0",
                                                "[코렛트] 그동안 감사했습니다...:0",
                                                "[THE_PIXEL] THE_PIXEL 회사 분할 및 악재의 연속...:0",
                                                "[원두컴퍼니] SPAC계의 신흥강자 원두컴퍼니 THE_PIXEL 목표 발언 논란...:0",
                                                "대 박:0"});   
                                  
        talkData.Add(1000 + 1, new string[]{    "사장님 갔다오신 동안에 저희 회사 망했습니다...:0",
                                                "지금 소속 스트리머 다 나가고 회사는 합병당하고 빚까지...:0",
                                                "남은건 굿즈를 만들 수 있는 공장 하나와 스트리밍룸 1개밖에 남지 않았네요..:0"});

        talkData.Add(0000 + 2, new string[]{    "망했다는 것치곤 배경이나 방이 나쁘지 않은데?:0"});

        talkData.Add(1000 + 2, new string[]{    "제작자가 원래는 단계에 따라 폐허, 반지하, 카페배경, 도시야경 순으로 그릴려고 했는데...:0",
                                                "제작자도 국가의 납치를 당해서...:0",
                                                "tmi는 그만하고 이제부터 제가 어떻게 돈을 벌고 다시 일어설지 말씀드리죠.:0",
                                                "우선 왼쪽 방에 가볼까요?:0"});

        talkData.Add(1000 + 3, new string[]{    "여기는 굿즈 공장입니다.:0",
                                                "왼쪽부터 순서대로 굿즈를 디자인, 개발, 저장공간, 판매하는 기계들이죠.:0",
                                                "대화하시다 기계가 움직여도 놀라지마세요.:0",
                                                "회사가 망했는데도 빨간 딱지가 안붙은 것들이니까요! 하하:0",
                                                "디자인은 굿즈를 사고싶게 디자인해서 프리미엄 굿즈로 만듭니다!.:0",
                                                "위에 ON/OFF 버튼을 눌러서 2배 보너스를 받을 수 있어요.:0",
                                                "계속 켜놓아도 돈은 안주고 디자인 가동시간만 떨어지니 굿즈를 팔 때만 켜놓으면 좋겠네요:0",
                                                "한번 굿즈를 디자인해보죠. 디자인 기계를 터치하거나 키보드 Q를 눌러서 만들어보세요.:0"});

        talkData.Add(1000 + 4, new string[]{    "역시 사장님! 우측 상단의 숫자가 올라간게 보이죠?:0",
                                                "저기에서 가지고있는 자원들을 확인할 수 있어요.:0",
                                                "위에서부터 돈, 굿즈, 시청자, 굿즈 보너스입니다.:0",
                                                "그럼 바로 다음으로 가볼까요?:0",
                                                "한번 굿즈를 만들어보죠. 굿즈 기계를 터치하거나 W를 눌러서 만들어보세요.:0"});

        talkData.Add(1000 + 5, new string[]{    "굿즈가 늘었습니다!:0",
                                                "이 굿즈는 저장공간에 저장됩니다.:0",
                                                "저장공간도 클릭을 통해 확장할 수 있습니다.:0",
                                                "저장공간을 클릭하거나 E를 눌러서 만들면 됩니다.:0",
                                                "한번 저장공간을 확장해보죠.:0"});
    
        talkData.Add(1000 + 6, new string[]{    "저장공간도 늘었네요.:0",
                                                "이후에 나오는 스태프 고용 최대 인원도 이곳에서 늘릴 수 있습니다.:0",
                                                "다음 기계는 굿즈 판매 기계입니다.:0",
                                                "누르면 자동으로 가지고 있는 굿즈를 팔 수 있습니다.:0",
                                                "파는 개수, 속도는 추후에 증가시킬 수 있습니다.:0",
                                                "이걸로 굿즈 공장의 설명은 끝입니다. 이제 나머지 설명을 빠르게 가볼까요?:0",
                                                "굿즈 공장을 제외하고 나머지 2개의 방은 큰 기능이 없습니다.:0",
                                                "사장님의 주요 업무는 모두 하단 패널에서 진행되죠.:0",
                                                "먼저 주식 패널을 눌러볼까요?:0"});            

        talkData.Add(1000 + 7, new string[]{    "저장공간도 늘었네요.:0",
                                                "이후에 나오는 스태프 고용 최대 인원도 이곳에서 늘릴 수 있습니다.:0",
                                                "다음 기계는 굿즈 판매 기계입니다.:0",
                                                "누르면 자동으로 가지고 있는 굿즈를 팔 수 있습니다.:0",
                                                "파는 개수, 속도는 추후에 증가시킬 수 있습니다.:0",
                                                "이걸로 굿즈 공장의 설명은 끝입니다. 이제 나머지 설명을 빠르게 가볼까요?:0",
                                                "굿즈 공장을 제외하고 나머지 2개의 방은 큰 기능이 없습니다.:0",
                                                "사장님의 주요 업무는 모두 하단 패널에서 진행되죠.:0",
                                                "먼저 주식 패널을 눌러볼까요?:0"});          
        //#.EventTalk




        //#.Portrait Data
        //#.0: 지누, 1000:아스톨프, 2000:금사향, 3000:코렛트, 4000:탬탬, 5000:나나양
        //#.0:Default 1:Speak, 2:Happy, 3:Sad, 4:Angry
        portraitData.Add(0000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 0, portraitArr[1]);
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

        if (curTalkIndex == talkData[id].Length){
            return null;
        }
        else   
            return talkData[id][curTalkIndex].Split(':')[0];
    }

    public Sprite GetPortrait(){
        int id = (int)curTalkActor * 1000 + talkState[(int)curTalkActor];
        if(curTalkIndex == talkData[id].Length){
            return null;
        }
        else{
            string curTalkStr = talkData[id][curTalkIndex];
            int portraitIndex = (int)curTalkActor * 1000 + int.Parse(curTalkStr.Split(':')[1]); //표정 :0
            return portraitData[portraitIndex];
        }
    }
}

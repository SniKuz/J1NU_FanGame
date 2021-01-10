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
        //#.0: 지누, 1000:아스톨프, 2000:금사향, 3000:코렛트, 4000:탬탬, 5000:나나양
        //#.0:Default 1:Sad, 2:Angry, 3:Smile, 4:Sneer
        //#1.: Tutorial Talk
        talkData.Add(0000 + 0, new string[]{   "I'm Back:0",
                                                "드디어... 드디어 집에 돌아왔다.:1",
                                                "아니 근데 28일만에 돌아왔는데 왜 아무도 연락이 없어?:2"});//뒤에 :0은 표정

        talkData.Add(1000 + 0, new string[]{    "사장님 드디어 나오셨군요!:3",
                                                "지금 아주 난장판입니다!:1"});

        talkData.Add(0000 + 1, new string[]{    "아리스톨씨! 진짜 오랜만이에요. 근데 왜 그렇게 급하게, 어라?:3",
                                                "[속보] 픽셀 네트워크 CEO J1NU 의문의 실종. 28일째 연락이 안돼:0",
                                                "[탬탬버린] 나는 내가 귀여운거 알고있어 발언...:4",
                                                "[코렛트] 그동안 감사했습니다...:0",
                                                "[THE_PIXEL] THE_PIXEL 회사 분할 및 악재의 연속...:0",
                                                "[원두컴퍼니] SPAC계의 신흥강자 원두컴퍼니 THE_PIXEL 목표 발언 논란...:2",
                                                "대 박:3"});   
                                  
        talkData.Add(1000 + 1, new string[]{    "사장님 갔다오신 동안에 저희 회사 망했습니다...:1",
                                                "지금 소속 스트리머 대부분 나가고 회사는 합병당하고 빚까지...:1",
                                                "남은건 굿즈를 만들 수 있는 공장 하나와 스트리밍룸 1개밖에 남지 않았네요..:0"});

        talkData.Add(0000 + 2, new string[]{    "망했다는 것치곤 배경이나 방이 나쁘지 않은데요?:0"});

        talkData.Add(1000 + 2, new string[]{    "원래는 단계별로 배경이 바뀌는건데...:0",
                                                "제작자도 국가의 납치를 당해서...:1",
                                                "tmi는 그만하고 이제부터 지금부터의 목표와 해야할 것을 말씀드리죠.:3",
                                                "역시 목표는 다시 PIXEL을 성장시키는 것입니다. 저 월급 주셔야죠.:0",
                                                "돈을 버는 방법은 크게 3가지가 있습니다. 굿즈 판매, 도네이션 그리고 주식이죠.:3",
                                                "우선 왼쪽 방에 가볼까요?:3"});

        talkData.Add(1000 + 3, new string[]{    "여기는 굿즈 공장입니다.:0",
                                                "왼쪽부터 순서대로 굿즈를 디자인, 개발, 저장공간, 판매하는 기계들이죠.:0",
                                                "대화하시다 기계가 움직여도 놀라지마세요.:3",
                                                "회사가 망했는데도 빨간 딱지가 안붙은 것들이니까요! 하하:3",
                                                "디자인은 굿즈를 사고싶게 디자인해서 프리미엄 굿즈로 만듭니다!.:0",
                                                "위에 ON/OFF 버튼을 눌러서 2배 보너스를 받을 수 있어요.:0",
                                                "계속 켜놓아도 돈은 안주고 디자인 가동시간만 떨어지니 굿즈를 팔 때만 켜놓으면 좋겠네요:0",
                                                "한번 굿즈를 디자인해보죠. 디자인 기계를 터치하거나 키보드 Q를 눌러서 만들어보세요.:0"});

        talkData.Add(1000 + 4, new string[]{    "역시 사장님! 우측 상단의 숫자가 올라간게 보이죠?:3",
                                                "저기에서 가지고있는 자원들을 확인할 수 있어요.:0",
                                                "위에서부터 돈, 굿즈, 시청자, 굿즈 보너스입니다.:0",
                                                "그럼 바로 다음으로 가볼까요?:0",
                                                "한번 굿즈를 만들어보죠. 굿즈 기계를 터치하거나 W를 눌러서 만들어보세요.:0"});

        talkData.Add(1000 + 5, new string[]{    "굿즈가 늘었습니다!:3",
                                                "이 굿즈는 저장공간에 저장됩니다.:0",
                                                "저장공간도 클릭을 통해 확장할 수 있습니다.:0",
                                                "저장공간을 클릭하거나 E를 눌러서 만들면 됩니다.:0",
                                                "한번 저장공간을 확장해보죠.:0"});
    
        talkData.Add(1000 + 6, new string[]{    "저장공간도 늘었네요.:3",
                                                "이후에 나오는 스태프 고용 최대 인원도 이곳에서 늘릴 수 있습니다.:0",
                                                "다음 기계는 굿즈 판매 기계입니다.:0",
                                                "누르면 자동으로 가지고 있는 굿즈를 팔 수 있습니다.:0",
                                                "파는 개수, 속도는 추후에 증가시킬 수 있습니다.:0",
                                                "이걸로 굿즈 공장의 설명은 끝입니다. 이제 나머지 설명을 빠르게 가볼까요?:0",
                                                "굿즈 공장을 제외하고 나머지 2개의 방은 큰 기능이 없습니다.:0",
                                                "사장님의 주요 업무는 모두 하단 패널에서 진행되죠.:0",
                                                "먼저 주식 패널을 눌러볼까요?:0"});            

        talkData.Add(1000 + 7, new string[]{    "여러 주식들이 보이죠?:0",
                                                "이곳에서 주식을 사고 팔 수 있습니다.:0",
                                                "대충 하락율 x%에서 상승율 y%를 가지고 있네요.:0",
                                                "왼쪽 위에 시간과 달력, 아래에는 게이지가 있는것이 보이나요?:0",
                                                "주식은 1게이지에 1번씩 가격이 변동합니다.:0",
                                                "1게이지는 20초이고, 5게이지가 지나면 하루가 지나며 장이 마감됩니다.:0",
                                                "장이 마감되면 몇몇 주식은 상장폐지되고 몇몇 주식은 상장되니 조심해야겠네요.:0",
                                                "이제 다음 패널로 가볼까요?:0",
                                                "밑에 스킬 패널을 눌러보죠.:0"});    

        talkData.Add(1000 + 8, new string[]{    "여기는 소속 스트리머의 스킬을 올릴 수 있는 곳입니다.:0",
                                                "다른 스트리머가 세운 회사를 합병하면 소속 스트리머가 늘어날겁니다.:3",
                                                "다행히 금사향님은 아직 회사에 남아있어 주셨네요.:0",
                                                "하루빨리 사장실이 꽉 차는 날이 왔으면 좋겠네요.:1",
                                                "그럼 이제 다음 패널인 스태프 패널로 넘어가보죠.:0",
                                                });

        talkData.Add(1000 + 9, new string[]{    "여기는 스태프를 배치하고 고용하는 곳입니다.:0",
                                                "굿즈 공장에서는 굿즈를, 사장실에서는 디자인 및 굿즈 용량, 스트리밍실에서는 시청자를 모읍니다.:3",
                                                "시청자분들이 주신 도네이션은 매 게이지마다 정산 받을 수 있어요.:0",
                                                "그러면 한 번 스태프를 뽑아볼까요?.:0",
                                                "스태프 뽑기창으로 가보죠.:0",
                                                });
        
        talkData.Add(1000 + 10, new string[]{    "여기는 스태프를 배치하고 고용하는 곳입니다.:0",
                                                "굿즈 공장에서는 굿즈를, 사장실에서는 디자인 및 굿즈 용량, 스트리밍실에서는 시청자를 모읍니다.:3",
                                                "시청자분들이 주신 도네이션은 매 게이지마다 정산 받을 수 있어요.:0",
                                                "그러면 한 번 스태프를 뽑아볼까요?.:0",
                                                "스태프 뽑기창으로 가보죠.:0",
                                                });
        //#.EventTalk



        //#.Portrait Data
        portraitData.Add(0000 + 0, portraitArr[0]);
        portraitData.Add(0000 + 1, portraitArr[1]);
        portraitData.Add(0000 + 2, portraitArr[2]);
        portraitData.Add(0000 + 3, portraitArr[3]);
        portraitData.Add(0000 + 4, portraitArr[4]);

        portraitData.Add(1000 + 0, portraitArr[5]);
        portraitData.Add(1000 + 1, portraitArr[6]);
        portraitData.Add(1000 + 2, portraitArr[7]);
        portraitData.Add(1000 + 3, portraitArr[8]);
        portraitData.Add(1000 + 4, portraitArr[9]);

        portraitData.Add(2000 + 0, portraitArr[10]);
        portraitData.Add(2000 + 1, portraitArr[11]);
        portraitData.Add(2000 + 2, portraitArr[12]);
        portraitData.Add(2000 + 3, portraitArr[13]);
        portraitData.Add(2000 + 4, portraitArr[14]);

        portraitData.Add(3000 + 0, portraitArr[15]);
        portraitData.Add(3000 + 1, portraitArr[16]);
        portraitData.Add(3000 + 2, portraitArr[17]);
        portraitData.Add(3000 + 3, portraitArr[18]);
        portraitData.Add(3000 + 4, portraitArr[19]);

        portraitData.Add(4000 + 0, portraitArr[20]);
        portraitData.Add(4000 + 1, portraitArr[21]);
        portraitData.Add(4000 + 2, portraitArr[22]);
        portraitData.Add(4000 + 3, portraitArr[23]);
        portraitData.Add(4000 + 4, portraitArr[24]);

        portraitData.Add(5000 + 0, portraitArr[25]);
        portraitData.Add(5000 + 1, portraitArr[26]);
        portraitData.Add(5000 + 2, portraitArr[27]);
        portraitData.Add(5000 + 3, portraitArr[28]);
        portraitData.Add(5000 + 4, portraitArr[29]);
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

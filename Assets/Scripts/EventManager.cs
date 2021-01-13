using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public UIManager uiManager;
    public EventVo[] eventList;
    public EventVo curEvent;
    public EventVo nextEvent;
    public int eventIndex;
    public GameObject eventBtn;
    public GameObject[] eventBtnPocket;//이벤트 버튼들 잠시 넣어두는 곳
    public GameObject Contents;//내용 content가 아니라 evenBtn 생성 위치
    private void Awake() {
        eventList = new EventVo[20];
        eventBtnPocket = new GameObject[3];
        Generate();
    }

    private void Start() {
        nextEvent = eventList[eventIndex];
    }

    void Generate(){
        EventVo event00 = new EventVo(0, 1, "군월급의 행방", 
        "생각해보니 군대에서 벌은 월급을 어떻게 했더라?\n기억이 나지 않네 다음 중 한 가지였던 걸로 기억하는데...",
        3,  new string[] {"당연히 매일 군적금에 넣었지.", "요즘 무슨 군적금이야, 매일 주식에 든든하게 넣었지", "X트코인 했지. 5만원으로 1억 2천... 신의 투자자."});
        EventVo event01 = new EventVo(1, 2, "빚쟁이?", 
        "쾅!쾅!쾅! 지누님! 밖에 빚쟁이가 온 것 같아요. 혹시 제가 모르는 빚이 있었나요? 아니 일단 이 상황을 어떻게 하죠? 도망쳐야 할까요.", 
        2,  new string[] {"잘 기억이 안나는데 일단 도망치자", "빌린 돈이 있으면 갚아야지... 일단 열어보자", ""});
        EventVo event02 = new EventVo(2, 3, "발전기", 
        "굿즈 기계가 갑자기 말을 안들어! 아마 발전기가 망가진 것 같아. 발전기를 수리해야 하는데... 누가 하지?", 
        3,  new string[] {"김진우", "금사향", "아리스톨"});
        EventVo event03 = new EventVo(3, 4, "굿즈 생산 의탁", 
        "타기업에서 굿즈 생산을 의뢰했다. 좋은 기회인거 같은데... 어떻게 할까?", 
        2,  new string[] {"수락!", "거절!"});

        EventVo event04 = new EventVo(4, 6, "뿌요야? 샤샤?", 
        "무슨일이지? 뿌요랑 샤샤가 서로 노려본다. 설마 싸우려는 건가? 어떡하지?", 
        2,  new string[] {"일단 나둬보자.", "뿌요야 차라리 나를 물어!"});
        EventVo event05 = new EventVo(5, 7, "츄즈미 플리즈", 
        "속보 - 츄즈미 플리즈가 기록적인 상승세를 보이며 조회수 천만신화를 찍으며 참여자인 밀감 컴퍼니의 CEO 탬탬버린 또한 주목을 받고 있다. 이전에 자신의 귀여움을 공식적으로 인정하며 폭발적인 이익을 취한 것과 맞물려 또 다시 시장이 독점되는 것은 아닌지 우려의 시선이나오며 반탬탬파라가 다시 활동을 시작했다고 한다.\n-스니커즈 기자", 
        2,  new string[] {"좋은 기회야. 반탬탬파를 지원해야겠어.", "좋은 기회네 신문사에 밀고를 해야겠어."});
        EventVo event06 = new EventVo(6, 8, "예은이랑 짱친인 탬탬버린", 
        "밀감사의 CEO 탬탬버린은 무려 그분의 짱친입니다. 천만신화 츄즈미 3인 중 한 분이자 대적할 자가 없는 그분 말이죠. 문제는 지금 그분이 뉴스 문제로 저희에게 소송을 걸었습니다. 다음 3가지 선택지 중 하나를 골라야 합니다.", 
        3,  new string[] {"배상금을 지불합니다. 배상금 : 10000", "현재 보유한 밀감사 주식의 10%를 양도합니다.(10개 미만시 지불 X)", "그분의 분노를 몸으로 체험합니다."});
        EventVo event07 = new EventVo(7, 9, "그 모자", 
        "그 모자는 이 업계에서 매우 유명합니다. 그는 탁월한 센스와 다양한 능력을 갖추었죠. 그런 그를 믿고 투자할 사람은 꽤 적지 않습니다. 그들은 미래의 보답을 바라며 당신에게 투자를 희망한다는 의견을 보입니다.", 
        1,  new string[] {"투자 수락"});
        
        EventVo event08 = new EventVo(8, 11, "주인님 제 몸이 이상해요...", 
        "평행세계의 망치는 끝내 실패했지만 여기서는 다를겁니다. 이 망치에게 22성의 기회를 주시겠나요?", 
        2,  new string[] {"살짝 맛만..? 일단 띄우면 이득이야", "어라? 평행세계의 기억이...? 내가 다신 스타포스 하나봐라..?"});
        EventVo event09 = new EventVo(9, 12, "사라진 나의 추억", 
        "새로운 기능 포인트 도박이 생겼습니다. 이 기능... 너무나 매력적입니다. 어떻게 할까요?", 
        2,  new string[] {"바로 도입해야지!", "이건 아닌거 같아..."});
        EventVo event10 = new EventVo(10, 13, "허위 뉴스와 악성단체", 
        "속보 - 김진우 적극적인 여성 좋아 발언에 악성적인 단체가 형성되고 있는 상태이다. 이에 대하여 우주대스타 컴퍼니의 나나양 CEO는 해명을 하지 않고 묵묵부답인 상태를 고수하고 있으며 이번 사건과 맞물려 나나양 CEO의 여러 스캔들에 대한 진실의 목소리를 들려달라는 대중들의 의견이 모여 일촉즉발의 상황을 만들고 있다.\n-스니커즈 기자", 
        2,  new string[] {"X발 당장 저거 내리고 정정 뉴스 올려", "당장 나나양을 제거해야해..."});
        EventVo event11 = new EventVo(11, 14, "전설 속 탬파이트", 
        "오랜만에 롤합방! 근데 어라? 내 눈이 잘못 됐나? C.Va 저 말파이트 뭐야???", 
        3,  new string[] {"(닷지 후) 뭐야 나 컴퓨터 왜이래?! 나 갑자기 꺼졌는데?", "(조이를 픽한다)", "다른 게임 할래요? 데바데라던지"});

        EventVo event12 = new EventVo(12, 16, "굿즈 도네 대란", 
        "굿즈 도네 대란이 일어났습니다. 원두 컴퍼니의 비정상적인 공급으로 굿즈와 도네가 심각하게 저하됩니다. 그들은 미친것처럼 시장을 어지럽히고 있습니다.", 
        1,  new string[] {"얼마나 저하가 되길래...? -자세히"});
        EventVo event13 = new EventVo(13, 17, "극한의 혼란장", 
        "엔터테인먼트 종목이 극한의 혼란장을 겪게 됩니다. 주식 가격 변동율이 증가합니다.", 
        1,  new string[] {"변동율이 어느정도지? -자세히"});
        EventVo event14 = new EventVo(14, 18, "공격적인 M&A", 
        "원두컴퍼니가 칼을 뽑아 들었습니다! 그들은 시장의 싸늘한 시선과 우려를 무시하고 픽셀을 차지하기 위해 시장의 보이지않는 룰을 깨고 날뛰기 시작합니다.", 
        1,  new string[] {"-자세히보기-"});
        EventVo event15 = new EventVo(15, 19, "영끌", 
        "원두 컴퍼니가 영끌을 시전합니다! 이제 서로간의 예의는 없고 남은건 혈투뿐입니다! 무조건 그들보다 더 많은 지분을 차지해야합니다!", 
        1,  new string[] {"-자세히보기-"});



        eventList[0] = event00;
        eventList[1] = event01;
        eventList[2] = event02;
        eventList[3] = event03;

        eventList[4] = event04;
        eventList[5] = event05;
        eventList[6] = event06;
        eventList[7] = event07;

        eventList[8] = event08;
        eventList[9] = event09;
        eventList[10] = event10;
        eventList[11] = event11;

        eventList[12] = event12;
        eventList[13] = event13;
        eventList[14] = event14;
        eventList[15] = event15;
    }

    public bool CheckEvent(int curDay){
        int eventDay = nextEvent._day;
        bool isEvent = eventDay == curDay;

        //#.이벤트 실행, 다음 이벤트 장전
        if(isEvent){
            curEvent = nextEvent;
            eventIndex++;
            nextEvent = eventList[eventIndex];
        }
        return isEvent;
    }

    public void MakeEventBtn(int id){
        int btnIndex = eventList[id]._btnIndex;
        for(int i=0; i<btnIndex; i++){
            eventBtnPocket[i] = newEvent(eventList[id]._btnText[i], i);
        }
    }

    public GameObject newEvent(string btnText, int i){
        GameObject newEventBtn = Instantiate(eventBtn, new Vector3(0,0,0), Quaternion.identity);
        newEventBtn.transform.SetParent(Contents.transform);
        newEventBtn.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newEventBtn.GetComponentInChildren<TextMeshProUGUI>().text = btnText;

        newEventBtn.GetComponent<Button>().onClick.AddListener(delegate{uiManager.EventBtn(i);});//각 버튼 AddListner 배치
        return newEventBtn;
    }
}

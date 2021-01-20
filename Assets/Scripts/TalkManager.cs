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
        talkState = new int[6] {-1, -1, -1, -1, -1, -1};
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
                                                "아니 근데 28일만에 돌아왔는데 왜 아무도 연락이 없어?:2",
                                                "가기전에는 그 난리를 하더니 진짜 너무하네:2"});//뒤에 :0은 표정

        talkData.Add(1000 + 0, new string[]{    "사장님 드디어 나오셨군요!:3",
                                                "지금 아주 난장판입니다!:1"});

        talkData.Add(0000 + 1, new string[]{    "아리스톨님! 진짜 오랜만이에요. 근데 왜 그렇게 급하게, 어라?:3",
                                                "[속보] 픽셀 네트워크 CEO J1NU 의문의 실종. 28일째 연락이 안돼:0",
                                                "[탬탬버린] 나는 내가 귀여운거 알고있어 발언...:4",
                                                "[코렛트] 그동안 감사했습니다...:0",
                                                "[THE_PIXEL] THE_PIXEL 회사 분할 및 악재의 연속...:0",
                                                "[원두컴퍼니] SPAC계의 신흥강자 원두컴퍼니 THE_PIXEL 목표 발언...:2",
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
                                                "우선 왼쪽 방에 가볼까요?:3",
                                                "장소 이동은 화면 가장자리 화살표로 가능합니다.:0"});

        talkData.Add(1000 + 3, new string[]{    "여기는 굿즈 공장입니다.:0",
                                                "첫 번째 기계는 굿즈를 사고싶게 디자인해서 프리미엄 굿즈로 만듭니다!.:0",
                                                "위에 ON/OFF 버튼을 눌러서 2배 보너스를 받을 수 있어요.:0",
                                                "디자인 보너스는 우측 상단 자원창에서 확인할 수 있습니다.:0",
                                                "위에서부터 차례대로 돈, 굿즈, 시청자, 디자인 보너스입니다.:0",
                                                "디자인은 스태프를 고용해서 사장실에 배치함으로써 만들 수 있습니다.:0",
                                                "또한 특정 시간주기로 자동으로 생성됩니다.:0",
                                                "디자인은 디자인 자원이 없으면 ON이 안되니 꼭 주의해주세요!:2"});

        talkData.Add(1000 + 4, new string[]{    "두 번째 기계는 굿즈 제작 기계입니다. 굿즈를 만들 수 있습니다..:0",
                                                "한번 굿즈를 만들어볼까요? 굿즈 기계를 터치하거나 Space를 눌러서 만들어보세요.:0"});

        talkData.Add(1000 + 5, new string[]{    "굿즈가 늘었습니다!:3",
                                                "굿즈는 최대 저장용량이 존재합니다.:0",
                                                "저장용량 또한 사장실에 스태프를 배치하면 확장시킬 수 있습니다.:0",
                                                "또한 특정 시간주기로 자동으로 늘어납니다.:0"
                                                });
    
        talkData.Add(1000 + 6, new string[]{    "가장 우측 기계는 굿즈 판매 기계입니다.:0",
                                                "누르면 지구가 돌면서 자동으로 가지고 있는 굿즈를 팔 수 있습니다.:0",
                                                "한번 굿즈를 팔아볼까요? 기계를 1번만 터치하면 됩니다.:0"
                                                });

        
        talkData.Add(1000 + 7, new string[]{    "굿즈를 판매해서 첫 수익을 거두었네요!:0",
                                                "굿즈 판매 기계는 굿즈가 없으면 자동으로 꺼집니다.:0",
                                                "굿즈 디자인은 보너스 포인트가 없으면 꺼지니 주의하세요.:0",
                                                "파는 개수, 속도는 추후에 증가시킬 수 있습니다.:0",
                                                "이걸로 굿즈 공장의 설명은 끝입니다. 이제 나머지 설명을 빠르게 가볼까요?:0",
                                                "사장님의 주요 업무는 모두 하단 패널에서 진행됩니다.:0",
                                                "먼저 주식 패널을 눌러볼까요?:0"});   

                 

        talkData.Add(1000 + 8, new string[]{    "여러 주식들이 보이죠?:0",
                                                "이곳에서 주식을 사고 팔 수 있습니다.:0",
                                                "대충 하락율 50%에서 상승율 30%를 가지고 있네요.:0",
                                                "한번 무슨 주식이 있나 볼까요?:0",
                                                "드래그를 하거나 마우스로 잡고 움직이면 됩니다.:0"});

        talkData.Add(1000 + 9, new string[]{    "가장 위에 있는 주식은 메인 주식입니다. 스토리용 주식이죠.:0",
                                                "나머지 10개의 주식은 서브 주식입니다. 불로소득 용이죠.:0",
                                                "왼쪽 위에 달력과 날짜, 신호등처럼 생긴 것이 있습니다.:0",
                                                "달력은 "+ GlobalVar.startFinalTime +"초 입니다.:0",
                                                "달력이 1바퀴 돌면 아래 게이지가 1개 감소합니다.:0",
                                                "매 게이지마다 서브 주식이 가격이 변동됩니다.:0",
                                                "3게이지가 지나면 날짜가 바뀌고 랜덤으로 서브 주식이 상장폐지됩니다.:3",
                                                "사라진 만큼 다시 생기니 총 11개가 유지되겠네요.:0",
                                                "그럼 한 번 주식을 사볼까요? 가장 위에 있는 메인 주식을 사보죠.:0"});

        talkData.Add(1000 + 10, new string[]{   "코렛샤 주식을 샀네요!:0",
                                                "매 스토리마다 5일안에 메인 스토리 주식을 다 사야합니다.:0",
                                                "안그러면 투자자들의 원성으로 바로 파산하고 말거에요...:0",
                                                "주식은 꾹 누르고만 있어도 많이 사지니 단타할 때 좋겠네요!:0",
                                                "이제 다음 패널로 가볼까요?:0",
                                                "밑에 스트리머 패널을 눌러보죠.:0"});

        talkData.Add(1000 + 11, new string[]{    "여기는 소속 스트리머의 스킬을 올릴 수 있는 곳입니다.:0",
                                                "다른 스트리머가 세운 회사를 합병하면 소속 스트리머가 늘어날겁니다.:3",
                                                "다행히 금사향님은 아직 회사에 남아있어 주셨네요.:0",
                                                "하루빨리 사장실이 꽉 차는 날이 왔으면 좋겠네요.:1",
                                                "그럼 이제 스킬을 구경한 후 다음 패널인 스태프 패널로 넘어가보죠.:0",
                                                });

        talkData.Add(1000 + 12, new string[]{    "여기는 스태프를 배치하고 고용하는 곳입니다.:0",
                                                "스태프를 어디 방에 배치하냐에 따라 생산하는 것이 다릅니다.:3",
                                                "굿즈 공장에서는 굿즈를 생산합니다.:0",
                                                "사장실에서는 디자인 보너스와 굿즈 저장공간을 확장합니다.:0",
                                                "마지막으로 스트리밍 룸에서는 시청자를 모읍니다.:0",
                                                "시청자분들이 주신 도네이션은 매 게이지마다 정산 받을 수 있어요.:0",
                                                "그러면 한 번 스태프를 뽑아볼까요?:0",
                                                "스태프 뽑기창으로 가보죠.:0",
                                                });
        
        talkData.Add(1000 + 13, new string[]{    "여기서 스태프를 뽑을 수 있습니다.:0",
                                                "스태프는 S, A, B, C 등급이 있습니다.:3",
                                                "각각 3%, 17%, 30%, 50%의 확률이라네요.:0",
                                                "그러면 제 전재산 1만 코인으로 한 번 스태프를 뽑아볼까요?:0"
                                                });

        talkData.Add(1000 + 14, new string[]{   "드디어 회사 인원이 늘었네요.:1",
                                                "마지막 패널은 정보패널입니다.:3",
                                                "굿즈가격, 도네가격 등의 정보를 알 수 있습니다.:0",
                                                "정말 마지막으로 매일 이벤트가 발생하니 현명한 선택을 하시길 바랍니다.:1",
                                                "이제 빨리 돈을 벌어서 다시 픽셀을 하나로 만들고 회사가 왜 이렇게 됐는지 조사하죠.:0",
                                                "조각난 회사를 다시 하나로 합치지 못하면 저희는 파산신청을 하거나 합병될 수 밖에 없습니다...:1",
                                                "현재 회사를 망친 주범으로 가장 의심이 되는 사람은 코렛트님입니다.:0",
                                                "첫 번째 목표는 코렛샤 컴퍼니로 하죠.:0",
                                                "5일이 되기 전까지 코렛샤 컴퍼니의 모든 주식을 사야합니다!:0",
                                                "실패하면 바로 파산엔딩이니 열심히하죠..:1"
                                                });

        talkData.Add(0000 + 3, new string[]{   "설명 진짜 길다.:0",
                                                "끄고 데바데하러 갈뻔:2",
                                                });
        
        talkData.Add(2000 + 0, new string[]{   "내가 있으니까 걱정하지마 지누오빠.:3",
                                                "남아준거에 마음 깊이 감사함을 느끼고:4",
                                                });

        talkData.Add(0000 + 4, new string[]{    "오우 Z같은거 봐.:4",
                                                "어디서 저렇게 Z같은 멘트만 가져올까:3",
                                                "그래 일이나 하자:0"
                                                });
        //#1. 지누 : 4, 아리스톨 : 11 금사향 : 0  코렛트 : -1 탬탬 :-1 나나양 :-1 :talkState

        //#2. Event Talk - Collet
        //#.0: 지누, 1000:아스톨프, 2000:금사향, 3000:코렛트, 4000:탬탬, 5000:나나양
        //#.0:Default 1:Sad, 2:Angry, 3:Smile, 4:Sneer
        talkData.Add(0000 + 5, new string[]{    "아 힘들었네:2",
                                                "그래서 님아 할말은 있어요?:3",
                                                "한번 들어나 보죠?:4"
                                                });

        talkData.Add(3000 + 0, new string[]{    "아 드디어 구세주가 등장하셨다:1",
                                                "지누 너밖에 없었어...:1",
                                                });

        talkData.Add(0000 + 6, new string[]{    "지랄하지 말고:0"
                                                });

        talkData.Add(3000 + 1, new string[]{    "콜록 콜록 콜록 지누야...:1"
                                                });

        talkData.Add(0000 + 7, new string[]{    "뒤져 그냥 뒤져:2",
                                                "아프지 말고 뒤져버리라고 그냥 :2",
                                                "더 이상 숨을 쉬지 말고!:2",
                                                "아마존아 미안해 하고 뒤지라고 그냥:2",
                                                });
                                            
        talkData.Add(3000 + 2, new string[]{    "이 야발새끼 말 진짜 졸라 너무하네?:2"
                                                });

        talkData.Add(0000 + 8, new string[]{    "그렇군요 렛트님!:3",
                                                "근데 방금 회사 뺏기신거 아시죠?:2",
                                                "아 맞네-!:3",
                                                "그게 맞네요 렛트님 그죠?:3",
                                                });

        talkData.Add(3000 + 3, new string[]{    "아 미안하다고!:2",
                                                "누군 이렇게 될줄 알았나?:2",
                                                "나도 피해자라고 피해자!:1",
                                                "회사 망하고! 애들 다 나가고! 나도 일단 살아야지!:2"
                                                });

        talkData.Add(0000 + 9, new string[]{    "후... 일단 알겠고.:2",
                                                "무슨 일 있었는지 말이나 해봐요.:0",
                                                "대체 무슨 짓을 하면 28일만에 회사가 망하는지 들어나 봅시다.:0"
                                                });

        talkData.Add(3000 + 4, new string[]{    "나도 잘 몰라:4",
                                                "그냥 너 가고 갑자기 터지던데?:3",
                                                "나는 너가 편한 삶으로 돌아가려고 터친줄 알았는데?:4"
                                                });

        talkData.Add(1000 + 15, new string[]{   "노동부를 포함한 몇몇 사람들을 제외한 대부분은 실제로 저렇게 알고 있습니다.:0",
                                                "지누님이 피로에 지쳐 편한 삶을 위해 잠적하신 것으로 허위 뉴스가 무더기로 나왔죠.:0"
                                                });

        talkData.Add(2000 + 1, new string[]{   "탬탬언니나 다른사람들도 말해보기 전에 다 갑자기 퇴사하고, 회사도 갑자기 망해가고:0",
                                                "나도 딱 한달만 있다가 갈려고 했는데 다행히 그 안에 왔네?:3",
                                                "지누오빠 또 생일파티 때 처럼 혼자 있을뻔 했네?:4",
                                                "조금 더 고마워해도 되는데?:3"
                                                });

        talkData.Add(0000 + 10, new string[]{   "엿:2",
                                                "그러니까 코렛트는 아니고 아직 다른 사람 중에 범인이 있다 그거죠?:2",
                                                "다음으로 의심되는 사람은 누구죠?:0"
                                                });

        talkData.Add(1000 + 16, new string[]{   "다음은 탬탬버린님의 밀감 컴퍼니입니다.:0",
                                                "어떻게인지는 모르겠지만 뛰어난 수완으로 몸집을 키우고 계십니다.:0",
                                                "오는 10일까지 회사를 인수하지 못하면 투자자들이 책임을 묻겠죠...:1"
                                                });

        talkData.Add(0000 + 11, new string[]{   "탬탬버린...:2",
                                                "이 그렇게 치밀한 계획을...? 할 수...가 있나...? 그..게 가능하나?:4",
                                                "아니야 아니야 정신차려 지누야 또 시X 윈도우를 새로 깔듯이:2",
                                                "호환 체계가 바뀌어서 능지를 땡겨 쓰는걸 수도 있어...:2",
                                                "내가 들어갈 때는 그렇게 꿀을 쪽쪽 빨더니 이제는 빨다 못해 회사까지 망쳐...?:2",
                                                "반드시 헤이하치컷 시켜주마...:2"
                                                });
        //#2. 지누 : 11, 아리스톨 : 16 금사향 : 1  코렛트 : 4 탬탬 :-1 나나양 :-1 :talkState

        //#3. Event Talk - TamX2
        talkData.Add(4000 + 0, new string[]{   "김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우!:3"
                                                });

        talkData.Add(0000 + 12, new string[]{   " :2"
                                                });

        talkData.Add(4000 + 1, new string[]{   "김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우! 김진우!:3"
                                                });

        talkData.Add(0000 + 13, new string[]{   " :2"
                                                });

        talkData.Add(4000 + 2, new string[]{   "김진우! 김진우! 김진우!.. 김진..우!... 김...진..우..:1"
                                                });

        talkData.Add(0000 + 14, new string[]{   "다 했어요?:2"
                                                });
        
        talkData.Add(4000 + 3, new string[]{   "눼.:1"
                                                });

        talkData.Add(0000 + 15, new string[]{   "탬탬님... 저 있잖아요...:2",
                                                "너무:0",
                                                "화가 나요...:2"
                                                });

        talkData.Add(4000 + 4, new string[]{   "진짜요?:3",
                                                "어떡해요?:0",
                                                "화를 가라 앉히세요:3"
                                                });

        talkData.Add(0000 + 16, new string[]{   "탬탬님 님 진짜...:2",
                                                "진지하게 말하면 상처받을까 봐:0",
                                                "말을 못하겠었는데:2",
                                                "아주 그냥 쓰X기 시네요?:0"
                                                });

        talkData.Add(4000 + 5, new string[]{   "아니!... 근뒈....:2",
                                                "니가! 나 짤랐자나....:2",
                                                "아니! 너가 먼저 해놓고눈... :1",
                                                "회사 좀 키울려고 그럴수도.. 있쥐...:1"
                                                });

        talkData.Add(0000 + 17, new string[]{   "탬탬님 저 정말 궁금해서 그런데...:2",
                                                "혹시 대뇌에 문제 생기셨나요?:3",
                                                "제가 짤랐다고요??:2"
                                                });

        talkData.Add(4000 + 6, new string[]{   "아뉘!...:2",
                                                "갑자기 해고통보 오고...:1",
                                                "회사에 내 자리 사라지고... 너는 어디갔는지 사라지고...:1",
                                                "익명의 투자자가 투자할테니 CEO 해볼 생각 있냐구 하구...:1",
                                                "그러믄 나보고 어떡하라는거야...:1"
                                                });
                                            
        talkData.Add(3000 + 5, new string[]{    "탬탬버린한테 투자를 한다고?:4",
                                                "지누야 저색...:3",
                                                "아 저새끼란다 미안:4",
                                                "지누야 탬탬버린 저거 분명 거짓말이야:3",
                                                "익명은 무슨 세상에 누가 돈을 땅에 버려 저거 개구라야:2"
                                                });

        talkData.Add(4000 + 7, new string[]{   "아니거든! 진짜거든!:2",
                                                "알지도 못하면서!:2"
                                                });

        talkData.Add(1000 + 17, new string[]{   "상황을 보니 탬탬버린님은 어떤 이유에서든 오해가 있었던 것 같군요.:0",
                                                "확실한건 누군가가 치밀하게 픽셀을 공격하고 있다는 것이군요...:2"
                                                });

        talkData.Add(2000 + 2, new string[]{   "그런 것 같네요. 대체 누가 착하고 귀여운 탬탬언니를...:0",
                                                "조금 모자란 면이 있지만 자기도 인정할 귀여움을 가지고 있는 탬탬언니를...:4"
                                                });

        talkData.Add(4000 + 8, new string[]{    "OH SHIT OH SHIT...:1",
                                                "어우.. 어후... 머리 띵해:2",
                                                "사향아 언니가 뭐 잘못했니?:0"
                                                });

        talkData.Add(2000 + 3, new string[]{   "아니아니 그냥 언니가(풋) 너무(풋) 착하고 귀여워서...:4",
                                                "이런 사람한테(풋) 사기친 사람이 누구일지 궁금해서:4",
                                                "누군진 모르겠지만 진짜 나쁜 사람이다.:4"
                                                });

        talkData.Add(0000 + 18, new string[]{   "원래 탬탬버린님 아닌 줄 알았으니 다음 얘기나 하죠.:3",
                                                "다음 목표는 어디죠?:0"
                                                });

        talkData.Add(4000 + 9, new string[]{    "나 아닌줄 알았다고?:0"
                                                });

        talkData.Add(0000 + 19, new string[]{   "당연하죠.:3",
                                                "윈도우를 새로 깐다고 macOS나 안드로이드가 깔리지는 않잖아요?:4",
                                                "탬탬님이 이런 치밀한 일을 할 수 있을리 없잖아요?:4"
                                                });

        talkData.Add(4000 + 10, new string[]{    "개X끼야!!!!:1"
                                                });

        talkData.Add(0000 + 20, new string[]{   "그래서 다음 목표는 어디죠?:0"
                                                });

        talkData.Add(1000 + 18, new string[]{   "우주대스타 컴퍼니의 나나양님입니다.:0",
                                                "빠르고 뛰어난 두뇌회전, 기존 픽셀의 글로벌전략팀을 책임지신 능력으로:3",
                                                "본진인 캐나다를 포함한 국외시장 영향력을 빠르게 높이고 계십니다.:0"
                                                });

        talkData.Add(0000 + 21, new string[]{   "나나양님...:0",
                                                "고무신을 거꾸로 신을 때 알아차렸어야 했는데...:2",
                                                "후... 나나양님은 꼭 아오지에 넣어드릴게요.:2",
                                                "아참. 탬탬님은 헤이하치 컷좀 시키고 오세요.:3",
                                                "전 먼저 급한 일이있어서.:4"
                                                });
        
        talkData.Add(1000 + 19, new string[]{   "알겠습니다.:0",
                                                "죄송합니다 탬탬님... 명령인지라:1"
                                                });

        talkData.Add(4000 + 11, new string[]{    "네?:0"
                                                });

        talkData.Add(2000 + 4, new string[]{   "괜찮아 언니. 제작자가 원래는 헤이하치컷 상체랑 전신 그림 넣을려고 했는데 시간이 없어서 못했대:3",
                                                "그것 만큼은 하루종일 그려서 퀄리티를 높이려다 실패했다나 뭐라나:4"
                                                });

        talkData.Add(4000 + 12, new string[]{    "아니 무슨 아니 아리스톨님 다가오지 마세요!:0"
                                                });
        
        //#3. 지누 : 21, 아리스톨 : 19 금사향 : 4  코렛트 : 5 탬탬 : 12 나나양 :-1 :talkState

        //#4. Event Talk - Nanayang
        talkData.Add(0000 + 22, new string[]{   "안녕:0"
                                                });

        talkData.Add(5000 + 0, new string[]{   "안녕!:0"
                                                });

        talkData.Add(0000 + 23, new string[]{   "왕위를 계승하지 못했네요?:0"
                                                });

        talkData.Add(5000 + 1, new string[]{   "그러니까 말이에요.:0",
                                                "아쉽네요. 더 잘할 수 있었는데.:3"
                                                });

        talkData.Add(0000 + 24, new string[]{   "회사 생활이 빡세서 그러셨나요?:2",
                                                "제가 싸이코패스 같아서 그랬나요?:2",
                                                "정말 궁금하네요?:0",
                                                "정.말.궁.금.하.네.요?:2"
                                                });

        talkData.Add(5000 + 2, new string[]{   "사장님 없는 동안에 뭐...:0",
                                                "사장과 직원 관계가 반대가 될 수 있지 않을까~:3",
                                                "난 사장님 뿐인거 알죠?:0"
                                                });

        talkData.Add(0000 + 25, new string[]{   "씨1발 하지마 제발:2",
                                                "아니 씨1빨 진짜 도대체 아니 하...:2",
                                                "그래서 어떻게 된 일인지 말이나 해 보시죠?:0"
                                                });
        
        talkData.Add(5000 + 3, new string[]{   "사장님 없어지고 갑자기 투자제의가 들어와서...:0",
                                                "사장과 직원의 위치를 바꿔볼 생각이 있냐는 편지가 있더라고요.:3",
                                                "솔직히 너무 끌리잖아요~:3"
                                                });

        talkData.Add(0000 + 26, new string[]{   "후.....:2",
                                                "그래서 혹시 투자 출처가 어딘지는 알고 있나요?:0"
                                                });

        talkData.Add(5000 + 4, new string[]{   "원두컴퍼니에서 투자가 들어왔어요.:0",
                                                "당시에는 크게 생각하지 않았었는데:3",
                                                "지금 보면 처음부터 PIXEL 크기를 적당히 줄이고 인수합병하기 위해 수작을 부린 것 같네요.:2"
                                                });

        talkData.Add(1000 + 20, new string[]{   "원두컴퍼니는 지누님 입대 이후 생긴 SPAC입니다.:0",
                                                "SPAC은 기업을 인수하는 것을 목적으로 하는 회사입니다.:0",
                                                "나나양님 말씀대로라면 PIXEL을 조각내서 크기를 줄이고 특정 부분만 인수할 목적을 가지고 있는 것 같네요.:2"
                                                });

        talkData.Add(3000 + 6, new string[]{    "탬탬도 저기서 사기 먹었네:3",
                                                "탬탬버린 진짜 생각좀 해라! 생각좀!:4"
                                                });

        talkData.Add(4000 + 13, new string[]{    "사기 당한거 아니라고!:2",
                                                "지는 투자 받지도 못했으면서!:2"
                                                });

        talkData.Add(0000 + 27, new string[]{   "...:2",
                                                "뭐 그러면 이제 남은건 뭘 해야하죠.:0",
                                                "진짜 다 포기하고 편한 삶을 찾으로 가고 싶어지는데요:2"
                                                });

        talkData.Add(1000 + 21, new string[]{   "PIXEL의 주식을 사서 조각난 회사를 하나로 합쳐야합니다.:0",
                                                "합병 또한 방어해야하니 의결권을 원두컴퍼니보다 많이 보유해야겠죠.:0",
                                                "하지만 이 정도로 치밀하다니... 쉬운 상대가 아닌 것 같습니다.:2"
                                                });

        talkData.Add(0000 + 28, new string[]{   "뭐 그곳만 이기면 드디어 끝이겠네요.:0",
                                                "이제 마지막이네요. 아!:3",
                                                "아리스톨님 잊지말고 나나양님 아오지 한번 부탁드려요.:4"
                                                });

        talkData.Add(1000 + 22, new string[]{   "네 알겠습니다.:0",
                                                "나나양님 죄송합니다...:0"
                                                });

        talkData.Add(5000 + 5, new string[]{   "네?:0",
                                                "아니 아리스톨님? 탬탬버린? 왜 그런 눈으로...:1",
                                                "아니 네? 네?!:1"
                                                });
        //#4. 지누 : 28, 아리스톨 : 22 금사향 : 4  코렛트 : 6 탬탬 : 13 나나양 :5 :talkState

        //#.0: 지누, 1000:아스톨프, 2000:금사향, 3000:코렛트, 4000:탬탬, 5000:나나양
        //#.0:Default 1:Sad, 2:Angry, 3:Smile, 4:Sneer

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
